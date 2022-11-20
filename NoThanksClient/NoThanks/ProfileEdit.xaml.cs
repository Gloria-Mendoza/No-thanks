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

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para Profile_Edit.xaml
    /// </summary>
    public partial class Profile_Edit : Window, PlayerManager.IUpdateProfileCallback
    {
     

        public Profile_Edit()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Player user = new Player();
            user.Nickname = tbName.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Imagen = new OpenFileDialog();
            Imagen.Title = "Visor de imagenes";
            Imagen.Filter = "Archivos de Imagen (*.jpg. *.png, *.bpm)|*.jpg; *.png; *.bpm";
            Imagen.FilterIndex = 1;
            Imagen.Multiselect = false;
            if (Imagen.ShowDialog() == true)
            {
                try
                {
                    BitmapImage photo = new BitmapImage();
                    photo.BeginInit();
                    photo.UriSource = new Uri(Imagen.FileName);
                    photo.EndInit();
                    photo.Freeze();
                    using (var Stream = new MemoryStream())
                    {
                        var bitmap = new JpegBitmapEncoder();
                        bitmap.Frames.Add(BitmapFrame.Create(photo));
                        bitmap.Save(Stream);
                        var context = new InstanceContext(this);
                        PlayerManager.UpdateProfileClient updateProfileClient = new PlayerManager.UpdateProfileClient(context);
                        updateProfileClient.SaveImage(Stream.ToArray(), Domain.Player.PlayerClient.Nickname);
                    }
                    imagenProfile.Source = photo;
                    tbUrlPhoto.Text = "foto_" + tbName.Text + ".jpg";
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen:" + ex.Message , "Error");
                }
            }
            
            


        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(tbName.Text == "")
            {
                MessageBox.Show("El campo debe ser rellenado", "Error");
                return;
            }
            try {
                Player user = new Player();
                user.Nickname = tbName.Text;
                user.Photo = tbUrlPhoto.Text;

                string destiny = @"C:\Prueba\";
                string correct = imagenProfile.Source.ToString().Replace("file:///", "");
                File.Copy(correct, destiny + tbUrlPhoto.Text, true);
                int id = Domain.Player.PlayerClient.IdPlayer;
                MessageBox.Show("Se guardo correctamente", "Exito");

                if (id > 0)
                {
                    MessageBox.Show("Se ha guardado correctamente los cambios", "Guardar");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible guardar los cambios" + ex.Message, "Error");
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
    }
}
