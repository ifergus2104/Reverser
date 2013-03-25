using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoodReverser;

namespace ReverserConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                IReverser reverser = new Reverser();
                var reversed = reverser.Reverse("abcdef");
                Console.Write(reversed);
            }
            catch (Exception e)
            {
                Console.Write("{0} Exception Caught:", e.Message);
            }
        }
    }
}
