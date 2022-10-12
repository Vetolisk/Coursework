using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttackUp : MonoBehaviour
{
    public static bool flagUp = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy"|| collision.tag == "EnemyArcher")
        {
            flagUp = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        flagUp = false;
    }
}
