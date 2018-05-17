using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

public static class SaveLoad {

    public static void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);


    }
}

//we need to set defualt values on save file creation
    [Serializable]
    public class KnightData {
        static public int exp, expNeeded;
        static public int level, levelsGained;
        static public float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
        static public int strength, agility, intellect, vitality, armour, luck;
}

    [Serializable]
    public class RogueData {
        static public int exp, expNeeded;
        static public int level;
        static public float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
        static public int strength, agility, intellect, vitality, armour, luck;
    }

    [Serializable]
    public class WarriorData {
        static public int exp, expNeeded;
        static public int level;
        static public float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
        static public int strength, agility, intellect, vitality, armour, luck;
    }

    [Serializable]
    public class WizzardData {
        static public int exp, expNeeded;
        static public int level;
        static public float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
        static public int strength, agility, intellect, vitality, armour, luck;
    }

    [Serializable]
    public class ArcherData {
        static public int exp, expNeeded;
        static public int level;
        static public float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
        static public int strength, agility, intellect, vitality, armour, luck;
    }

    [Serializable]
    public  class GameData {

        //in here would go game data like unlocks and stuff
    }
