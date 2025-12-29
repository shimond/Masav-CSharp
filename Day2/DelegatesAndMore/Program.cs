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

            FileSystemWatcher fs = new FileSystemWatcher("c:\\");
            fs.IncludeSubdirectories = true;


            Console.ForegroundColor = ConsoleColor.White;

            FileDownloader downloader = new FileDownloader();
            //downloader.progressCallback += UpdateProgress;
            //downloader.progressCallback += UpdateProgress2 ;
            //downloader.progressCallback = UpdateProgress2;

            //downloader.progressCallback(80);
            var result = downloader.DownloadFile("http://example.com/file");
            //Console.WriteLine("FINISHED: " + result.Length);
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
