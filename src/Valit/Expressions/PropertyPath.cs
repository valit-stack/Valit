using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using static Valit.Exceptions.SemanticExceptions;

namespace Valit.Expressions
{
    /// <summary> 
    /// https://stackoverflow.com/questions/1667408/c-getting-names-of-properties-in-a-chain-from-lambda-expression 
    /// with soem changes... such as support for fields
    /// </summary>
    internal static class PropertyPath<TSource>
    {   
        public static IReadOnlyList<MemberInfo> GetRightToLeft<TResult>(Expression<Func<TSource, TResult>> expression)
        {
            var visitor = new PropertyVisitor();
            visitor.Visit(expression.Body);
            return visitor.Path;
        }

        public static IReadOnlyList<MemberInfo> GetLeftToRight<TResult>(Expression<Func<TSource, TResult>> expression)
        {
            var visitor = new PropertyVisitor();
            visitor.Visit(expression.Body);
            visitor.Path.Reverse();
            return visitor.Path;
        }

        class PropertyVisitor : ExpressionVisitor
        {
            internal readonly List<MemberInfo> Path = new List<MemberInfo>();

            protected override Expression VisitMember(MemberExpression node)
            {
                if (!(node.Member is FieldInfo || node.Member is PropertyInfo))
                {
                    throw IncorrectPathExpression();
                }

                this.Path.Add(node.Member);

                return base.VisitMember(node);
            }
        }
    }
}
