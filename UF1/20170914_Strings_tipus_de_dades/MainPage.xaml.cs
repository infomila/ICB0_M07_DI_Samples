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

namespace _20170914_Strings_tipus_de_dades
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
            string nom = "Paco";
            string cognom = "Jones";

            string nomComplet = "El paio es diu:\n" + 
                                nom + " " +cognom  ;

            nomComplet += "\n i es un capullo";
            txtResultat.Text = nomComplet;

            //                  0123456
            string matricula = "    41g5 THW  ";
            matricula = matricula.Trim();

            //matricula = matricula.Replace(" ", "");
            //string matricula = "KAKA";
            if (matricula.Length == 8)
            {
                string incognita = matricula.Substring(3);
                string numero = matricula.Substring(0, 4);
                string lletres = matricula.Substring(5);

                txtResultat.Text += "\n Numero:" + numero;
                txtResultat.Text += "\n Lletres:" + lletres;

                // verificació de si la cadena conté un número
                try
                {
                    int numeroConvertit = int.Parse(numero);
                    // aquí el número està bé !

                } catch(Exception ex)
                {
                    txtResultat.Text += "Capullo! això no és un número";
                }                                
            }

            int numeroX = 23;
            string numeroEnCadena = numeroX.ToString(); //"23"
            double numeroDecimal = 23.23;
            string numeroDecimalEnCadena = numeroDecimal.ToString("####.000");

            txtResultat.Text += "\n numeroDecimalEnCadena:" + numeroDecimalEnCadena;

          

        }
    }
}
