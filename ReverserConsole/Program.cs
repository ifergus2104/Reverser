using System;
using FileManager;
using Reverser;
using FileReverser;

namespace ReverserConsole
{
    public static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 0) return;
                Console.WriteLine("Please enter the location of the file to reverse");
                var inputFile = Console.ReadLine();

                if (args.Length != 0) return;
                Console.WriteLine("Please enter the location of the file to output reversed text");
                var outputFile = Console.ReadLine();

                var reversed = CreateReversedOutputFile(inputFile, outputFile);

                if (string.IsNullOrEmpty(reversed))
                    Console.WriteLine("File not created.  Exiting ...");
                else
                {
                    Console.WriteLine("the input file: " + inputFile);
                    Console.WriteLine("has been reversed and output to the file: " + outputFile);
                    Console.WriteLine("with the reversed content: " + reversed);

                    if (args.Length != 0) return;
                    var exitText = Console.ReadLine();
                    Console.WriteLine("Please press any key to exit " + exitText);
                }
            }
            catch (Exception e)
            {
                Console.Write("{0} Exception Caught:", e.Message);
            }
        }

        private static string CreateReversedOutputFile(string inputFile, string outputFile)
        {
            var factory = new FileFactory<IFile>();
            object[] arguments = {inputFile};
            IFile textFile = factory.Create<TextFile>(arguments);
            IReverser reverser = new Reverser.Reverser();
            ITextFileReverser textFileReverser = new TextFileReverser(textFile, reverser);
            var reversed = textFileReverser.ReverseTextFileContents(textFile.FileName);
            return textFile.WriteFileContents(outputFile, reversed) ? reversed : string.Empty;
        }
    }
}
