using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.NewDb {
    class Program {

        static void Main(string[] args) {

            AddData();

            List<User> data = GetSortedBy("Name");
            List<User> data2 = GetSortedBy("LastName");
            List<User> data3 = GetSortedBy("Phone");

           // OutputMethods.PrintList(data, "Name");
            OutputMethods.WriteToHTML(data, "Name");

           // OutputMethods.PrintList(data2, "LastName");
            OutputMethods.WriteToHTML(data2, "LastName");

            //OutputMethods.PrintList(data3, "Phone");
            OutputMethods.WriteToHTML(data3, "Phone");

            Console.Read();
        }

        
        private static void AddData() {
            using (var db = new UserContext()) {
                db.Users.Add(new User { Name = "Arnas", LastName = "nasfkl", Phone = "31853" });
                db.Users.Add(new User { Name = "Domas", LastName = "asdf", Phone = "183134" });
                db.Users.Add(new User { Name = "Rokas", LastName = "sfghss", Phone = "1381" });
                db.Users.Add(new User { Name = "Pranas", LastName = "sgf", Phone = "12387" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
            }
        }

       

        private static List<User> GetSortedBy(string v, bool desc = false) {
            string query = $"Select * from Users Order by {v} {(desc?"desc":"")}" ;
           // Console.WriteLine(query);
            using (var context = new UserContext()) {
                return context.Users
                    .FromSql(query)
                    .ToList();
            }
        }

       
    }
}