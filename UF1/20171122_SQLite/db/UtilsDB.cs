using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20171122_SQLite.db
{
    class UtilsDB
    {

        public static void AddParameter( 
            DbCommand consulta, 
            string nom, 
            object valor,
            System.Data.DbType tipus)
        {
            DbParameter param = consulta.CreateParameter();
            param.DbType = tipus;
            param.Value = valor;
            param.ParameterName = nom;
            consulta.Parameters.Add(param);
        }

        internal static Dictionary<string, object> getFila(DbDataReader reader)
        {
            Dictionary<string, object> fila = new Dictionary<string, object>();
            for(int i=0;i< reader.FieldCount;i++)
            {
                object valor = reader.GetValue(i);
                string nomColumna = reader.GetName(i);
                fila[nomColumna] = valor;
            }

            return fila;
        }
    }
}
