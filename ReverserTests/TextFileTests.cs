﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FileManager;
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
            IFile textFile = CreateTextFile("text.file");
            var textFileException = Assert.Throws(Is.TypeOf<ArgumentException>().
                And.Message.EqualTo("Invalid Argument"),
                delegate { textFile.FileExists(string.Empty); });
        }

        [Test]
        [Category("Unit Tests")]
        public void NullStringFileExistsThrowsValidArgumentExceptionError()
        {
            IFile textFile = CreateTextFile("text.file");
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
            IFile textFile = CreateTextFile(fileName);
            Assert.That(expected, Is.EqualTo(textFile.GetFileContents(fileName)));
        }

        [Test]
        [Category("Integration Test")]
        public void ValidFileNameFileExistsReturnsTrue()
        {
            var fileName = @"c:\Github\TextToReverse.txt";
            var expected = true;
            IFile textFile = CreateTextFile("text.file");
            Assert.That(expected, Is.EqualTo(textFile.FileExists(fileName)));
        }

        [Test]
        [Category("Integration Test")]
        public void MissingFileOnCallingGetFileContentsThrowsFileNotFoundException()
        {
            var fileName = @"c:\github\MissingTextToReverse.txt";
            IFile textFile = CreateTextFile(fileName);
            var reverserFileException = Assert.Throws(Is.TypeOf<FileNotFoundException>().
                And.Message.EqualTo("File Not Found"),
                delegate { textFile.GetFileContents("text.file"); });
        }

        private static IFile CreateTextFile(string fileName)
        {
            IFileFactory fileFactory = new FileFactory();
            IFile textFile = fileFactory.Create(FileTypes.Text, fileName);
            return textFile;
        }
    }
}
