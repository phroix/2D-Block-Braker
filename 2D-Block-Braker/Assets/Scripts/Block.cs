using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit; 

    public void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()//counts the times of hit it needs with tag
    {
        level = FindObjectOfType<Level>();//finds Object of type Level which equals the varaible level

        if (tag == "Breakable")
        {
            level.CountBlocks();//add one to the total number of blocks

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//OnCollisionEnter2D, on hit mehthod when Ball hits Block
    {
        if (tag == "Breakable")//looks for the tag in Unity which was added to the Object Block 
        {
            HandleHit();
        }

    }

    private void HandleHit()//increases timesHit by one and looks if timesHit bigger or equal maxHits,if thats true it destroys the block/if false it shows next HitSprite 
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()//shows next Sprite after Hit
    {
        int spriteIndex = timesHit - 1;//timesHit -1 because of the array index, it starts at 0
        if (hitSprites[spriteIndex] != null)//checks if hitSpritesIndex is not undefined
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];//gets Component of type SpriteRendere.sprite and this equals the hitSprites of type Sprite array
        }
        else
        {

            Debug.LogError("Block sprite is missing from array" + gameObject.name);//puts Error in Console
        }
    }

    private void DestroyBlock()//Destroys Block with SFX and VFX and if 0 blocks then it starts next Scene(Level)
    {
        PlayBlockDestroySFX();//calls method
        Destroy(gameObject);//gameObject is the current Object which the Script is conneted with/function creates an audio source but automatically disposes of it once the clip has finished playing
        level.BlockDestroyed();//calls BlockDestroyed method of Level class and if 0 blocks then its loading next level(Scene)
        TriggerSparklesVFX();//calls method
    }

    private void PlayBlockDestroySFX()//plays Audioclip
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);//Plays the Audio Source with AudioClip variable at MainCameras position
    }

    public void TriggerSparklesVFX()//triggers VFX
    {
        GameObject sparkles = Instantiate(blockSparkleVFX,transform.position, transform.rotation);//tell Instantiable Object of GameObject where the block is and where it rotates
        Destroy(sparkles, 1f);//Destroys after 2 seconds
    }
}
