using LinqCustomProvider.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqCustomProvider.QueryContext
{
    public class FileSystemQueryContext
    {
        internal static object Execute(Expression expression, bool isEnumerable, string root)
        {
            var queriableElements = GetAllFilesAndFolders(root);
            return null;
        }

        private static IQueryable<FileSystemElement> GetAllFilesAndFolders(string root)
        {
            var list = new List<FileSystemElement>();
            foreach (var directory in Directory.GetDirectories(root))
            {
                list.Add(new FolderElement(directory));
            }
            foreach (var file in Directory.GetFiles(root))
            {
                list.Add(new FileElement(file));
            }
            return list.AsQueryable();
        }
    }
}
