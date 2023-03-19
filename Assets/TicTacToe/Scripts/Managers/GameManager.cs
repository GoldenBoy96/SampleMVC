using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static GameObjectPool XSymbolPool;
    public static GameObjectPool OSymbolPool;

    //Game state: include 2 states
    //1) State 0: Game on
    //2) State 1: Game pause
    private static int _gameState;


    public static CellController CellController { get; private set; }
    public static BoardController BoardController { get; private set; }
    public static BotController BotController { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = GetComponent<GameManager>();        

        gameObject.AddComponent<CellController>();
        CellController = gameObject.GetComponent<CellController>();
        gameObject.AddComponent<BoardController>();
        BoardController = gameObject.GetComponent<BoardController>();
        gameObject.AddComponent<BotController>();
        BotController = gameObject.GetComponent<BotController>();

        _gameState = 0;

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

    public void PauseGame()
    {
        _gameState = 1;
    }

    public bool IsPause()
    {
        return _gameState == 1;
    }
}
