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
            file.Close();

            GameData.data = data.test;
        }
        else
        {
            save();
        }
    }
}

//we need to set defualt values on save file creation

public static class GameData {
    public static Dictionary<string, Dictionary<string, object>> data = new Dictionary<string, Dictionary<string, object>>()//look this is a thing that needed to happen its ugly but just ignore that okay
    {
        {"knight", new Dictionary<string, object>
            {
                {"exp", 0 },
                {"level", 1 },
                {"expNeeded", 100 },
                {"levelsGained", 5 },
                {"runSpeedMult", 0.8 },
                {"healthMult", 1.5 },
                {"manaMult", 0.2 },
                {"armourMult", 2.5 },
                {"knockbackMult", 1.6 },
                {"strength", 10 },
                {"agility", 4 },
                {"intellect", 4 },
                {"vitality", 7 },
                {"luck", 5 }
            }
        },
        {"theif", new Dictionary<string, object>
            {
                {"exp", 0 },
                {"level", 1 },
                {"expNeeded", 100 },
                {"levelsGained", 5 },
                {"runSpeedMult", 1.5 },
                {"healthMult", 0.5 },
                {"manaMult", 0.4 },
                {"armourMult", 0.5 },
                {"knockbackMult", 0.7 },
                {"strength", 4 },
                {"agility", 10 },
                {"intellect", 5 },
                {"vitality", 4 },
                {"luck", 7 }
            }
        },
        {"warrior", new Dictionary<string, object>
            {
                {"exp", 0 },
                {"level", 1 },
                {"expNeeded", 100 },
                {"levelsGained", 5 },
                {"runSpeedMult", 1.0 },
                {"healthMult", 4.0 },
                {"manaMult", 0.0 },
                {"armourMult", 0.0 },
                {"knockbackMult", 2.0 },
                {"strength", 15 },
                {"agility", 0 },
                {"intellect", 0 },
                {"vitality", 15 },
                {"luck", 0 }
            }
        },
        {"mage", new Dictionary<string, object>
            {
                {"exp", 0 },
                {"level", 1 },
                {"expNeeded", 100 },
                {"levelsGained", 5 },
                {"runSpeedMult", 0.9 },
                {"healthMult", 1.0 },
                {"manaMult", 4.0 },
                {"armourMult", 0.5 },
                {"knockbackMult", 0.1 },
                {"strength", 1 },
                {"agility", 4 },
                {"intellect", 15 },
                {"vitality", 5 },
                {"luck", 5 }
            }
        },
        {"archer", new Dictionary<string, object>
            {
                {"exp", 0 },
                {"level", 1 },
                {"expNeeded", 100 },
                {"levelsGained", 5 },
                {"runSpeedMult", 1.2 },
                {"healthMult", 1.1 },
                {"manaMult", 0.6 },
                {"armourMult", 0.9 },
                {"knockbackMult", 0.8 },
                {"strength", 5 },
                {"agility", 7 },
                {"intellect", 5 },
                {"vitality", 6 },
                {"luck", 7 }
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
        test = GameData.data;
    }
}
