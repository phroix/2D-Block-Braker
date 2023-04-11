using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//OnTriggerEnter2D if something passes through the Collider(Ontrigger)
    {
        SceneManager.LoadScene("Game Over");//loads "Game Over" Scene in Unity
    }


}
