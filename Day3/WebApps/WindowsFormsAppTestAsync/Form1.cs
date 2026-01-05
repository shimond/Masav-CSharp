

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            var task = Task.Factory.StartNew<int>(() =>
            {
                // Simulate download
                if (url.Contains("walla"))
                {
                    Thread.Sleep(5000);
                    throw new Exception("Walla walla");
                }
                return rnd.Next(10000, 1000000); 
            });

            return task;
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Text = "Start";
            await DownloadAll();
            this.Text = "Completed";
        }
        private async Task DownloadAll()
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
                    var result = await DownloadUrl(url);
                    sum += result;
                    listBox1.Items.Add("Finished " + url);
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
