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
using JsonParse;

namespace UI
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

        private void FormatButton_Click(object sender, RoutedEventArgs e)
        {
            JsonParser jsonParser = new JsonParser();
            jsonParser.SetTabConst(4).SetLineBreakeConst(1);

            ResultTextBox.Text = jsonParser.HandleString(InputTextBox.Text);
        }
    }
}
