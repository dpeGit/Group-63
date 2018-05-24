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
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.OpenOrCreate);
        bf.Serialize(file, new serialGameData());
        file.Close();
    }

    public static void load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            serialGameData data = (serialGameData)bf.Deserialize(file);
            gameData.test = data.test;
        }
    }
}

//we need to set defualt values on save file creation

public static class gameData {
    public static Dictionary<string, Dictionary<string, object>> test = new Dictionary<string, Dictionary<string, object>>()//look this is a thing that needed to happen its ugly but just ignore that okay
    {
        {"knight", new Dictionary<string, object>
            {
                { "exp", 0 },
                {"level", 10 },
                {"levelsGained", 10 },
                {"runSpeedMult", 0 },
                {"healthMult", 0 },
                {"manaMult", 0 },
                {"armourMult", 0 },
                {"knockbackMult", 0 },
                {"strength", 1 },
                {"agility", 1 },
                {"intellect", 1 },
                {"vitality", 1 },
                {"armour", 1 },
                {"luck", 1 }
            }
        },
        {"rogue", new Dictionary<string, object>
            {
                { "exp", 0 },
                {"level", 0 },
                {"levelsGained", 0 },
                {"runSpeedMult", 0 },
                {"healthMult", 0 },
                {"manaMult", 0 },
                {"armourMult", 0 },
                {"knockbackMult", 0 },
                {"strength", 0 },
                {"agility", 0 },
                {"intellect", 0 },
                {"vitality", 0 },
                {"armour", 0},
                {"luck", 0 }
            }
        },
        {"warrior", new Dictionary<string, object>
            {
                { "exp", 0 },
                {"level", 0 },
                {"levelsGained", 0 },
                {"runSpeedMult", 0 },
                {"healthMult", 0 },
                {"manaMult", 0 },
                {"armourMult", 0 },
                {"knockbackMult", 0 },
                {"strength", 0 },
                {"agility", 0 },
                {"intellect", 0 },
                {"vitality", 0 },
                {"armour", 0},
                {"luck", 0 }
            }
        },
        {"wizard", new Dictionary<string, object>
            {
                { "exp", 0 },
                {"level", 0 },
                {"levelsGained", 0 },
                {"runSpeedMult", 0 },
                {"healthMult", 0 },
                {"manaMult", 0 },
                {"armourMult", 0 },
                {"knockbackMult", 0 },
                {"strength", 0 },
                {"agility", 0 },
                {"intellect", 0 },
                {"vitality", 0 },
                {"armour", 0},
                {"luck", 0 }
            }
        },
        {"archer", new Dictionary<string, object>
            {
                { "exp", 0 },
                {"level", 0 },
                {"levelsGained", 0 },
                {"runSpeedMult", 0 },
                {"healthMult", 0 },
                {"manaMult", 0 },
                {"armourMult", 0 },
                {"knockbackMult", 0 },
                {"strength", 0 },
                {"agility", 0 },
                {"intellect", 0 },
                {"vitality", 0 },
                {"armour", 0},
                {"luck", 0 }
            }
        }
    };

    //down here goes other game data
}

[Serializable]
public class serialGameData {
    public Dictionary<string, Dictionary<string, object>> test = new Dictionary<string, Dictionary<string, object>>();
    public serialGameData()
    {
        test = gameData.test;
    }
}
