
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private int _edgeLength;

    private List<List<Cell>> _boards;

    public int EdgeLength { get => _edgeLength; set => _edgeLength = value; }
    public List<List<Cell>> Boards { get => _boards; set => _boards = value; }

    public Board()
    {
        _edgeLength = 3;
        Boards = new List<List<Cell>>();
        int rowCount;
        int colCount;
        int location = 0;
        for (rowCount = 0; rowCount < _edgeLength; rowCount++)
        {
            List<Cell> row = new List<Cell>();
            for (colCount = 0; colCount < _edgeLength; colCount++)
            {
                Cell cell = new Cell();
                cell.Location = location;
                row.Add(cell);
                location++;
            }
            Boards.Add(row);
        }
    }
    public Board(int edgeLength)
    {
        _edgeLength = edgeLength;
        Boards = new List<List<Cell>>();
        int rowCount;
        int colCount;
        int location = 0;
        for (rowCount = 0; rowCount < _edgeLength; rowCount++)
        {
            List<Cell> row = new List<Cell>();
            for (colCount = 0; colCount < _edgeLength; colCount++)
            {
                Cell cell = new Cell();
                cell.Location = location;
                row.Add(cell);
                location++;
            }
            Boards.Add(row);
        }
    }

    public int GetCellValue(int row, int col)
    {
        if ((row < _edgeLength && row >= 0) && (col < _edgeLength && col >= 0))
        {
            return _boards[row][col].Status;
        }
        else
        {
            Debug.Log("Out of bound");
            return 0;
        }

    }

    public void SetCellValue(int row, int col, int value)
    {
        if ((row < _edgeLength && row >= 0) && (col < _edgeLength && col >= 0))
        {
            if (value >= 0 && value < 3)
            {
                _boards[row][col].Status = value;
            }
            else
            {
                Debug.Log("Value is not valid");
            }
        }
        else
        {
            Debug.Log("Out of bound");
        }
    }

    public void PrintBoard()
    {
        Debug.Log(_boards);
    }

}
