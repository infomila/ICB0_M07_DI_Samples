using _20171122_SQLite.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20171122_SQLite.db
{
    class DeptDB
    {

        public static List<Dept> GetAllDept( string numeroDept = null )
        {
            List<Dept> depts = new List<Dept>();
            //---------------------------------
            using (EmpresaContext context = new EmpresaContext())
            {
                using( DbConnection connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();
                    // crear la comanda SQL
                    using( DbCommand consulta = connexio.CreateCommand())
                    {


                        consulta.CommandText = "select * from dept";
                        if(numeroDept!=null)
                        {
                            consulta.CommandText += " where dept_no = :numDept";

                            UtilsDB.AddParameter(consulta, "numDept", numeroDept, DbType.Int32);

                        }
                        DbDataReader reader = consulta.ExecuteReader();
                        while(reader.Read())
                        {
                            int numero =        reader.GetInt32( reader.GetOrdinal("DEPT_NO"));
                            string  nom =       reader.GetString(reader.GetOrdinal("DNOM"));
                            string localitat =  reader.GetString(reader.GetOrdinal("LOC"));

                            Dept d = new Dept(numero, nom, localitat);
                            depts.Add(d);
                        }
                    }                    
                }
            }
            
             //---------------------------------
                return depts;
        }

    }
}
