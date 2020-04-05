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
            var results = new FileSystemContext<FileSystemElement>(@"C:\")
                .Where(x => x.Size == 100 && x.Attributes.Any(x => x.Key == "readonly"))
                .Select(x => x.Path)
                .ToList();

            Console.ReadKey();
        }
    }
}
