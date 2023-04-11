using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config params
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;//[Range(float min, float max)] allows to change gameSpeed with slider
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    //state variables
    [SerializeField] int currentScore = 0;


    private void Awake()//before Startmethod
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;//stores how may gameStatusObjects currently are

        if(gameStatusCount > 1)//if theres more than one GameSession-GameObject destroy yourself /else dont destroy when level loads in the future 
        {
            gameObject.SetActive(false);//set gameObject to not active
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        setScore();
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed; //adds currentScore the pointsPerBlockDestroyed, both of type int
        setScore();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;//starts regular Time
    }
    public void setScore()//sets scoreText to currentScore
    {
        scoreText.text = currentScore.ToString();

    }

    public void ResetGame()//Destroys the gameObject GameStatus
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()//returns bool
    {
        return isAutoPlayEnabled;
    }
    }
