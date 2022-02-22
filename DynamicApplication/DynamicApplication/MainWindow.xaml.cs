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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Npgsql;
using MySql.Data.MySqlClient;
using System.IO;

namespace DynamicApplication
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

        //mssql
        private static string mssqlfile = AppDomain.CurrentDomain.BaseDirectory + "\\mssqlFile";
        public static string mssqlConString;
        public static SqlConnection mscon = new SqlConnection(mssqlConString);
        //mysql
        private static string mysqlfile = AppDomain.CurrentDomain.BaseDirectory + "\\mysqlFile";
        public static string mysqlConString;
        public static MySqlConnection mycon = new MySqlConnection(mysqlConString);

        //postgre
        private static string postgrefile = AppDomain.CurrentDomain.BaseDirectory + "\\postgreFile";
        public static string postgreConString;
        public static NpgsqlConnection pgcon = new NpgsqlConnection(postgreConString);


        //mssql
        public static void MsSqlInitializeFile()
        {
            if (!File.Exists(mssqlfile))
            {
                StreamWriter sw = new StreamWriter(mssqlfile);
                sw.WriteLine("");
                sw.Dispose();
                sw.Close();
            }
        }

        public static string MsSqlRead()
        {
            if (!File.Exists(mssqlfile))
            {
                return "";
            }
            StreamReader sr = new StreamReader(mssqlfile);
            string str = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();

            return str.Trim();
        }

        //mysql
        public static void MySqlInitializeFile()
        {
            if (!File.Exists(mysqlfile))
            {
                StreamWriter sw = new StreamWriter(mysqlfile);
                sw.WriteLine("");
                sw.Dispose();
                sw.Close();
            }
        }

        public static string MySqlRead()
        {
            if (!File.Exists(mysqlfile))
            {
                return "";
            }
            StreamReader sr = new StreamReader(mysqlfile);
            string str = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();

            return str.Trim();
        }

        //postgre
        public static void PostgreInitializeFile()
        {
            if (!File.Exists(postgrefile))
            {
                StreamWriter sw = new StreamWriter(postgrefile);
                sw.WriteLine("");
                sw.Dispose();
                sw.Close();
            }
        }

        public static string PostgreRead()
        {
            if (!File.Exists(postgrefile))
            {
                return "";
            }
            StreamReader sr = new StreamReader(postgrefile);
            string str = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();

            return str.Trim();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MsSqlInitializeFile();
            mssqlConString = MsSqlRead();
            MySqlInitializeFile();
            mysqlConString = MySqlRead();
            PostgreInitializeFile();
            postgreConString = PostgreRead();

            Button btn = new Button();
            btn.Content = "Add";
              
            pnlStack.Orientation = Orientation.Vertical;
            pnlStack.Margin = new Thickness(10);
            pnlStack.Children.Add(btn); 

            UserControls ctrl = new UserControls();
             
            pnlDock.Children.Add(ctrl);         

        }

    }
}
