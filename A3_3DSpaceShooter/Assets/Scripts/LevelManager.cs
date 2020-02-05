using System.Collections;

using UnityEngine;
//using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    //public void LoadByIndex (int sceneIndex) {

    //       SceneManager.LoadScene(sceneIndex);
    //}

    public void LoadLevel(int index)
    {
        if (index == -1)
        {
            Application.Quit();
        }
        else
        {
            Application.LoadLevel(index);
        }
    }

}
