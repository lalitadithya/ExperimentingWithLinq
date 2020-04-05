using LinqCustomProvider.Context;
using LinqCustomProvider.Models;
using System;
using System.Linq;

namespace LinqCustomProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = new FileSystemContext<FileSystemElement>(@"C:\");
            var r1 = results.Where(x => x.Size == 100);
            var r2 = r1.Select(x => x.Path);
            var r3 = r2.ToList();

            Console.ReadKey();
        }
    }
}
