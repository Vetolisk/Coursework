using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpriteAttack : MonoBehaviour
{
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public Sprite[] sprites;
    int i = 0;
    private void Start()
    {
        
        
    }
    private void Update()
    {
        if (timeBtwAttack <= 0)
        {

            timeBtwAttack = startTimeBtwAttack;

            
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
            i++;
            if (i > 2)
            {
                Destroy(gameObject);
            }


        }
        else
        {

            timeBtwAttack -= Time.deltaTime;
        }
    }
}
