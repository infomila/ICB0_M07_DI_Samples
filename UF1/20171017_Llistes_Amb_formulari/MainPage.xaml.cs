using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _20171010_Llistes
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        private ObservableCollection<Cotxe> mCotxes;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mCotxes = Cotxe.getCotxes();
            lsvCotxes.ItemsSource = mCotxes;
            cboMarca.ItemsSource = Cotxe.getMarques();
        }

        private void lsvCotxes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if( lsvCotxes.SelectedValue!=null)
            {
                Cotxe c = (Cotxe)lsvCotxes.SelectedValue;
                txbModel.Text = c.Model;
                txbMatricula.Text = c.Matricula;
                cboMarca.SelectedValue = c.Marca;
                clpColor.Color = c.ColorCotxe;
            }
        }

      

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (lsvCotxes.SelectedValue != null)
            {
                Cotxe c = (Cotxe)lsvCotxes.SelectedValue;
                c.Model = txbModel.Text;
                c.Matricula = txbMatricula.Text;
                c.Marca = cboMarca.SelectedValue.ToString();
                c.ColorCotxe = clpColor.Color;

                
                int idx = mCotxes.IndexOf(c);
                // "matxaquem" l'element amb un de nou.....si no, no s'actualitza.
                mCotxes[idx] = 
                    new _20171010_Llistes.Cotxe(
                        txbMatricula.Text, txbModel.Text, cboMarca.SelectedValue.ToString(), clpColor.Color);
            }
            //-----------------------------------------------
            // Actualització de la llista "a lo caçurro"
            //object cotxesTmp = lsvCotxes.ItemsSource;
            //lsvCotxes.ItemsSource = null;
            //lsvCotxes.ItemsSource = cotxesTmp;
            //-----------------------------------------------
        }
    }
}
