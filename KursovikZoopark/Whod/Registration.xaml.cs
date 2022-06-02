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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registrat(object sender, RoutedEventArgs e)
        {
            var AllLogin = from l in App.Context.User
                           select l.login;
            foreach (var item in AllLogin)
            {
                if (item == loginBox.Text)
                {
                    MessageBox.Show("Такой пользователь уже существует");
                    return;
                }
            }
            User client = new User();
            client.login = loginBox.Text;
            client.password = PassBox.Password;
            client.name = NameBox.Text;
            client.familia = FamiliaBox.Text;
            client.role = 1;
            App.Context.User.Add(client);
            App.Context.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно");
            MainWindow MW = (MainWindow)Window.GetWindow(this);
            MW.MainFrame.Content = new Autorization();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            MainWindow MW = (MainWindow)Window.GetWindow(this);
            MW.MainFrame.Content = new Autorization();
        }
    }
}
