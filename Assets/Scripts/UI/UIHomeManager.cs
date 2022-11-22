using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHomeManager : MonoBehaviour
{
    public static UIHomeManager _instance;
    public static UIHomeManager Instance => _instance;

    protected void Awake()
    {
        _instance = this;
      //  GameManager.Instance.uIHome = this;
    }

    public void StartPlayCampaign()
    {
        SceneManager.LoadScene("Game");
    }
}
