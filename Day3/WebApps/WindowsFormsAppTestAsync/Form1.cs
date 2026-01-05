using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppTestAsync
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }


        public Task<int> DownloadUrl(string url)
        {
            var task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                if (url.Contains("walla"))
                {
                    throw new Exception("Walla walla");
                }
                var res = rnd.Next(10000, 1000000);
                return res;
            });
            return task;
        }
        //public void DownloadUrl(string url, Action<int> onSuccess, Action<Exception> onFailed)
        //{
        //    new Thread(() => {
        //        Thread.Sleep(5000);
        //        if (url.Contains("walla"))
        //        {
        //            throw new Exception("Walla walla");
        //        }
        //        var res = rnd.Next(10000, 1000000);

        //    }).Start();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            var urls = new List<string>();
            urls.Add("http://mako.co.il");
            urls.Add("http://walla.co.il");
            urls.Add("http://ynet.co.il");
            foreach (var url in urls)
            {
                try
                {
                    listBox1.Items.Add("Starting " + url);
                    var result = DownloadUrl(url).ContinueWith(task =>
                    {
                        sum += task.Result; ;
                        listBox1.BeginInvoke(new Action(() =>
                        {
                            listBox1.Items.Add("Finished " + url);
                        }));
                    });


                }
                catch (Exception ex)
                {
                    listBox1.Items.Add("Error downloading " + url + " : " + ex.Message);
                }
            }

            listBox1.Items.Add("Total bytes downloaded: " + sum);
        }
    }
}
