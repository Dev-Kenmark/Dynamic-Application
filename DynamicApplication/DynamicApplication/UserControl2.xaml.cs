using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace DynamicApplication
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        private static string mssqlfile = AppDomain.CurrentDomain.BaseDirectory + "\\mssqlFile";
        private static string mysqlfile = AppDomain.CurrentDomain.BaseDirectory + "\\mysqlFile";
        public static string mssqlConString, mysqlConString;
        public static SqlConnection mscon = new SqlConnection(mssqlConString);
        public static MySqlConnection mycon;
        public DataTable Dt = new DataTable();
        public UserControl2()
        {
            InitializeComponent();
            grid();
        }
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
        private void SearchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            MsSqlInitializeFile();
            mssqlConString = MsSqlRead();
        }
        public void grid()
        {
            MsSqlInitializeFile();
            mssqlConString = MsSqlRead();
            using (SqlConnection conn = new SqlConnection(mssqlConString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.sp_Task6Tbl_View";
                    Dt = new DataTable();
                    SqlDataReader sdr = command.ExecuteReader();
                    Dt.Load(sdr);
                    DataGrid.ItemsSource = Dt.DefaultView;
                }
                conn.Close();               
            }   
        }

    }
}
