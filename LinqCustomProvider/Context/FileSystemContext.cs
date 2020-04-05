using LinqCustomProvider.Models;
using LinqCustomProvider.QueryProvider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqCustomProvider.Context
{
    public class FileSystemContext<T> : IOrderedQueryable<T>
    {
        public Type ElementType
        {
            get
            {
                return typeof(T);
            }
        }

        public Expression Expression { get; private set; }

        public IQueryProvider Provider { get; private set; }

        internal FileSystemContext(IQueryProvider queryProvider, Expression expression)
        {
            Provider = queryProvider;
            Expression = expression;
        }

        public FileSystemContext(string root)
        {
            Provider = new FileSystemQueryProvider<T>(root);
            Expression = Expression.Constant(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Provider.Execute<IEnumerable<T>>(Expression)?.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
