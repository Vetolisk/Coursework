using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject gj;
    public PlayerControll playerControll;
    public HealthBar healthBar;
    public ParticleSystem particle;
    public int PlusHil;
    bool flag = true;
    private void Start()
    {
        gj = GameObject.FindGameObjectWithTag("Player");
        playerControll = gj.GetComponent<PlayerControll>();
     
        healthBar = gj.GetComponent<PlayerControll>().healthBar;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (gj!=null) {
            if (collision.gameObject.tag == "Player" && playerControll.currentHealth < playerControll.health&& flag)
            {
                playerControll.currentHealth += PlusHil;
                if (playerControll.currentHealth > playerControll.health)
                {
                    int Count;
                    Count = playerControll.currentHealth - playerControll.health;
                    playerControll.currentHealth -= Count;
                }
                healthBar.SetHealth(playerControll.currentHealth);
                Destroy(gameObject);
                Instantiate(particle, gameObject.transform.position, Quaternion.identity);
                flag = false;
            }
        }
    }
}
