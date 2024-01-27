using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void GameEvent(GameObject go);

    public static GameEvent onPickUp;
    public static GameEvent onThrow;
   
   
}
