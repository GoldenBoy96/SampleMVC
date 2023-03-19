using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CellController : MonoBehaviour
{
    public GameObject Cell;

    private List<Cell> _cellModels;

    private List<CellView> _cellViews;

    public List<Cell> CellModels { get => _cellModels; set => _cellModels = value; }
    public List<CellView> CellViews { get => _cellViews; set => _cellViews = value; }

    void Start()
    {
        Cell = (GameObject)Resources.Load("Prefabs/Cell");
        CellModels = new List<Cell>();
        CellViews = new List<CellView>();
        //InitCell();
    }

    public void CreateCell()
    {
        Cell cellModel = new Cell();
        GameObject cellObject = Instantiate(Cell);
        if (cellObject.GetComponent<CellView>() == null)
        {
            cellObject.AddComponent<CellView>();

        }
        CellView cellView = cellObject.GetComponent<CellView>();

        CellModels.Add(cellModel);
        CellViews.Add(cellView);
    }

    public GameObject CreateCell(Cell cell)
    {
        //Debug.Log(cell);
        GameObject cellObject = Instantiate(Cell);
        if (cellObject.GetComponent<CellView>() == null)
        {
            cellObject.AddComponent<CellView>();

        }
        CellView cellView = cellObject.GetComponent<CellView>();        

        CellModels.Add(cell);
        CellViews.Add(cellView);

        return cellObject;
    }

    public Cell GetCell(int index)
    {
        return CellModels[index];
    }

    public Cell GetCell(CellView cellView)
    {
        return CellModels[CellViews.IndexOf(cellView)];
    }

    public void SetCell(CellView cellView, int value)
    {
        CellModels[CellViews.IndexOf(cellView)].State = value;
    }

    public CellView GetCellView(Cell cell)
    {
        return CellViews[CellModels.IndexOf(cell)];
    }

    public void SetPosition()
    {
        
    }

    

    public void OnClick(CellView cellView)
    {
        Cell onClickCell = GetCell(cellView);
        if (!GameManager.Instance.IsPause())
        {
            if (GetCell(cellView).State == 0)
            {
                cellView.UpdateView(1);
                SetCell(cellView, 1);
                //Add call bot player here
                GameManager.BoardController.CheckEndGame(onClickCell);
                if (!GameManager.Instance.IsPause())
                {
                    GameManager.BotController.OnTurn();
                };


                //GameManager.BoardController.PrintBoard();
            }
        }

        GameManager.BoardController.CheckEndGame(onClickCell);
    }


}

