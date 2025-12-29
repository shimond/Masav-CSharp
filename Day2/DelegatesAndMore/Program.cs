using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesAndMore
{
    public delegate void ProgressChangedHandler<T>(T percentage);


    public class Program
    {
        static void Main(string[] args)
        {
            Search search = new Search()
            {
                Pattern = "*.txt",
                Root = "C:\\"
            };

            search.FileFound += Search_FileFound;
            search.DoSearch();
        }

        private static void Search_FileFound(object sender, FiledFoundEventArgs e)
        {
            Console.WriteLine($"Name : {e.FileName} Parent {e.Directory} length {e.Length/1024} KB");
        }

        static void UpdateProgress(int percentage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Download progress: {percentage}%");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void UpdateProgress2(int percentage)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Download progress: {percentage}%");
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
