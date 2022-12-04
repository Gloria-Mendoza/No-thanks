using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para ConsultRecord.xaml
    /// </summary>
    public partial class ConsultRecord : Window
    {

        public ConsultRecord()
        {
            InitializeComponent();
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuWindow = new MenuPrincipal();
            menuWindow.Show();
            this.Close();
        }

        public void FillDataGrid ()
        {
            DataSet data = new DataSet();
            DataTableCollection collection = data.Tables;
            DataTable table = collection[0];
            PlayerManager.PlayerManagerClient playerManager = new PlayerManager.PlayerManagerClient();
            /*dgRecord.DataContext = playerManager.GetRecord();
            txcUsername.Binding = playerManager.GetRecord();
            dgRecord.ItemsSource = playerManager.GetScore();
            var data = new Modelo { nombre = row["Nombre"].ToString(), apellido = row["Apellidos"].ToString(), sexo = row["Sexo"].ToString(), edad = row["Edad"].ToString() };
        dataGridUsuarios.Items.Add(data);*/

            foreach (DataRow row in table.Rows)
            {
                for (int i=0; i>playerManager.GetRecord().Length; i++)
                {
                    string score = playerManager.GetScore().ElementAt(i).ToString();
                    var datas = new Domain.PlayerRecord { Nickname = row[playerManager.GetRecord().ElementAt(i)].ToString(), Score = row[score].ToString() };
                    dgRecord.Items.Add(data);
                }
                
            }
        }
    }
}

