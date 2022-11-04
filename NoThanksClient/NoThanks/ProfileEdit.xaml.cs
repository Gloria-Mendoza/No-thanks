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

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para Profile_Edit.xaml
    /// </summary>
    public partial class Profile_Edit : Window
    {
     

        public Profile_Edit()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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

                    imagenProfile.Source = photo;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen:" + ex.Message , "Error");
                }
            }
            
            


        }

      //  public static void SaveProfilePicture(string username, Image imageProfile)
      //    {
      //      var profilePicturePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "../../ProfilePictures/" + username + ".jpg";
        //    using (var fileStream = new FileStream(profilePicturePath, FileMode.Create))
          //  {
            //    var jpegBitmapEncoder = new JpegBitmapEncoder();
             //   jpegBitmapEncoder.Frames.Add(BitmapFrame.Create((BitmapSource)imageProfile.Source));
             //   jpegBitmapEncoder.Save(fileStream);
           // }
       // }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(txtName.Text == "")
            {
                MessageBox.Show("El campo debe ser rellenado", "Error");
                return;
            }
            try { 
                Player user = new Player();
                user.Name = txtName.Text;
                
                string destiny = @"C:\Streams";
                string correct = imagenProfile.Source.ToString().Replace("file:///", "");
                File.Copy(correct, destiny, true);
                // int id = Player.PlayerClient.Nickname ;
                MessageBox.Show("Se guardo correctamente", "Exito");

            }
            catch
            {

            }
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
    }
}
