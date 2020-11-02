using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{


    public Transform groundPoint;
    public ObjectPooler[] groundPollers;
    private float[] groundWidth;
    public Transform minHeightPoint;
    public Transform maxHeightPoint;


    private float minY;
    private float maxY;

    public float minGap;
    public float maxGap;


    public Rigidbody rb1;
    public Rigidbody rb2;
    public Rigidbody rb3;

    private CoinsGenerator coinGenerator;

    private SpikeGenerator spikeGenerator;

    private EnemyGenerator enemyGenerator;

    void Start()
    {

        minY = minHeightPoint.position.y;
        maxY = maxHeightPoint.position.y;

        groundWidth = new float[groundPollers.Length];
        for (int i = 0; i < groundPollers.Length; i++)
        {
            groundWidth[i] = groundPollers[i].pooledObject.GetComponent<BoxCollider>().size.x;
        }

        coinGenerator = FindObjectOfType<CoinsGenerator>();

        spikeGenerator = FindObjectOfType<SpikeGenerator>();

        enemyGenerator = FindObjectOfType<EnemyGenerator>();


        
    }



    
    void Update()
    {
        if (transform.position.x < groundPoint.position.x)
        {
            int random = Random.Range(0, groundPollers.Length);
            float distance = groundWidth[random] / 4;

            float gap = Random.Range(minGap, maxGap);
            float height = Random.Range(minY, maxY);

            transform.position = new Vector3(
                transform.position.x + distance + gap,
                height,
                transform.position.z
            );

            GameObject ground = groundPollers[random].GetPooledGameObject();
            ground.transform.position = transform.position;
            ground.GetComponent<Rigidbody>().isKinematic = true;
            ground.SetActive(true);
           

            coinGenerator.SpawnCoins(
                transform.position,
                groundWidth[random]
            );

            spikeGenerator.SpawnSpikes(
                transform.position,
                groundWidth[random]
            );


            enemyGenerator.SpawnEnemy(
                 transform.position,
                groundWidth[random]
            );

            transform.position = new Vector3(
                transform.position.x + distance,
                transform.position.y,
                transform.position.z
            );

        }
    }
}
