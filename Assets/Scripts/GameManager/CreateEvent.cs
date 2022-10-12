using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateEvent : MonoBehaviour
{
    public GameObject[] ListEnemy;
    BoxCollider2D boxCollider;
    public GameObject EnemyBos;
    public Vector3Int GlobPos;
    public Vector3 Glob;
    GameObject gj;
    public bool FlagBos;
    public static bool FlagWinMenu = false;
    public PickUp LivePotion;
    public bool FlagEnemy;
    public int Count;
    public int MaxEnemy;
    public static int EnemyCount;
    public bool  FlagsPlayer;
    public GameObject Portal;
    public Vector3 PotralPos;
    public GameObject ShieldItem;
    public GameObject FlagCubeFinishTrigger;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        gj = GameObject.Find("TilemapVisualizer");
        Count = 20;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&FlagsPlayer)
        {
            if (gameObject.tag == "Trigger")
            {
                CreateEnemy();
                FlagEnemy = true;
            }
            else if (gameObject.tag == "TriggerBos")
            {
                CreateEnemyBos();

                FlagBos = true;
            }
            
      
            //Debug.Log(boxCollider.size.x); // размер тригера
            Vector3 vector3 = new Vector3(boxCollider.bounds.min.x - 2, boxCollider.bounds.min.y - 2);
            Glob = new Vector3(boxCollider.size.x + 3, boxCollider.size.y + 3);
            Vector3Int newPos = Vector3Int.FloorToInt(vector3);
            GlobPos = newPos;

            gj.GetComponent<TilemapVisualizer>().SetTrap(Glob, GlobPos);
            boxCollider.enabled = false;
            FlagsPlayer = false;
        }
        
    }

    public  void CreateEnemyBos()
    {

        Vector3 position = new Vector3(Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.min.x + boxCollider.size.x), Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.min.y + boxCollider.size.y));
        Instantiate(EnemyBos, position, Quaternion.identity);
        PotralPos = position;
    }
    private void CreateEnemy()
    {
        if (PlayerControll.Scorem >= Count)
        {
            Count += 10;
            if (EnemyCount <= 4)
            {
                EnemyCount += 1;
            }
        }
            for (int j = 0; j < EnemyCount; j++)
            {
                Vector3 position = new Vector3(Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.min.x + boxCollider.size.x), Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.min.y + boxCollider.size.y));
                int Rand = Random.Range(0, 100);
            if (Rand>25)
            {
                Instantiate(ListEnemy[0], position, Quaternion.identity);
            }else if (Rand<=25)
            {
                Instantiate(ListEnemy[1], position, Quaternion.identity);
            }
               
                position = new Vector3(Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.min.x + boxCollider.size.x), Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.min.y + boxCollider.size.y));
                
            }
        
        
    }
    public void SetPotion()
    {
        
        LivePotion.PlusHil = 10;
       // Debug.Log($"{boxCollider.transform.position.x} {boxCollider.transform.position.y}"); //позиция центра комнаты
       // Debug.Log($"{boxCollider.size.x} {boxCollider.size.y}"); //размер тригера комнаты
         float pos1 =boxCollider.transform.position.x - boxCollider.size.x+4; 
         float pos2 = boxCollider.transform.position.x + boxCollider.size.x-4;
         float pos3= boxCollider.transform.position.y - boxCollider.size.y+4;
        float pos4 = boxCollider.transform.position.y + boxCollider.size.y-4;
        //Debug.Log($"{pos1} {pos2} {pos3} {pos4}");
        Vector2 PosXY1 = new Vector2(pos1, pos3);
        Vector2 PosXY2 = new Vector2(pos2, pos3);
        Vector2 PosXY3 = new Vector2(pos1, pos4);
        Vector2 PosXY4 = new Vector2(pos2, pos4);

        Vector3 positionP = new Vector3(Random.Range(pos1,pos2 ), Random.Range(pos3,pos4));

            Instantiate(LivePotion, positionP, Quaternion.identity);
        Vector2 PosFinish = new Vector2(boxCollider.transform.position.x, boxCollider.transform.position.y);
        Instantiate(FlagCubeFinishTrigger, PosFinish, Quaternion.identity);
    }
    public void SetShield()
    {
       
        int n = Random.Range(0, 100);
        if (n<=50) {
            Vector3 positionP = new Vector3(Random.Range(boxCollider.transform.position.x, boxCollider.transform.position.x + boxCollider.size.x / 2), Random.Range(boxCollider.transform.position.y, boxCollider.transform.position.y + boxCollider.size.y / 2));
            Instantiate(ShieldItem, positionP, Quaternion.identity);
        }
            
        
        
    }
   
    public void SetBigPotion()
    {
        LivePotion.PlusHil = 50;
        Vector3 positionP = new Vector3(Random.Range(boxCollider.transform.position.x, boxCollider.transform.position.x + boxCollider.size.x / 2), Random.Range(boxCollider.transform.position.y, boxCollider.transform.position.y + boxCollider.size.y / 2));
        Instantiate(LivePotion, positionP, Quaternion.identity);

    }
    private void Update()
    {
       
        if (GameObject.FindGameObjectWithTag("Enemy") == null&& FlagEnemy&& GameObject.FindGameObjectWithTag("EnemyArcher") == null)
        {           
          // уберает плитки
          gj.GetComponent<TilemapVisualizer>().Objects.ClearAllTiles();
          SetPotion();
            FlagEnemy = false;


        }

        if (GameObject.FindGameObjectWithTag("Enemy") == null && FlagBos)
        {
            
            FlagWinMenu = true;
            FlagBos = false;
            SetBigPotion();
           
            SetShield();
               
            

            GameObject  p =  Instantiate(Portal, PotralPos,Quaternion.identity);
            p.GetComponent<BoxCollider2D>().enabled = true;

        }
        
    }
    

}
