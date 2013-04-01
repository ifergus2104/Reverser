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
        [Category("Integration Tests")]
        public void FileExistsEmptyStringThrowsInvalidArgumentExceptionException()
        {
            IFile textFile = CreateTextFile("text.file");
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => textFile.FileExists(string.Empty));
        }

        [Test]
        [Category("Integration Tests")]
        public void FileExistsNullStringFileThrowsInvalidArgumentExceptionException()
        {
            IFile textFile = CreateTextFile("text.file");
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => textFile.FileExists(null));
        }

        [Test]
        [Category("Integration Test")]
        public void GetFileContentsValidFileNameReturnsValidText()
        {
            var fileName = GetSetting();
            const string expected = "abcdef12345";
            IFile textFile = CreateTextFile(fileName);
            Assert.That(expected, Is.EqualTo(textFile.GetFileContents(fileName)));
        }

        [Test]
        [Category("Integration Test")]
        public void FileExistsValidFileNameReturnsTrue()
        {
            var fileName = GetSetting();
            const bool expected = true;
            IFile textFile = CreateTextFile("text.file");
            Assert.That(expected, Is.EqualTo(textFile.FileExists(fileName)));
        }

        [Test]
        [Category("Integration Test")]
        public void GetFileContentsMissingFileThrowsFileNotFoundException()
        {
            const string fileName = @"c:\missing\TextToReverse.txt";
            IFile textFile = CreateTextFile(fileName);
            Assert.Throws(Is.TypeOf<FileNotFoundException>().
                             And.Message.EqualTo("File Not Found"),
                          () => textFile.GetFileContents("text.file"));
        }

        [Test]
        [Category("Integration Test")]
        public void WriteFileContentsValidFileNameCreateFileReturnsTrue()
        {
            var fileName = GetSetting();
            IFile textFile = CreateTextFile(fileName);
            const string fileContents = "abcdef";
            const bool expected = true;
            Assert.That(expected, Is.EqualTo(textFile.WriteFileContents(fileName, fileContents)));
        }

        [Test]
        [Category("Integration Test")]
        public void WriteFileContentsInvalidFileNameCreateFileReturnsFalse()
        {
            const string fileName = @"c:\missing\TextReversed.txt";
            IFile textFile = CreateTextFile(fileName);
            const string fileContents = "abcdef";
            const bool expected = false;
            Assert.That(expected, Is.EqualTo(textFile.WriteFileContents(fileName, fileContents)));
        }

        private static IFile CreateTextFile(string fileName)
        {
            var fileFactory = new FileFactory<IFile>();
            IFile textFile = fileFactory.Create<TextFile>(fileName);
            return textFile;
        }

        private string GetSetting()
        {
            return Properties.Settings.Default.textfiletoreverse;
        }
    }
}
