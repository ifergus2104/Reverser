using System;
using System.Linq;

namespace Reverser
{
    public class Reverser : IReverser
    {
        public string Reverse(string forwardText)
        {
            if (InValidArgument(forwardText)) throw new ArgumentException("Invalid Argument");
            var reverseChar = forwardText.Reverse();
            return reverseChar.Aggregate(string.Empty, (current, character) => current + character);
        }

        private static bool InValidArgument(string forwardText)
        {
            var inValid = string.IsNullOrEmpty(forwardText);
            return inValid;
        }
    }
}
