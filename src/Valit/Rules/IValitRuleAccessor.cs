using System;
using System.Collections.Generic;
using Valit.Errors;

namespace Valit.Rules
{
    internal interface IValitRuleAccessor
    {
        IValitMessageProvider GetMessageProvider();
        IValitMessageProvider<TKey> GetMessageProvider<TKey>();
        void AddError(ValitRuleError error);
        void AddTags(params string[] tags);
        bool HasPredicate();
    }

    internal interface IValitRuleAccessor<TObject> : IValitRuleAccessor where TObject : class
    {
        IEnumerable<IValitRule<TObject>> GetEnsureRules(TObject @object);
    }

    internal interface IValitRuleAccessor<TObject, TProperty> : IValitRuleAccessor<TObject> where TObject : class
    {
        Func<TObject, TProperty> PropertySelector { get; }
        IValitRule<TObject, TProperty> PreviousRule { get; }
        void SetPredicate(Predicate<TProperty> predicate);
        void AddCondition(Predicate<TObject> condition);
    }
}
