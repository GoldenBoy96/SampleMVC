using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cell
{
    //status value chart:
    //status == 0 => empty cell
    //status == 1 mean => cell contain X symbol
    //status == 2 mean => cell contain O symbol
    private int _state;

    private int _id;
    
    public Cell()
    {
        this._state = 0;
    }

    public Cell(int status)
    {
        _state = status;
    }

    public int State { get => _state; set => _state = value; }
    public int Id { get => _id; set => _id = value; }
}

