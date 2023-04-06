using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MdfDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\m.yovchevski\OneDrive\MdfDB\MdfDB\Database1.mdf;Integrated Security=True");
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            try
            {


                //opening the connection to the db 

                sqlCon.Open();

                //Build our actual query 

                string query = "INSERT INTO SignUpDetails(FirstName,Password,Email)values ('" + this.txtUsername.Text + "','" + this.pswrdBox.Password + "','" + this.emailBox.Text + "') ";

                //Establish a sql command

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully saved");

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                sqlCon.Close();

            }
        

    }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            MdfDB.Database1DataSet database1DataSet = ((MdfDB.Database1DataSet)(this.FindResource("database1DataSet")));
            // Load data into the table SignUpDetails. You can modify this code as needed.
            MdfDB.Database1DataSetTableAdapters.SignUpDetailsTableAdapter database1DataSetSignUpDetailsTableAdapter = new MdfDB.Database1DataSetTableAdapters.SignUpDetailsTableAdapter();
            database1DataSetSignUpDetailsTableAdapter.Fill(database1DataSet.SignUpDetails);
            System.Windows.Data.CollectionViewSource signUpDetailsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("signUpDetailsViewSource")));
            signUpDetailsViewSource.View.MoveCurrentToFirst();
        }
    }
}
