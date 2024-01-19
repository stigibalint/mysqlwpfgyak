using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace OldtimerGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Auto> dataList;
        private readonly string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=oldtimer;";
        private readonly MySqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            dataList = new();
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string queryText = "SELECT rendszam,szin,nev,evjarat,ar FROM autok";
                MySqlCommand command = new MySqlCommand(queryText, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string rendszam = reader.GetString(0);
                    string szin = reader.GetString(1);
                    string nev = reader.GetString(2);
                    int evjarat = reader.GetInt32(3);
                    int ar = reader.GetInt32(4);
                    Auto uj = new(rendszam, szin, nev, evjarat, ar);
                    dataList.Add(uj);
                }
                resultTable.ItemsSource = dataList;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string commandText = "DELETE FROM autok WHERE id=(SELECT MAX(id) FROM autok)";
            MySqlCommand command= new MySqlCommand(commandText, connection);
            command.ExecuteNonQuery();
        }
    }
}