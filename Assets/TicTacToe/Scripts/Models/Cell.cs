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
    private int _status;
    
    public Cell()
    {
        this._status = 0;
    }

    public Cell(int status)
    {
        _status = status;
    }

    public int Status { get => _status; set => _status = value; }
}

