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
            updateImage();
        }
        private void updateImage()
        {
            if (!Domain.Player.PlayerClient.IsGuest)
            {
                var context = new InstanceContext(this);
                PlayerManager.UpdateProfileClient updateProfileClient = new PlayerManager.UpdateProfileClient(context);
                updateProfileClient.GetImage(Domain.Player.PlayerClient.Nickname);
            }

        }

        private void ConfigureWindow()
        {
            LabelName.Content = Domain.Player.PlayerClient.Nickname;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlaySelection go = new PlaySelection()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
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



        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Personalization go = new Personalization()
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

        private void Image_Trophy(object sender, MouseButtonEventArgs e)
        {
            if (!Domain.Player.PlayerClient.IsGuest)
            {
                ConsultRecord record = new ConsultRecord()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
                record.Show();
                this.Close();
            }
        }
    }
}
