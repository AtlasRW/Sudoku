using System.Collections.Generic;

public static class Random
{
    static int Range(int minInclusive, int maxEclusive) => UnityEngine.Random.Range(minInclusive, maxEclusive);

    public static bool Bool() => Int(0, 1) == 0;
    public static Number Num() => Number.Get(Int(1, 9));
    public static int Int(int min, int max) => Range(min, max + 1);
    public static T ListElement<T>(List<T> list) => list.Count > 0 ? list[Range(0, list.Count)] : default;
}