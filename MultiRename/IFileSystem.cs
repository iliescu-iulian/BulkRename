namespace MultiRename
{
    public interface IFileSystem
    {
        string GetCurrentDirectory();
        bool DirectoryExists(string path);
        string[] GetFiles(string path, string pattern);
        void MoveFile(string sourceFileName, string destFileName);
    }
}