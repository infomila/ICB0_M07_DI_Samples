using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
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

namespace ExempleMenuDialeg
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


        private async void MenuFlyoutItemAbout_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog locationPromptDialog = new ContentDialog
            {
                Title = "IES Milà Enterprises",
                Content = "Fucking minds since 1990",
                //CloseButtonText = "Block",
                PrimaryButtonText = "Ok",
            };


            ContentDialogResult result = await locationPromptDialog.ShowAsync();
        }


        private async void MenuFlyoutItemQuit_Click(object sender, RoutedEventArgs e)
        {

            /*StackPanel sp = new StackPanel();
            TextBlock tb = new TextBlock()
            {
                Text = "HOLA"
            };
            Button btnTrampa = new Button()
            {
                Content = "Trampa"
            };
            sp.Children.Add(tb);
            sp.Children.Add(btnTrampa);*/

            ContentDialog locationPromptDialog = new ContentDialog
            {
                Title = "IES Milà Enterprises",
                Content = "Vols sortir",
                PrimaryButtonText = "Ok",
                SecondaryButtonText = "Cancel",
            };
            ContentDialogResult result = await locationPromptDialog.ShowAsync();
            if(result==ContentDialogResult.Primary)
            {
                Application.Current.Exit(); // Fugir d'aquí !!
            }
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            LlistaParaules lp = new LlistaParaules();
            lp.Paraules = new List<string>() { "First", "Second", "Third", "Fourth", "Fifth" };
            ContentDialogResult r = await lp.ShowAsync();
            if(r==ContentDialogResult.Primary) //OK
            {
                txbParaula.Text =  lp.ParaulaSeleccionada;
            }
        }

        private void txbParaula_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txbParaula.Text.Length>5)
            {
                FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
            }
        }

  
        private void txbParaula_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
            e.Handled = true;
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            OutputClipboardText();
        }

        async void OutputClipboardText()
        {
            DataPackageView dataPackageView = Clipboard.GetContent();
            if (dataPackageView.Contains(StandardDataFormats.Text))
            {
                string text = await dataPackageView.GetTextAsync();
                txbParaula.Text =   text;
            }
        }

        private void txbOther_ContextMenuOpening(object sender, TextChangedEventArgs e)
        {
            LlistaParaules lp = new LlistaParaules();
            List < string > paraules = new List<string>() { "First", "Second", "Third", "Fourth", "Fifth" };
            paraules = paraules.Where(i => i.StartsWith(txbOther.Text)).ToList();
            lsvInner.ItemsSource = paraules;
            
            MyPopup.IsOpen = paraules.Count > 0 && (paraules.Count==1 || !paraules[0].Equals(txbOther.Text));
            txbOther.Focus(FocusState.Pointer);
        }
 
        private void lsvInner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lsvInner.SelectedValue!=null)
            {
                txbOther.Text = lsvInner.SelectedValue.ToString();                
               MyPopup.IsOpen = false;
                txbOther.Focus(FocusState.Pointer);
            }
        }
    }
}
