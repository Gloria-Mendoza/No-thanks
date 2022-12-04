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

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para Profile.xaml
    /// </summary>
    public partial class Profile : Window, PlayerManager.IUpdateProfileCallback
    {
        public Profile()
        {
            InitializeComponent();
            ConfigureWindow();
            updateImage();
        }
        private void updateImage()
        {
            var context = new InstanceContext(this);
            PlayerManager.UpdateProfileClient updateProfileClient = new PlayerManager.UpdateProfileClient(context);
            updateProfileClient.GetImage(Domain.Player.PlayerClient.IdPlayer);
        }
        private void ConfigureWindow()
        {
            LabelName.Content = Domain.Player.PlayerClient.Nickname;
            LabelReal.Content = Domain.Player.PlayerClient.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal go = new MenuPrincipal();
            go.WindowState = this.WindowState;
            go.Show();
            this.Close();
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
    }
}
