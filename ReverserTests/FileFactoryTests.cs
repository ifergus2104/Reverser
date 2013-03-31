using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileManager;
using NUnit.Framework;

namespace ReverserTests
{
    [TestFixture]
    public class FileFactoryTests
    {
        [Test]
        public void FileFactoryCreateTextFileValidFilenameReturnsValidFile()
        {
            IFileFactory fileFactory = new FileFactory();
            Assert.That(fileFactory.Create(FileTypes.Text, "text.file"), Is.TypeOf(typeof(TextFile)));
        }

        [Test]
        public void FileFactoryCreateTextFileMissingFileNameThrowArgumentExceptionError()
        {
            IFileFactory fileFactory = new FileFactory();
            var fileFactoryException = Assert.Throws(Is.TypeOf<ArgumentException>().
                And.Message.EqualTo("Invalid Argument"),
                delegate { fileFactory.Create(FileTypes.Text, null); });
        }

        [Test]
        public void FileFactoryCreateTextFileEmptyFileNameThrowArgumentExceptionError()
        {
            IFileFactory fileFactory = new FileFactory();
            var fileFactoryException = Assert.Throws(Is.TypeOf<ArgumentException>().
                And.Message.EqualTo("Invalid Argument"),
                delegate { fileFactory.Create(FileTypes.Text, string.Empty); });
        }
    }
}
