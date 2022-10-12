using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttackDown : MonoBehaviour
{
    public static bool flagDown = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "EnemyArcher")
        {
            flagDown = true;
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        flagDown = false;
    }
}
