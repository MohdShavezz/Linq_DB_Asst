using HelloWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Validation
    {
        public static string checkName( string name)
        {
            string regexPattern = @"^[A-Za-z]{3,}$";
            Regex regex = new Regex(regexPattern);
            while (!regex.IsMatch(name))
            {
                if (name=="quit")
                {
                    return name;
                }
                Console.WriteLine("enter valid data!!! or to go back write 'quit' ");
                name = Console.ReadLine();
            }
            return name;
        }
        public static string checkNullorEmpty(string name)
        {
            while (string.IsNullOrWhiteSpace(name))
            {
                if (name == "quit")
                {
                    return name;
                }
                Console.WriteLine("enter valid data!!! or to go back write 'quit' ");
                name = Console.ReadLine();
            }
            return name;
        }

        public static string checkId(string userIDUp)
        {

            //while (!Employees.Any(e => e.ID == userIDUp))
            //{
            //    if (userIDUp == "quit")
            //    {
            //        return userIDUp;
            //    }
            //    Console.WriteLine("enter valid Id... or to go back write 'quit' ");
            //    userIDUp = Console.ReadLine();
            //}
            return userIDUp;
        }


    }
}
