using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager
{
    public class TextFile : IFile
    {
        private string _fileName;

        public TextFile()
        {
        }

        public TextFile(string fileName)
        {
            this.FileName = fileName;
        }

        public bool FileExists(string fileName)
        {
            this.FileName = fileName;
            bool exists = File.Exists(this._fileName);
            return exists;
        }

        public string FileName
        {
            get { return this._fileName; }
            set 
            {
                if (InValidFileName(value)) throw new ArgumentException("Invalid Argument");
                this._fileName = value; 
            }
        }

        public string GetFileContents(string fileName)
        {
            this.FileName = fileName;
            var textFileContents = string.Empty;
            if (this.FileExists(this.FileName))
            {
                var allLines = File.ReadAllLines(this.FileName);
                foreach (string line in allLines)
                    textFileContents = textFileContents + line;
            }
            else
                throw new FileNotFoundException("File Not Found");
            return textFileContents;
        }

        private bool InValidFileName(string fileName)
        {
            bool inValid = ((fileName == string.Empty) || (fileName == null));
            return inValid;
        }
    }
}
