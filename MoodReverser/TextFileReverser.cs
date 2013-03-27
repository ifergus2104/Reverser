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

        private TextFileReverser()
        {
        }

        public TextFileReverser(IFile textFile, IReverser reverser)
        {
            if (InValidArguments(textFile, reverser)) 
                throw new ArgumentNullException("Invalid Argument");
            this._textFile = textFile;
            this._reverser = reverser;
        }

        public string ReverseTextFileContents(string fileName)
        {
            if (this._textFile.FileExists(fileName))
            {
                var forwardText = this._textFile.GetFileContents(this._textFile.FileName);
                return _reverser.Reverse(forwardText);
            }
            return string.Empty;
        }

        private bool InValidArguments(IFile textFile, IReverser reverser)
        {
            bool inValid = ((textFile == null) || (reverser == null));
            return inValid;
        }
    }
}
