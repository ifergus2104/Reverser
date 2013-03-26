﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MoodReverser;

namespace ReverserTests
{
    [TestFixture]
    public class ReverseTests
    {
        [Test]
        public void ValidMultipleCharacterTextReversalReturnsValidReversedText()
        {
            var expected = "fedcba";
            IReverser reverser = new Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("abcdef")).IgnoreCase);
        }

        [Test]
        public void ValidOneCharacterTextReversalReturnsValidOneCharacterText()
        {
            var expected = "a";
            IReverser reverser = new Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("a")).IgnoreCase);
        }

        [Test]
        public void ValidMixedNumericalCharacterTextReversalReturnsValidReversedText()
        {
            var expected = "4321fedcba";
            IReverser reverser = new Reverser();
            Assert.That(expected, Is.EqualTo(reverser.Reverse("abcdef1234")).IgnoreCase);
        }

        [Test]
        public void EmptyStringTextReversalThrowsValidArgumentExceptionError()
        {
            IReverser reverser = new Reverser();
            var reverserException = Assert.Throws(Is.TypeOf<ArgumentException>().
                And.Message.EqualTo("Invalid Argument"),
                delegate { reverser.Reverse(string.Empty); });
        }

        [Test]
        public void NullTextReversalThrowsValidArgumentExceptionError()
        {
            IReverser reverser = new Reverser();
            var reverserException = Assert.Throws(Is.TypeOf<ArgumentException>().
                And.Message.EqualTo("Invalid Argument"),
                delegate { reverser.Reverse(null); });
        }
    }
}
