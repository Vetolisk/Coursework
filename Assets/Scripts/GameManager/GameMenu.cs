using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{


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
