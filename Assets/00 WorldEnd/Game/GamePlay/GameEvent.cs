using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvent :  Singleton<GameEvent>
{ 
    private static GameEvent _instance;

    public Action OnGetAllIdataPersisTence;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    private void OnDisable()
    {
        _instance = null;
    }

}
