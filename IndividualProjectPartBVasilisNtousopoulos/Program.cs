using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using IndividualProjectPartBVasilisNtousopoulos.Business_Logic;


namespace IndividualProjectPartBVasilisNtousopoulos
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            cputils utility = new cputils();
            string selection="y";
            while (selection == "y")
            {
                SelectAll(utility.Stringselector());

                Console.Write("Press y to see another list: \t");
                selection = Console.ReadLine().ToLower();
            }
            
            
           
            
        }
        private static void SelectAll(string sql)
        {
            SqlConnection conn = new SqlConnection("Server =.; Database = Vasilis_Ntousopoulos_Individual_PartB; Trusted_Connection = True;");
            SqlDataReader rdr = null;





            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            Console.Write($"{rdr.GetName(i),-15}:{rdr[i]}\n");

                        }
                    }

                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
            }
        }
        
    }
}
