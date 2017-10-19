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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace _20171019_ControlsPersonalitzats_1
{
    public sealed partial class NumericTextBox : UserControl
    {
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
    }
}
