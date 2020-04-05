using System;
using System.Collections.Generic;
using System.Text;

namespace LinqCustomProvider.Models
{
    public enum ElementType
    {
        File, 
        Folder
    }

    public abstract class FileSystemElement
    {
        public string Path { get; private set; }
        public abstract ElementType ElementType { get; }

        public FileSystemElement(string path)
        {
            Path = path;
        }
    }
}
