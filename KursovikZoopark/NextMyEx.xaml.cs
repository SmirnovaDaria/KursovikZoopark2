﻿using System;
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
    /// Логика взаимодействия для NextMyEx.xaml
    /// </summary>
    public partial class NextMyEx : Page
    {
        User _client;
        public NextMyEx(User _client)
        {
            InitializeComponent();
            this._client = _client;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var result = (from E in App.Context.Exkursion.ToList()
                          join B in App.Context.Booking on E.id equals B.idExkursion
                          //join U in App.Context.User on B.idUser equals U.id
                          where (B.idUser == _client.id) && (B.isEnd == false)
                          select new { B.id, E.name, B.itog, B.valueMan, B.dateTime }).OrderBy(x => x.id);
            listEx.DataContext = result;
        }

        private void SelectEx(object sender, MouseButtonEventArgs e)
        {

        }

        private void listEx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
