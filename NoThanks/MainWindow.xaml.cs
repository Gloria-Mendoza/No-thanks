﻿using NoThanks.PlayerManager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Authentication;
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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginAction()
        {
            var username = txtUsername.Text;
            var password = pfPassword.Password;

            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                PlayerManager.PlayerManagerClient client = new PlayerManager.PlayerManagerClient();
                var aux = client.Login(username, password);
                if (aux)
                {
                    Player player = new Player()
                    {
                        Nickname = username
                    };
                    MenuPrincipal go = new MenuPrincipal();
                    go.WindowState = this.WindowState;
                    go.SettingData(player);
                    go.Show();
                    this.Close();
                }
                else
                {
                    //TODO
                    MessageBox.Show("No Funciona", "Upss", MessageBoxButton.OK);
                }
            }
            else
            {
                //TODO
                MessageBox.Show("Debes ingresar tú usuario y contraseña");
            }
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            try
            {           
                LoginAction();
            }
            catch (EndpointNotFoundException)
            {
                //TODO
                MessageBox.Show("No se pudo establecer conexión con el servidor", "Upss", MessageBoxButton.OK);
            }

        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal go = new MenuPrincipal();
            Player player = new Player()
            {
                Nickname = "Guest" + new Random().Next()
            };
            go.WindowState = this.WindowState;
            go.SettingData(player);
            go.Show();
            this.Close();
        }
    }
}