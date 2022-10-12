using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Animator anim;
   public GameObject player;
    public GameObject generator;
    public AbstractDungeonGenerator ADG;
    public static bool Flag=false;
    private void Start()
    {
        anim=GetComponent<Animator>();
        player = GameObject.Find("Player");
        generator = GameObject.FindGameObjectWithTag("RFD");
        ADG = generator.GetComponent<AbstractDungeonGenerator>();
      
    }
    private void Update()
    {
        if (Flag)
        {
            ADG.GenerateDungeon();
            Flag = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.SetActive(false);
            Flag = true;
        }

    }
    public void CreatePortal(Vector3 Pos)
    {
        GameObject p=  Instantiate(gameObject, Pos, Quaternion.identity);
        p.GetComponent<BoxCollider2D>().enabled = true;
        
    }

}
