using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private float timeBtwShots;
    public float startTimeBtwShots;



    public GameObject bullet;

    




    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

   
    void Update()
    {
        if (timeBtwShots <= 0)
        {

            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {

            timeBtwShots -= Time.deltaTime;

        }
    }
}
