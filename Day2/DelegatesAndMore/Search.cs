using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndMore
{
    public class Search
    {
        public event  EventHandler<FiledFoundEventArgs> FileFound;

        protected void OnFileFound(string directory, string fileName, long length)
        {
            FileFound?.Invoke(this, new FiledFoundEventArgs(fileName, directory, length));
        }

        public string Root { get; set; }
        public string Pattern { get; set; }

        public void DoSearch()
        {
            SearchItems(Root, Pattern);
        }

        private void SearchItems(string path , string pattern)
        {
            var directory = new System.IO.DirectoryInfo(path);

            try
            {
                var files = directory.GetFiles(pattern, System.IO.SearchOption.TopDirectoryOnly);

                foreach (var item in files)
                {
                    OnFileFound(directory.FullName, item.Name, item.Length);
                }
            }
            catch (Exception)
            {

            }

            foreach (var dir in directory.GetDirectories())
            {
                try
                {
                    SearchItems(dir.FullName, pattern);
                }
                catch (Exception ex)
                {

                }
            }

        }


    }
}
