using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager
{
    public enum FileTypes { Text };

    public interface IFileFactory
    {        
        IFile Create(FileTypes fileType, string fileName);
    }
}
