using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _20170919_CadenesDatesDoubles
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            validaAdrecaRegExp();
        }
        private void txtAdreca_TextChanged(object sender, TextChangedEventArgs e)
        {
            validaAdrecaRegExp();
        }

        private bool caracterValid(char v)
        {
            string caractersValids = "-./\\·ªº ";
            return Char.IsLetterOrDigit(v) || caractersValids.Contains(v);//.IndexOf(v) >= 0;
        }

        /// <summary>
        ///  Funció de validació d'adreces usant expresions regulars.
        /// </summary>
        private void validaAdrecaRegExp()
        {
            string paraula = "[a-z0-9áéíóúàèìòùïüâêîôû\\/\\-]{2,}";
            bool adrecaCorrecta = Regex.IsMatch(txtAdreca.Text.Trim().ToLower(), $"^{paraula}([ ]{paraula})+$");
            SolidColorBrush unPutoColor;
            if (!adrecaCorrecta)
            {
                unPutoColor = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            }
            else
            {
                unPutoColor = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            }
            txtAdreca.Background = unPutoColor;
        }

        private void validaAdreca()
        {
            string adreca = txtAdreca.Text.Trim();
            bool adrecaCorrecta = true;
            for (int i = 0; i < adreca.Length; i++)
            {
                if (!caracterValid(adreca[i]))
                {
                    adrecaCorrecta = false;
                    break;
                }
            }
            // Validació de nombre de paraules
            string[] paraules = adreca.Split(" -".ToCharArray());
            if(paraules.Length<2)
            {
                adrecaCorrecta = false;
            } else
            {
                for(int n=0;n<paraules.Length;n++)
                {
                    if (paraules[n].Length < 2)
                    {
                        adrecaCorrecta = false;
                        break;
                    }
                }

                // versió foreach
                /*foreach(string paraula in paraules)
                {
                    if (paraula.Length < 2)
                    {
                        adrecaCorrecta = false;
                        break;
                    }
                }*/

            }

            SolidColorBrush unPutoColor;
            if (!adrecaCorrecta)
            {
                unPutoColor = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            }
            else
            {
                unPutoColor = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            }
            txtAdreca.Background = unPutoColor;

        }
    }
}
