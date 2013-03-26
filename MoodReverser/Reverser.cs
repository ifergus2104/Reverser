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
            if (InValidArgument(forwardText)) 
                throw new ArgumentException("Invalid Argument");
            var reverseChar = forwardText.Reverse();
            var reverseText = string.Empty;
            foreach (char character in reverseChar)
                reverseText += character;
            return reverseText;
        }

        private bool InValidArgument(string forwardText)
        {
            bool inValid = ((forwardText == string.Empty) || (forwardText == null));
            return inValid;
        }
    }
}
