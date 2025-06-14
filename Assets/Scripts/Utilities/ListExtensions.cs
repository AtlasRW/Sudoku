using System;
using System.Collections.Generic;

public static class ListExtensions
{
    public static void Pop<T>(this List<T> list)
    {
        int index = list.Count - 1;
        if (index >= 0)
            list.RemoveAt(index);
    }
    public static void RemoveBySwap<T>(this List<T> list, int index)
    {
        list[index] = list[^1];
        list.Pop();
    }
    public static void RemoveBySwap<T>(this List<T> list, T item)
    {
        int index = list.IndexOf(item);
        RemoveBySwap(list, index);
    }
    public static void RemoveBySwap<T>(this List<T> list, Predicate<T> predicate)
    {
        int index = list.FindIndex(predicate);
        RemoveBySwap(list, index);
    }
}
