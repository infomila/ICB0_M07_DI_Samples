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

namespace _20170920_Llistes
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            List<int> notes = new List<int>() ;
            List<int> notesPlena = new List<int>() { 12, 23, 53, 34 };
            notes.Add(12);
            notes.Add(21);
            notes.Add(55);
            notes.Add(34);

            notes.RemoveAt(0);
            notes.Insert(2, 45);
            string llista = "";
            for(int i = 0; i < notes.Count; i++)
            {
                llista += (notes[i] + ",");
            }
            foreach(int nota in notes)
            {
                llista += nota + ",";
            }
            //----------------------------------.
            Dictionary<int, string> nomPerDorsal = new Dictionary<int, string>();
            Dictionary<string, int> dorsalsPerNom = new Dictionary<string, int>();
            nomPerDorsal[10] = "Messi";
            nomPerDorsal.Add(9, "Patata");

            dorsalsPerNom["Messi"] = 10;
            dorsalsPerNom["Patata"] = 9;

            string nomJugador10 = nomPerDorsal[10];
            int dorsalMessi = dorsalsPerNom["Messi"];

            try
            {
                string nomJugadorNoExistent = nomPerDorsal[2342342];
            }
            catch (Exception)
            {
                // el jugador no existia
            }
            string totsElsNoms = "";
            foreach( int dorsal in nomPerDorsal.Keys)
            {
                totsElsNoms += nomPerDorsal[dorsal] +",";
            }

            foreach( string nom2 in nomPerDorsal.Values)
            {
                totsElsNoms += nom2 + ",";
            }
            foreach( var tupla in nomPerDorsal)
            {
                totsElsNoms += tupla.Value+ "amb dorsal "+tupla.Key + ",";
            }
            //------------------------------
            if(nomPerDorsal.ContainsKey(10))
            {
                string nomExisteixSegur = nomPerDorsal[10];
            }
            // cerca per clau de forma segura ( si  no el troba, no peta )
            string nom;
            bool heTrobatLaClau = nomPerDorsal.TryGetValue(10, out nom);
            




        }
    }
}
