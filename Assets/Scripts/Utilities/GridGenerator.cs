using System.Collections.Generic;
using System.Linq;

public static class GridGenerator
{
    const byte GRID_LENGTH = 81;

    public static List<Cell> Generate(Difficulty difficulty = Difficulty.MEDIUM)
    {
        List<Cell> cells = new();
        List<List<byte>> options = GetOptions();
        bool[] prefills = GetPrefills(difficulty);

        byte c = 0;
        while (c != GRID_LENGTH)
        {
            if (options[c].Count > 0)
            {
                int optionIndex = Random.Index(options[c]);
                Cell optionCell = new((byte)(c + 1), options[c][optionIndex], prefills[c]);

                options[c].RemoveBySwap(optionIndex);

                if (IsCompatible(cells, optionCell))
                {
                    cells.Add(optionCell);
                    c++;
                }
            }
            else
            {
                options[c] = GetNumberOptions();
                cells.Pop();
                c--;
            }
        }

        return cells;
    }

    static bool IsCompatible(List<Cell> cells, Cell test)
    {
        foreach (Cell cell in cells.Where(cell => cell.Aligns(test.Position)))
            if (cell.Matches(test.Value))
                return false;

        return true;
    }

    static List<byte> GetNumberOptions() => new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    static List<List<byte>> GetOptions()
    {
        List<List<byte>> options = new();

        for (byte i = 0; i < GRID_LENGTH; i++)
            options.Add(GetNumberOptions());

        return options;
    }

    static bool[] GetPrefills(Difficulty difficulty)
    {
        bool[] prefills = new bool[GRID_LENGTH];

        for (byte i = 0; i < difficulty.ToPrefills(); i++)
            prefills[i] = true;

        return prefills.Shuffle();
    }
}
