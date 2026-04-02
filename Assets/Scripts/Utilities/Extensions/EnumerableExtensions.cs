using System;
using System.Collections.Generic;
using System.Linq;

public static partial class Extensions
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
    {
        return source.Select((item, index) => (item, index));
    }

    public static string AsString<T>(this IEnumerable<T> source)
    {
        return $"<{typeof(T)}> ({string.Join(", ", source)})";
    }
    public static string AsString<TElement, TResult>(this IEnumerable<TElement> source, Func<TElement, TResult> fn)
    {
        return AsString(source.Select(item => fn(item)));
    }
    public static string AsString<TElement, TResult>(this IEnumerable<TElement> source, Func<TElement, int, TResult> fn)
    {
        return AsString(source.Select((item, index) => fn(item, index)));
    }
}
