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
    public sealed partial class EmpleatUI : UserControl
    {
        public EmpleatUI()
        {
            this.InitializeComponent();
        }


        
        public string EmpName
        {
            get { return (string)GetValue(EmpNameProperty); }
            set { SetValue(EmpNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EmpName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmpNameProperty =
            DependencyProperty.Register("EmpName", typeof(string), 
                typeof(EmpleatUI), new PropertyMetadata(""));



        public int EmpID
        {
            get { return (int)GetValue(EmpIDProperty); }
            set { SetValue(EmpIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EmpID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmpIDProperty =
            DependencyProperty.Register("EmpID", typeof(int), typeof(EmpleatUI), new PropertyMetadata(0));



        public int EmpDeptNo
        {
            get { return (int)GetValue(EmpDeptNoProperty); }
            set {SetValue(EmpDeptNoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EmpDeptNo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmpDeptNoProperty =
            DependencyProperty.Register("EmpDeptNo", typeof(int),
                typeof(EmpleatUI),
                new PropertyMetadata(-1));




        public BitmapImage Photo
        {
            get { return (BitmapImage)GetValue(PhotoProperty); }
            set { SetValue(PhotoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PhotoProperty =
            DependencyProperty.Register("Photo",
                typeof(BitmapImage), 
                typeof(EmpleatUI), 
                new PropertyMetadata(null));



        public List<string> Departaments
        {
            get { return (List<string>)GetValue(DepartamentsProperty); }
            set { SetValue(DepartamentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Departaments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DepartamentsProperty =
            DependencyProperty.Register("Departaments", typeof(List<string>),
                typeof(EmpleatUI),
                new PropertyMetadata(new List<string>()));




    }
}
