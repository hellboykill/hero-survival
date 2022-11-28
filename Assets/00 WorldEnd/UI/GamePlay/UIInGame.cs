using System.Collections;
using System.Collections.Generic;
using TigerForge;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WE.Manager;
using WE.UI;
using WE.Support;


public class UIInGame : UIBase
{
    public TextMeshProUGUI textCount;
    public TextMeshProUGUI textCoin;
    public TextMeshProUGUI textKill;
    public TextMeshProUGUI textLevel;
    public Transform expBar;
    public Image expBarFlash;

    float currentExp;
    float nextExpLevel;

    bool cachedFrame = false;
    float cachedExp;

    public override void InitUI()
    {
        EventManager.StartListening(Constant.ON_COINS_CHANGE_IN_GAME, OnCoinChange);
   //     EventManager.StartListening(Constant.GAME_TICK_EVENT, OnTick);
        EventManager.StartListening(Constant.ON_ENEMY_DIE, OnEnemyKill);
        EventManager.StartListening(Constant.ON_RECEVICE_EXP, OnReceiveExp);
        expBar.localScale = new Vector3(0, 1, 1);
        currentExp = 0;
     //   nextExpLevel = DataManager.Instance.dataGlobalUpgrade.GetNextLevelExp(0, GameplayManager.Instance.CurrentLevel);
        textLevel.text = "1";
        textCount.text = "00:00";
        textCoin.text = "0";
        textKill.text = "0";
        cachedFrame = false;
        cachedExp = 0;
    }
    private void OnDisable()
    {
        EventManager.StopListening(Constant.ON_COINS_CHANGE_IN_GAME, OnCoinChange);
      //  EventManager.StopListening(Constant.GAME_TICK_EVENT, OnTick);
        EventManager.StopListening(Constant.ON_ENEMY_DIE, OnEnemyKill);
        EventManager.StopListening(Constant.ON_RECEVICE_EXP, OnReceiveExp);
      //  EventManager.StopListening(Constant.ON_SKILL_CHANGE, InitSkillBar);
    }
    public void OnCoinChange()
    {
        textCoin.text = GamePlayManager.Instance.CurrentCoinCount.ToString();
    }
    public void OnEnemyKill()
    {
        textKill.text = GamePlayManager.Instance.CurrentKillCount.ToString();
    }

    public void OnReceiveExp()
    {
        float exp = EventManager.GetFloat(Constant.ON_RECEVICE_EXP);
      //  AddExp(exp);
    }

    //public void AddExp(float exp)
    //{
    //    if (!cachedFrame)
    //    {
    //        currentExp += exp;
    //        expBar.transform.DOKill();
    //        expBarFlash.DOKill();
    //        if (currentExp >= nextExpLevel)
    //        {
    //            cachedFrame = true;
    //            GamePlayManager.Instance.LevelUp();
    //            textLevel.text = "LV." + GameplayManager.Instance.CurrentLevel.ToString();
    //            currentExp -= nextExpLevel;
    //            nextExpLevel = DataManager.Instance.dataGlobalUpgrade.GetNextLevelExp(nextExpLevel, GameplayManager.Instance.CurrentLevel);
    //            expBar.transform.localScale = new Vector3(0, 1, 1);
    //        }
    //        expBar.transform.DOScale(new Vector3((currentExp / nextExpLevel), 1, 1), 0.2f);
    //        expBarFlash.color = new Color(1, 1, 1, 0.6f);
    //        expBarFlash.DOFade(0, 0.2f);
    //    }
    //    else
    //    {
    //        cachedExp += exp;
    //    }
    //}

}
