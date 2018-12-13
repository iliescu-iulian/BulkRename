using System.IO;

namespace MultiRename
{
    public class InputArguments
    {
        public InputArguments(string[] args)
        {
            if (args.Length == 1 && AppTools.FileSystem.DirectoryExists(args[0]))
            {
                SourceDirectory = args[0];
            }
            else
            {
                SourceDirectory = AppTools.FileSystem.GetCurrentDirectory();
            }
        }

        public string SourceDirectory { get; private set; }
    }
}
