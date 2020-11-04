using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class deathmenu : MonoBehaviour
{


    public GameObject deathMenu;
    public GameObject playerPrefab;

    private CoinPicker coinPicker;
    private GameManager gameManager;

    private ScoreManager scoreManager;

    private bool isAdded = false;


    // Start is called before the first frame update

    void Start()
    {
        isAdded = false;
        Time.timeScale = 1;
        deathMenu.SetActive(false);
        scoreManager = FindObjectOfType<ScoreManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPrefab.activeSelf == false)
        {



            

            if (!isAdded)
            {
                addMoney();
                isAdded = true;
            }



            
            Time.timeScale = 0;
            deathMenu.SetActive(true);
            




        }
            

    }
    
    public void addMoney()
    {


        
        

            Debug.Log("DODAJE");
            GameManager.Instance.currency += scoreManager.moneyCollected;
            GameManager.Instance.Save();
            



    }



    public void toogleDeathMenu()
    {






    }

    public void restartGame()
    {
        SceneManager.LoadScene("game");

    }

    public void backToMenu()
    {

        SceneManager.LoadScene("Hub");


    }
}
