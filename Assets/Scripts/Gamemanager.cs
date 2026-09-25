using System.Drawing;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance { get; private set; }

    public int highScore;
    public int score;
    public string playerName;
    public string playerHighScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        Load();
    }

    public void BestScore(int point)
    {
           score = point;
    }
    public void PlayerName(string inputName)
    {
           playerName = inputName;
    }

    public void HighScoreName()
    {
        if (score > highScore)
        {
            highScore = score;
            playerHighScore = playerName;
        }

    }
    private void OnApplicationQuit()
    {
        Save();
    }

    [System.Serializable]
    class SaveData
    {
        public int s_Score;
        public string s_PlayerName;
    }

    public void Save()
    { 
        SaveData data  = new SaveData();
        data.s_Score = highScore;
        data.s_PlayerName = playerHighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.s_Score;
            playerHighScore = data.s_PlayerName;
        }
        Debug.Log("DataLoad!!!");
    }
}
