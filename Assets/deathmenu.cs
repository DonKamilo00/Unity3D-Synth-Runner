using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class deathmenu : MonoBehaviour
{


    public GameObject deathMenu;
    public GameObject playerPrefab;
    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 1;
        deathMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPrefab.activeSelf == false)
        {
            Time.timeScale = 0;
            deathMenu.SetActive(true);


        }
            

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
