using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{

    public GameObject coinCollectEffect;
    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            GameManager.Init.PlayOneShoot(clip);
            GameObject createdEffect = Instantiate(coinCollectEffect, transform.position, quaternion.identity);
            Destroy(createdEffect,2);
            GameManager.Init.AddCoin();
            Destroy(gameObject);
        }
    }
}
