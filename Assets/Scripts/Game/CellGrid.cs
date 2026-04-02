using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SudokuGrid", menuName = "Grid", order = 0)]
public class CellGrid : ScriptableObject
{
    public List<CellInstance> cells = new();
    [SerializeField] List<CellInstance> cells2;
    [SerializeField] CellInstance[] cells3;

    public void Destroy()
    {
        foreach (CellInstance cell in cells) cell.Destroy();
    }

    public override string ToString() => string.Join("", cells.ConvertAll(cell => cell.Cell.Value));

    public CellInstance FindCell(Predicate<CellInstance> predicate) => cells.Find(predicate);
    public CellInstance FindCell(Position pos) => FindCell(c => c.Cell.Aligns(pos));
    public List<CellInstance> FindCells(Predicate<CellInstance> predicate) => cells.FindAll(predicate);
    public List<CellInstance> FindCells(Number num) => FindCells(c => c.Cell.Matches(num));
    public List<CellInstance> FindCells(Number? num) => FindCells(c => c.Cell.MatchesCurrent(num));
    public List<CellInstance> FindCells(Position position) => FindCells(c => c.Cell.Aligns(position));

    public bool IsSolved()
    {
        foreach (CellInstance cell in cells) if (!cell.IsValid()) return false;
        return true;
    }
}