using HelloWorld;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Delete
    {
        public Delete()
        {

            Console.WriteLine("enter UserID to Delete: ");
            string userIdDel = Console.ReadLine();
            Validation.checkId( userIdDel);

            try
            {
                string ConString = "data source=SHAVEZ; database=linq_db; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand($"DELETE from Employee WHERE id='{userIdDel}'", connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleted sucessfully..");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }

            Console.WriteLine("---------------------------");
            Program.showEmployees();

        }
    }
}
