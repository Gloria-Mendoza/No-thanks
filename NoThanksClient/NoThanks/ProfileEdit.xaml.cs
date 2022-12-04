using Domain;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Image = System.Drawing.Image;
using System.IO;
using Path = System.IO.Path;
using System.Reflection;
using System.ServiceModel;
using NoThanks.PlayerManager;
using System.Runtime.Remoting.Contexts;
using System.Windows.Interop;
using System.Collections;
using System.Resources;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para Profile_Edit.xaml
    /// </summary>
    public partial class Profile_Edit : Window, PlayerManager.IUpdateProfileCallback
    {
        private BitmapImage photo = new BitmapImage();

        String imageResource = "";

        public Profile_Edit()
        {
            InitializeComponent();
            ReadResource();
           
        }

        private void ReadResource()
        {
            string[] files = Directory.GetFiles(@"..\..\Resources", "*.jpg");
            for (int i = 0; i < files.Length; i++)
            {
                var ext = files[i].Split('\\');
                ext = ext.Last().Split('.');

                lxtImageSelector.Items.Add(ext.First());
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Domain.Player user = new Domain.Player();
            user.Nickname = tbName.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog Imagen = new OpenFileDialog();
            Imagen.Title = "Visor de imagenes";
            Imagen.Filter = "Archivos de Imagen (*.jpg)|*.jpg";
            Imagen.FilterIndex = 1;
            Imagen.Multiselect = false;

            if (Imagen.ShowDialog() == true)
            {
                try
                {
                    
                    photo.BeginInit();
                    photo.UriSource = new Uri(Imagen.FileName);
                    photo.EndInit();
                    photo.Freeze();
                    imagenProfile.Source = photo;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen:" + ex.Message , "Error");
                }
            }
            
            


        }
        private void ImagenInit(string nameImage)
        {



            Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject(nameImage);


            BitmapSource bmpImage = Imaging.CreateBitmapSourceFromHBitmap(
                bmp.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions()
                );
            imagenProfile.Source = bmpImage;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try { 
            if(tbName.Text == "")
            {
                MessageBox.Show("El campo debe ser rellenado", "Error");
                return;
            }




                var context = new InstanceContext(this);
                PlayerManager.UpdateProfileClient updateProfileClient = new PlayerManager.UpdateProfileClient(context);
                updateProfileClient.SaveImage(imageResource, Domain.Player.PlayerClient.IdPlayer);
                updateProfileClient.UpdateNewNickname(tbName.Text, Domain.Player.PlayerClient.Nickname);
                Domain.Player.PlayerClient.Nickname = tbName.Text;
            
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error");
            }
                Profile go = new Profile()
                {
                WindowState = this.WindowState,
                Left = this.Left
                };
            go.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Profile go = new Profile()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
        }
        public void ImageCallBack(byte[] image)
        {
            throw new NotImplementedException();
        }

        private void lxtImageSelector_MouseLeftButtonDown(object sender, SelectionChangedEventArgs e)
        {
            if (lxtImageSelector.SelectedItem != null)
            {
                //Console.WriteLine(listafea.SelectedItem);

                Bitmap bmp = (Bitmap)Properties.ResourcesImage.ResourceManager.GetObject(lxtImageSelector.SelectedItem.ToString());

                BitmapSource bmpImage = Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                    );

                imagenProfile.Source = bmpImage;
                imageResource = lxtImageSelector.SelectedItem.ToString();
            }
        }
    }
}
