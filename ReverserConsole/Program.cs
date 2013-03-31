using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using FileManager;
using Reverser;
using FileReverser;

namespace ReverserConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IFile textFile;
            try
            {                
                var fileName = @"c:\github\texttoreverse.txt";
                FileFactory<IFile> factory = new FileFactory<IFile>();
                string[] arguments = { fileName };
                textFile = factory.Create<TextFile>(arguments);
                IReverser reverser = new Reverser.Reverser();
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
