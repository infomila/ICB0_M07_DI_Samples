using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _20171010_Llistes
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private enum MODE
        {
            BLOQUEJAT,
            EDICIO,
            NOU
        }

        private MODE mMode;

        private MODE CURRENT_MODE
        {
            get
            {
                return mMode;
            }
            set
            {
                mMode = value;
                ActivarControls(mMode != MODE.BLOQUEJAT);
                btnSave.IsEnabled = false;
                btnAfegir.IsEnabled = mMode !=MODE.NOU;
                btnEsborrar.IsEnabled = mMode == MODE.EDICIO;
                //activar edició matricula
                txbMatricula.IsEnabled = mMode==MODE.NOU;
                if (mMode == MODE.NOU || mMode == MODE.BLOQUEJAT)
                {
                    buidarFormulari();
                }
                if (mMode == MODE.NOU)
                {                    
                    valida();
                }
            }
        }

        private void buidarFormulari()
        {
            // deseleccionar el valor de la llista
            lsvCotxes.SelectedValue = null;
            //lsvCotxes.SelectedIndex = -1; // Això fa el mateix que l'anterior

            txbMatricula.Text = "";
            txbModel.Text = "";
            cboMarca.SelectedValue = null;
            clpColor.Color = Color.FromArgb(255, 0, 255, 0);
        }

        private void ActivarControls(bool actius)
        {
            foreach (UIElement ctrl in grdForms.Children)
            {
                Type t = ctrl.GetType();
                if (t==typeof(TextBox)|| t == typeof(ComboBox))
                {
                    ((Control)ctrl).IsEnabled = actius;

                }
            }
        }


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

            //-------------------------
            // programació dels events de canvi en el formulari
            txbMatricula.TextChanged += _TextChanged;
            txbModel.TextChanged += _TextChanged;
            cboMarca.SelectionChanged += CboMarca_SelectionChanged;

            //desactivem el botó de desar            

            CURRENT_MODE = MODE.BLOQUEJAT;

        }

        private void CboMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            valida();
        }

        private void _TextChanged(object sender, TextChangedEventArgs e)
        {
            valida();
        }

        private void clpColor_ColorChanged(object sender, Color color)
        {
            valida();
        }

        private void lsvCotxes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if( lsvCotxes.SelectedValue!=null)
            {

                CURRENT_MODE = MODE.EDICIO;

                Cotxe c = (Cotxe)lsvCotxes.SelectedValue;
                txbModel.Text = c.Model;
                txbMatricula.Text = c.Matricula;
                cboMarca.SelectedValue = c.Marca;
                clpColor.Color = c.ColorCotxe;
            }
        }

      

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (valida())
            {
                // és vàlid
                Cotxe c = new Cotxe(
                            txbMatricula.Text, 
                            txbModel.Text, 
                            cboMarca.SelectedValue.ToString(), 
                            clpColor.Color);
            
                if (CURRENT_MODE == MODE.NOU)
                {
                    mCotxes.Add(c);
                } else {                    
                    int idx = mCotxes.IndexOf((Cotxe)lsvCotxes.SelectedValue);
                    // "matxaquem" l'element amb un de nou.....si no, no s'actualitza.
                    mCotxes[idx] = c;                   
                }
                lsvCotxes.SelectedValue = c;

                //-----------------------------------------------
                // Actualització de la llista "a lo caçurro"
                //object cotxesTmp = lsvCotxes.ItemsSource;
                //lsvCotxes.ItemsSource = null;
                //lsvCotxes.ItemsSource = cotxesTmp;
                //-----------------------------------------------
            }
        }

        private bool valida()
        {
            if (CURRENT_MODE == MODE.BLOQUEJAT) return false;

            bool valida = true;
            valida &= validaMatricula();
            valida &= validaModel();
            valida &= validaMarca();

            btnSave.IsEnabled = valida;
            return valida;
        }

        private bool validaMarca()
        {
            bool ok = cboMarca.SelectedValue != null;
            mostrarCampAmbErrors(cboMarca, ok, "Marca obligatoria");
            return ok;
        }

        private bool validaModel()
        {
            bool ok = txbModel.Text.Length >= 2;
            mostrarCampAmbErrors(txbModel, ok, "Longitud mínima 2 caràcters");     

            return ok;
        }

        private bool validaMatricula()
        {
            
            string consonant =  "[WRTYPSDFGHJKLZXCVBNM]";
            String m = txbMatricula.Text.Trim();
            bool matriculaValida = 
                Regex.IsMatch(m, "^[0-9]{4,4}-"+consonant+"{3,3}$");
            string missatgeError = "Format esperat: 0000-YYY";
            // Si la matrícula és correcta, i és un cotxe nou, hem 
            // de validar que no sigui repetida.
            if (CURRENT_MODE == MODE.NOU && matriculaValida)
            {                
                foreach (Cotxe c in mCotxes)
                {
                    if (c.Matricula.Equals(m))
                    {
                        matriculaValida = false;
                        missatgeError = "Matricula repetida";
                        break;
                    }
                }
            }
            mostrarCampAmbErrors(txbMatricula, matriculaValida, missatgeError);
            return matriculaValida;
        }

        private void mostrarCampAmbErrors(Control control, bool valid, string missatgeError)
        {
            Color c = Colors.White;            
            if (!valid)
            {
                c = Colors.Red;
            }
            control.Background = new SolidColorBrush(c);

            //Busquem el ToolTìp associat al control si ja existia i l'amaguem
            ToolTip t = (ToolTip)control.GetValue(ToolTipService.ToolTipProperty);
            if (t != null)
            {
                t.IsOpen = false;
            }
            if(!valid) { 
                // Creem un nou ToolTip
                t = new ToolTip();
                t.PlacementTarget = control; // indiquem que es mostre sobre el control actual
                t.Placement = PlacementMode.Right; // n'indiquem també la posició
                t.HorizontalOffset = 10;
                t.VerticalOffset = 20;
                // Desem el ToolTip al control
                control.SetValue(ToolTipService.ToolTipProperty, t);
                t.Content =   missatgeError;
                t.IsOpen = true;
            }            
         }

        private void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            CURRENT_MODE = MODE.NOU;
        }

        private void btnEsborrar_Click(object sender, RoutedEventArgs e)
        {
            if(lsvCotxes.SelectedIndex != -1)
            {
                mCotxes.RemoveAt(lsvCotxes.SelectedIndex);
                CURRENT_MODE = MODE.BLOQUEJAT;
            }
        }
    }
}
