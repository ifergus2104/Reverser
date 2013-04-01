using System;
using FileManager;
using Reverser;
using FileReverser;
using Moq;
using NUnit.Framework;


namespace ReverserTests
{
    [TestFixture]
    public class TextFileReverserTests
    {
        private Mock<IFile> _mockTextFile;
        private Mock<IReverser> _mockReverser;

        [Test]        
        public void TextFileReverserNullDependenciesThrowsInvalidArgumentException()
        {
            Assert.Throws(Is.TypeOf<ArgumentNullException>(), 
                          () => new TextFileReverser(null, null));
        }

        [Test]
        [Category("Unit Test")]
        public void ReverseTextFileContentsChecksIfAnyFileExists()
        {
            _mockTextFile = new Mock<IFile>();
            _mockReverser = new Mock<IReverser>();
            _mockTextFile.Setup(s => s.FileExists(It.IsAny<string>())).Returns(true);
            ITextFileReverser textFileReverser = new TextFileReverser(_mockTextFile.Object, _mockReverser.Object);
            textFileReverser.ReverseTextFileContents(It.IsAny<string>());
            _mockTextFile.Verify(v => v.FileExists(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        [Category("Unit Test")]
        public void ReverseTextFileContentsChecksIfNamedFileExists()
        {
            _mockTextFile = new Mock<IFile>();
            _mockReverser = new Mock<IReverser>();
            _mockTextFile.Setup(s => s.FileExists("text.file")).Returns(true);
            ITextFileReverser textFileReverser = new TextFileReverser(_mockTextFile.Object, _mockReverser.Object);
            textFileReverser.ReverseTextFileContents("text.file");
            _mockTextFile.Verify(v => v.FileExists("text.file"), Times.Exactly(1));
        }

        [Test]
        [Category("Unit Test")]
        public void ReverseTextFileContentsExistingFileCallsGetFileContents()
        {
            _mockTextFile = new Mock<IFile>();
            _mockReverser = new Mock<IReverser>();
            _mockTextFile.Setup(s => s.FileExists(It.IsAny<string>())).Returns(true);
            _mockTextFile.Setup(s => s.GetFileContents(It.IsAny<string>())).Returns(It.IsAny<string>());
            ITextFileReverser textFileReverser = new TextFileReverser(_mockTextFile.Object, _mockReverser.Object);
            textFileReverser.ReverseTextFileContents(It.IsAny<string>());
            _mockTextFile.Verify(v => v.GetFileContents(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        [Category("Unit Test")]
        public void ReverseTextFileContentsMissingFileDoesNotCallGetFileContents()
        {
            _mockTextFile = new Mock<IFile>();
            _mockReverser = new Mock<IReverser>();
            _mockTextFile.Setup(s => s.FileExists("text.file")).Returns(false);
            ITextFileReverser textFileReverser = new TextFileReverser(_mockTextFile.Object, _mockReverser.Object);
            textFileReverser.ReverseTextFileContents("text.file");
            _mockTextFile.Verify(v => v.FileExists("text.file"), Times.Exactly(1));
            _mockTextFile.Verify(v => v.GetFileContents(It.IsAny<string>()), Times.Never());
        }        
    }
}
