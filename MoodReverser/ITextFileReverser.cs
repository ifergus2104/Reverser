using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reverser
{
    public interface ITextFileReverser
    {
        string ReverseTextFileContents(string fileName);
    }
}
