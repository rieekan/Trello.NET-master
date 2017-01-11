using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> terms = new List<string>();
            List<string> fileNames = new List<string>();
            List<string> filters = new List<string>();
            filters.Add("*.txt");
            filters.Add("*.pdf");
            filters.Add("*.doc");

            foreach (string filter in filters)
            {
                Console.WriteLine("Filter: " + filter);
                fileNames = GetFileList(filter, @"C:\Users\bpayne\Desktop\UDR").ToList<string>();
                foreach (string name in fileNames)
                {
                    Console.WriteLine(name);
                }
            }

            Console.WriteLine("\rPress any key.");
            Console.ReadKey();
        }

        public static IEnumerable<string> GetFileList(string fileSearchPattern, string rootFolderPath)
        {
            Queue<string> pending = new Queue<string>();
            pending.Enqueue(rootFolderPath);
            string[] tmp;
            while (pending.Count > 0)
            {
                rootFolderPath = pending.Dequeue();
                tmp = Directory.GetFiles(rootFolderPath, fileSearchPattern);
                for (int i = 0; i < tmp.Length; i++)
                {
                    yield return tmp[i];
                }
                tmp = Directory.GetDirectories(rootFolderPath);
                for (int i = 0; i < tmp.Length; i++)
                {
                    pending.Enqueue(tmp[i]);
                }
            }
        }
    }
}
