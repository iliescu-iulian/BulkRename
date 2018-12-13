using System.IO;

namespace MultiRename
{
    public static class AppTools
    {
        private static IFileSystem _fileSystem;

        public static IFileSystem FileSystem
        {
            get { return _fileSystem ?? (_fileSystem = new WinFileSystem()); }
            set { _fileSystem = value; }

        }

        public static string CreateNewFileName(string sourcePath)
        {
            var name = Path.GetFileNameWithoutExtension(sourcePath);
            var numberPart = name.Substring(5);
            var value = int.Parse(numberPart);
            return string.Format("{0:000}.png", value);
        }
    }
}