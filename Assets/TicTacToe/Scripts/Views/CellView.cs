using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseDown()
    {
        GameManager.CellController.OnClick((gameObject.GetComponent<CellView>()));
    }

    public void UpdateView(int status)
    {
        switch(status)
        {
            case 0:
                break;
            case 1:
                GameObject o = GameManager.OSymbolPool.Pop();
                o.transform.parent = gameObject.transform;
                o.transform.localPosition = Vector3.zero;
                o.transform.localScale = Vector3.one;
                o.GetComponent<SpriteRenderer>().sortingOrder = 1;
                break;
            case 2:
                break;
            default:
                break;
        }
    }
}
