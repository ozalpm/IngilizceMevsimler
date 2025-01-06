using System;
using System.Collections;
using System.Collections.Generic;
using SupanthaPaul;
using UnityEngine;

public static class EventManager
{
    public static Action<int> onCoinChange;
    public static Action<int> onHealthChange;
    public static Action onPlayerDead;
    public static Action onPlayerRespawn;
}
