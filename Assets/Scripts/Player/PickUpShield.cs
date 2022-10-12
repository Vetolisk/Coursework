using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpShield : MonoBehaviour
{
    public GameObject gj;
    public GameObject ShieldSet;
    public GameObject ButtonUI;
    public GameObject txt;
    public static bool SetShield;
    private void Awake()
    {
        SetShield = true;
    }
    void Start()
    {
        gj = GameObject.FindGameObjectWithTag("Player");
        ShieldSet = GameObject.FindGameObjectWithTag("Shield");
        if (ApplicationPlatform.FlagMob)
        {
            ButtonUI = GameObject.FindGameObjectWithTag("ShieldB");
        }
            txt = GameObject.FindGameObjectWithTag("txt");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gj != null)
        {
            if (ApplicationPlatform.FlagMob)
            {
                if (collision.gameObject.tag == "Player")
                {

                    ShieldSet.GetComponent<SpriteRenderer>().enabled = true;
                    ShieldSet.GetComponent<BoxCollider2D>().enabled = true;
                    ButtonUI.GetComponent <Image>().enabled= true;
                    ButtonUI.GetComponent <Button>().enabled= true;
                    txt.GetComponent<TextMeshProUGUI>().enabled = true;
                    SetShield = false;
                    Destroy(gameObject);
                }
            }
            else
            {
                if (collision.gameObject.tag == "Player")
                {

                    ShieldSet.GetComponent<SpriteRenderer>().enabled = true;
                    ShieldSet.GetComponent<BoxCollider2D>().enabled = true;
                    SetShield = false;
                    Destroy(gameObject);
                }
            }
           
        }
    }

}
