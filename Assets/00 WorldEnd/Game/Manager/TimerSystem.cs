using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WE.Manager;
using DG.Tweening;

public class TimerSystem : MonoBehaviour
{
    public static TimerSystem Instance;
    float tcount;
    public bool bannerOn;
    private void Awake()
    {
        Instance = this;
        tcount = 0;
    }

    private void Update()
    {

    }


    public void StopTimeScale()
    {
        Time.timeScale = 0;
        GamePlayManager.Instance.SetState(GameState.Pause);
    }

    public void StopTimeScale(float t, Action callBack)
    {
        int wait = 1;
        DOTween.To(() => wait, x => wait = x, 0, t).SetUpdate(true).OnComplete(() => { callBack?.Invoke(); StopTimeScale(); });
    }
    public void ReturnTimeScale()
    {
        Time.timeScale = 1;
        if (GamePlayManager.Instance.State == GameState.Pause)
        {
            GamePlayManager.Instance.SetState(GameState.Gameplay);
        }
    }
}
