using Assets._Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assets._Scripts.Data
{

    [Serializable]
    [XmlRoot(ElementName = "Level")]
    public class Level
    {
        
        //[XmlElement(ElementName = "number")]
        [XmlElement("number")]
        public readonly int levelNumber;

        //[XmlAttribute("description")]
        //[XmlElement(ElementName = "description")]
        [XmlElement("description")]
        public string description;
        
        [XmlElement("levelType")]
        public LevelType levelType;
        
        [XmlArray("fieldsType")]
        [XmlArrayItem("fieldType")]
        public List<FieldType> levelCode;

        [XmlArray("puzzles")]
        [XmlArrayItem("puzzle")]
        public List<String> puzzleToLevel;

        public Level(int n, LevelType lT, string descript, List<FieldType> fields, List<String> puzzles)
        {
            levelNumber = n;
            levelType = lT;
            description = descript;
            levelCode = fields;
            puzzleToLevel = puzzles;
        }

        public Level(int n, String lT, string descript, List<String> fields, List<String> puzzles)
        {
            levelNumber = n;
            levelType = (LevelType) Enum.Parse(typeof(FieldType), lT);
            description = descript;
            puzzleToLevel = puzzles;
            

            foreach(String str in fields)
            {
                levelCode.Add((FieldType) Enum.Parse(typeof(FieldType), str));
            }

        }
    }
}
