using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _20171122_SQLite.model
{
    class Dept: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /*
         CREATE TABLE DEPT (
             DEPT_NO  NUMERIC(2) CONSTRAINT DEPT_PK PRIMARY KEY  CONSTRAINT DEPT_CK_COD_POSITIU CHECK (DEPT_NO > 0),
             DNOM     VARCHAR(14) CONSTRAINT DEPT_NN_DNOM NOT NULL     CONSTRAINT DEPT_UN_DNOM UNIQUE,
             LOC      VARCHAR(14) ) ;
         * */
        public Dept( int pNumero, string pNom, string pLocalitat)
        {
            Numero = pNumero;
            Nom = pNom;
            Localitat = pLocalitat;
        }
   
        #region properties

        private int mNumero;

        public int Numero
        {
            get { return mNumero; }
            set {
                mNumero = value;
                OnPropertyChanged(); 
            }
        }

        private string mNom;

        public string Nom
        {
            get { return mNom; }
            set { mNom = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Numero"));
                OnPropertyChanged();
            }
        }

        private string mLocalitat;


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string Localitat
        {
            get { return mLocalitat; }
            set { mLocalitat = value;
                OnPropertyChanged();
            }
        }

        #endregion


        public override string ToString()
        {
            return $"NUM: {Numero}, NOM: {Nom}, Localitat: {Localitat}";
        }
    }
}
