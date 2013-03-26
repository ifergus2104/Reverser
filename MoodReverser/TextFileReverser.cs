using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodReverser
{
    public class TextFileReverser : ITextFileReverser
    {
        private IFile _textFile;
        private IReverser _reverser;

        public TextFileReverser()
        {
        }

        public TextFileReverser(IFile textFile, IReverser reverser)
        {
            if (InValidArguments(textFile, reverser)) 
                throw new ArgumentNullException("Invalid Argument");
            this._textFile = textFile;
            this._reverser = reverser;
        }

        private bool InValidArguments(IFile textFile, IReverser reverser)
        {
            bool inValid = ((textFile == null) || (reverser == null));
            return inValid;
        }

        public string ReverseTextFileContents(string fileName)
        {
            if (this._textFile.FileExists(fileName))
                return _reverser.Reverse(this._textFile.GetFileContents(this._textFile.FileName));
            return string.Empty;
        } 
    }
}
