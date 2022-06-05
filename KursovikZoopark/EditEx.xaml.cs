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

namespace KursovikZoopark
{
    /// <summary>
    /// Логика взаимодействия для EditEx.xaml
    /// </summary>
    public partial class EditEx : Page
    {
        Exkursion Ex = new Exkursion();
        public EditEx(Exkursion _Ex)
        {
            InitializeComponent();
            Ex = _Ex;
            if (_Ex == null)
            {
                EditBtn.Visibility = Visibility.Hidden;
                SaveBtn.Visibility = Visibility.Visible;
                return;
            }
            nameEx.Text = Ex.name;
            infoEx.Text = Ex.info;
            priceEx.Text = Ex.price.ToString();
            durationEx.Text = Ex.duration.ToString();
            maxManEx.Text = Ex.maxMan.ToString();
            skidkaEx.Text = Ex.skidka.ToString();
            IsRead(true);
        }

        public void IsRead(bool isR)
        {
            nameEx.IsReadOnly = isR;
            infoEx.IsReadOnly = isR;
            priceEx.IsReadOnly = isR;
            durationEx.IsReadOnly = isR;
            maxManEx.IsReadOnly = isR;
            skidkaEx.IsReadOnly = isR;
        }

        private void StartEdit(object sender, RoutedEventArgs e)
        {
            IsRead(false);
            EditBtn.Visibility = Visibility.Hidden;
            SaveBtn.Visibility = Visibility.Visible;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            IsRead(true);
            EditBtn.Visibility = Visibility.Visible;
            SaveBtn.Visibility = Visibility.Hidden;
            bool isUpdate = true;
            if (Ex==null)
            {
                Ex = new Exkursion();
                isUpdate = false;
            }
            Ex.name = nameEx.Text;
            Ex.info = infoEx.Text;
            Ex.duration = int.Parse(durationEx.Text);
            Ex.maxMan = int.Parse(maxManEx.Text);
            Ex.price = int.Parse(priceEx.Text);
            Ex.skidka = int.Parse(skidkaEx.Text);
            if (isUpdate == false)
            {
                App.Context.Exkursion.Add(Ex);
            }
            App.Context.SaveChanges();
        }

        private void skidkaEx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
