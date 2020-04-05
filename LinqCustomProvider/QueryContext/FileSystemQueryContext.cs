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
        internal static object Execute<TResult>(Expression expression, bool isEnumerable, string root)
        {
            var expressionVisitor = new ExpressionTree.ExpressionVisitor();
            expressionVisitor.Visit(expression);
            string query = "SELECT " + expressionVisitor.Query["SELECT"] + "\n WHERE " + expressionVisitor.Query["WHERE"];
            Console.WriteLine("Generated query \n- " + query);
            Type t = typeof(TResult);

            if (isEnumerable)
            {
                Type d1 = typeof(List<>);
                Type[] typeArgs = new Type[] { Type.GetType(t.GenericTypeArguments[0].AssemblyQualifiedName) };
                Type constructed = d1.MakeGenericType(typeArgs);
                object o = Activator.CreateInstance(constructed);
                return o;
            }
            else
            {
                return default(TResult);
            }
        }
    }
}
