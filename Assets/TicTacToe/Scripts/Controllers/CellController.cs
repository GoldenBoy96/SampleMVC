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

    //public Cell CellModel { get => _cellModel; set => _cellModel = value; }
    //public CellView CellView { get => _cellView; set => _cellView = value; }

    void Start()
    {
        Cell = (GameObject)Resources.Load("Prefabs/Cell");
        _cellModels = new List<Cell>();
        _cellViews = new List<CellView>();
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

        _cellModels.Add(cellModel);
        _cellViews.Add(cellView);
    }

    public GameObject CreateCell(Cell cell)
    {
        Debug.Log(cell);
        GameObject cellObject = Instantiate(Cell);
        if (cellObject.GetComponent<CellView>() == null)
        {
            cellObject.AddComponent<CellView>();

        }
        CellView cellView = cellObject.GetComponent<CellView>();        

        _cellModels.Add(cell);
        _cellViews.Add(cellView);

        return cellObject;
    }

    public Cell GetCell(int index)
    {
        return _cellModels[index];
    }

    public void SetPosition()
    {
        
    }

    public void OnClick(CellView cellView)
    {
        Debug.Log(_cellModels[_cellViews.IndexOf(cellView)].Location);
        cellView.UpdateView(1);
    }


}

