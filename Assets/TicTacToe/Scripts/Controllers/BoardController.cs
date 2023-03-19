using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public GameObject Board;

    private Board _boardModel;

    private BoardView _boardView;

    private float _cellSize = 1;

    private int _pointToEndGame;

    public Board BoardModel { get => _boardModel; set => _boardModel = value; }


    void Start()
    {
        Board = (GameObject)Resources.Load("Prefabs/Board");

        if (GetComponent<CellController>() == null)
        {
            gameObject.AddComponent<CellController>();
        }


        //Board test = new(4);
        //CreateBoard(test);

        CreateBoard();
        SetEndPoint();
        //PrintBoard();
    }

    public void CreateBoard()
    {
        BoardModel = new Board();
        GameObject boardObject = Instantiate(Board, transform);
        if (boardObject.GetComponent<BoardView>() == null)
        {
            boardObject.AddComponent<BoardView>();

        }
        _boardView = boardObject.GetComponent<BoardView>();
        GenerateCellOnBoard();
    }

    public void CreateBoard(Board boardModel)
    {
        BoardModel = boardModel;
        GameObject boardObject = Instantiate(Board, transform);
        if (boardObject.GetComponent<BoardView>() == null)
        {
            boardObject.AddComponent<BoardView>();

        }
        _boardView = boardObject.GetComponent<BoardView>();
        GenerateCellOnBoard();
    }

    private void GenerateCellOnBoard()
    {

        if (BoardModel != null && _boardView != null)
        {
            CellController cellController = GameManager.CellController;
            int row;
            int col;
            for (row = 0; row < BoardModel.EdgeLength; row++)
            {
                for (col = 0; col < BoardModel.EdgeLength; col++)
                {
                    GameObject cellView = cellController.CreateCell(BoardModel.Boards[row][col]);
                    float w = col * _cellSize - 1;
                    float h = row * -_cellSize + 1;
                    cellView.gameObject.transform.parent = _boardView.gameObject.transform;
                    cellView.transform.position = new Vector2(w, h);
                }
            }
        }
        //Debug.Log(BoardModel);
    }

    private void SetEndPoint()
    {
        if (BoardModel.EdgeLength == 3)
        {
            _pointToEndGame = 3;
        }
        else
        {
            _pointToEndGame = 5;
        }
    }

    public void UpdateBoardValue(Cell cell, int value)
    {
        int row;
        int col;
        for (row = 0; row < BoardModel.EdgeLength; row++)
        {
            for (col = 0; col < BoardModel.EdgeLength; col++)
            {
                if (BoardModel.Boards[row][col] == cell)
                {
                    BoardModel.SetCellValue(row, col, value);
                    return;
                }
            }
        }
    }

    public List<Cell> GetAvailableCells()
    {
        List<Cell> availableCells = new List<Cell>();
        int row;
        int col;
        for (row = 0; row < BoardModel.EdgeLength; row++)
        {
            for (col = 0; col < BoardModel.EdgeLength; col++)
            {
                if (BoardModel.Boards[row][col].State == 0)
                {
                    availableCells.Add(BoardModel.Boards[row][col]);
                }
            }
        }
        return availableCells;
    }
    public void SetPosition(float x, float y)
    {
        _boardView.transform.position = new Vector2(x, y);
    }

    public Vector2 GetPosition(Cell cell)
    {
        int row;
        int col;
        for (row = 0; row < BoardModel.EdgeLength; row++)
        {
            for (col = 0; col < BoardModel.EdgeLength; col++)
            {
                if (BoardModel.Boards[row][col] == cell)
                {
                    return new Vector2(row, col);
                }
            }
        }
        return Vector2.zero;
    }

    public Cell GetCell(int row, int col)
    {
        return BoardModel.Boards[row][col];
    }

    public void SwapCell()
    {
        //This function is not yet available
        //If in the future, any feature require swapping location of 2 cells, please put the code here
    }

    public void DropCell()
    {
        //This function is not yet available
    }

    public void PrintBoard()
    {
        string board = "";
        if (BoardModel != null && _boardView != null)
        {
            CellController cellController = GetComponent<CellController>();
            int row;
            int col;
            for (row = 0; row < BoardModel.EdgeLength; row++)
            {

                for (col = 0; col < BoardModel.EdgeLength; col++)
                {
                    //board += BoardModel.Boards[row][col].Location.ToString() + " ";
                    board += BoardModel.Boards[row][col].State.ToString() + " ";
                }
                board += " | ";


            }
        }
        Debug.Log(board.ToString());
    }

    public int CheckEndGame(Cell cell)
    {
        int checkRow = CheckRow(cell);
        int checkCol = CheckCol(cell);
        int checkDiagonal = CheckDiagonal(cell);
        if (checkRow == 1 || checkCol == 1 || checkDiagonal == 1)
        {
            Debug.Log("Win");
            GameManager.Instance.PauseGame();
            return 1;
        }
        else if (checkRow == 2 || checkCol == 2 || checkDiagonal == 2)
        {
            Debug.Log("Lose");
            GameManager.Instance.PauseGame();
            return 2;
        }
        else if (GetAvailableCells().Count == 0)
        {
            Debug.Log("Draw");
            GameManager.Instance.PauseGame();
            return 0;
        }
        return 0;
    }

    private int CheckCol(Cell cell)
    {
        int count = 0;
        int distance;        
        Vector2 cellPosition = GetPosition(cell);
        int col = (int)cellPosition.y;
        for (distance = (int)(cellPosition.x - _pointToEndGame + 1); distance < cellPosition.x + _pointToEndGame; distance++)
        {
            if (distance >= 0 && distance < _pointToEndGame)
            {
                if (GetCell(distance, col).State == cell.State)
                {
                    count++;
                }
            }
        }
        if (count >= _pointToEndGame)
        {
            return cell.State;
        }
        return 0;
    }

    private int CheckRow(Cell cell)
    {
        int count = 0;
        int distance;
        Vector2 cellPosition = GetPosition(cell);
        int row = (int)cellPosition.x;
        for (distance = (int)(cellPosition.y - _pointToEndGame + 1); distance < cellPosition.y + _pointToEndGame; distance++)
        {
            if (distance >= 0 && distance < _pointToEndGame)
            {
                if (GetCell(row, distance).State == cell.State)
                {
                    count++;
                }
            }
        }
        if (count >= _pointToEndGame)
        {
            return cell.State;
        }
        return 0;
    }

    
    private int CheckDiagonal(Cell cell)
    {
        int count = 0;
        int distance;
        Vector2 cellPosition = GetPosition(cell);
        int row = (int)cellPosition.x;
        int col = (int)cellPosition.y;
        for (distance = - _pointToEndGame + 1; distance < _pointToEndGame; distance++)
        {
            if ((row + distance) >= 0 && (col + distance) >= 0 && (row + distance) < _pointToEndGame && (col + distance) < _pointToEndGame)
            {
                if (GetCell(row + distance, col + distance).State == cell.State)
                {
                    count++;
                }
            }
        }
        if (count >= _pointToEndGame)
        {
            return cell.State;
        }

        count = 0;
        for (distance = -_pointToEndGame + 1; distance < _pointToEndGame; distance++)
        {
            if ((row - distance) >= 0 && (col + distance) >= 0 && (row - distance) < _pointToEndGame && (col + distance) < _pointToEndGame)
            {
                if (GetCell(row - distance, col + distance).State == cell.State)
                {
                    count++;
                }
            }
        }
        if (count >= _pointToEndGame)
        {
            return cell.State;
        }

        return 0;
    }
}
