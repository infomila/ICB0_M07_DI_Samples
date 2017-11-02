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

namespace Controls_Personalitzats_3
{
    public sealed partial class Asteroid : UserControl
    {
        public Asteroid()
        {
            this.InitializeComponent();
        }




        public int Forward
        {
            get { return (int)GetValue(ForwardProperty); }
            set { SetValue(ForwardProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Forward.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForwardProperty =
            DependencyProperty.Register("Forward", typeof(int), typeof(Asteroid), new PropertyMetadata(0));




        public int Y
        {
            get { return (int)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(int), typeof(Asteroid), new PropertyMetadata(0));



        public int X
        {
            get { return (int)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        // Using a DependencyProperty as the backing store for X.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(int), typeof(Asteroid), new PropertyMetadata(0));




        public int Angle
        {
            get { return (int)GetValue(AngleProperty); }

            set {
                SetValue(AngleProperty, value);

                CompositeTransform t = (CompositeTransform)plyNau.RenderTransform;
                t.Rotation = value;
            }
        }

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", 
                typeof(int), 
                typeof(Asteroid), 
                new PropertyMetadata(0));



    }
}
