using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ScoreSave : MonoBehaviour
{
  
    public GameObject canvas;
    public TMP_Text myText;
    public float ScoreSaves;
    public static float Score;
    public GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        ScoreSaves = PlayerPrefs.GetFloat("Player Score");
        canvas.SetActive(false);
    }
    private void Update()
    {
        DeadPlayer();
    }
    
   

    public void DeadPlayer()
    {
        if (!player.GetComponent<PlayerControll>().live)
        {
            if (PlayerControll.Scorem> ScoreSaves)
            {
                PlayerPrefs.SetFloat("Player Score", PlayerControll.Scorem);
            }
            myText.text ="Best Score "+ ScoreSaves;
            canvas.SetActive(true);
        }
        if (WinMenu.FlagRestartVideo)
        {
            myText.text = " ";
            
        }
    }
}
