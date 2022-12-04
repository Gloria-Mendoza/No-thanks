using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoThanks
{
    /// <summary>
    /// Interaction logic for FriendsProfile.xaml
    /// </summary>
    public partial class FriendsProfile : Window, PlayerManager.IUpdateProfileCallback
    {
        public FriendsProfile()
        {
            InitializeComponent();
            updateImage();
            ConfigureWindow();

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
            imageProfile.Source = photo;

        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Profile_Edit go = new Profile_Edit();
            go.WindowState = this.WindowState;
            go.Show();
            this.Close();
        }
    }
}
