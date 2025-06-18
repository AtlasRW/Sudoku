using System;
using System.Collections.Generic;
using System.Linq;

public static class Random
{
    public static bool Bool() => Int(0, 1) == 0;
    public static Number Num() => Int(1, 9);
    public static int Int(int min, int max) => FromRange(min, max + 1);
    public static int ListIndex<T>(List<T> list) => list.Count > 0 ? FromRange(0, list.Count) : default;
    public static T ListElement<T>(List<T> list) => list.Count > 0 ? list[FromRange(0, list.Count)] : default;
    public static T EnumMember<T>() where T : Enum => (T)Enum.GetValues(typeof(T)).GetValue(FromRange(0, Enum.GetValues(typeof(T)).Length));

    private static int FromRange(int minInclusive, int maxExclusive) => UnityEngine.Random.Range(minInclusive, maxExclusive);
}