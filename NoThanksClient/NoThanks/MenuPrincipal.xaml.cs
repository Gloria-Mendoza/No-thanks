using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            ConfigureWindow();
            ImagenInit();
        }

        private void ImagenInit()
        {
            if (!Domain.Player.PlayerClient.IsGuest)
            {
                var playerImage = Domain.Player.PlayerClient.ProfileImage;
                if(playerImage == "") 
                {
                    Domain.Player.PlayerClient.ProfileImage = "acosador";
                }
                Bitmap bmp = (Bitmap)Properties.ResourcesImage.ResourceManager.GetObject(Domain.Player.PlayerClient.ProfileImage);

                BitmapSource bmpImage = Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                    );

                imagenProfile.Source = bmpImage;
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
            if (!Domain.Player.PlayerClient.IsGuest)
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

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            if (!Domain.Player.PlayerClient.IsGuest)
            {
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
    }
}
