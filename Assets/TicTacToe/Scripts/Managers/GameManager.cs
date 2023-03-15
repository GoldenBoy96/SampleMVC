using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static GameObjectPool XSymbolPool;
    public static GameObjectPool OSymbolPool;


    public static CellController CellController { get; private set; }
    public static BoardController BoardController { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = GetComponent<GameManager>();        

        gameObject.AddComponent<CellController>();
        gameObject.AddComponent<BoardController>();
        CellController = gameObject.GetComponent<CellController>();
        BoardController = gameObject.GetComponent<BoardController>();

        InitSymbolPool();
    }

    void InitSymbolPool()
    {
        GameObject symbolX = (GameObject)Resources.Load("Prefabs/XSymbol");
        GameObject symbolO = (GameObject)Resources.Load("Prefabs/OSymbol");

        XSymbolPool = gameObject.AddComponent<GameObjectPool>();
        OSymbolPool = gameObject.AddComponent<GameObjectPool>();

        //int symbolTotal = BoardController.BoardModel.EdgeLength;
        //symbolTotal = symbolTotal * symbolTotal;
        int symbolTotal = 9;
        XSymbolPool.CreatePool(symbolX, symbolTotal);
        OSymbolPool.CreatePool(symbolO, symbolTotal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
