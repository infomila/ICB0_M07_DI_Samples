using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace _20171010_Llistes
{
    class Cotxe : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }


        public static List<String> getMarques()
        {
            //return getCotxes().Select(element => element.Marca).Distinct().ToList<string>();

            List<String> marques = new List<String>();
            foreach (Cotxe c in getCotxes())
            {
                if (!marques.Contains(c.Marca))
                {
                    marques.Add(c.Marca);
                }
            }
            return marques;
        }

        public static ObservableCollection<Cotxe>
            getCotxes()
        {
            ItemsChangeObservableCollection<Cotxe> llistaCotxes =
                new ItemsChangeObservableCollection<Cotxe>();
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
            set {
                mMatricula = value;
                NotifyPropertyChanged("Matricula");
            }
        }
        //----------------------------------------
        private String mMarca;

        public String Marca
        {
            get { return mMarca; }
            set {
                mMarca = value;
                NotifyPropertyChanged("Marca");
            }
        }
        //----------------------------------------
        private String mModel;

        public String Model
        {
            get { return mModel; }
            set {
                mModel = value;
                NotifyPropertyChanged("Model");
            }
        }
        //----------------------------------------

        private Color mColor;

        public Color ColorCotxe
        {
            get { return mColor; }
            set {
                mColor = value;
                NotifyPropertyChanged("ColorCotxe");
            }
        }
        //----------------------------------------
        public Brush Pinzell
        {
            get { return new SolidColorBrush(mColor); }
        }


        public override string ToString()
        {
            return "M:" + Matricula + " , marca:" + Marca + ", model:" + Model;
        }


        public String RutaImatgeMarca
        {
            get { return "Assets/" + Marca + ".png"; }
        }

        #endregion
    }
}
