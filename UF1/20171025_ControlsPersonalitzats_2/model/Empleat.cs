using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml.Media.Imaging;

namespace _20171025_ControlsPersonalitzats_2
{
    public class Empleat
    {
        // SINGLETON 
        static List<Empleat> emp;

        public static List<string> GetDepartaments()
        {
            return new List<string>() {"INFORMATICA", "VENDES", "COMPRES"};
        }


        public static List<Empleat> GetEmpleats()
        {
            if (emp == null)
            {
                emp = new List<Empleat>();
                emp.Add(new Empleat(1, "GranBarrufet", 0, 
                    new BitmapImage(new Uri("ms-appx:///Assets/GranBarrufet.jpg"))));
                emp.Add(new Empleat(2, "Azrael", 1,
                    new BitmapImage(new Uri("ms-appx:///Assets/Azrael.jpg"))));
                emp.Add(new Empleat(3, "Gargamel", 2,
                    new BitmapImage(new Uri("ms-appx:///Assets/Gargamel.jpg"))));
            }
            return emp;
        }

        

        public Empleat( int pId, string pNom, int pDeptId, BitmapImage pFoto)
        {
            ID = pId;
            Nom = pNom;
            NumDepartament = pDeptId;
            Foto = pFoto;           
        }


        public List<string> Departaments
        {
            get { return Empleat.GetDepartaments(); }
        }
        private string mNom;

        public string Nom
        {
            get { return mNom; }
            set { mNom = value; }
        }

        private int mId;

        public int ID
        {
            get { return mId; }
            set {
                if (value < 0) throw new Exception("ID negatiu no permés");
                mId = value; }
        }

        private int mNumDept;

        public int NumDepartament
        {
            get { return mNumDept; }
            set { mNumDept = value; }
        }

        private BitmapImage mFoto;

        public BitmapImage Foto
        {
            get { return mFoto; }
            set { mFoto = value; }
        }



    }
}
