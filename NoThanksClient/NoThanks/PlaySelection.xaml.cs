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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para PlaySelection.xaml
    /// </summary>
    public partial class PlaySelection : Window
    {
        public PlaySelection()
        {
            InitializeComponent();
        }

        private void JoinWithCodeClick(object sender, RoutedEventArgs e)
        {
            JoinWithCode goJoinWithCode = new JoinWithCode()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            goJoinWithCode.Show();
            this.Close();
        }

        private void NewGameClick(object sender, RoutedEventArgs e)
        {
            Room goRoom = new Room()
            {
                WindowState = this.WindowState,
                Left = this.Left,
                IsNewRoom = true
            };
            goRoom.CreateNewRoom(true);
            goRoom.Show();
            this.Close();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            MainMenu goMainMenu = new MainMenu()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            goMainMenu.Show();
            this.Close();
        }
    }
}
