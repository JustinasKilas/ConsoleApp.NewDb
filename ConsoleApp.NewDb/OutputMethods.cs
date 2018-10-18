using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.NewDb {
    class OutputMethods {
        public static void PrintList(List<User> data, string sortedBy = "") {
            Console.WriteLine("List{0}:", sortedBy != null ? " sorted by " + sortedBy : "");
            foreach (var user in data) {
                Console.WriteLine("{0}. {1} {2} {3}", user.Id, user.Name, user.LastName, user.Phone);
            }
        }

        public static void WriteToHTML(List<User> data, string sortedBy = null) {
            string output = $"<!DOCTYPE html>\n<html>\n<body>\n<h1>Sorted List{(sortedBy!=null?" by " + sortedBy:"")}:</ h1 >\n";
            foreach (var user in data) {
                output += $"<h3>{user.Id}. {user.Name}\t{user.LastName}\t{user.Phone}</h3>\n";
            }
            output += "</body>\n</html>";
           // Console.WriteLine(output);

            System.IO.File.WriteAllText($"./{sortedBy}List.html", output);
        }

    }


}
