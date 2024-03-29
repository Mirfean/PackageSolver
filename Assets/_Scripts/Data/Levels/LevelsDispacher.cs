﻿using Assets._Scripts.Data;
using Assets._Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets._Scripts.Levels
{
    [XmlRoot("Level")]
    internal class LevelsDispacher
    {
        private XmlDocument xmlDoc = new XmlDocument();
        private XDocument xDoc = XDocument.Load(Application.persistentDataPath + "/LevelList.xml");

        [XmlArray("number")]
        private int number;

        [XmlElement("")]
        private string text;

        private LevelType levelType;

        private List<string> puzzles;

        public LevelsDispacher()
        {
            xmlDoc.Load(Application.dataPath + "/XMLs/LevelList.xml");
            XElement levelList = xDoc.Element("AllLevels").Element("LevelsList");

            //Level(int n, LevelType lT, string descript, FieldType[] fields, List<String> puzzles)
            if (LevelsInfo.ListOfLevels.Count == 0)
            {
                foreach (XElement x in levelList.Elements("Level"))
                {
                    
                    LevelsInfo.ListOfLevels.Add(int.Parse(x.Element("id").Value),
                        new Level(
                        int.Parse(x.Element("id").Value),
                        (LevelType)Enum.Parse(typeof(LevelType), x.Element("levelType").Value, true),
                        x.Element("description").Value,
                        GetFieldTypes(x),
                        GetPuzzles(x)

                        ));
                    //Debug.Log("number of elements " + LevelsInfo.ListOfLevels.Count());
                }
            }
        }

        public List<FieldType> GetFieldTypes(XElement x)
        {
            List<FieldType> temp = new List<FieldType>();

            //Debug.Log("fieldType number "+ xxx.Count());
            //Debug.Log(x.Element("fieldsType").Descendants().Count());

            foreach (XElement xEle in x.Element("fieldsType").Descendants())
            {
                temp.Add((FieldType)Enum.Parse(typeof(FieldType), xEle.Value));
            }
            return temp;
        }

        public List<String> GetPuzzles(XElement x)
        {
            List<String> temp = new List<string>();
            foreach (XElement xEle in x.Element("puzzles").Elements("puzzle"))
            {
                temp.Add(xEle.Value);
            }
            //Debug.Log("List of puzzles " + temp.Count);
            return temp;
        }
    }
}