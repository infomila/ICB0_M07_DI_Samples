using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Controls_Personalitzats_3
{
    public sealed partial class Asteroid : UserControl
    {
        public Asteroid()
        {
            this.InitializeComponent();
        }

        private const double D= 10;
        public void MoveForward(int direccio)
        {
            Y -= (int)(D * Math.Cos(Angle* Math.PI / 180))* direccio;
            X += (int)(D * Math.Sin(Angle * Math.PI / 180))* direccio;
        }


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

        internal void Fire()
        {

            /*
             * <Rectangle Width="5" Height="20" Canvas.Left="22" Canvas.Top="0" Fill="Yellow" Stroke="Black">
                <Rectangle.RenderTransform>
                    <CompositeTransform Rotation="45" 
                                        CenterX="2"
                                        CenterY="30"/>
                </Rectangle.RenderTransform>
            </Rectangle>
             **/

            Rectangle r = new Rectangle();
            r.Width = 5;
            r.Height = 20;
            r.Fill = new SolidColorBrush(Colors.Yellow);
            r.Stroke = new SolidColorBrush(Colors.Black);
            CompositeTransform t = new CompositeTransform();
            t.Rotation = Angle;
            t.CenterX = 2;
            t.CenterY = 30;
            r.RenderTransform = t;
            
            r.SetValue(Canvas.TopProperty, 0 + Y);
            r.SetValue(Canvas.LeftProperty, 22 + X);
            cnvAsteroids.Children.Add(r);
            //----------------------------------------------------------------------

        }
    }
}
