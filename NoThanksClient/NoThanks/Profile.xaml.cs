using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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
using System.Windows.Media;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            ConfigureWindow();
            ImagenInit();
        }

        private void ConfigureWindow()
        {
            lbName.Content = Domain.Player.PlayerClient.Nickname;
            lbReal.Content = Domain.Player.PlayerClient.Name;
            
        }

        private void BackBotton(object sender, RoutedEventArgs e)
        {
            MainMenu goMainMenu = new MainMenu();
            goMainMenu.WindowState = this.WindowState;
            goMainMenu.Show();
            this.Close();
        }

        private void ProfileEditClick(object sender, MouseButtonEventArgs e)
        {
            Profile_Edit goProfileEdit = new Profile_Edit();
            goProfileEdit.WindowState = this.WindowState;
            goProfileEdit.Show();
            this.Close();
        }

        private void ChangePasswordClick(object sender, RoutedEventArgs e)
        {
            ChangePassword goChangePassword = new ChangePassword();
            goChangePassword.WindowState = this.WindowState;
            goChangePassword.Show();
            this.Close();
        }
        private void ImagenInit()
        {
            if (!Domain.Player.PlayerClient.IsGuest)
            {
                Bitmap bmp = (Bitmap)Properties.ResourcesImage.ResourceManager.GetObject(Domain.Player.PlayerClient.ProfileImage);

                BitmapSource bmpImage = Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                    );

                imageProfile.Source = bmpImage;
            }
        }

    }
}
