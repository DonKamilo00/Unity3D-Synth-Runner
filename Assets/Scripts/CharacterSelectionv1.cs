using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionv1 : MonoBehaviour
{

    [SerializeField]
    Text MoneyText;



    private GameObject[] characterList;
    private int index;

    public int Money;

    int Char_1;
    int Char_2;
    int Char_3;
    int Char_4;
    int Char_5;
    int Char_6;
    int Char_7;
    int Char_8;
    int Char_9;
    int Char_10;

    public void Start()
    {

        index = PlayerPrefs.GetInt("CharacterSelected");


        Money = PlayerPrefs.GetInt("Money");
        MoneyText.text = Money.ToString();

        Char_1 = PlayerPrefs.GetInt("char1");
        Char_2 = PlayerPrefs.GetInt("char2");
        Char_3 = PlayerPrefs.GetInt("char3");
        Char_4 = PlayerPrefs.GetInt("char4");
        Char_5 = PlayerPrefs.GetInt("char5");
        Char_6 = PlayerPrefs.GetInt("char6");
        Char_7 = PlayerPrefs.GetInt("char7");
        Char_8 = PlayerPrefs.GetInt("char8");
        Char_9 = PlayerPrefs.GetInt("char9");
        Char_10 = PlayerPrefs.GetInt("char10");






        characterList = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        foreach(GameObject go in characterList)
            go.SetActive(false);


        if (characterList[index])
            characterList[index].SetActive(true);
    }


    








   

    public void ToggleLeft()
    {

        characterList[index].SetActive(false);

        index--;
        if(index < 0)
        {
            index = characterList.Length - 1;
        }

        characterList[index].SetActive(true);

    }

    public void ToggleRight()
    {

        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        characterList[index].SetActive(true);

    }


    private void Update()
    {
        
        



    }



    public void SelectButton()
    {

      

                PlayerPrefs.SetInt("CharacterSelected", index);







            
        
      






    }

}
