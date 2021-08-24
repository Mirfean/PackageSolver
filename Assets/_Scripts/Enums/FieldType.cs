using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assets._Scripts.Enums
{

    // North -> 1, West -> 2, East -> 3, South -> 4 
    [XmlType("fieldType")]
    public enum FieldType
    {
        [XmlEnum(Name = "EMPTY")]
        EMPTY = 0,
        [XmlEnum(Name = "NONE")]
        NONE = 999,
        [XmlEnum(Name = "FULL")]
        FULL = 1234,
        [XmlEnum(Name = "N")]
        N = 1,
        [XmlEnum(Name = "W")]
        W = 2,
        [XmlEnum(Name = "E")]
        E = 3,
        [XmlEnum(Name = "S")]
        S = 4,
        [XmlEnum(Name = "NW")]
        NW = 12,
        [XmlEnum(Name = "NE")]
        NE = 13,
        [XmlEnum(Name = "NS")]
        NS = 14,
        [XmlEnum(Name = "WE")]
        WE = 23,
        [XmlEnum(Name = "WS")]
        WS = 24,
        [XmlEnum(Name = "ES")]
        ES = 34,
        [XmlEnum(Name = "NWE")]
        NWE = 123,
        [XmlEnum(Name = "NWS")]
        NWS = 124,
        [XmlEnum(Name = "NES")]
        NES = 134,
        [XmlEnum(Name = "WES")]
        WES = 234
    }   
    
}
