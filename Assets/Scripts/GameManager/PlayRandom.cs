using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandom : MonoBehaviour
{
    public AbstractDungeonGenerator abstractDungeonGenerator;
    void Start()
    {
        abstractDungeonGenerator.GenerateDungeon();
    }

    
}
