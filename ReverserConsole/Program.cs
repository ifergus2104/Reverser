using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Reverser;

namespace ReverserConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {                
                var fileName = @"c:\github\texttoreverse.txt";
                IFile textFile = new TextFile(fileName);
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
