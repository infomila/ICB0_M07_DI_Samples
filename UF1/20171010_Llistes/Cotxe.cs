using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace _20171010_Llistes
{
    class Cotxe
    {

        public static ObservableCollection<Cotxe>
            getCotxes()
        {
            ObservableCollection<Cotxe> llistaCotxes =
                new ObservableCollection<Cotxe>();

            llistaCotxes.Add(new Cotxe("1232-JLK", "2008", "Peugeot", Colors.Aquamarine));
            llistaCotxes.Add(new Cotxe("2345-PTR", "Ibiza", "Seat", Colors.Red));
            llistaCotxes.Add(new Cotxe("8234-PTR", "Leon", "Seat", Colors.Green));
            llistaCotxes.Add(new Cotxe("6523-YYY", "Meriva", "Opel", Colors.Blue));

            return llistaCotxes;
        }

        //----------------------------------------------------
        public Cotxe(String pMatricula, 
            String pModel, 
            String pMarca, 
            Color pColor)
        {
            Matricula = pMatricula;
            Model = pModel;
            Marca = pMarca;
            ColorCotxe = pColor;
        }
        //----------------------------------------------------
        #region Propietats

        //----------------------------------------
        private String mMatricula;

        public String Matricula
        {
            get { return mMatricula; }
            set { mMatricula = value; }
        }
        //----------------------------------------
        private String mMarca;

        public String Marca
        {
            get { return mMarca; }
            set { mMarca = value; }
        }
        //----------------------------------------
        private String mModel;

        public String Model
        {
            get { return mModel; }
            set { mModel = value; }
        }
        //----------------------------------------

        private Color mColor;

        public Color ColorCotxe
        {
            get { return mColor; }
            set { mColor = value; }
        }







        #endregion
    }
}
