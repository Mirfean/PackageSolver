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
        private static LevelsDispacher levelsDispacher;

        [XmlArray("Levels")]
        public static List<Level> LevelsList = new List<Level>();

        private static string pathToFile = Application.persistentDataPath + "/LevelList.xml";

        public void Save(string path)
        {
            var serializer = new XmlSerializer(typeof(LevelsDataFromXml));
            var stream = new FileStream(path, FileMode.Create);
            serializer.Serialize(stream, this);
        }

        public static LevelsDataFromXml Load(string path)
        {
            levelsDispacher = new LevelsDispacher();
            Debug.Log("xmlTest " + LevelsInfo.ListOfLevels);
            Debug.Log("Loading levels...");
            var serializer = new XmlSerializer(typeof(LevelsDataFromXml));
            var stream = new FileStream(path, FileMode.Open);
            LevelsDataFromXml data = serializer.Deserialize(stream) as LevelsDataFromXml;
            return data;
        }

        public static Level GetLevelById(int id)
        {
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