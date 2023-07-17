using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    public class Employee
    {
        
        public string Name;
        public string Dept;
        public string Tech;
        public string CName;
        public Employee(string name, string dept, string tech, string cname)
        {   
            
            Name = name;
            Dept = dept;
            Tech = tech;
            CName = cname;
        }
    }
    public class Program
    {
        public static void showEmployees()
        {
            //foreach (var i in Employees)
            //{
            //    Console.WriteLine("{0} {1} {2} {3} {4}", i.ID, i.Name, i.Dept, i.Tech, i.CName);
            //}
            try
            {
                string ConString = "data source=SHAVEZ; database=linq_db; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select * from Employee";
                    cmd.Connection = connection;
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    SqlDataReader sdr = cmd.ExecuteReader();
                    Console.WriteLine("Name Dept Tech Company");
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["id"] + ", " + sdr["name"] + ", " + sdr["department"] + ", " + sdr["technology"] + ", " + sdr["company"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }

        public static void addEmployee(string EmpId, string name, string dep, string tech, string cname)
        {
            try
            {
                string ConString = "data source=SHAVEZ; database=linq_db; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = $"INSERT INTO Employee VALUES ('{EmpId}','{name}', '{dep}', '{tech}', '{cname}')";
                    cmd.Connection = connection;
                    connection.Open();
                    // Executing the SQL query  
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("inserted successfully...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadLine();
        }

        public static void Main(string[] args)
        {
            var Employees = new List<Employee>{

            new Employee("shavez","IT","DotNet","AspireFox"),
            new Employee("sharad","Dev","Devops","Google"),
            new Employee("amit","IT","Cloud","Amazon"),
            new Employee("sahil","Sales","Shopify","Unknown"),
            new Employee("rehan","IT","Analyst","Google"),

          };


            // Print Employees Table
            Program.showEmployees();
            Console.WriteLine("---------------------------");


            while (true)
            {
                Console.WriteLine("Add : press a");
                Console.WriteLine("Update : press u");
                Console.WriteLine("Delete : press d");
                Console.WriteLine("Show CompanyName by Emp Id : press n");
                Console.WriteLine("Show Employees GroupBy Company : press s");
                Console.WriteLine("Exit : press e");
                string usrChoice = Console.ReadLine();
                if (usrChoice == "a")
                {
                    // add Employee
                    new Add();
                }
                else if (usrChoice == "u")
                {
                    // Update Row
                    new Update();
                }
                else if (usrChoice == "d")
                {
                    // Delete Row
                    new Delete();
                    Console.ReadLine();

                }
                else if (usrChoice == "n")
                {
                    // Compnay By Employee ID
                    new CName();
                }
                else if (usrChoice == "s")
                {
                    new Show();
                    Console.ReadLine();
                }
                else if (usrChoice == "e")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input");
                }
            }




        }
    }
}