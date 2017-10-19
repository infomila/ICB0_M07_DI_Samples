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

namespace _20171019_Forms
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

        List<string> mNoms = new List<string>() { "Paco", "Maria", "Joan" };

        Page1 mPage1 = new Page1();
        Page2 mPage2 = new Page2();
        Stack<Page> mBackStack = new Stack<Page>();

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(typeof(Page1), mNoms);
            //mBackStack.Push((Page)frmPrincipal.Content);
            //frmPrincipal.Content = mPage1;
            

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(typeof(Page2),mNoms);
            //mBackStack.Push((Page)frmPrincipal.Content);
            //frmPrincipal.Content = mPage2;
            
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (mBackStack.Count > 0)
            {
                Page p = mBackStack.Pop();
                frmPrincipal.Content = p;
            }
            /*if (frmPrincipal.CanGoBack)
            {
                frmPrincipal.GoBack();
            }*/
        }
    }
}
