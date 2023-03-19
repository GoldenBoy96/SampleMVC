
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private int _edgeLength;

    private List<List<Cell>> _boards;

    //type include 2 value:
    //1) 0 => it means this board is used for Tic-tac-toe game
    //2) 1 => it means this board is used for normal caro game
    private int _type;

    public int EdgeLength { get => _edgeLength; set => _edgeLength = value; }
    public List<List<Cell>> Boards { get => _boards; set => _boards = value; }
    public int Type { get => _type; set => _type = value; }

    public Board()
    {
        _edgeLength = 3;
        Boards = new List<List<Cell>>();
        int rowCount;
        int colCount;
        int id = 0;
        for (rowCount = 0; rowCount < _edgeLength; rowCount++)
        {
            List<Cell> row = new List<Cell>();
            for (colCount = 0; colCount < _edgeLength; colCount++)
            {
                Cell cell = new Cell();
                cell.Id = id;
                row.Add(cell);
                id++;
            }
            Boards.Add(row);
        }
        Type = 0;
    }
    public Board(int edgeLength)
    {
        bool isValid = false;
        if (edgeLength == 3)
        {
            Type = 0;
            isValid = true;
        } 
        else if (edgeLength >= 5)
        {
            Type = 1;
            isValid |= true;
        }

        if (isValid)
        {
            _edgeLength = edgeLength;
            Boards = new List<List<Cell>>();
            int rowCount;
            int colCount;
            int id = 0;
            for (rowCount = 0; rowCount < _edgeLength; rowCount++)
            {
                List<Cell> row = new List<Cell>();
                for (colCount = 0; colCount < _edgeLength; colCount++)
                {
                    Cell cell = new Cell();
                    cell.Id = id;
                    row.Add(cell);
                    id++;
                }
                Boards.Add(row);
            }
        } 
        else
        {
            throw new System.Exception("Invalit input! Must be 3 or larger than 5.");
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
