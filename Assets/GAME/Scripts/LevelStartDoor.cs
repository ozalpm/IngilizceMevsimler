using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelStartDoor : MonoBehaviour
{
    public Sprite completedSprite, notCompletedSprite;
    public GameObject translateObject;
    public Image isCompletedSprite;

    public string doorKey;
    public string sceneName;
    public Animator anim;

    public static string activeTargetSceneName;

    public GameObject startLevelButton;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            anim.SetBool("Open", true);
            translateObject.SetActive(true);
            activeTargetSceneName = sceneName;
            startLevelButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            anim.SetBool("Open", false);
            translateObject.SetActive(false);
            startLevelButton.SetActive(false);
        }
    }

    private void Awake()
    {
        if (PlayerPrefs.GetInt(doorKey) == 0)
        {
            isCompletedSprite.sprite = notCompletedSprite;
        }
        else
        {
            isCompletedSprite.sprite = completedSprite;
        }
    }
}


