using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public Transform attackPos;
    public float attackRange;
    public int damage;
   // public BoxCollider2D ShieldCollider;
    public static  bool flagFamagPlayer=true;
    public LayerMask PlayerMask;
    GameObject gj;
    private void Start()
    {
        gj = GameObject.FindGameObjectWithTag("Player");

    }
    private void OnDrawGizmosSelected()
    {
        if (gameObject!=null) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
    }
    public void OnAttack()
    {
        if (AttackEnemy.flagFamagPlayer) {
            if (attackPos != null)
            {
                Collider2D[] PlayerAttack = Physics2D.OverlapCircleAll(attackPos.position, attackRange, PlayerMask);
                for (int i = 0; i < PlayerAttack.Length; i++)
                {
                    PlayerAttack[i].GetComponent<PlayerControll>().TakeDamage(damage);
                }
            }
        }
    }
        
       


    }

   
    
