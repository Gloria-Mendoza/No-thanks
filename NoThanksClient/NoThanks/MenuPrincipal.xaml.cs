using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window, PlayerManager.IUpdateProfileCallback
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            ConfigureWindow();
            //updateImage();
            ImagenInit();
        }
        private void updateImage()
        {
            if (!Domain.Player.PlayerClient.IsGuest)
            {
                var context = new InstanceContext(this);
                PlayerManager.UpdateProfileClient updateProfileClient = new PlayerManager.UpdateProfileClient(context);
                updateProfileClient.GetImage(Domain.Player.PlayerClient.IdPlayer);
            }

        }

        private void ConfigureWindow()
        {
            LabelName.Content = Domain.Player.PlayerClient.Nickname;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow go = new MainWindow()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
        }


        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!Domain.Player.PlayerClient.IsGuest) { 
                Profile go = new Profile()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
            
                go.Show();
                this.Close();
            }

        }
        public void ImageCallBack(byte[] imageBytes)
        {
            BitmapImage photo = new BitmapImage();
            photo.BeginInit();
            photo.StreamSource = new MemoryStream(imageBytes);
            photo.EndInit();
            photo.Freeze();
            imagenProfile.Source = photo;

        }

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
                if (!Domain.Player.PlayerClient.IsGuest) { 
                    Friends go = new Friends()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
                go.Show();
                this.Close();
            }
        }

        private void Image_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            Personalization go = new Personalization()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
        }

        private void Image_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            PlaySelection go = new PlaySelection()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
        }
        private void ImagenInit()
        {


            try { 
            Bitmap bmp = (Bitmap)Properties.ResourcesImage.ResourceManager.GetObject(Domain.Player.PlayerClient.Photo);

               
            BitmapSource bmpImage = Imaging.CreateBitmapSourceFromHBitmap(
                bmp.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions()

                );
            imagenProfile.Source = bmpImage;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
