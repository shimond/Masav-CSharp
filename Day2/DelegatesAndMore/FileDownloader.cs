using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesAndMore
{
    public class FileDownloadStatusEventArgs : EventArgs
    {
        public int Percentage { get; }

        public FileDownloadStatusEventArgs(int percentage)
        {
            this.Percentage = percentage;
        }
    }

    public class FileDownloader
    {
        public int Id { get; set; }
        public event EventHandler<FileDownloadStatusEventArgs> ProgressCallback;

        protected void OnProgressChanged(int percentage)
        {
            ProgressCallback?.Invoke(this, new  FileDownloadStatusEventArgs(percentage));
        }


        //public event ProgressChangedHandler progressCallbackTEst
        //{
        //    add { }
        //    remove { }
        //}

        //public void AddProgressChangedHandler(ProgressChangedHandler callback)
        //{
        //    progressCallback += callback;
        //}
        //public void RemoveProgressChangedHandler(ProgressChangedHandler callback)
        //{
        //    progressCallback -= callback;
        //}   
        public byte[] DownloadFile(string url)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                //progressCallback.Invoke(i + 1);
                //progressCallback?.Invoke(i + 1);
                OnProgressChanged(i + 1);
            }

            return new byte[12] { 2, 3, 4, 24, 5, 1, 3, 3, 3, 1, 2, 2 };

        }
    }


    public class StrongFileDownloader : FileDownloader
    {
        public StrongFileDownloader()
        {
            OnProgressChanged(20);
        }

    }
}
