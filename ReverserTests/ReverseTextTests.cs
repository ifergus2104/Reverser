using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using MoodReverser;

namespace ReverserTests
{
    [TestFixture]
    public class ReverseTextTests
    {
        [Test]
        public void ValidTextReversalReturnsValidReversedText()
        {
            var expected = "fedcba";
            IReverser reverser = new Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("abcdef")).IgnoreCase);
        }

        [Test]
        public void InvalidTextReversalRaisesInvalidInputError()
        {
            
        }
    }
}

