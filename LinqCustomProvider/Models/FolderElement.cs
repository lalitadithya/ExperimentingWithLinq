using System;
using System.Collections.Generic;
using System.Text;

namespace LinqCustomProvider.Models
{
    public class FolderElement : FileSystemElement
    {
        public override ElementType ElementType { get; } = ElementType.Folder;

        public FolderElement(string path) : base(path)
        {
        }
    }
}
