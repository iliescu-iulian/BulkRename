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
            var dir= new InputArguments(args).SourceDirectory;

            Console.WriteLine("Using directory {0}", dir);
            
            RenameFrom(dir);
        }

        static void RenameFrom(string path)
        {
            var files = Directory.GetFiles(path, "Slide*.png");
            foreach (var file in files)
            {
                var newName = AppTools.CreateNewFileName(file);
                Console.WriteLine("Renaming {0} to {1}",
                    Path.GetFileName(file), newName);
                File.Move(file, Path.Combine(path, newName));
            }
        }
    }
}
