using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject Arrow;
    public Transform showPoint;
    private float timeBtwShots;
    public  float startBtwShots;
  [SerializeField]  private PlayerControll player;
    private Vector3 different;
    private float rotZ;
    public float offset;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
    }
    private void Update()
    {
        different = player.transform.position - transform.position;
        rotZ = Mathf.Atan2(different.y, different.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ-90 + offset);
        if (timeBtwShots<=0)
        {
            
            Shoot();
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }
    public void Shoot()
    {
        Instantiate(Arrow, showPoint.position, showPoint.rotation);
        timeBtwShots = startBtwShots;
    }
}
