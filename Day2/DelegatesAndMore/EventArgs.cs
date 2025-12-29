using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndMore
{
    public class FiledFoundEventArgs : EventArgs
    {
        public long Length { get; }
        public string FileName { get; }
        public string Directory { get; }
        public FiledFoundEventArgs(string fileName, string directoryName, long length)
        {

            FileName = fileName;
            Directory = directoryName;
            Length = length;
        }

    }
}
