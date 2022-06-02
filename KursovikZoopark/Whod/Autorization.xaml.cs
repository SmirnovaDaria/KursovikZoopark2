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

namespace KursovikZoopark.Whod
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Whod(object sender, RoutedEventArgs e)
        {
            foreach (var item in App.Context.User.ToList())
            {
                if (loginBox.Text == item.login)
                {
                    if (PassBox.Password == item.password)
                    {
                        if (item.role == 1)
                        {
                            ClientWin CW = new ClientWin(item);
                            
                            MainWindow MW = (MainWindow)Window.GetWindow(this);
                            MW.Close();
                            CW.Show();
                        }
                        else if (item.role == 2)
                        {
                            AdminWin AW = new AdminWin();
                            MainWindow MW = (MainWindow)Window.GetWindow(this);
                            MW.Close();
                            AW.Show();
                        }
                        break;
                    }
                }
            }
        }

        private void Regisrtation(object sender, RoutedEventArgs e)
        {
            MainWindow MW = (MainWindow)Window.GetWindow(this);
            MW.MainFrame.Content = new Registration();
        }
    }
}
