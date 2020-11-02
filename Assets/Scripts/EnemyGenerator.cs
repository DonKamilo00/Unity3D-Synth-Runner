using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public ObjectPooler enemyPooler;

    public void SpawnEnemy(Vector3 position, float groundWidth)
    {

        int random = Random.Range(1, 100);

        if (random < 90)
            return;




        int numberOfEnemies = (int)1;


        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemy = enemyPooler.GetPooledGameObject();

            float x = position.x - groundWidth  + 1;


            enemy.transform.position = new Vector3(position.x - (groundWidth / 4) + i, position.y + 1, position.z);

            enemy.SetActive(true);
        }



    }
}
