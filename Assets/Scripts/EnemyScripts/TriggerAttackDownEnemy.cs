using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttackDownEnemy : MonoBehaviour
{
    public static bool flagDown = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flagDown = true;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        flagDown = false;
    }
}
