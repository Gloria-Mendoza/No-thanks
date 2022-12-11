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
            LabelName.Content = Domain.Player.PlayerClient.Nickname;
            LabelReal.Content = Domain.Player.PlayerClient.Name;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu go = new MainMenu();
            go.WindowState = this.WindowState;
            go.Show();
            this.Close();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Profile_Edit go = new Profile_Edit();
            go.WindowState = this.WindowState;
            go.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChangePassword go = new ChangePassword();
            go.WindowState = this.WindowState;
            go.Show();
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

                imagenProfile.Source = bmpImage;
            }
        }
    }
}
