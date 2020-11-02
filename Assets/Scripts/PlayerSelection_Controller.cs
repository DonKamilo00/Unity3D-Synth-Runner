using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelection_Controller : MonoBehaviour
{

    [System.Serializable]
    public class MenuPlayer
    {
        [Header("Details")]
        public string name;
        public int price;
        public bool unlocked;
    }



    public static PlayerSelection_Controller instance;

    public GameObject[] playerList;
    public int index;

    public GameObject buyButton, levelPlayButton;


    [Header("Player selection")]
    public MenuPlayer[] menuPlayers;


    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll ();


        index = PlayerPrefs.GetInt("PlayerSelected");

        playerList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            playerList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in playerList)
        {
            go.SetActive(false);
        }
        if (playerList[index])
        {
            playerList[index].SetActive(true);
        }

        //FillPlayerList ();
        CheckForUnlockedPlayer();
    }

    public void PrevPlayerButton()
    {
        playerList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = playerList.Length - 1;
        }

        playerList[index].SetActive(true);

        //BUY BUTTON ACTIVATE
        if (!menuPlayers[index].unlocked)
        {
            buyButton.SetActive(true);
        }
        else
        {
            buyButton.SetActive(false);
        }
    }

    public void NextPlayerButton()
    {
        playerList[index].SetActive(false);

        index++;
        if (index == playerList.Length)
        {
            index = 0;
        }

        playerList[index].SetActive(true);

        //BUY BUTTON ACTIVATE
        if (!menuPlayers[index].unlocked)
        {
            buyButton.SetActive(true);
        }
        else
        {
            buyButton.SetActive(false);
        }

    }

    public void LoadGameScene()
    {
        PlayerPrefs.SetInt("PlayerSelected", index);
        SceneManager.LoadScene("Game");
    }

    private void CheckForUnlockedPlayer()
    {
        //Check for unlokced players
        for (int i = 0; i < menuPlayers.Length; i++)
        {
            //First check if the player is pre-unlocked
            if (menuPlayers[i].unlocked)
            {
                PlayerPrefs.SetInt(menuPlayers[i].name, 1);
            }

            if (PlayerPrefs.GetInt(menuPlayers[i].name) == 1)
            {
                menuPlayers[i].unlocked = true;
            }
            else
            {
                menuPlayers[i].unlocked = false;
            }
        }
    }

    public void BuyButton()
    {
        //if (GameController.instance.totalCoins >= menuPlayers [index].price)
        {
            menuPlayers[index].unlocked = true;
            PlayerPrefs.SetInt(menuPlayers[index].name, 1);
            buyButton.SetActive(false);
            print("PURCHASED");
        }
    }
}
