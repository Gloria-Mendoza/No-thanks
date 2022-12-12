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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Text.RegularExpressions;

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
            lxtImageSelector.Items.Add("acosardor");
            lxtImageSelector.Items.Add("gato");
            lxtImageSelector.Items.Add("hamster");
            lxtImageSelector.Items.Add("nina");

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

            imageProfile.Source = bmpImage;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Domain.Player.PlayerClient.ProfileImage = imageResource;

                updateProfileClient.SaveImage(imageResource, Domain.Player.PlayerClient.IdPlayer);

                if (!String.IsNullOrWhiteSpace(txtName.Text))
                {
                    if (!ExistsInvalidFields()) 
                    { 
                    updateProfileClient.UpdateNewNickname(txtName.Text, Domain.Player.PlayerClient.Nickname);
                    Domain.Player.PlayerClient.Nickname = txtName.Text;
                    }
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
            finally
            {
                updateProfileClient.Abort();
            }
            
            Profile go = new Profile()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            goProfile.Show();
            this.Close();

        }

        private void CancelClick(object sender, RoutedEventArgs e)//Cancelar?
        {
            updateProfileClient.Abort();
            Profile go = new Profile()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            goProfile.Show();
            this.Close();
        }

        private void ImageSelector(object sender, SelectionChangedEventArgs e)
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

                imageProfile.Source = bmpImage;
                imageResource = lxtImageSelector.SelectedItem.ToString();
            }
        }

        #region Validations
        private Boolean ExistsInvalidFields()
        {
            Boolean invalidFields = false;
            if (ExistsEmptyFields() || ExistsExcessLength())
            {
                invalidFields = true;
            }
            return invalidFields;
        }

        private Boolean ExistsEmptyFields()
        {
            Boolean emptyFields = false;
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                emptyFields = true;
                MessageBox.Show($"{Properties.Resources.SIGNIN_EMPTYFIELDS_MESSAGE}", $"{Properties.Resources.SIGNIN_EMPTYFIELDS_MESSAGEWINDOW}", MessageBoxButton.OK);
            }
            return emptyFields;
        }
        private Boolean ExistsExcessLength()
        {
            Boolean emptyFields = false;
            if (txtName.Text.Length > 45)
            {
                emptyFields = true;
                MessageBox.Show($"{Properties.Resources.SIGNIN_EXCESSLENGTH_MESSAGE}", $"{Properties.Resources.SIGNIN_EXCESSLENGTH_MESSAGEWINDOW}", MessageBoxButton.OK);
            }
            return emptyFields;
        }
        #endregion
    }
}
