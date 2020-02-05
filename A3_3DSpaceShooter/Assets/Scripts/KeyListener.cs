using UnityEngine;
using System.Collections;

public class KeyListener : MonoBehaviour
{

    public Transform menuInGame;
    public Transform resumeBTN;

    public GameController controller;
    
    public bool check;
    void Start()
    {
        check = true;
        if (menuInGame.gameObject.activeInHierarchy == true)
        {
            menuInGame.gameObject.SetActive(false);

        }
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (Time.timeScale == 1.0f && !controller.isGameOver())
            {
               
               
                Time.timeScale = 0;
                Cursor.visible = true;
                menuInGame.gameObject.SetActive(true);
                //check = !check;

            }
            else if (Time.timeScale == 0 && !controller.isGameOver())
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                menuInGame.gameObject.SetActive(false);
            }
        }

        if(controller.isGameOver() && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            menuInGame.gameObject.SetActive(true);
            resumeBTN.gameObject.SetActive(false);
            
        }

    }


    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        menuInGame.gameObject.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Application.LoadLevel(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public void Exist()
    {
        Application.Quit();
    }

}
