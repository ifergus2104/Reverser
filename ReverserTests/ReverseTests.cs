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
        public void ValidMultipleCharacterTextReversalReturnsValidReversedText()
        {
            const string expected = "fedcba";
            IReverser reverser = new Reverser.Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("abcdef")).IgnoreCase);
        }

        [Test]
        [Category("Unit Tests")]
        public void ValidOneCharacterTextReversalReturnsValidOneCharacterText()
        {
            const string expected = "a";
            IReverser reverser = new Reverser.Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("a")).IgnoreCase);
        }

        [Test]
        [Category("Unit Tests")]
        public void ValidMixedNumericalCharacterTextReversalReturnsValidReversedText()
        {
            const string expected = "4321fedcba";
            IReverser reverser = new Reverser.Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("abcdef1234")).IgnoreCase);
        }

        [Test]
        [Category("Unit Tests")]
        public void EmptyStringTextReversalThrowsValidArgumentExceptionError()
        {
            IReverser reverser = new Reverser.Reverser();
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => reverser.Reverse(string.Empty));
        }

        [Test]
        [Category("Unit Tests")]
        public void NullTextReversalThrowsValidArgumentExceptionError()
        {
            IReverser reverser = new Reverser.Reverser();
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => reverser.Reverse(null));
        }
    }
}

