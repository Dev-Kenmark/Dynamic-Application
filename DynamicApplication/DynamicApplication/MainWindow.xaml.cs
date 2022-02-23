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
using System.Data;

namespace DynamicApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string mssqlfile = AppDomain.CurrentDomain.BaseDirectory + "\\mssqlFile";
        private static string mysqlfile = AppDomain.CurrentDomain.BaseDirectory + "\\mysqlFile";
        public static string mssqlConString, mysqlConString;
        public static SqlConnection mscon = new SqlConnection(mssqlConString);
        public static MySqlConnection mycon;
        public DataTable Dt = new DataTable();

        public int numParameters;
        public string[] info;
        public MainWindow()
        {
            InitializeComponent();
            Check();
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

        public void Check()
        {
            MsSqlInitializeFile();
            mssqlConString = MsSqlRead();
            string query = "SELECT * FROM dbo.TASK6TBL";
            using (SqlConnection con = new SqlConnection(mssqlConString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    Dt = new DataTable("Test");
                    da.Fill(Dt);
                }
            }
            foreach (DataRow row in Dt.Rows)
            {
                Button btn = new Button();
                btn.Tag = Convert.ToInt32(row[0]);

                btn.Width = 75;
                btn.Height = 40;

                btn.Margin = new Thickness(10, 10, 10, 10);
                btn.BorderBrush = Brushes.AliceBlue;
                btn.BorderThickness = new Thickness(2, 2, 2, 2);

                btn.Name = "btn" + row[1].ToString();
                btn.Content = row[1].ToString();

                btn.FontFamily = new FontFamily("Century Gothic");
                btn.FontSize = 15;
                btn.FontWeight = FontWeights.UltraBold;

                pnlStack.Orientation = Orientation.Vertical;
                pnlStack.Margin = new Thickness(10);

                btn.Click += (s, e) =>
                {
                    pnlDock.Children.Clear();
                    if(row[1].ToString() == "Test")
                    { 
                        
                        numParameters = Convert.ToInt32(row.ItemArray[4].ToString());

                        UserControls ctrl = new UserControls();                    
  
                        string a = row.ItemArray[6].ToString();                   
                        string strtrim = a.Trim(); 
                    
                        if (!strtrim.Equals(""))
                        {
                            info = a.Split(',');                                        
                              
                        }
                        ctrl.AddButton(numParameters, info);
                        pnlDock.Children.Add(ctrl);
                    } 
                    if (row[1].ToString() == "Test1")
                    {  
                        numParameters = Convert.ToInt32(row.ItemArray[4].ToString());
                        UserControls ctrl = new UserControls(); 
                        string a = row.ItemArray[6].ToString();
                        string strtrim = a.Trim();

                        if (!strtrim.Equals("")) 
                        {
                            info = a.Split(',');

                        }
                        ctrl.AddButton(numParameters, info);
                        pnlDock.Children.Add(ctrl);

                    } 
                };

                pnlStack.Children.Add(btn); 
                
            }

            void AddTextLabel()
            { 
            }
 /*           Button btn = new Button();

            btn.Width = 75;
            btn.Height = 40;

            btn.Margin = new Thickness(10, 10, 10, 10);
            btn.BorderBrush = Brushes.AliceBlue;
            btn.BorderThickness = new Thickness(2, 2, 2, 2);
            btn.Content = "Add";
            btn.FontFamily = new FontFamily("Century Gothic");
            btn.FontSize = 15;
            btn.FontWeight = FontWeights.UltraBold;

            pnlStack.Orientation = Orientation.Vertical;
            pnlStack.Margin = new Thickness(10);

            btn.Click += (s, e) =>
            {
                MessageBox.Show("KM THE GREAT!", "SAKALAM", MessageBoxButton.OK, MessageBoxImage.Information);
            };

            pnlStack.Children.Add(btn);
            UserControls ctrl = new UserControls();
            pnlDock.Children.Add(ctrl); */
            
        }
    }
}
