using NoThanks.PlayerManager;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class MenuPrincipal : Window
    {
        private Player player = new Player();
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        public void SettingData(Player player)
        {
            this.player = player;
            LabelName.Content = player.Nickname;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Room go = new Room();
            go.WindowState = this.WindowState;
            go.SettingData(this.player);
            go.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow go = new MainWindow();
            go.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Profile go = new Profile();
            go.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Personalization go = new Personalization();
            go.Show();
            this.Close();
        }
    }
}
