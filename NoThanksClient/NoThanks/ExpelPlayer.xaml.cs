﻿using System;
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
    /// Lógica de interacción para ExpelPlayer.xaml
    /// </summary>
    public partial class ExpelPlayer : Window
    {
        public ExpelPlayer()
        {
            InitializeComponent();
        }

        #region Listeners
        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            Expel();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Private Funcitons
        private void Expel()
        {
            string expelReason = DateTime.Now.ToString();

            if (chAfk.IsChecked == true)
            {
                expelReason += $" {chAfk.Content}";
            }

            if (chCheats.IsChecked == true)
            {
                expelReason += $" {chCheats.Content}";
            }

            if (chToxic.IsChecked == true)
            {
                expelReason += $" {chCheats.Content}";
            }

        }
        #endregion
    }
}
