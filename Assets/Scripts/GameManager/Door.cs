using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Door : MonoBehaviour
{
    
 
    public  TilemapVisualizer tilemap;
    public Tilemap Objects;
    public GameObject Player;
    public TileBase DoorTile;
    public GridLayout gridLayout;
   
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
       
    //    if (collision.gameObject.tag == "Player")
    //    {

            
    //        foreach (var position in tilemap.tiledoor)
    //        {              
    //            bool FlagXMin = true;       
    //            bool FlagYMin = true;
    //            var Pos =new Vector3 (collision.collider.bounds.center.x, collision.collider.bounds.center.y);
    //                Vector3 newPos = Vector3Int.FloorToInt(Pos);



    //            if (newPos.x != position.x)
    //            {

    //                for (int i = 0; i < 1; i++)
    //                {
    //                    newPos = new Vector3(newPos.x + 1, newPos.y, 0);
    //                    if (newPos.x == position.x)
    //                    {
    //                        FlagXMin = false;
    //                        break;

    //                    }
    //                }
    //                if (FlagXMin)
    //                {


    //                    newPos = Vector3Int.FloorToInt(Pos);
    //                    for (int i = 0; i < 1; i++)
    //                    {
    //                        newPos = new Vector3(newPos.x - 1, newPos.y, 0);
    //                        if (newPos.x == position.x)
    //                        {

    //                            break;
    //                        }
    //                    }
    //                }
    //            }
    //             if (newPos.y != position.y)
    //            {
    //                for (int i = 0; i < 1; i++)
    //                {
    //                    newPos = new Vector3(newPos.x, newPos.y + 1, 0);
    //                    if (newPos.y == position.y)
    //                    {
    //                        FlagYMin = false;
    //                        break;
    //                    }

    //                }
    //                if (FlagYMin) {
    //                    newPos = Vector3Int.FloorToInt(Pos);
    //                    for (int i = 0; i < 1; i++)
    //                    {
    //                        newPos = new Vector3(newPos.x, newPos.y - 1, 0);
    //                        if (newPos.y == position.y && FlagYMin)
    //                        {

    //                            break;
    //                        }
    //                    }
    //                }
    //            }
    //                if (newPos.x == position.x && newPos.y == position.y)
    //                {          
    //                    Objects.SetTile(position, null);
                   
    //                }
    //            }
                       
    //        }
    //    }
    }

   


























//var Pos =new Vector3 (collision.collider.bounds.center.x, collision.collider.bounds.center.y);
//Vector3 newPos = Vector3Int.FloorToInt(Pos);
//bool Flag = false ;
//foreach (var item in tilemap.tiledoor)
//{
//    //if (newPos.x == item.x|| newPos.y == item.y)
//    //{
//    //    Objects.SetTile(item, null);

//    //}
//}