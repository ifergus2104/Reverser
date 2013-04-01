using System;
using FileManager;
using Reverser;
using FileReverser;

namespace ReverserConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {                
                const string fileName = @"c:\github\texttoreverse.txt";
                var factory = new FileFactory<IFile>();
                object[] arguments = { fileName };
                IFile textFile = factory.Create<TextFile>(arguments);
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
