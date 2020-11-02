using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStuff : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject Player;

    void Start()
    {

        Instantiate(Player, spawnPoint);

    }

  
}
