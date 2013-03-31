using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using FileManager;

namespace ReverserTests
{
    [TestFixture]
    public class ReverseTests
    {
        [Test]
        [Category("Unit Tests")]
        public void ValidMultipleCharacterTextReversalReturnsValidReversedText()
        {
            var expected = "fedcba";
            IReverser reverser = new FileManager.Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("abcdef")).IgnoreCase);
        }

        [Test]
        [Category("Unit Tests")]
        public void ValidOneCharacterTextReversalReturnsValidOneCharacterText()
        {
            var expected = "a";
            IReverser reverser = new FileManager.Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("a")).IgnoreCase);
        }

        [Test]
        [Category("Unit Tests")]
        public void ValidMixedNumericalCharacterTextReversalReturnsValidReversedText()
        {
            var expected = "4321fedcba";
            IReverser reverser = new FileManager.Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("abcdef1234")).IgnoreCase);
        }

        [Test]
        [Category("Unit Tests")]
        public void EmptyStringTextReversalThrowsValidArgumentExceptionError()
        {
            IReverser reverser = new FileManager.Reverser();
            var reverserException = Assert.Throws(Is.TypeOf<ArgumentException>().
                And.Message.EqualTo("Invalid Argument"),
                delegate { reverser.Reverse(string.Empty); });
        }

        [Test]
        [Category("Unit Tests")]
        public void NullTextReversalThrowsValidArgumentExceptionError()
        {
            IReverser reverser = new FileManager.Reverser();
            var reverserException = Assert.Throws(Is.TypeOf<ArgumentException>().
                And.Message.EqualTo("Invalid Argument"),
                delegate { reverser.Reverse(null); });
        }
    }
}

