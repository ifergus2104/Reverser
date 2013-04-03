using System;
using FileManager;
using Reverser;

namespace FileReverser
{
    public class TextFileReverser : ITextFileReverser
    {
        private readonly IFile _textFile;
        private readonly IReverser _reverser;

        public TextFileReverser(IFile textFile, IReverser reverser)
        {
            const string argumentText = "Invalid Argument";
            if (InValidArguments(textFile, reverser)) 
                throw new ArgumentNullException(argumentText);
            _textFile = textFile;
            _reverser = reverser;
        }

        public string ReverseTextFileContents(string fileName)
        {
            if (_textFile.FileExists(fileName))
            {
                var forwardText = _textFile.GetFileContents(_textFile.FileName);
                return _reverser.Reverse(forwardText);
            }
            return string.Empty;
        }

        private static bool InValidArguments(IFile textFile, IReverser reverser)
        {
            var inValid = ((textFile == null) || (reverser == null));
            return inValid;
        }
    }
}
