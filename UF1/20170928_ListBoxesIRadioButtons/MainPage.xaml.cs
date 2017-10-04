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

        private List<Pregunta> mPreguntes;
        //private bool mNoDisparisEvents = false;



        private  void programarEventsRadioICheckboxes(bool pActivar)
        {
            List<UIElement> llista = new List<UIElement>();
            llista.AddRange(stpMonoreposta.Children);
            llista.AddRange(stpMultireposta.Children);
            foreach (ToggleButton t in llista)
            {
                if (pActivar)
                {
                    t.Checked += CheckBox_Checked;
                    t.Unchecked += CheckBox_Unchecked;
                }
                else
                {
                    t.Checked -= CheckBox_Checked;
                    t.Unchecked -= CheckBox_Unchecked;
                }
            }
            

            
        }

    

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            mPreguntes = Pregunta.GetPreguntes();
            lsbPreguntes.Items.Clear(); // netejar tota la llista d'ítems actual
            // Recorregut sobre totes les preguntes
            foreach (Pregunta p in mPreguntes) {
                ListBoxItem item = new ListBoxItem(); // Creem un ítem
                item.Content = p.Numero; // assignem el text de l'ítem al número de la pregunat
                lsbPreguntes.Items.Add(item);
            }
            if (mPreguntes.Count > 0)
            {
                lsbPreguntes.SelectedIndex = 0;
            }

            programarEventsRadioICheckboxes(true);
        }

        private void lsbPreguntes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indexPreguntaSeleccionada = lsbPreguntes.SelectedIndex;
            lsbPreguntes.SelectedItem.ToString();
            mostrarPregunta(indexPreguntaSeleccionada);
        }

        private void mostrarPregunta(int indexPreguntaSeleccionada)
        {
            //List<Pregunta> preguntes = Pregunta.GetPreguntes();
            Pregunta p = mPreguntes[indexPreguntaSeleccionada];
            txbPregunta.Text = p.TextPregunta;
            StackPanel panellSeleccionat = p.EsMultiresposta ? stpMultireposta : stpMonoreposta;
            StackPanel panellAmagat = p.EsMultiresposta ?  stpMonoreposta: stpMultireposta;
            panellSeleccionat.Visibility = Visibility.Visible;
            panellAmagat.Visibility = Visibility.Collapsed;


            programarEventsRadioICheckboxes(false);
            int i = 0;
            char lletra = 'a';
            foreach ( string resposta in p.Respostes)
            {
                ToggleButton b = (ToggleButton)panellSeleccionat.Children[i];
                b.Content = lletra+") "+resposta;

                // ara hauríem de ser capaços d'activar o desactivar el radio o el checkbox

                bool respostaSeleccionada = p.RespostesSeleccionades.Contains(i);
                b.IsChecked =  respostaSeleccionada;

                i++;
                lletra++;
            }
            programarEventsRadioICheckboxes(true);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //if (mNoDisparisEvents) return;

            ToggleButton b = (ToggleButton)sender;
            int idxPregunta = Int32.Parse(b.Tag.ToString());

            int indexPreguntaSeleccionada = lsbPreguntes.SelectedIndex;

            List<int> respostesSelecionades = 
                mPreguntes[indexPreguntaSeleccionada].RespostesSeleccionades;
            if (!respostesSelecionades.Contains(idxPregunta))
            {
                respostesSelecionades.Add(idxPregunta);
            }


        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //if (mNoDisparisEvents) return;

            ToggleButton b = (ToggleButton)sender;
            int idxPregunta = Int32.Parse(b.Tag.ToString());

            int indexPreguntaSeleccionada = lsbPreguntes.SelectedIndex;

            mPreguntes[indexPreguntaSeleccionada].RespostesSeleccionades.Remove(idxPregunta);
        }
    }
}
