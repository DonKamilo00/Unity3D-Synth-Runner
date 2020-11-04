using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{


   
    private ScoreManager scoreManager;


    public int coinvalue = 5;


    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name =="Player")
        {
            scoreManager.moneyCollected += coinvalue;
            gameObject.SetActive(false);
            


           
        }
    }

  

}
