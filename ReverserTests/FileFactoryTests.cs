using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using FileManager;
using Reverser;
using NUnit.Framework;

namespace ReverserTests
{
    [TestFixture]
    public class FileFactoryTests
    {
        [Test]
        [Category("Unit Tests")]
        public void FileFactoryCreateTextFileValidFilenameReturnsValidFile()
        {
            FileFactory<IFile> fileFactory = new FileFactory<IFile>();
            Assert.That(fileFactory.Create<TextFile>("text.file"), Is.TypeOf(typeof(TextFile)));
        }

        [Test]
        [Category("Unit Tests")]
        public void FileFactoryCreateTextFileMissingFileNameReturnsValidFile()
        {
            FileFactory<IFile> fileFactory = new FileFactory<IFile>();
            Assert.That(fileFactory.Create<TextFile>(null), Is.TypeOf(typeof(TextFile)));
        }

        [Test]
        [Category("Unit Tests")]
        [ExpectedException(typeof(TargetInvocationException))]
        public void FileFactoryCreateTextFileEmptyFileNameThrowTargetInvocationException()
        {
            FileFactory<IFile> fileFactory = new FileFactory<IFile>();
            IFile textFile = fileFactory.Create<TextFile>(string.Empty);
        }
    }
}
