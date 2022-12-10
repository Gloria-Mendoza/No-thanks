using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System.ServiceModel;
using System.Windows.Interop;
using log4net;
using Logs;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para Profile_Edit.xaml
    /// </summary>
    public partial class Profile_Edit : Window
    {
        String imageResource = "";
        NoThanksService.UpdateProfileClient updateProfileClient = new NoThanksService.UpdateProfileClient();
        private static readonly ILog Log = Logger.GetLogger();

        public Profile_Edit()
        {
            InitializeComponent();
            ReadResource();
            ImagenInit();
        }

        private void ReadResource()
        {
            string[] files = Directory.GetFiles(@"..\..\Resources", "*.jpg");
            for (int i = 0; i < files.Length; i++)
            {
                var ext = files[i].Split('\\');
                ext = ext.Last().Split('.');

                lxtImageSelector.Items.Add(ext.First());
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Domain.Player user = new Domain.Player();
            user.Nickname = tbName.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Botón Abrir
        }

        private void ImagenInit()
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

        private void Button_Click_1(object sender, RoutedEventArgs e)//Botón Guardar
        {
            try
            {
                Domain.Player.PlayerClient.ProfileImage = imageResource;

                updateProfileClient.SaveImage(imageResource, Domain.Player.PlayerClient.IdPlayer);

                if (!String.IsNullOrWhiteSpace(tbName.Text))
                {
                    updateProfileClient.UpdateNewNickname(tbName.Text, Domain.Player.PlayerClient.Nickname);
                    Domain.Player.PlayerClient.Nickname = tbName.Text;
                }
            }
            catch (EndpointNotFoundException ex)
            {
                Log.Error($"{ex.Message}");
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                Log.Error($"{ex.Message}");
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (TimeoutException ex)
            {
                Log.Error($"{ex.Message}");
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Profile go = new Profile()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Cancelar?
        {
            Profile go = new Profile()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
        }

        private void lxtImageSelector_MouseLeftButtonDown(object sender, SelectionChangedEventArgs e)
        {
            if (lxtImageSelector.SelectedItem != null)
            {

                Bitmap bmp = (Bitmap)Properties.ResourcesImage.ResourceManager.GetObject(lxtImageSelector.SelectedItem.ToString());

                BitmapSource bmpImage = Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                    );

                imagenProfile.Source = bmpImage;
                imageResource = lxtImageSelector.SelectedItem.ToString();
            }
        }
    }
}
