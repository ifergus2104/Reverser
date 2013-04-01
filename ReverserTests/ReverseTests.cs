using System;
using NUnit.Framework;
using Reverser;

namespace ReverserTests
{
    [TestFixture]
    public class ReverseTests
    {
        [Test]
        [Category("Unit Tests")]
        public void ReverseValidMultipleCharacterTextReturnsValidReversedText()
        {
            const string expected = "fedcba";
            IReverser reverser = new Reverser.Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("abcdef")).IgnoreCase);
        }

        [Test]
        [Category("Unit Tests")]
        public void ReverseValidOneCharacterTextReturnsValidOneCharacterText()
        {
            const string expected = "a";
            IReverser reverser = new Reverser.Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("a")).IgnoreCase);
        }

        [Test]
        [Category("Unit Tests")]
        public void ReverseValidMixedNumericalCharacterTextReturnsValidReversedText()
        {
            const string expected = "4321fedcba";
            IReverser reverser = new Reverser.Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("abcdef1234")).IgnoreCase);
        }

        [Test]
        [Category("Unit Tests")]
        public void ReverseEmptyStringTextThrowsInvalidArgumentExceptionError()
        {
            IReverser reverser = new Reverser.Reverser();
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => reverser.Reverse(string.Empty));
        }

        [Test]
        [Category("Unit Tests")]
        public void ReverseNullTextThrowsInvalidArgumentExceptionError()
        {
            IReverser reverser = new Reverser.Reverser();
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => reverser.Reverse(null));
        }
    }
}

