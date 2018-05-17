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
        bf.Serialize(file, new KnightData());
        bf.Serialize(file, new RogueData());
        bf.Serialize(file, new WarriorData());
        bf.Serialize(file, new WizzardData());
        bf.Serialize(file, new ArcherData());
        bf.Serialize(file, new GameData());
    }

    public static void load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            KnightData knight = (KnightData)bf.Deserialize(file);
        }
    }
}

//we need to set defualt values on save file creation

    [Serializable]
    public class PlayerClass {
        public int exp, expNeeded;
        public int level, levelsGained;
        public float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
        public int strength, agility, intellect, vitality, armour, luck;

}

    [Serializable]
    public class KnightData: PlayerClass {
        public static new int exp, expNeeded;
        public static new int level, levelsGained;
        public static new float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
        public static new int strength, agility, intellect, vitality, armour, luck;
}

    [Serializable]
    public class RogueData : PlayerClass {
        public static new int exp, expNeeded;
        public static new int level;
        public static new float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
        public static new int strength, agility, intellect, vitality, armour, luck;
    }

    [Serializable]
    public class WarriorData : PlayerClass {
        public static new int exp, expNeeded;
        public static new int level;
        public static new float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
        public static new int strength, agility, intellect, vitality, armour, luck;
    }

    [Serializable]
    public class WizzardData : PlayerClass {
        public static new int exp, expNeeded;
        public static new int level;
        public static new float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
        public static new int strength, agility, intellect, vitality, armour, luck;
    }

    [Serializable]
    public class ArcherData : PlayerClass {
        public static new int exp, expNeeded;
        public static new int level;
        public static new float runSpeedMult, healthMult, manaMult, armourMult, knockbackMult;
        public static new int strength, agility, intellect, vitality, armour, luck;
    }

    [Serializable]
    public  class GameData {

        //in here would go game data like unlocks and stuff
    }
