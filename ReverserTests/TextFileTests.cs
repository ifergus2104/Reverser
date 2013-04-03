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
        [Category("Integration Test")]
        public void FileNameSetEmptyStringThrowsInvalidArgumentException()
        {
            IFile textFile = CreateTextFile("text.file");
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => textFile.FileName = string.Empty);
        }

        [Test]
        [Category("Integration Test")]
        public void FileNameSetNullThrowsInvalidArgumentException()
        {
            IFile textFile = CreateTextFile("text.file");
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => textFile.FileName = null);
        }

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
        public void GetFileContentsStringEmptyThrowsInvalidArgumentException()
        {
            const string fileName = @"c:\missing\TextToReverse.txt";
            IFile textFile = CreateTextFile(fileName);
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => textFile.GetFileContents(string.Empty));
        }

        [Test]
        [Category("Integration Test")]
        public void GetFileContentsNullThrowsInvalidArgumentException()
        {
            const string fileName = @"c:\missing\TextToReverse.txt";
            IFile textFile = CreateTextFile(fileName);
            Assert.Throws(Is.TypeOf<ArgumentException>().
                             And.Message.EqualTo("Invalid Argument"),
                          () => textFile.GetFileContents(null));
        }

        [Test]
        [Category("Integration Test")]
        public void WriteFileContentsValidFileNameCreateFileReturnsTrue()
        {
            var fileName = GetSetting();
            IFile textFile = CreateTextFile(fileName);
            const string fileContents = "abcdef12345";
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

        private static string GetSetting()
        {
            return Properties.Settings.Default.TextfileToReverse;
        }
    }
}
