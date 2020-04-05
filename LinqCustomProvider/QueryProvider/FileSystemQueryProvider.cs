using LinqCustomProvider.Context;
using LinqCustomProvider.Models;
using LinqCustomProvider.QueryContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqCustomProvider.QueryProvider
{
    public class FileSystemQueryProvider : IQueryProvider
    {
        private readonly string root;

        public FileSystemQueryProvider(string root)
        {
            this.root = root;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new FileSystemContext(this, expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return (IQueryable<TElement>)new FileSystemContext(this, expression);
        }

        public object Execute(Expression expression)
        {
            return Execute<FileSystemElement>(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            var isEnumerable = (typeof(TResult).Name == "IEnumerable`1");
            return (TResult)FileSystemQueryContext.Execute(expression, isEnumerable, root);
        }
    }
}
