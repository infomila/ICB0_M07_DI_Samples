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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace _20171025_ControlsPersonalitzats_2
{
    public sealed partial class EmpleatObjUI : UserControl
    {
        public EmpleatObjUI()
        {
            this.InitializeComponent();
        }


        public Empleat Emp
        {
            get { return (Empleat)GetValue(EmpProperty); }
            set { SetValue(EmpProperty, value);

                this.DataContext = value;
            }
        }

        // Using a DependencyProperty as the backing store for Emp.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmpProperty =
            DependencyProperty.Register("Emp", typeof(Empleat), 
                typeof(EmpleatObjUI), new PropertyMetadata(0));
        /*
        public List<string> Departaments
        {
            get { return (List<string>)GetValue(DepartamentsProperty); }
            set { SetValue(DepartamentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Departaments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DepartamentsProperty =
            DependencyProperty.Register("Departaments", typeof(List<string>),
                typeof(EmpleatUI),
                new PropertyMetadata(new List<string>() { "a" }));
                */



    }
}
