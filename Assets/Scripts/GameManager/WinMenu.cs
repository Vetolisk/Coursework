using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using YG;
//Сделать через Action
public class WinMenu : MonoBehaviour
{
    public GameObject ButtonResume;
    public GameObject canvas;
    public GameObject particle;
    public GameObject player;
    public GameObject WinText;
    public GameObject canvasWIn;
    public GameObject ButtonCanvasLoose;
    public GameObject ButtonRestartLoose;
    public GameObject ButtonCanvasWin;
    public TMP_Text myText;
    public AbstractDungeonGenerator generator;
    public static bool FlagRestartVideo = false;
    private void Start()
    {
        Invoke("SetMenu", 1.30f);
    }
    public void SetMenu()
    {
        canvas.SetActive(false);
    }
    private void Update()
    {
        if (CreateEvent.FlagWinMenu)
        {
            SetWin();
            CreateEvent.FlagWinMenu = false;
        }
    }
    void SetWin()
    {
            myText.text = "You Win!";
            canvasWIn.SetActive(true);
            Vector3 pos = player.transform.position;
            Instantiate(particle, new Vector3(pos.x, pos.y + 3, 0), Quaternion.identity);
            WinText.SetActive(true);
            StartCoroutine("YouCoroutine");
    }
   public void SetLooseMenu()
    {
        myText.text = "You Lose!";
        canvasWIn.SetActive(true);
        WinText.SetActive(true);
        ButtonCanvasLoose.SetActive(true);
        ButtonRestartLoose.SetActive(true);
    }
    public void DeliteWinMenu(){
        ButtonCanvasWin.SetActive(false);
        ButtonCanvasLoose.SetActive(false);
        ButtonRestartLoose.SetActive(false);
        player.GetComponent<PlayerControll>().enabled = true;
        player.GetComponent<PlayerAttack>().enabled = true;
        canvasWIn.SetActive(false);
        if (GameObject.Find("Particle System(Clone)")!=null)
        {
            Destroy(GameObject.Find("Particle System(Clone)"));
        }
        Vector3 pos = player.transform.position;
        WinText.SetActive(false);
        generator.GenerateDungeon();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
    public void Video()
    {
        YandexGame.RewVideoShow(0);
        ButtonRestartLoose.SetActive(false);
        WinText.SetActive(false);
        ButtonResume.SetActive(true);
    }
    public void RestartVideo()
    {
        
        FlagRestartVideo = true;
        canvasWIn.SetActive(false);
        WinText.SetActive(false);
        ButtonCanvasLoose.SetActive(false);
        player.GetComponent<PlayerControll>().live = true;
        player.SetActive(true);
        player.GetComponent<PlayerControll>().enabled = true;
        player.GetComponent<PlayerAttack>().enabled = true;
        player.GetComponent<PlayerControll>().currentHealth = 50;
        ButtonResume.SetActive(false);
    }
    IEnumerator YouCoroutine()
    {

        yield return new WaitForSeconds(3f);
        WinText.SetActive(false);
    }
}
