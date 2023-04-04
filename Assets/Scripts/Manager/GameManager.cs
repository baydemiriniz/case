using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public PlayerController playerController;
    public UIManager UIManager;
    public LevelManager levelManager;
    public Level currentLevel;
    public bool levelStart;
    void Start()
    {
        Instance = this;
        levelManager.CreateLevel();
    }

    public void GameStartClick()
    {
        levelStart = true;
        UIManager.startPanel.SetActive(false);
    }
 
}
