using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttackUpEnemy : MonoBehaviour
{
    public static bool flagUp = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flagUp = true;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        flagUp = false;
    }
}
