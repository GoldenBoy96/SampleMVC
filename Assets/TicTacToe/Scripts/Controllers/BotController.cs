using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BotController : MonoBehaviour
{
    private List<Cell> availableCells;

    // Start is called before the first frame update
    void Start()
    {
        availableCells = new List<Cell>();
    }


    public void OnTurn()
    {
        availableCells = GameManager.BoardController.GetAvailableCells();

        if (availableCells.Count > 0)
        {
            int randomIndex;
            while (true)
            {
                randomIndex = Random.Range(0, availableCells.Count);
                if (availableCells[randomIndex].Status == 0)
                {
                    availableCells[randomIndex].Status = 2;
                    CellView cellView = GameManager.CellController.GetCellView(availableCells[randomIndex]);
                    cellView.UpdateView(2);

                    GameManager.BoardController.CheckEndGame(GameManager.CellController.GetCell(cellView));
                    return;
                }
            }
        }


    }

}
