using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace _20171019_ControlsPersonalitzats_1
{
    public sealed partial class NumericTextBox : UserControl
    {

        public event EventHandler ValueChanged;

        public NumericTextBox()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txbNum.Text = "0";
        }

        public int Value
        {
            get {
                if (txbNum.Text.Length == 0) return 0;
                return int.Parse(txbNum.Text); }
            set {
                    if (value >= MinValue && value < MaxValue)
                    {
                        txbNum.Text = "" + value;
                        ValueChanged?.Invoke(this, new EventArgs());
                    }
                }
        }

        private int mMax = 100;

        public int MaxValue
        {
            get { return mMax; }
            set {
                if (value > Value)
                {
                    mMax = value;
                }
                }
        }

        private int mMin=0;

        public int MinValue
        {
            get { return mMin; }
            set {
                if (value <= Value)
                {
                    mMin = value;
                }
            }
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            if (Value < MaxValue - 1) Value++;
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            if (Value > MinValue) Value--;
        }

        private void txbNum_KeyDown(object sender, KeyRoutedEventArgs e)
        {

   
            if (!e.Key.ToString().StartsWith("Number"))
            {
                e.Handled = true; // tecla interceptada
            } else
            {
                // la tecla és numèrica.....però no sabem si el número que sortirà
                // és vàlid....
                char numero = e.Key.ToString().Last();
                string t = txbNum.Text;
                int posCursor = txbNum.SelectionStart+txbNum.SelectionLength;
                string numeroAmbCanvi = t.Substring(0, txbNum.SelectionStart) + 
                                numero + t.Substring(posCursor);
                int n;
                bool numeroValid=  !Int32.TryParse(numeroAmbCanvi, out n);

                e.Handled = !numeroValid || n >= MaxValue || n < MinValue;            

            }
        }

        private void txbNum_Paste(object sender, TextControlPasteEventArgs e)
        {
            
            /*bool esNumero = false;
            DataPackageView dataPackageView = Clipboard.GetContent();
            if (dataPackageView.Contains(StandardDataFormats.Text))
            {
                string text =  dataPackageView.GetTextAsync().GetResults().;
                // To output the text from this example, you need a TextBlock control
                int numero;
                esNumero = Int32.TryParse(text, out numero);
            }*/

            e.Handled = true;// !esNumero;
        }

        private void txbNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValueChanged?.Invoke(this, new EventArgs());
        }
    }
}
