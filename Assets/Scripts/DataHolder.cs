using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance;

    public string playerName;
    public string lastName;
    public int bestScore;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        ToLoadData();
    }

    [System.Serializable]
    class SaveData
    {
        public string namePlayer;
        public int bestScore;
    }
    public void ToSaveData()
    {
        SaveData data = new SaveData();

        data.bestScore = bestScore;
        data.namePlayer = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Persistent Data Path: " + Application.persistentDataPath);
    }

    public void ToLoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Persistent Data Path: " + Application.persistentDataPath);

            bestScore = data.bestScore;
            playerName = data.namePlayer;
        }
    }
}
