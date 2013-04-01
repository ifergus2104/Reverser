using System.Reflection;
using FileManager;
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
            var fileFactory = new FileFactory<IFile>();
            Assert.That(fileFactory.Create<TextFile>("text.file"), Is.TypeOf(typeof(TextFile)));
        }

        [Test]
        [Category("Unit Tests")]
        public void FileFactoryCreateTextFileMissingFileNameReturnsValidFile()
        {
            var fileFactory = new FileFactory<IFile>();
            Assert.That(fileFactory.Create<TextFile>(null), Is.TypeOf(typeof(TextFile)));
        }

        [Test]
        [Category("Unit Tests")]
        [ExpectedException(typeof(TargetInvocationException))]
        public void FileFactoryCreateTextFileEmptyFileNameThrowTargetInvocationException()
        {
            var fileFactory = new FileFactory<IFile>();
            fileFactory.Create<TextFile>(string.Empty);
        }
    }
}
