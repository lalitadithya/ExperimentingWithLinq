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
            string query = "SELECT " + expressionVisitor.Query["SELECT"] + "\n" +
                "FROM " +
                "WHERE " + expressionVisitor.Query["WHERE"];

            if (expressionVisitor.Tables.Count > 0)
            {
                string joinClause = expressionVisitor.BaseTable;
                foreach(var table in expressionVisitor.Tables)
                {
                    joinClause += $" JOIN {table}";
                }
                query = query.Replace("FROM ", $"FROM {joinClause} \n");
            }
            else
            {
                query = query.Replace("FROM ", $"FROM {expressionVisitor.BaseTable} \n");
            }

            Console.WriteLine("Generated query \n" + query);
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
