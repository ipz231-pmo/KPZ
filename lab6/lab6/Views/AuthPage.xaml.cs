using lab6.ViewModels;
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

namespace lab6.Views
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class AuthPage : UserControl
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e) 
        { 
            Mouse.OverrideCursor = Cursors.Hand;
            Label lbl = sender as Label;
            lbl.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private void Label_MouseLeave(object sender, MouseEventArgs e) 
        { 
            Mouse.OverrideCursor = null;
            Label lbl = sender as Label;
            lbl.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is AuthVM dc)
            {
                dc.RegisterHndl?.Invoke(dc, EventArgs.Empty);
            }
        }
    }
}
