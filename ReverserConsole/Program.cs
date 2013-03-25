using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoodReverser;

namespace ReverserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IReverser reverser = new Reverser();
            var reversed = reverser.Reverse("abcdef");
            Console.Write(reversed);
        }

    }
}
