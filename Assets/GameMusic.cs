using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public static GameMusic Init;
    private void Start()
    {
        if (Init==null)
        {
            Init = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (Init!=this)
            {
                Destroy(gameObject);
            }
        }
    }
}
