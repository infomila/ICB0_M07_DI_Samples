﻿using System;
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

namespace _20171025_ControlsPersonalitzats_2
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Empleat emp = Empleat.GetEmpleats().Last();

            empPrimer.Photo =           emp.Foto;
            empPrimer.EmpName =         emp.Nom;
            empPrimer.EmpID =           emp.ID;
            empPrimer.Departaments = Empleat.GetDepartaments();
            empPrimer.EmpDeptNo =       emp.NumDepartament;
            
            //---------------------------------------------

            foreach (Empleat ep in Empleat.GetEmpleats())
            {
                /*
                EmpleatUI eUI = new EmpleatUI();
                eUI.Photo =         ep.Foto;
                eUI.EmpName =       ep.Nom;
                eUI.EmpID =         ep.ID;                
                eUI.Departaments =  Empleat.GetDepartaments();
                eUI.EmpDeptNo = ep.NumDepartament;
                grdEmpleats.Children.Add(eUI);
                */

                EmpleatObjUI eo = new EmpleatObjUI();
                //eo.Departaments = Empleat.GetDepartaments();
                eo.Emp = ep;
                grdEmpleats.Children.Add(eo);
            }
            Empleat.GetEmpleats()[0].Nom = "Txumari";
        }
    }
}
