using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string PlayerName;
    public int Score;
}
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public SaveData DataInfo;

    public string BestScoreInfo;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }

    public void SaveInfo()
    {
        string json = JsonUtility.ToJson(DataInfo);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataInfo = JsonUtility.FromJson<SaveData>(json);
        }
        BestScoreInfo = "Best Score: " + DataInfo.PlayerName + " : " + DataInfo.Score;
    }
}
