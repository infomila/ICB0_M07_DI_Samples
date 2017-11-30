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

        public static List<Dept> GetAllDept( 
            string numeroDept = "" , 
            string nomLocalitat = "")
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


                        int numDeptInteger;
                        bool conversioCorrecta= Int32.TryParse(numeroDept, out numDeptInteger);
                        if (!conversioCorrecta) numDeptInteger = -1;

                        consulta.CommandText = @"select * from dept  
                                                    where (:p_numeroDept=-1 or dept_no = :p_numeroDept) and
                                                          (:p_nomLocalitat='' or loc like :p_nomLocalitat) ";


                        UtilsDB.AddParameter(consulta, "p_numeroDept",      numDeptInteger, DbType.Int32);
                        UtilsDB.AddParameter(consulta, "p_nomLocalitat",  nomLocalitat+"%", DbType.String);




                        /*
                        if (numeroDept!=null)
                        {
                            consulta.CommandText += " where dept_no = :numDept";

                            UtilsDB.AddParameter(consulta, "numDept", numeroDept, DbType.Int32);
                            
                        }*/
                        DbDataReader reader = consulta.ExecuteReader();
                        while(reader.Read())
                        {
                            //int numero =        reader.GetInt32( reader.GetOrdinal("DEPT_NO"));
                            //string  nom =       reader.GetString(reader.GetOrdinal("DNOM"));
                            //string localitat =  reader.GetString(reader.GetOrdinal("LOC"));
                            //Dept d = new Dept(numero, nom, localitat);

                            Dictionary<string, object> fila = UtilsDB.getFila(reader);
                            Dept d = new Dept( (int)((long)fila["DEPT_NO"]), (string)fila["DNOM"], (string)fila["LOC"]);

                            
                            depts.Add(d);
                        }
                    }                    
                }
            }
            
             //---------------------------------
                return depts;
        }

        internal static long CountEmp(int numero)
        {
            using (EmpresaContext context = new EmpresaContext())
            {
                using (DbConnection connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();
                    // crear la comanda SQL
                    using (DbCommand consulta = connexio.CreateCommand())
                    {


                        consulta.CommandText = @"select count(*) from emp  
                                                    where   dept_no = :p_numeroDept";


                        UtilsDB.AddParameter(consulta, "p_numeroDept", numero, DbType.Int32);


                        return ((long)consulta.ExecuteScalar());
                    }
                }
            }
        }

        internal static void RemoveDept(int numeroDept)
        {
            using (EmpresaContext context = new EmpresaContext())
            {
                using (DbConnection connexio = context.Database.GetDbConnection())
                {
                    connexio.Open();

                    DbTransaction trans = connexio.BeginTransaction();
                    // crear la comanda SQL
                    using (DbCommand consulta = connexio.CreateCommand())
                    {
                        consulta.Transaction = trans;

                        consulta.CommandText = "delete from dept where dept_no =:p_numeroDept";
                        UtilsDB.AddParameter(consulta, "p_numeroDept", numeroDept, DbType.Int32);

                        try
                        {
                            int numRows = consulta.ExecuteNonQuery();
                            if (numRows > 1)
                            {
                                trans.Rollback();

                            }
                            else
                            {
                                trans.Commit();
                            }

                        }catch(Exception e)
                        {
                            trans.Rollback();
                        }


                    }
                }
            }
        }
    }
}
