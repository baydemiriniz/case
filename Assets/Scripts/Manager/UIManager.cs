using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   [Header("Level Panel Settings")]
   public GameObject startPanel;
   public GameObject retryPanel;
   public GameObject wonPanel;
   [Header("Info Text")] 
   public TextMeshProUGUI levelTxt;
   private void Start()
   {
      int i = PlayerPrefs.GetInt("CurrentLevel") + 1;
      levelTxt.text = "LEVEL " + i;
   }

   public void LevelWon()
   {
      SceneManager.LoadScene("Game");
      PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
      var i = PlayerPrefs.GetInt("CurrentLevel") + 1;
      levelTxt.text = "LEVEL " + i;
   }

   public void LevelFail()
   {
      SceneManager.LoadScene("Game");
      int i = PlayerPrefs.GetInt("CurrentLevel") + 1;
      levelTxt.text = "LEVEL " + i;
   }
}
