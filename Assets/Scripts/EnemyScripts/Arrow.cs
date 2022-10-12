using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider!=null)
        {
            if(hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlayerControll>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Shield"))
            {
                Destroy(gameObject);
            }
                Destroy(gameObject);
        }
        
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }
}
