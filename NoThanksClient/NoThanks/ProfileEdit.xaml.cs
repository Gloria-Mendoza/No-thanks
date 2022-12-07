using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System.ServiceModel;
using System.Windows.Interop;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para Profile_Edit.xaml
    /// </summary>
    public partial class Profile_Edit : Window, PlayerManager.IUpdateProfileCallback
    {
        String imageResource = "";

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
                var context = new InstanceContext(this);
                PlayerManager.UpdateProfileClient updateProfileClient = new PlayerManager.UpdateProfileClient(context);

                Domain.Player.PlayerClient.ProfileImage = imageResource;

                updateProfileClient.SaveImage(imageResource, Domain.Player.PlayerClient.IdPlayer);

                if (!String.IsNullOrWhiteSpace(tbName.Text))
                {
                    updateProfileClient.UpdateNewNickname(tbName.Text, Domain.Player.PlayerClient.Nickname);
                    Domain.Player.PlayerClient.Nickname = tbName.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error");
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
        public void ImageCallBack(byte[] image)
        {
            throw new NotImplementedException();
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
