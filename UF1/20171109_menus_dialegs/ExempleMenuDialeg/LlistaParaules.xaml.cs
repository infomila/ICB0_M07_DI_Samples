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

// La plantilla de elemento del cuadro de diálogo de contenido está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace ExempleMenuDialeg
{
    public sealed partial class LlistaParaules : ContentDialog
    {
        public LlistaParaules()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }



        public List<string> Paraules
        {
            get { return (List<string>)GetValue(ParaulesProperty); }
            set
            {
                SetValue(ParaulesProperty, value);
                lsvParaules.ItemsSource = value;
            }
        }

        // Using a DependencyProperty as the backing store for Paraules.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ParaulesProperty =
            DependencyProperty.Register("Paraules", 
                typeof(List<string>), 
                typeof(LlistaParaules), 
                new PropertyMetadata(new List<string>()));


        public string ParaulaSeleccionada {
            get
            {
                return (string)lsvParaules.SelectedValue;
            }
        }

    }
}
