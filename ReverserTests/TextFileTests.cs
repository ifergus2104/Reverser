using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoodReverser;
using NUnit.Framework;
using Moq;

namespace ReverserTests
{
    [TestFixture]
    public class TextFileTests
    {
        [Test]
        [Category("Unit Tests")]
        public void EmptyStringFileExistsThrowsValidArgumentExceptionError()
        {
            IFile textFile = new TextFile();
            var textFileException = Assert.Throws(Is.TypeOf<ArgumentException>().
                And.Message.EqualTo("Invalid Argument"),
                delegate { textFile.FileExists(string.Empty); });
        }

        [Test]
        [Category("Unit Tests")]
        public void NullStringFileExistsThrowsValidArgumentExceptionError()
        {
            IFile textFile = new TextFile();
            var textFileException = Assert.Throws(Is.TypeOf<ArgumentException>().
                And.Message.EqualTo("Invalid Argument"),
                delegate { textFile.FileExists(null); });
        }

        [Test]
        [Category("Integration Test")]
        public void ValidFileNameGetFileContentsReturnsValidText()
        {
            var fileName = @"c:\Github\TextToReverse.txt";
            var expected = "abcdef12345";
            IFile textFile = new TextFile(fileName);
            Assert.That(expected, Is.EqualTo(textFile.GetFileContents(fileName)));
        }

        [Test]
        [Category("Integration Test")]
        public void ValidFileNameFileExistsReturnsTrue()
        {
            var fileName = @"c:\Github\TextToReverse.txt";
            var expected = true;
            IFile textFile = new TextFile(fileName);
            Assert.That(expected, Is.EqualTo(textFile.FileExists(fileName)));
        }
    }
}
