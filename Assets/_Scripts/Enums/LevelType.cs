using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assets._Scripts.Enums
{
    [XmlType("levelType")]
    public enum LevelType
    {
        None = 0,
        [XmlEnum(Name = "Basic4x4")]
        Basic4x4,
        [XmlEnum(Name = "Basic6x6")]
        Basic6x6,
        [XmlEnum(Name = "Triangles8x6")]
        Triangles8x6,
    }
}
