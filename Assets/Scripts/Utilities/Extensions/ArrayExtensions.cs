public static partial class Extensions
{
    public static T[] Shuffle<T>(this T[] list)
    {
        for (int i = list.Length - 1; i > 0; i--)
        {
            int j = Random.Int(0, i);
            (list[j], list[i]) = (list[i], list[j]);
        }

        return list;
    }
}
