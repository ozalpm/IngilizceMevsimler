using System;
using System.Collections;
using System.Collections.Generic;
using SupanthaPaul;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public static GameManager Init;

    public int requireCoinCount;
    public int collectedCoin;

    public int playerHealth;

    public Transform startPoint;

    public AudioSource source;

    public AudioClip deadClip, levelEndClip;
    private void Awake()
    {
        Init = this;
    }

    public void PlayerDeath()
    {
        playerHealth--;
        EventManager.onHealthChange?.Invoke(Math.Clamp(playerHealth,0,5));
        if (playerHealth>0)
        {
            EventManager.onPlayerRespawn?.Invoke();
            Transform playerController=GameObject.FindWithTag("Player").transform;
            playerController.position = startPoint.position;
            playerController.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
        }
        else
        {
            EventManager.onPlayerDead?.Invoke();
        }
        PlayOneShoot(deadClip);
        
    }
    
    public void AddCoin()
    {
        collectedCoin++;
        EventManager.onCoinChange?.Invoke(collectedCoin);
    }

    public bool CanLevelComplete()
    {
        bool forReturn = requireCoinCount <= collectedCoin;
        if (forReturn==false)
        {
            UIManager.Init.NotEnoughCoinError();
        }
        return forReturn;
    }

    public void PlayOneShoot(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void LevelEnd()
    {
        PlayOneShoot(levelEndClip);
    }
}
