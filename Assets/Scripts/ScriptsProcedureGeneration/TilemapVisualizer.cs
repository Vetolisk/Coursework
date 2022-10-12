using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    public CreateEvent createEvent;
    private GameObject[] gameObjects;
    [SerializeField]
    public GameObject Trigger;
    [SerializeField]
    public List<Vector3Int> tiledoor;
    [SerializeField]
    public Tilemap floorTilemap, wallTilemap,Objects;
    [SerializeField]
    private TileBase floorTile, wallTop, wallSideRight, wallSiderLeft, wallBottom, wallFull, 
        wallInnerCornerDownLeft, wallInnerCornerDownRight, 
        wallDiagonalCornerDownRight, wallDiagonalCornerDownLeft, wallDiagonalCornerUpRight, wallDiagonalCornerUpLeft,Door;
    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile);

    }
    public void PaintTrapTiles(IEnumerable<Vector2Int> floorPositions)
    {
        
        PaintTiles(floorPositions, Objects, Door);
        
    }
    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }
    internal void PaintSingleBasicWall(Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;
        if (WallTypesHelper.wallTop.Contains(typeAsInt))
        {
            tile = wallTop;
        }else if (WallTypesHelper.wallSideRight.Contains(typeAsInt))
        {
            tile = wallSideRight;
        }
        else if (WallTypesHelper.wallSideLeft.Contains(typeAsInt))
        {
            tile = wallSiderLeft;
        }
        else if (WallTypesHelper.wallBottm.Contains(typeAsInt))
        {
            tile = wallBottom;
        }
        else if (WallTypesHelper.wallFull.Contains(typeAsInt))
        {
            tile = wallFull;
        }

        if (tile!=null)
            PaintSingleTile(wallTilemap, tile, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);

        tilemap.SetTile(tilePosition, tile);
    }
    //создание тригера
    public void SetTriggers(List<BoundsInt> roomsList)
    {
        Vector3 newPos = Vector3.zero;
        GameObject jg;
        for (int i = 0; i < roomsList.Count; i++)
        {
            
            if (i>0)
            {               
                jg = Instantiate(Trigger, new Vector3(roomsList[i].center.x, roomsList[i].center.y, 0), Quaternion.identity);

                jg.AddComponent<BoxCollider2D>().size = new Vector2(roomsList[i].size.x - 6, roomsList[i].size.y - 6);
                jg.GetComponent<BoxCollider2D>().isTrigger = true;
                if (i == roomsList.Count-1)
                {
                    jg.tag = "TriggerBos";
                    
                }
            }
            


        }

    }
    public void DeleteTriggers()
    {

        gameObjects = GameObject.FindGameObjectsWithTag("Trigger");
        for (int i = 0; i < gameObjects.Length; ++i)
        {
            if (gameObjects[i] != null)
            {
                DestroyImmediate(gameObjects[i], true);
                //Destroy(gameObjects[i]);
            }

        }
        gameObjects = GameObject.FindGameObjectsWithTag("TriggerBos");
        for (int i = 0; i < gameObjects.Length; ++i)
        {
            if (gameObjects[i] != null)
            {
               DestroyImmediate(gameObjects[i], true);
                //Destroy(gameObjects[i]);
            }
        }
        gameObjects = GameObject.FindGameObjectsWithTag("HP");
        for (int i = 0; i < gameObjects.Length; ++i)
        {
            if (gameObjects[i] != null)
            {
                DestroyImmediate(gameObjects[i], true);
                //Destroy(gameObjects[i]);
            }
        }
        gameObjects = GameObject.FindGameObjectsWithTag("ShieldItem");
        for (int i = 0; i < gameObjects.Length; ++i)
        {
            if (gameObjects[i] != null)
            {
                DestroyImmediate(gameObjects[i], true);
                //Destroy(gameObjects[i]);
            }
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Cube");
        for (int i = 0; i < gameObjects.Length; ++i)
        {
            if (gameObjects[i] != null)
            {
                DestroyImmediate(gameObjects[i], true);
                //Destroy(gameObjects[i]);
            }
        }

    }
   
     
        
       public void SetTrap( Vector3 col, Vector3Int newPos)
       {
        HashSet<Vector2Int> trap = new HashSet<Vector2Int>();
        TileBase tile = floorTilemap.GetTile(newPos);


        for (int j = 0; j < col.y; j++)
        {

            tile = floorTilemap.GetTile(newPos);
            if (tile != null)
            {
                trap.Add(new Vector2Int(newPos.x, newPos.y));
                tiledoor.Add(newPos);

            }
            newPos += Vector3Int.up;
        }

        for (int s = 0; s < col.x; s++)
        {

            tile = floorTilemap.GetTile(newPos);
            if (tile != null)
            {
                    trap.Add(new Vector2Int(newPos.x, newPos.y));
                    tiledoor.Add(newPos);
            }

            newPos += Vector3Int.right;
        }

        for (int j = 0; j < col.y; j++)
        {

            tile = floorTilemap.GetTile(newPos);
            if (tile != null)
            {
                trap.Add(new Vector2Int(newPos.x, newPos.y));
                tiledoor.Add(newPos);


            }
            newPos += Vector3Int.down;

        }

        for (int s = 0; s < col.x; s++)
        {

            tile = floorTilemap.GetTile(newPos);
            if (tile != null)
            {
                trap.Add(new Vector2Int(newPos.x, newPos.y));
                tiledoor.Add(newPos);

            }
            newPos += Vector3Int.left;
        }




        PaintTrapTiles(trap);
    }
    

    public void Clear()
    {
        DeleteTriggers();
        tiledoor.Clear();   
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
        Objects.ClearAllTiles();
       
    }

    internal void PaintSingleCornerWall(Vector2Int position, string binaryType)
    {
        int typeASInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;

        if (WallTypesHelper.wallInnerCornerDownLeft.Contains(typeASInt))
        {
            tile = wallInnerCornerDownLeft;
        }
        else if (WallTypesHelper.wallInnerCornerDownRight.Contains(typeASInt))
        {
            tile = wallInnerCornerDownRight;
        }
        else if (WallTypesHelper.wallDiagonalCornerDownLeft.Contains(typeASInt))
        {
            tile = wallDiagonalCornerDownLeft;
        }
        else if (WallTypesHelper.wallDiagonalCornerDownRight.Contains(typeASInt))
        {
            tile = wallDiagonalCornerDownRight;
        }
        else if (WallTypesHelper.wallDiagonalCornerUpRight.Contains(typeASInt))
        {
            tile = wallDiagonalCornerUpRight;
        }
        else if (WallTypesHelper.wallDiagonalCornerUpLeft.Contains(typeASInt))
        {
            tile = wallDiagonalCornerUpLeft;
        }
        else if (WallTypesHelper.wallFullEightDirections.Contains(typeASInt))
        {
            tile = wallFull;
        }
        else if (WallTypesHelper.wallBottmEightDirections.Contains(typeASInt))
        {
            tile = wallBottom;
        }

        if (tile != null)
            PaintSingleTile(wallTilemap, tile, position);
    }
}
