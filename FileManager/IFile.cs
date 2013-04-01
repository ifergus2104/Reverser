namespace FileManager
{
    public interface IFile
    {
        bool FileExists(string fileName);
        string FileName { get; set; }
        string GetFileContents(string fileName);
        bool WriteFileContents(string fileName, string fileContents);
    }
}
