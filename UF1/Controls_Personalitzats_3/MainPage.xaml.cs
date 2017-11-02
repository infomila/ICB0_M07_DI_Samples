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

namespace Controls_Personalitzats_3
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int rotacio = int.Parse(((Button)sender).Tag.ToString());

            ast.Angle += 6*rotacio;
            //ast.Angle = ast.Angle + rotacio;

            /*
            int rotacio = 0;
            if(sender== btnDreta)
            {
                rotacio = 1;
            } else
            {
                rotacio = -1;
            }
            */

        }

        private void btnFire_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            int avanc = int.Parse(((Button)sender).Tag.ToString());

            ast.MoveForward(avanc);
        }

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch(e.Key)
            {
                case Windows.System.VirtualKey.Right:
                    ast.Angle += 6;
                    break;
                case Windows.System.VirtualKey.Left:
                    ast.Angle -= 6;
                    break;
                case Windows.System.VirtualKey.Up:
                    ast.MoveForward(1);break;
                case Windows.System.VirtualKey.Down:
                    ast.MoveForward(-1); break;

                case Windows.System.VirtualKey.Control:
                    ast.Fire(); break;

            }
        }
    }
}
