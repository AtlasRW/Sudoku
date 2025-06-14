using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GridGenerator
{
    private const int GRID_LENGTH = 81;

    public class Cell
    {
        public int Position;
        public int Value;
        public int Column;
        public int Row;
        public int Box;

        public Cell(int i, int v)
        {
            Value = v;
            Position = i + 1;
            Column = Position % 9 == 0 ? 9 : Position % 9;
            Row = Column == 9 ? Position / 9 : Position / 9 + 1;
            Box = Row switch
            {
                1 or 2 or 3 =>
                    Column switch
                    {
                        1 or 2 or 3 => 1,
                        4 or 5 or 6 => 2,
                        7 or 8 or 9 => 3,
                        _ => 0
                    },
                4 or 5 or 6 =>
                    Column switch
                    {
                        1 or 2 or 3 => 4,
                        4 or 5 or 6 => 5,
                        7 or 8 or 9 => 6,
                        _ => 0
                    },
                7 or 8 or 9 =>
                    Column switch
                    {
                        1 or 2 or 3 => 7,
                        4 or 5 or 6 => 8,
                        7 or 8 or 9 => 9,
                        _ => 0
                    },
                _ => 0
            };
        }
    }

    public static List<Cell> Generate()
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
                Cell optionCell = new(c, options[c][optionIndex]);

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
        // return cells.ConvertAll(cell => cell.Value).ToArray();
    }

    private static bool IsCompatible(List<Cell> cells, Cell test)
    {
        foreach (Cell cell in cells.Where(cell => cell.Column == test.Column || cell.Row == test.Row || cell.Box == test.Box))
            if (cell.Value == test.Value)
                return false;

        return true;
    }

    private static List<int> GetNumberOptions() => new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
}
