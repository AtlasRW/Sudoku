using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class Logger
{
    public static void Log(
        object obj,
        [CallerFilePath] string file = default,
        [CallerLineNumber] int line = default,
        [CallerMemberName] string member = default
    ) => Debug.Log($"{Header(file, line, member)} {obj}");

    public static void Log<T>(
        IEnumerable<T> list,
        [CallerFilePath] string file = default,
        [CallerLineNumber] int line = default,
        [CallerMemberName] string member = default
    ) => Debug.Log($"{Header(file, line, member)} {list.AsString()}");

    public static void Log<TElement, TResult>(
        IEnumerable<TElement> list,
        Func<TElement, TResult> fn,
        [CallerFilePath] string file = default,
        [CallerLineNumber] int line = default,
        [CallerMemberName] string member = default
    ) => Debug.Log($"{Header(file, line, member)} {list.AsString(fn)}");

    public static void Log<TElement, TResult>(
        IEnumerable<TElement> list,
        Func<TElement, int, TResult> fn,
        [CallerFilePath] string file = default,
        [CallerLineNumber] int line = default,
        [CallerMemberName] string member = default
    ) => Debug.Log($"{Header(file, line, member)} {list.AsString(fn)}");

    static string Header(string file, int line, string member) => $"[{Path.GetFileName(file)}:{line}:{member}]";
}