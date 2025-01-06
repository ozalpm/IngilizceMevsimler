using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text levelNameText,coinText,healthText;

    public static UIManager Init;

    public GameObject restartPanel;
    public void Awake()
    {
        Init = this;
    }

    private void Start()
    {
        levelNameText.text = SceneManager.GetActiveScene().name.ToUpper();
    }

    private void OnEnable()
    {
        EventManager.onCoinChange += OnCoinChange;
        EventManager.onHealthChange += OnHealthChange;
        EventManager.onPlayerDead += OnPlayerDead;
    }

    private void OnDisable()
    {
        EventManager.onCoinChange -= OnCoinChange;
        EventManager.onHealthChange -= OnHealthChange;
        EventManager.onPlayerDead -= OnPlayerDead;
    }

    public void OnCoinChange(int count)
    {
        coinText.text = count.ToString();
    }
    public void OnHealthChange(int count)
    {
        healthText.text = count.ToString();
    }

    public void OnPlayerDead()
    {
        restartPanel.SetActive(true);
    }

    public void NotEnoughCoinError()
    {
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
