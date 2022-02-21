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
    /// Interaction logic for UserControls.xaml
    /// </summary>
    public partial class UserControls : UserControl
    {
        public UserControls()
        {
            InitializeComponent();
            AddButton();
           
        }
        public void AddButton()
        {
            TextBox txtSample = new TextBox();
            txtSample.Text = "Textbox Sample";
            TextBox txtSample1 = new TextBox();
            txtSample1.Text = "Textbox Sample 2nd";

            stackPanel.Orientation = Orientation.Vertical;
            stackPanel.Margin = new Thickness(10);
            stackPanel.Children.Add(txtSample);
            stackPanel.Children.Add(txtSample1);
        }
    }
}
