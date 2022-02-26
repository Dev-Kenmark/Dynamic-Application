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
    /// Interaction logic for UserControls.xaml
    /// </summary>
    public partial class UserControls : UserControl
    {
        private static string mssqlfile = AppDomain.CurrentDomain.BaseDirectory + "\\mssqlFile";
        private static string mysqlfile = AppDomain.CurrentDomain.BaseDirectory + "\\mysqlFile";
        public static string mssqlConString, mysqlConString;
        public static SqlConnection mscon = new SqlConnection(mssqlConString);
        public static MySqlConnection mycon;
        public DataTable Dt = new DataTable();
        MainWindow main = new MainWindow();
        public string[] storedprodreal, paranames;
        public int parametercount;
        //Button btn = new Button();
        public TextBox txtSample;
        
        public UserControls()
        {
            InitializeComponent();
           
            MsSqlInitializeFile();
            mssqlConString = MsSqlRead();
            
        }
        //mssql
        /*postgre
        private static string postgrefile = AppDomain.CurrentDomain.BaseDirectory + "\\postgreFile";
        public static string postgreConString;
        public static NpgsqlConnection pgcon = new NpgsqlConnection(postgreConString);
        */

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

        /*postgre
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
            c
            StreamReader sr = new StreamReader(postgrefile);
            string str = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();

            return str.Trim();
        }
        */
        public void AddButton(string[] storedprod, int numParameters, string[] parameters, string[] info, int numButtons, string[] buttonnames, DataTable dt, int numGrids)
        {
            storedprodreal = storedprod;
            paranames = parameters;
            
            parametercount = numParameters;
            MsSqlInitializeFile();
            mssqlConString = MsSqlRead();
            //string query = "SELECT * FROM dbo.TASK6TBL";
            //using (SqlConnection con = new SqlConnection(mssqlConString))
            //{
            //    con.Open();
            //    using (SqlCommand cmd = new SqlCommand(query, con))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(query, con);
            //        Dt = new DataTable("Insert");
            //        da.Fill(Dt);
            //    }
            //}

            if (numGrids != 0)
            {
                for (int a = 0; a < numGrids; ++a)
                {
                    StackPanel pnldg = new StackPanel();
                pnldg.Children.Clear();
                pnldg.Orientation = Orientation.Horizontal;
                pnldg.Margin = new Thickness(10);

                DataGrid dg = new DataGrid();
                dg.ItemsSource = dt.DefaultView;
                dg.IsReadOnly = true;
                dg.Width = 625;
                pnldg.Children.Add(dg);
                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.Margin = new Thickness(10);

                stackPanel.Children.Add(pnldg);
                }
            }


            if (numParameters != 0)
            {
                for (int a = 0; a < numParameters; ++a)
                {
                    StackPanel pnl = new StackPanel();
                    pnl.Children.Clear();
                    pnl.Orientation = Orientation.Horizontal;
                    pnl.Margin = new Thickness(10);

                    Label lblSample = new Label();
                    lblSample.Content = info[a];
                    lblSample.FontFamily = new FontFamily("Century Gothic");
                    lblSample.FontSize = 13;

                    txtSample = new TextBox();
                    txtSample.Width = 150;
                    txtSample.FontFamily = new FontFamily("Century Gothic");
                    txtSample.FontSize = 15;
                    txtSample.Name = "txtBox" + a.ToString();

                    pnl.Children.Add(lblSample);
                    pnl.Children.Add(txtSample);

                    stackPanel.Orientation = Orientation.Vertical;
                    stackPanel.Margin = new Thickness(10);

                    stackPanel.Children.Add(pnl);
                }
            }
                if (numButtons != 0)
            {
                StackPanel pnlbtn = new StackPanel();
                pnlbtn.Children.Clear();
                pnlbtn.Orientation = Orientation.Horizontal;
                pnlbtn.Margin = new Thickness(10);
                for (int i = 0; i < numButtons; i++)
                {
                    Button btn = new Button();
                    btn.Width = 75;
                    btn.Height = 40;
                    btn.Margin = new Thickness(10, 10, 10, 10);
                    btn.BorderBrush = Brushes.AliceBlue;
                    btn.BorderThickness = new Thickness(2, 2, 2, 2);
                    string p = "btn" + buttonnames[i].ToString();
                    string strtrim = p.Trim();
                    btn.Name = strtrim;
                    btn.Content = buttonnames[i].ToString();
                    btn.FontFamily = new FontFamily("Century Gothic");
                    btn.FontSize = 15;
                    btn.FontWeight = FontWeights.UltraBold;
                    if (i == 0) btn.Click += ClickHandler0;
                    else if (i == 1) btn.Click += ClickHandler1;
                    else if (i == 2) btn.Click += ClickHandler2;
                    else if (i == 3) btn.Click += ClickHandler3;
                    else if (i == 4) btn.Click += ClickHandler4;
                    pnlbtn.Children.Add(btn);
                }
                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.Margin = new Thickness(10);
                stackPanel.Children.Add(pnlbtn);
            }
        }

        private void ClickHandler0(object sender, RoutedEventArgs e)
        {
            if (storedprodreal.Count() == 1)
            {
                //string[] values;
                //for (int a = 0; a < parametercount; ++a)
                //{
                //    values[a] = ((TextBox)stackPanel.Children["txtBox" +a.ToString()]).Text;
                //}
                try
                {
                    using (SqlConnection con = new SqlConnection(mssqlConString))
                    {
                        con.Open();
                        var command = con.CreateCommand();
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "[dbo].[" + storedprodreal[0].ToString() + "]";
                            if (parametercount != 0)
                            {
                                for (int a = 0; a < parametercount; ++a)
                                {
                                    command.Parameters.AddWithValue("@" + paranames[a], "charlie");
                                }
                            }
                            command.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Query executed successfully!");
                        }


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occurred" + Environment.NewLine + ex.ToString());
                }


            }
        }
        private void ClickHandler1(object sender, RoutedEventArgs e)
        {
            if (storedprodreal.Count() == 2)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(mssqlConString))
                    {
                        con.Open();
                        var command = con.CreateCommand();
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "[dbo].[" + storedprodreal[0].ToString() + "]";
                            if (parametercount != 0)
                            {
                                for (int a = 0; a < parametercount; ++a)
                                {
                                    command.Parameters.AddWithValue("@" + paranames[a], "charlie");
                                }
                            }
                            command.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Query executed successfully!");
                        }


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occurred" + Environment.NewLine + ex.ToString());
                }
            }

        }
        private void ClickHandler2(object sender, RoutedEventArgs e)
        {
            if (storedprodreal.Count() == 3)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(mssqlConString))
                    {
                        con.Open();
                        var command = con.CreateCommand();
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "[dbo].[" + storedprodreal[0].ToString() + "]";
                            if (parametercount != 0)
                            {
                                for (int a = 0; a < parametercount; ++a)
                                {
                                    command.Parameters.AddWithValue("@" + paranames[a], "charlie");
                                }
                            }
                            command.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Query executed successfully!");
                        }


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occurred" + Environment.NewLine + ex.ToString());
                }
            }
        }
        private void ClickHandler3(object sender, RoutedEventArgs e)
        {
            if (storedprodreal.Count() == 4)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(mssqlConString))
                    {
                        con.Open();
                        var command = con.CreateCommand();
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "[dbo].[" + storedprodreal[0].ToString() + "]";
                            if (parametercount != 0)
                            {
                                for (int a = 0; a < parametercount; ++a)
                                {
                                    command.Parameters.AddWithValue("@" + paranames[a], "charlie");
                                }
                            }
                            command.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Query executed successfully!");
                        }


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occurred" + Environment.NewLine + ex.ToString());
                }
            }
        }
        private void ClickHandler4(object sender, RoutedEventArgs e)
        {
            if (storedprodreal.Count() == 5)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(mssqlConString))
                    {
                        con.Open();
                        var command = con.CreateCommand();
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "[dbo].[" + storedprodreal[0].ToString() + "]";
                            if (parametercount != 0)
                            {
                                for (int a = 0; a < parametercount; ++a)
                                {
                                    command.Parameters.AddWithValue("@" + paranames[a], "charlie");
                                }
                            }
                            command.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Query executed successfully!");
                        }


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occurred" + Environment.NewLine + ex.ToString());
                }
            }
        }
    }
}
