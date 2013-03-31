using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using FileManager;

namespace ReverserConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {                
                var fileName = @"c:\github\texttoreverse.txt";
                IFileFactory fileFactory = new FileFactory();
                IFile textFile = fileFactory.Create(FileTypes.Text, fileName);
                IReverser reverser = new FileManager.Reverser();
                ITextFileReverser textFileReverser = new TextFileReverser(textFile, reverser);
                var reversed = textFileReverser.ReverseTextFileContents(textFile.FileName);
                Console.Write(reversed);
            }
            catch (Exception e)
            {
                Console.Write("{0} Exception Caught:", e.Message);
            }
        }
    }
}
