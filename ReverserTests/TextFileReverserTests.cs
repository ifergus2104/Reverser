using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Moq;
using NUnit.Framework;
using MoodReverser;

namespace ReverserTests
{
    [TestFixture]
    public class TextFileReverserTests
    {
        private Mock<IFile> _mockTextFile;
        private Mock<IReverser> _mockReverser;

        [Test]
        [Category("Unit Test")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullDependenciesThrowsInvalidArgumentException()
        {
            ITextFileReverser textFileReverser = new TextFileReverser(null, null);
        }

        [Test]
        [Category("Unit Test")]
        public void ReverseTextFileContentsChecksIfFileExists()
        {
            _mockTextFile = new Mock<IFile>();
            _mockReverser = new Mock<IReverser>();
            _mockTextFile.Setup(s => s.FileExists(It.IsAny<string>())).Returns(true);
            ITextFileReverser textFileReverser = new TextFileReverser(_mockTextFile.Object, _mockReverser.Object);
            var reversedText = textFileReverser.ReverseTextFileContents(It.IsAny<string>());
            _mockTextFile.Verify(v => v.FileExists(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        [Category("Unit Test")]
        public void ReverseTextFileContentsCallsGetFileContents()
        {
            _mockTextFile = new Mock<IFile>();
            _mockReverser = new Mock<IReverser>();
            _mockTextFile.Setup(s => s.FileExists(It.IsAny<string>())).Returns(true);
            _mockTextFile.Setup(s => s.GetFileContents(It.IsAny<string>())).Returns(It.IsAny<string>());
            ITextFileReverser textFileReverser = new TextFileReverser(_mockTextFile.Object, _mockReverser.Object);
            var reversedText = textFileReverser.ReverseTextFileContents(It.IsAny<string>());
            _mockTextFile.Verify(v => v.GetFileContents(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        [Category("Integration Test")]
        public void MissingFileOnCallingGetFileContentsThrowsFileNotFoundException()
        {   
            var fileName = @"c:\github\MissingTextToReverse.txt";
            IFile reverserFile = new TextFile(fileName);
            var reverserFileException = Assert.Throws(Is.TypeOf<FileNotFoundException>().
                And.Message.EqualTo("File Not Found"), 
                delegate { reverserFile.GetFileContents("text.file"); });
        }        
    }
}
