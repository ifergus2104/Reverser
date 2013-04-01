using System;
using System.IO;
using System.Linq;

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
            FileName = fileName;
        }

        public bool FileExists(string fileName)
        {
            FileName = fileName;
            var exists = File.Exists(_fileName);
            return exists;
        }

        public string FileName
        {
            get { return _fileName; }
            set 
            {
                if (InValidFileName(value)) throw new ArgumentException("Invalid Argument");
                _fileName = value; 
            }
        }

        public string GetFileContents(string fileName)
        {
            FileName = fileName;
            var textFileContents = string.Empty;
            if (FileExists(FileName))
            {
                var allLines = File.ReadAllLines(FileName);
                textFileContents = allLines.Aggregate(textFileContents, (current, line) => current + line);
            }
            else
                throw new FileNotFoundException("File Not Found");
            return textFileContents;
        }

        public bool WriteFileContents(string fileName, string fileContents)
        {
            try
            {
                File.WriteAllText(fileName, fileContents);
                return true;
            }
            catch (Exception)
            { return false; }
        }

        private bool InValidFileName(string fileName)
        {
            var inValid = string.IsNullOrEmpty(fileName);
            return inValid;
        }
    }
}
