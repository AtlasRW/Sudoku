using System.Collections.Generic;
using System.Linq;
using Unity.Burst;

public static class GridGenerator
{
    private const int GRID_LENGTH = 81;

    public static List<Cell> Generate(Difficulty difficulty = Difficulty.MEDIUM)
    {
        List<Cell> cells = new();
        List<List<int>> options = new();

        for (int i = 0; i < GRID_LENGTH; i++)
            options.Add(GetNumberOptions());

        int c = 0;
        while (c != GRID_LENGTH)
        {
            if (options[c].Count > 0)
            {
                int optionIndex = Random.ListIndex(options[c]);
                Cell optionCell = new(c + 1, options[c][optionIndex]);

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

    private static bool IsCompatible(List<Cell> cells, Cell test)
    {
        foreach (Cell cell in cells.Where(cell => cell.Aligns(test.Position)))
            if (cell.Matches(test.Value))
                return false;

        return true;
    }

    private static List<int> GetNumberOptions() => new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
}
