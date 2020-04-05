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
            var results = new FileSystemContext(@"C:\")
                .Where(x => x.ElementType == ElementType.File)
                .ToList();

            foreach (var result in results)
            {
                Console.WriteLine(result.Path);
            }

            Console.ReadKey();
        }
    }
}
