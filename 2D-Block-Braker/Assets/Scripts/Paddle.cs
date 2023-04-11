using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Konfiguration paramaters
    [SerializeField] float screenWithInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //cached references
    Ball ball;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        PaddlePosition();
    }

    private void PaddlePosition()//sets paddlePos 
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y); //Vector with x and y, transoform.position.x leaves it at the same point
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);//paddlePos Vector sets X to look for Mousposition and only be between min and max value
        transform.position = paddlePos;//sets current position equal to paddlePos position
    }

    private float GetXPos()
    {
        
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;//if IsAutoPlayEnabled true then the paddle follows the balls position
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWithInUnits;//current MousposotionX / ScreenWidth*screenWithInUnits
        }
        
    }
}
