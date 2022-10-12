using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    //добавить увелечение жизней боссу.
    public int Count=0;
    public EnemyControl enemy;
    public ArcherControl archer;
    public int HealthArcher = 0;
    public int HealthEnemy = 0;
    private void Start()
    {
        archer.health = HealthArcher;
        enemy.health= HealthEnemy;
 
    }
    private void Update()
    {
        ChekScore();
    }
    public void ChekScore()
    {
        
        if (PlayerControll.Scorem >= Count)
        {
            archer.health += 2;
            enemy.health += 5;
            Count += 10;
            
        }
    }
}
