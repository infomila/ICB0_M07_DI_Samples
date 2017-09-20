using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
   

    public class Persona
    {
        // Atributs PRIVATS !!!!
        private char mLletraNIF;
        private DateTime mDataNaixement;
        private string mNom;
        private int mNumeroNIF;

        // ----------------- Propietats que desen el seu valor en els
        // ----------------- seus atributs respectius
        public int NumeroNIF
        {
            get { return mNumeroNIF; }
            set { mNumeroNIF = value; }
        }
        public char LletraNIF
        {
            get { return mLletraNIF; }
        }
        public string Nom
        {
            get { return mNom; }
            set { if(value==null || value.Trim().Length < 2)
                {
                    throw new Exception("nom invalid");
                }
                mNom = value;
            }
        }
        public DateTime DataNaixement
        {
            get { return mDataNaixement; }
            set
            {
                if (value == null || mDataNaixement > DateTime.Now)
                {
                    throw new Exception("data invalida");
                }
                mDataNaixement = value;
            }
        }


        public Persona()
        {
        }

        public Persona(string pNom, int pNumeroNIF, char pLletraNIF, DateTime pDataNaix)
        {
            mNom = pNom;
            mNumeroNIF = pNumeroNIF;
            mLletraNIF = pLletraNIF;
            mNom = pNom;
            mDataNaixement = pDataNaix;
        }

        public static void test() {
            Persona p = new Persona("Paco", 12345678,'C', DateTime.Now.AddYears(-10));
            p.mNom = "Joan";
            string nom = p.mNom;
            Persona p1 = new Persona("Paco", 12345678, 'C', new DateTime(1990,12,31));
        }
    }
}
