using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //Parameters
    [SerializeField]int breakableBlocks; //Serialized for debugging purposes

    //cached reference
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();//finds Object of type SceneLoader which equals the varaible sceneLoader
    }


    public void CountBlocks()//counts int replaycing the breakableBlocks
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()//Destroys Block
    {
        breakableBlocks--;//minus 1
        if (breakableBlocks <= 0)//If less or equals 0
        {      
            sceneLoader.LoadNextScene();//scenLoader of type SceneLoader(Scritp) call LoadNextScene() method
        }
    }
}
