using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class MenuScript : MonoBehaviour
{
    public GameObject canvasLoad;
    private Animator anim;
    private void Start()
    {
       
        CreateEvent.EnemyCount = 1;
            anim = canvasLoad.GetComponent<Animator>();      
    }

    public void PlayGame()
    {
        canvasLoad.SetActive(true);
        anim.SetTrigger("Play");
        Invoke("ChengeMenu",1.30f);


    }
    public void ChengeMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
    
}
