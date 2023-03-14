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

    //public Board BoardModel { get => _boardModel; set => _boardModel = value; }
    //public BoardView BoardView { get => _boardView; set => _boardView = value; }

    void Start()
    {
        Board = (GameObject)Resources.Load("Prefabs/Board");
        InitBoard();
        Debug.Log(_boardModel);
    }

    public void InitBoard()
    {
        _boardModel = new Board();
        GameObject boardObject = Instantiate(Board);
        if (boardObject.GetComponent<BoardView>() == null)
        {
            boardObject.AddComponent<BoardView>();

        }
        _boardView = boardObject.GetComponent<BoardView>();
        GenerateCellOnBoard();
    }

    public void InitBoard(Board boardModel)
    {
        _boardModel = boardModel;
        GameObject boardObject = Instantiate(Board);
        if (boardObject.GetComponent<BoardView>() == null)
        {
            boardObject.AddComponent<BoardView>();

        }
        _boardView = boardObject.GetComponent<BoardView>();
        GenerateCellOnBoard();
    }

    private void GenerateCellOnBoard()
    {
        if (_boardModel != null && _boardView != null)
        {
            int row;
            int col;
            for (row = 0; row < _boardModel.EdgeLength; row++)
            {
                for (col = 0; col < _boardModel.EdgeLength; col++)
                {
                    Debug.Log(_boardModel.Boards[row][col]);
                    CellController cellController = new CellController();
                    cellController.InitCell(_boardModel.Boards[row][col]);
                }
            }
        }
    }

    public void SetPosition()
    {

    }
}
