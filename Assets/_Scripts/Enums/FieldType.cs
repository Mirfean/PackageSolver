using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Scripts.Enums
{

    // North -> 1, West -> 2, East -> 3, South -> 4 

    public enum FieldType
    {
        EMPTY = 0,
        NONE = 999,
        FULL = 1234,
        N = 1,
        W = 2,
        E = 3,
        S = 4,
        NW = 12,
        NE = 13,
        NS = 14,
        WE = 23,
        WS = 24,
        ES = 34,
        NWE = 123,
        NWS = 124,
        NES = 134,
        WES = 234
    }   
    
}
