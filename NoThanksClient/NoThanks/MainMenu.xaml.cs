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
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
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


        private void BackBotton(object sender, RoutedEventArgs e)
        {
            MainWindow goMainWindow = new MainWindow()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            goMainWindow.Show();
            this.Close();
        }


        private void ProfileClick(object sender, MouseButtonEventArgs e)
        {
            if (!Domain.Player.PlayerClient.IsGuest)
            {
                Profile goProfile = new Profile()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };

                goProfile.Show();
                this.Close();
            }

        }

        private void PlayersClick(object sender, MouseButtonEventArgs e)
        {
            if (!Domain.Player.PlayerClient.IsGuest)
            {
                Players goPlayers = new Players()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
                goPlayers.Show();
                this.Close();
            }
        }

        private void LanguageClick(object sender, MouseButtonEventArgs e)
        {
            Personalization goPersonalization = new Personalization()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            goPersonalization.Show();
            this.Close();
        }

        private void PlayClick(object sender, MouseButtonEventArgs e)
        {
            PlaySelection goPlaySelection = new PlaySelection()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            goPlaySelection.Show();
            this.Close();
        }


    }
}
