using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTakePlayerDamag : MonoBehaviour
{
    private GameObject Player;
    bool flag;
    private float timeBtwShots;
    public float startBtwShots;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (timeBtwShots <= 0)
        {
            flag = true;
        }
        else
        {
            flag = false;
            timeBtwShots -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            flag = false;

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "Player"&&flag)
        {

            Player.GetComponent<PlayerControll>().TakeDamage(3);
            timeBtwShots = startBtwShots;
        }
    }

}
