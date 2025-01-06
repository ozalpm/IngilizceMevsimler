using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupanthaPaul;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndDoor : MonoBehaviour
{

    public string doorKey;
    public Animator anim;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            LevelEnd();
        }
    }

    private bool ended;

    public async void LevelEnd()
    {
        if (ended)
        {
            return;
        }

        if (!GameManager.Init.CanLevelComplete())
        {
            return;
        }

        GameManager.Init.LevelEnd();
        anim.SetBool("Open", true);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().canMove = false;
        PlayerPrefs.SetInt(doorKey,1);
        ended = true;
        await Task.Delay(3000);
        SceneManager.LoadScene("Menu");
        
    }
}
