using System;
using System.Collections.Generic;
using System.Text;

namespace LinqCustomProvider.Models
{
    public class FileElement : FileSystemElement
    {
        public override ElementType ElementType { get; } = ElementType.File;

        public FileElement(string path) : base(path)
        {
        }
    }
}
