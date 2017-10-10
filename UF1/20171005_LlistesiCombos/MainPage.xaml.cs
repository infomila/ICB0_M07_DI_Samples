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

namespace _20171005_LlistesiCombos
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        List<ObservableCollection<string>> municipisPerProvincia =
                new List<ObservableCollection<string>>();

        public MainPage()
        {
            this.InitializeComponent();

            // AQUI NO PROGRAMEU SIUSPLAU  ;-)
            // ( SOTA LA VOSTRA RESPONSABILITAT)
            /*
                                 Envoyer par email 	

                                         _,.-------.,_
                                     ,;~'             '~;,
                                   ,;                     ;,
                                  ;                         ;
                                 ,'                         ',
                                ,;                           ;,
                                ; ;      .           .      ; ;
                                | ;   ______       ______   ; |
                                |  `/~"     ~" . "~     "~\'  |
                                |  ~  ,-~~~^~, | ,~^~~~-,  ~  |
                                 |   |        }:{        |   |
                                 |   l       / | \       !   |
                                 .~  (__,.--" .^. "--.,__)  ~.
                                 |     ---;' / | \ `;---     |
                                  \__.       \/^\/       .__/
                                   V| \                 / |V
                                    | |T~\___!___!___/~T| |
                                    | |`IIII_I_I_I_IIII'| |
                                    |  \,III I I I III,/  |
                                     \   `~~~~~~~~~~'    /
                                       \   .       .   /     -dcau (4/15/95)
                                         \.    ^    ./
                                           ^~~~^~~~^


             **/
        }

        private ObservableCollection<string> mProvincies;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*cboProvincies.Items.Add("Barcelona");
            cboProvincies.Items.Add("Lleida");
            cboProvincies.Items.Add("Girona");
            cboProvincies.Items.Add("Tarragona");
            */
            mProvincies = new ObservableCollection<string>();
            mProvincies.Add("Barcelona");
            mProvincies.Add("Lleida");
            mProvincies.Add("Girona");
            mProvincies.Add("Tarragona");




            ObservableCollection<string> llistaMunicipisBarcelona =
                new ObservableCollection<string>();
            llistaMunicipisBarcelona.Add("Barcelona");
            llistaMunicipisBarcelona.Add("Igualada");
            llistaMunicipisBarcelona.Add("Mataró");
            llistaMunicipisBarcelona.Add("Sant Esteve Sesrovires");
            llistaMunicipisBarcelona.Add("Keep calm");
            municipisPerProvincia.Add(llistaMunicipisBarcelona);
            //----------------------------------------------------------
            ObservableCollection<string> llistaMunicipisTarragona =
                new ObservableCollection<string>()
                {
                    "Tarragona", "Reus", "Salou"
                };
            municipisPerProvincia.Add(llistaMunicipisTarragona);
            //----------------------------------------------------------
            ObservableCollection<string> llistaMunicipisGirona =
                new ObservableCollection<string>()
                {
                    "Girona", "Figueres", "Salt"
                };
            municipisPerProvincia.Add(llistaMunicipisGirona);
            //----------------------------------------------------------
            ObservableCollection<string> llistaMunicipisLleida =
                new ObservableCollection<string>()
                {
                    "Lleida", "Tremp", "Sort"
                };
            municipisPerProvincia.Add(llistaMunicipisLleida);
            //----------------------------------------------------------

            cboProvincies.ItemsSource = mProvincies;

 
        }

        private void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            string novaProvincia = txtProvincia.Text;
            if (!mProvincies.Contains(novaProvincia))
            {
                mProvincies.Add(novaProvincia);
                municipisPerProvincia.Add(new ObservableCollection<string>());
            }
        }

        private void cboProvincies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboProvincies.SelectedIndex >= 0)
            {
                cboMunicipis.ItemsSource = municipisPerProvincia[cboProvincies.SelectedIndex];
            }

            
        }
    }
}
