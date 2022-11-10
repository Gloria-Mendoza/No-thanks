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
            JoinWithCode go = new JoinWithCode()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
        }

        private void FastMatchClick(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void NewGameClick(object sender, RoutedEventArgs e)
        {
            Room go = new Room()
            {
                WindowState = this.WindowState,
                Left = this.Left,
                IsNewRoom = true
            };
            go.CreateNewRoom(true);
            go.Show();
            this.Close();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            MenuPrincipal go = new MenuPrincipal()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
        }
    }
}
