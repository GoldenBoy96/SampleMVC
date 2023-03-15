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

    public Board BoardModel { get => _boardModel; set => _boardModel = value; }

    //public Board BoardModel { get => _boardModel; set => _boardModel = value; }
    //public BoardView BoardView { get => _boardView; set => _boardView = value; }

    void Start()
    {
        Board = (GameObject)Resources.Load("Prefabs/Board");

        if (GetComponent<CellController>() == null)
        {
            gameObject.AddComponent<CellController>();
        }

        

        CreateBoard();
        PrintBoard();
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
            CellController cellController = GetComponent<CellController>();
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

    public void SetPosition()
    {

    }

    public void PrintBoard()
    {
        string board = "" ;
        if (BoardModel != null && _boardView != null)
        {
            CellController cellController = GetComponent<CellController>();
            int row;
            int col;
            for (row = 0; row < BoardModel.EdgeLength; row++)
            {
                
                for (col = 0; col < BoardModel.EdgeLength; col++)
                {
                    board += BoardModel.Boards[row][col].Location.ToString() + " ";
                    
                }
                board += " | ";
                Debug.Log(board.ToString());

            }
        }

    }
}
