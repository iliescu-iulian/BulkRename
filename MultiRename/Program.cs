using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiRename
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = Directory.GetCurrentDirectory();
            if (args.Length == 1)
            {
                if (Directory.Exists(args[0]))
                {
                    dir = args[0];
                }
            }

            Console.WriteLine("Using directory {0}", dir);
            
            RenameFrom(dir);
        }

        static void RenameFrom(string path)
        {
            var files = Directory.GetFiles(path, "Slide*.png");
            foreach (var file in files)
            {
                var newName = GetNewFileName(file);
                Console.WriteLine("Renaming {0} to {1}",
                    Path.GetFileName(file), newName);
                File.Move(file, Path.Combine(path, newName));
            }
        }

        static string GetNewFileName(string filePath)
        {
            var name = Path.GetFileNameWithoutExtension(filePath);
            var numberPart = name.Substring(5);
            var value = int.Parse(numberPart);
            return string.Format("{0:000}.png", value);
        }
    }
}
