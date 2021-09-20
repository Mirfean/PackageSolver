using Assets._Scripts.Levels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets._Scripts.Data
{
    //[Serializable, XmlRoot("AllLevels"), XmlType("AllLevels")]
    [Serializable, XmlType("AllLevels")]
    public class LevelsDataFromXml
    {
        private static XmlTest xmlTest;

        //Contains all levels data
        //[XmlArray("Levels"), XmlArrayItem("Level")]
        //[XmlArrayItem("Level")]
        [XmlArray("Levels")]
        static public List<Level> LevelsList = new List<Level>();

        private string pathToFile = Application.persistentDataPath + "/LevelList.xml";

        //To serialize
        //XmlDocument xmlDoc = new XmlDocument();
        //XDocument xDoc = XDocument.Load(Application.dataPath + "/XMLs/LevelList.xml");

        //Application.persistentDataPath -> C:\Users\Mirfean\AppData\LocalLow\Purple Duck\EqSolver
        //levelsDataFromXml.Save(Path.Combine(Application.persistentDataPath, "LevelList.xml"));
        public void Save(string path)
        {
            var serializer = new XmlSerializer(typeof(LevelsDataFromXml));
            var stream = new FileStream(path, FileMode.Create);
            serializer.Serialize(stream, this);
        }

        public static LevelsDataFromXml Load(string path)
        {
            xmlTest = new XmlTest();
            Debug.Log("xmlTest " + LevelsInfo.ListOfLevels);

            Debug.Log("Loading levels...");
            var serializer = new XmlSerializer(typeof(LevelsDataFromXml));
            var stream = new FileStream(path, FileMode.Open);
            LevelsDataFromXml xyz = serializer.Deserialize(stream) as LevelsDataFromXml;
            return xyz;
        }

        public static Level GetLevelById(int id)
        {
            /*foreach(Level level in LevelsList)
            {
                if (level.levelNumber == id)
                {
                    return level;
                }
            } */
            Level level;
            try
            {
                if (LevelsInfo.ListOfLevels.TryGetValue(id, out level))
                {
                    return level;
                }
            }
            catch
            {
                throw new InvalidOperationException($"There is not a level with that id and we contain {LevelsList.Count.ToString()} levels");
            }
            return level;
        }
    }
}