using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20170928_ListBoxesIRadioButtons.Model
{
    class Pregunta
    {

        #region Propietats
        private int mNumero;

        public int Numero
        {
            get { return mNumero; }
            set { mNumero = value; }
        }
        private string mPregunta;

        public string TextPregunta
        {
            get { return mPregunta; }
            set { mPregunta = value; }
        }

        private List<string> mRespostes;

        public List<string> Respostes
        {
            get { return mRespostes; }
            set { mRespostes = value; }
        }

        private bool mEsMultireposta;

        public bool EsMultiresposta
        {
            get { return mEsMultireposta; }
            set { mEsMultireposta = value; }
        }

        private List<int> mRespostesCorrectes;

        public List<int> RespostesCorrectes
        {
            get { return mRespostesCorrectes; }
            set { mRespostesCorrectes = value; }
        }

        private List<int> mRespostesSeleccionades;

        public List<int> RespostesSeleccionades
        {
            get { return mRespostesSeleccionades; }
            set { mRespostesSeleccionades = value; }
        }

#endregion


        public Pregunta(
            int pNumero, 
            string pTextPregunta , 
            List<string> pRespostes,
            List<int> pRespostesCorrectes, 
            bool pEsMultiresposta )
        {
            Numero = pNumero;
            TextPregunta = pTextPregunta;
            Respostes = pRespostes;
            RespostesCorrectes = pRespostesCorrectes;
            EsMultiresposta = pEsMultiresposta;
        }

        public static List<Pregunta> GetPreguntes()
        {
            List<Pregunta> preguntes = new List<Pregunta>();
            Pregunta primera = new Pregunta(1,
                "De que color es el caballo blanco de Santiago",
                new List<string>() { "Negre", "Blanc", "Groc", "Verd" },
                new List<int>() { 1 },
                false
                );
            Pregunta segona = new Pregunta(2,
                "Selecciona dues poblacions de la província de Barcelona:",
                new List<string>() { "Barcelona", "Igualada", "Tarragona", "Tremp" },
                new List<int>() { 0,1 },
                true
                );
            Pregunta tercera = new Pregunta(3,
                "Tradueix 'inheritance': ",
                new List<string>() { "Inexistència", "Inoperancia", "Herència", "Cuscupiscència" },
                new List<int>() { 2 },
                false
                );
            preguntes.Add(primera);
            preguntes.Add(segona);
            preguntes.Add(tercera);
            return preguntes;

        }


    }
}
