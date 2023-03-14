using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CellController : MonoBehaviour
{
    public GameObject Cell;

    private Cell _cellModel;

    private CellView _cellView;

    //public Cell CellModel { get => _cellModel; set => _cellModel = value; }
    //public CellView CellView { get => _cellView; set => _cellView = value; }

    void Start()
    {
        Cell = (GameObject)Resources.Load("Prefabs/Cell");
        //InitCell();
    }

    public void InitCell()
    {
        _cellModel = new Cell();
        GameObject cellObject = Instantiate(Cell);
        if (cellObject.GetComponent<CellView>() == null)
        {
            cellObject.AddComponent<CellView>();

        }
        _cellView = cellObject.GetComponent<CellView>();
    }

    public void InitCell(Cell cellModel)
    {
        _cellModel = cellModel;
        GameObject cellObject = Instantiate(Cell);
        if (cellObject.GetComponent<CellView>() == null)
        {
            cellObject.AddComponent<CellView>();

        }
        _cellView = cellObject.GetComponent<CellView>();
    }

    public void SetPosition()
    {
        
    }



}

