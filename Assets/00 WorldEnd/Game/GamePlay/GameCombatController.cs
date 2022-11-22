using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCombatController : MonoBehaviour
{
    private static GameCombatController _instance;
    public static GameCombatController Instance => _instance;
    
    public List<EnemyBase> EnemyOnFieldList;

    private void Awake()
    {
        //if (_instance == null)
        //{
        //    _instance = this;
        //}
    }
    private void Start()
    {
  
    }
    private void OnDisable()
    {
        //_instance = null;
    }
}
