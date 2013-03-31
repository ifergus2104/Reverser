using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager
{
    public interface ITextFileReverser
    {
        string ReverseTextFileContents(string fileName);
    }
}
