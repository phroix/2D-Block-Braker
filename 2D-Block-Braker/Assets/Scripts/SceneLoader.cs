using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()//loads next Scene
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;//Gets currentSceneIndex in int 
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()//loads Scene at Index 0
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();//calls ResetGame() method of GameStatus Calss 
    }

    public void QuitGame()//Quits Game
    {
        Application.Quit();//Quits Application (from Unity no C#)
    }


}
