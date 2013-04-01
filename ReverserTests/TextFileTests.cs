using System;
using System.IO;
using FileManager;
using NUnit.Framework;

namespace ReverserTests
{
    [TestFixture]
    public class TextFileTests
    {
        [Test]
        [Category("Unit Tests")]
        public void EmptyStringFileExistsThrowsValidArgumentExceptionException()
        {
            IFile textFile = CreateTextFile("text.file");
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => textFile.FileExists(string.Empty));
        }

        [Test]
        [Category("Unit Tests")]
        public void NullStringFileExistsThrowsValidArgumentExceptionException()
        {
            IFile textFile = CreateTextFile("text.file");
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => textFile.FileExists(null));
        }

        [Test]
        [Category("Integration Test")]
        public void ValidFileNameGetFileContentsReturnsValidText()
        {
            const string fileName = @"c:\Github\TextToReverse.txt";
            const string expected = "abcdef12345";
            IFile textFile = CreateTextFile(fileName);
            Assert.That(expected, Is.EqualTo(textFile.GetFileContents(fileName)));
        }

        [Test]
        [Category("Integration Test")]
        public void ValidFileNameFileExistsReturnsTrue()
        {
            const string fileName = @"c:\Github\TextToReverse.txt";
            const bool expected = true;
            IFile textFile = CreateTextFile("text.file");
            Assert.That(expected, Is.EqualTo(textFile.FileExists(fileName)));
        }

        [Test]
        [Category("Integration Test")]
        public void MissingFileOnCallingGetFileContentsThrowsFileNotFoundException()
        {
            const string fileName = @"c:\github\MissingTextToReverse.txt";
            IFile textFile = CreateTextFile(fileName);
            Assert.Throws(Is.TypeOf<FileNotFoundException>().
                             And.Message.EqualTo("File Not Found"),
                          () => textFile.GetFileContents("text.file"));
        }

        private static IFile CreateTextFile(string fileName)
        {
            var fileFactory = new FileFactory<IFile>();
            IFile textFile = fileFactory.Create<TextFile>(fileName);
            return textFile;
        }
    }
}
