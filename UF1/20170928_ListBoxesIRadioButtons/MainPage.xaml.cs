using _20170928_ListBoxesIRadioButtons.Model;
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

namespace _20170928_ListBoxesIRadioButtons
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
            List<Pregunta> preguntes = Pregunta.GetPreguntes();
            lsbPreguntes.Items.Clear(); // netejar tota la llista d'ítems actual
            // Recorregut sobre totes les preguntes
            foreach (Pregunta p in preguntes) {
                ListBoxItem item = new ListBoxItem(); // Creem un ítem
                item.Content = p.Numero; // assignem el text de l'ítem al número de la pregunat
                lsbPreguntes.Items.Add(item);
            }
            if (preguntes.Count > 0)
            {
                lsbPreguntes.SelectedIndex = 0;
            }
        }

        private void lsbPreguntes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indexPreguntaSeleccionada = lsbPreguntes.SelectedIndex;
            mostrarPregunta(indexPreguntaSeleccionada);
        }

        private void mostrarPregunta(int indexPreguntaSeleccionada)
        {
            List<Pregunta> preguntes = Pregunta.GetPreguntes();
            Pregunta p = preguntes[indexPreguntaSeleccionada];
            txbPregunta.Text = p.TextPregunta;
            StackPanel panellSeleccionat = p.EsMultiresposta ? stpMultireposta : stpMonoreposta;
            StackPanel panellAmagat = p.EsMultiresposta ?  stpMonoreposta: stpMultireposta;
            panellSeleccionat.Visibility = Visibility.Visible;
            panellAmagat.Visibility = Visibility.Collapsed;

            int i = 0;
            char lletra = 'a';
            foreach ( string resposta in p.Respostes)
            {
                ButtonBase b = (ButtonBase)panellSeleccionat.Children[i];
                b.Content = lletra+") "+resposta;
                i++;
                lletra++;
            }
        }
    }
}
