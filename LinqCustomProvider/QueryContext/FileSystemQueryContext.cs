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
            var expressionVisitor = new ExpressionTree.ExpressionVisitor();
            expressionVisitor.Visit(expression);
            Console.WriteLine("Generated query - " + expressionVisitor.Query);
            return new List<FileSystemElement>();
        }
    }
}
