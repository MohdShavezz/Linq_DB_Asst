using HelloWorld;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CName
    {
        public CName()
        {

            Console.WriteLine("enter UserID Id to get the Company Name: ");
            string userIdforName = Console.ReadLine();
            Validation.checkId(userIdforName);

            //var comp = from i in Employees where i.id == userIdforName select i;
            //    foreach (var i in comp)
            //    {
            //        Console.WriteLine(i.CName);
            //    }
            //    Console.WriteLine("---------------------------");
            try
            {

                string ConString = "data source=SHAVEZ; database=linq_db; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = $"select company from Employee where id='{userIdforName}'";
                    cmd.Connection = connection;
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["company"]);
                        Console.ReadLine();
                        Console.WriteLine("-------------------");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }

        }
    }
}
