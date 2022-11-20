﻿using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para Friends.xaml
    /// </summary>
    public partial class Friends : Window, PlayerManager.IUpdateProfileCallback
    {
        private List<String> strings = new List<String>();
        public Friends()
        {
            InitializeComponent();
            cargealluser();
            cargeallFriend();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal go = new MenuPrincipal()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtConsult.Text))
            {
                ltbAllUser.ItemsSource = strings;
            }
            else
            {
                List<String> resultSearch = new List<string>();

                string nickFriend = txtConsult.Text;
                resultSearch.Add(strings.Find(i => i.Contains(nickFriend)));
                ltbAllUser.ItemsSource = resultSearch;
            }
        }

        public void cargealluser()
        {
            var context = new InstanceContext(this);
            PlayerManager.UpdateProfileClient updateProfileClient = new PlayerManager.UpdateProfileClient(context);
            strings = updateProfileClient.GetGlobalPlayers().ToList();
            ltbAllUser.ItemsSource = strings;
        }

        public void cargeallFriend()
        {
            var context = new InstanceContext(this);
            PlayerManager.UpdateProfileClient updateProfileClient = new PlayerManager.UpdateProfileClient(context);
            //updateProfileClient.GetGlobalFriends().ToList();

        }

        public void ImageCallBack(byte[] image)
        {
            throw new NotImplementedException();
        }

        private void ltbAllUser_PreviewMouseDown(object sender, MouseButtonEventArgs e)
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