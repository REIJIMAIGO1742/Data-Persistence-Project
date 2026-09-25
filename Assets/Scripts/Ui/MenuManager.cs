using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI baseScoreText;
    private int highScore;
    private string playerName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = Gamemanager.instance.highScore;
        playerName = Gamemanager.instance.playerHighScore;
        baseScoreText.text = $"Best Score : {playerName} : {highScore}";
    }

    public void OnEndEdit(string playerName)
    {
        Gamemanager.instance.PlayerName(playerName);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }


    public void Exit()
    {
        Gamemanager.instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

#else
        Application.Quit();
#endif
        
    }

}
