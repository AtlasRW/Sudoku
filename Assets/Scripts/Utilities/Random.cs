using System.Collections.Generic;
using EnumType = System.Enum;

public static class Random
{
    public static bool Bool()
    {
        return Byte(0, 1) == 0;
    }

    public static byte Number()
    {
        return Byte(1, 9);
    }

    public static int Int(int min, int max)
    {
        return FromRange(min, max + 1);
    }

    public static byte Byte(byte min, byte max)
    {
        return (byte)FromRange(min, max + 1);
    }

    public static int Index<T>(T[] list)
    {
        return list.Length > 0 ? FromRange(0, list.Length) : default;
    }
    public static int Index<T>(List<T> list)
    {
        return list.Count > 0 ? FromRange(0, list.Count) : default;
    }

    public static T Element<T>(T[] list)
    {
        return list.Length > 0 ? list[FromRange(0, list.Length)] : default;
    }
    public static T Element<T>(List<T> list)
    {
        return list.Count > 0 ? list[FromRange(0, list.Count)] : default;
    }

    public static T Enum<T>() where T : EnumType
    {
        return (T)EnumType.GetValues(typeof(T)).GetValue(FromRange(0, EnumType.GetValues(typeof(T)).Length));
    }

    static int FromRange(int minInclusive, int maxExclusive) => UnityEngine.Random.Range(minInclusive, maxExclusive);
}