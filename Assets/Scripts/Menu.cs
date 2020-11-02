using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    public GameObject startbtn;
    public GameObject optionsbtn;
    public GameObject quitbtn;
    public GameObject backbtn;



    public GameObject startbtnui;
    public GameObject optionsbtnui;
    public GameObject quitbtnui;


    


    public GameObject optionsWindow;


    public void btn_change_scene(string scene_name)
    {


        SceneManager.LoadScene(scene_name);




    }


    public void btn_quit_game()
    {

        Application.Quit();


    }

    public void btn_options()
    {

        startbtn.SetActive(false);
        optionsbtn.SetActive(false);
        quitbtn.SetActive(false);

        startbtnui.SetActive(false);
        optionsbtnui.SetActive(false);
        quitbtnui.SetActive(false);

        optionsWindow.SetActive(true);
        backbtn.SetActive(true);



    }
   
    public void btn_back()
    {

        startbtn.SetActive(true);
        optionsbtn.SetActive(true);
        quitbtn.SetActive(true);

        startbtnui.SetActive(true);
        optionsbtnui.SetActive(true);
        quitbtnui.SetActive(true);

        optionsWindow.SetActive(false);
        backbtn.SetActive(false);




    }

}
