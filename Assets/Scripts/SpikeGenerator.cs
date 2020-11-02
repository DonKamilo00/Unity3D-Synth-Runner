using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{

    public ObjectPooler spikePooler;

    public void SpawnSpikes(Vector3 position, float groundWidth)
    {

        int random = Random.Range(1, 100);

        if (random < 50)
            return;


        int numberOfSpikes = (int)Random.Range(1f, 3f);
        float y = Random.Range(1, 1);

        for (int i = 0; i < numberOfSpikes; i++)
        {
            GameObject spike = spikePooler.GetPooledGameObject();

            float x = position.x - (groundWidth / 4) + 1;

            spike.transform.position = new Vector3(
                x + i,
                position.y + y,
                3.2f
            );

            spike.SetActive(true);
        }
    }
}
