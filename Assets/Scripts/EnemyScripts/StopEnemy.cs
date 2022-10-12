using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopEnemy : MonoBehaviour
{
    public EnemyControl enemy;
    public Animator anim;
    public bool flag;
    public GameObject Player;
    private float timeBtwShots;
    public float startBtwShots;
    public AttackEnemy attackEnemy;

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


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flag = false;
            enemy.speed = 2;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
            if (collision.tag == "Player")
            {
                enemy.speed = 0;
                if (timeBtwShots <= 0 && flag)
                {
                    if (TriggerAttackDownEnemy.flagDown)
                    {

                        anim.SetTrigger("AttackDown");

                        Invoke("OnAnimAttack", 0.4f);


                    }
                    else if (TriggerAttackUpEnemy.flagUp)
                    {

                        anim.SetTrigger("AttackUp");
                        Invoke("OnAnimAttack", 0.07f);

                    }
                    else
                    {

                        anim.SetTrigger("enemyAttack");
                        Invoke("OnAnimAttack", 0.2f);


                    }
                    timeBtwShots = startBtwShots;
                }
            }
        
        

    }
    public void OnAnimAttack() {
        
            attackEnemy.OnAttack();
        
        
    }
   
    

}
