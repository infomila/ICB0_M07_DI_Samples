﻿using _20171122_SQLite.db;
using _20171122_SQLite.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _20171122_SQLite
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lsvDept.ItemsSource = DeptDB.GetAllDept();
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            lsvDept.ItemsSource = DeptDB.GetAllDept(txbNumero.Text, txbLocalitat.Text);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lsvDept.SelectedValue!=null)
            {
                DeptDB.RemoveDept(((Dept)lsvDept.SelectedValue).Numero);
            }
        }

        private void lsvDept_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsvDept.SelectedValue != null)
            {
                long numEmp = DeptDB.CountEmp(((Dept)lsvDept.SelectedValue).Numero);
                btnDelete.IsEnabled = ( numEmp == 0);
            }
        }
    }
}
