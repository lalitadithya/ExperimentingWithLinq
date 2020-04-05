using LinqCustomProvider.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqCustomProvider.Context
{
    public class FileSystemContext : IOrderedQueryable<FileSystemElement>
    {
        public Type ElementType
        {
            get
            {
                return typeof(FileSystemElement);
            }
        }

        public Expression Expression { get; private set; }

        public IQueryProvider Provider { get; private set; }

        internal FileSystemContext(IQueryProvider queryProvider, Expression expression)
        {
            Provider = queryProvider;
            Expression = expression;
        }

        public IEnumerator<FileSystemElement> GetEnumerator()
        {
            return Provider.Execute<IEnumerable<FileSystemElement>>(Expression).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
