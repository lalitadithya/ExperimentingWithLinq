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

    public class FileSystemElement
    {
        public string Path { get; set; }
        public ElementType ElementType { get; set; }

        public FileSystemElement(string path)
        {
            Path = path;
        }
    }
}
