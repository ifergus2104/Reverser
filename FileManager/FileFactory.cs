using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager
{
    public sealed class FileFactory : IFileFactory
    {
        public IFile Create(FileTypes fileType, string fileName)
        {
            if (fileType == FileTypes.Text)
                return new TextFile(fileName);
            throw new ArgumentOutOfRangeException("Invalid File Type");
        }
    }
}
