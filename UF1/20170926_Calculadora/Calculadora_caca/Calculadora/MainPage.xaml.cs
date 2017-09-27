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

namespace Calculadora
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            //btn1.Click += Numero_Click;

            foreach(  var objecte in grdTeclat.Children)
            {
                if(objecte.GetType() == typeof(Button))
                {
                    Button b = (Button)objecte;
                    b.Click += Numero_Click;
                }
            }
        }



        private void Numero_Click(object sender, RoutedEventArgs e)
        {
            Button elDitxosBotoQueHanApretat = (Button)sender;
            int numero = Int32.Parse(elDitxosBotoQueHanApretat.Content.ToString());

            tbkPantalla.Text = numero + "";
        }
    }
}
