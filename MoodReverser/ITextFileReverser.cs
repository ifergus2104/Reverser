using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodReverser
{
    public interface ITextFileReverser
    {
        string ReverseTextFileContents(string fileName);
    }
}
