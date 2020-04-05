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
                .Where(x => x.Path == "Hello" && x.Size == 100)
                .ToList();

            Console.ReadKey();
        }
    }
}
