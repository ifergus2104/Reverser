using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodReverser
{
    public class Reverser : IReverser
    {
        public string Reverse(string forwardText)
        {
            var reverseChar = forwardText.Reverse();
            var reverseString = string.Empty;
            foreach (char character in reverseChar)
                reverseString = reverseString + character;
            return reverseString;
        }
    }
}
