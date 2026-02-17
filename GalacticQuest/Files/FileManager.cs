using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Files
{
    public class FileManager
    {
        // Lazy<T> handles thread safety and ensures creation happens only once.
        private static readonly Lazy<FileManager> _instance =
            new Lazy<FileManager>(() => new FileManager());

        public static FileManager Instance => _instance.Value;

        private FileManager()
        {
            Console.WriteLine("FileManager initialized...");
        }

        public void Write()
        {
            Console.WriteLine("FileManager Write method call");
        }

        public void Read()
        {
            Console.WriteLine("FileManager Read method call");
        }
    }
}
