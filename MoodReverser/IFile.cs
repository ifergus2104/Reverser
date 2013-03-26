using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodReverser
{
    public interface IFile
    {
        bool FileExists(string fileName);
        string FileName { get; set; }
        string GetFileContents(string fileName);
    }
}
