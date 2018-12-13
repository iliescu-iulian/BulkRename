using System.IO;

namespace MultiRename
{
    public class WinFileSystem: IFileSystem
    {
        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public string[] GetFiles(string path, string pattern)
        {
            return Directory.GetFiles(path, pattern);
        }

        public void MoveFile(string sourceFileName, string destFileName)
        {
            File.Move(sourceFileName, destFileName);
        }
    }
}