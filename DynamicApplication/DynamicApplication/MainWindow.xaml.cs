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
        private static string dbasefile = AppDomain.CurrentDomain.BaseDirectory + "\\dbFile";
        private static string mysqldbasefile = AppDomain.CurrentDomain.BaseDirectory + "\\mysqldbFile";
        private static string postgrefile = AppDomain.CurrentDomain.BaseDirectory + "\\postgreFile";
        public static string connString, mysqlconnString, postgreConString;
        public static SqlConnection con = new SqlConnection(connString);
        public static NpgsqlConnection pgcon;
        public static MySqlConnection mcon;

        public MainWindow()
        {
            InitializeComponent();
        }

        public static void InitializeFile()
        {
            if (!File.Exists(dbasefile))
            {
                StreamWriter sw = new StreamWriter(dbasefile);
                sw.WriteLine("");
                sw.Dispose();
                sw.Close();
            }
        }

        public static void MInitializeFile()
        {
            if (!File.Exists(mysqldbasefile))
            {
                StreamWriter sw = new StreamWriter(mysqldbasefile);
                sw.WriteLine("");
                sw.Dispose();
                sw.Close();
            }
        }

        public static void Write(string strData)
        {
            StreamWriter sw = new StreamWriter(dbasefile);
            sw.WriteLine(strData);
            sw.Dispose();
            sw.Close();
        }

        public static string Read()
        {
            if (!File.Exists(dbasefile))
            {
                return "";
            }
            StreamReader sr = new StreamReader(dbasefile);
            string str = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();

            return str.Trim();
        }

        public static void MWrite(string strData)
        {
            StreamWriter sw = new StreamWriter(mysqldbasefile);
            sw.WriteLine(strData);
            sw.Dispose();
            sw.Close();
        }

        public static string MRead()
        {
            if (!File.Exists(mysqldbasefile))
            {
                return "";
            }
            StreamReader sr = new StreamReader(mysqldbasefile);
            string str = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();

            return str.Trim();
        }
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

            InitializeFile();
            MInitializeFile();
            connString = Read();
            mysqlconnString = MRead();

            mcon = new MySqlConnection(mysqlconnString);
            pgcon = new NpgsqlConnection(postgreConString);
            mcon.Open();
            mcon.Close();
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
