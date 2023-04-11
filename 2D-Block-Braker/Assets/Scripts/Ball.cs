
using UnityEngine;

public class Ball : MonoBehaviour
{
    //coinfig params
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.3f;

    
    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached Component refernces
    AudioSource myAudioScource;
    Rigidbody2D myRigodbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;//paddleToBallVector equal to the current positon of Baldd - current Postion if paddle
        myAudioScource = GetComponent<AudioSource>();//Gets current Audio Source
        myRigodbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)//If has started is true it doesnt calls the if statemant anymore
        {
            LockBalltoPaddle();
            LaunchBallOnMousClick();
        }
    }

    private void LaunchBallOnMousClick()//Starts to shoot the ball if left MouseButton is clicked
    {
        if (Input.GetMouseButtonDown(0))//Gets MouseButton click with left MouseButton
        {
            hasStarted = true;//stes hasStarted to true
            myRigodbody2D.velocity = new Vector2(xPush, yPush);//Rigidbodys velocity is set to new Vector with xPush and yPush as coordinates
        }
    }

    private void LockBalltoPaddle()//Locks ball permanent to paddle
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);//creates new Vector which has the [SerializeField] Paddle, paddle1`s x and y transform.poition
        transform.position = paddlePos + paddleToBallVector;//adds paddlePos and distance between PaddleAndVector and sets it to the current Ball tranform.poisition
    }

    private void OnCollisionEnter2D(Collision2D collision)//OnColisionEnter2D when ball hits other collider
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));//creates Vector with random x and y cooridnates between 0 and randomFactor

        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0,ballSounds.Length)];//creating variable AudioClip type and sets it equal to the ballSounds which is random between lowest point of array till ballSounds.length
            myAudioScource.PlayOneShot(clip);//PLayONeShot when new Audio triggers other cant stop
            myRigodbody2D.velocity += velocityTweak;//adds velocityTweak to current velocity to stop loops from wall to wall
        }
    }
}
