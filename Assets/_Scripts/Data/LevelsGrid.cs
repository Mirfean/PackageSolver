using Assets._Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Assets._Scripts.Data
{

    public struct Level
    {
        public readonly string description;
        public readonly FieldType[] levelCode;

        public Level(string x, FieldType[] fields)
        {
            description = x;
            levelCode = fields;
        }
    }



    public static class LevelsGrid
    {
        public static Level levelFull = new Level("LevelFull", new FieldType[48]
        {
            FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL,
            FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL,
            FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL,
            FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL,
            FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL,
            FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL, FieldType.FULL});

        public static Level FlamingWCzapceNaSankach = new Level("FlamingWCzapceNaSankach", new FieldType[48]
        {
            FieldType.NONE,    FieldType.NONE,   FieldType.NONE, FieldType.ES,       FieldType.WS,       FieldType.NONE,    FieldType.NONE,    FieldType.NONE,
            FieldType.NONE,    FieldType.NONE,   FieldType.WS,    FieldType.FULL,     FieldType.FULL,     FieldType.NONE,    FieldType.NONE,    FieldType.NONE,
            FieldType.NONE,    FieldType.NONE,   FieldType.FULL,  FieldType.FULL,     FieldType.NONE,    FieldType.NONE,    FieldType.NONE,    FieldType.NONE,
            FieldType.NONE,    FieldType.NONE,   FieldType.FULL,  FieldType.NONE,    FieldType.NONE,    FieldType.WS,       FieldType.NONE,    FieldType.NONE,
            FieldType.NONE,    FieldType.NONE,   FieldType.FULL,  FieldType.FULL,     FieldType.NONE,    FieldType.FULL,     FieldType.WS,       FieldType.NONE,
            FieldType.NONE,    FieldType.FULL,    FieldType.FULL,  FieldType.FULL,     FieldType.FULL,     FieldType.FULL,     FieldType.FULL,     FieldType.NONE});

        public static Level level0 = new Level("Level 0 - Test", new FieldType[4] 
        {
            FieldType.ES, FieldType.FULL, FieldType.N, FieldType.NES });



    }
}
