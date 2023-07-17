using HelloWorld;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Update
    {
        public Update()
        {
            Console.WriteLine("enter UserID to Update: ");
            string userID = Console.ReadLine();
            Validation.checkId(userID);

            Console.WriteLine("enter Name : ");
            string userName = Console.ReadLine();
            userName = Validation.checkName(userName);
            if (userName == "quit")
            {
                return;
            }

            Console.WriteLine("enter Department : ");
            string userDept = Console.ReadLine();
            userDept = Validation.checkName(userDept);
            if (userName == "quit")
            {
                return;
            }

            Console.WriteLine("enter Technology : ");
            string userTech = Console.ReadLine();
            userTech = Validation.checkNullorEmpty(userTech);
            if (userName == "quit")
            {
                return;
            }

            Console.WriteLine("enter Company Name : ");
            string userComp = Console.ReadLine();
            userComp = Validation.checkNullorEmpty(userComp);
            if (userName == "quit")
            {
                return;
            }
            //foreach (var i in Employees.Where(emp => emp.ID == userID))
            //{
            //    i.Name = userName;
            //    i.Dept = userDept;
            //    i.Tech = userTech;
            //    i.CName = userComp;
            //}
            try
            {
                string ConString = "data source=SHAVEZ; database=linq_db; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand($"UPDATE Employee SET  name='{userName}',department='{userDept}',technology='{userTech}',company='{userComp}' WHERE id='{userID}'", connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Updated sucessfully..");
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
