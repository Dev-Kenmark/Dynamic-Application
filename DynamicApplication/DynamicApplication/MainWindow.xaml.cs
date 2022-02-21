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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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
