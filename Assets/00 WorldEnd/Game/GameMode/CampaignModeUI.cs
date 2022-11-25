using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using WE.UI.Gameplay.Campaign;
using UnityEngine.UI;
using UnityEngine.Diagnostics;

namespace WE.Game.Gamemode.Campaign
{
    public class CampaignModeUI : MonoBehaviour
    {
        public const string ICON_COIN = "COIN";
        public const string ICOIN_TIMING = "TIMING";
        public const string ICON_KILL_ENEMY = "KILL_ENEMY";

        public static CampaignModeUI Instance { get; private set; }
      //  [SerializeField]
      //  private UIMissionIcon iconPrefabs;
        [SerializeField]
        private Text txtCoin, txtTiming, txtKillEnemy;
        [SerializeField]
        private Text textTitleCampaign;
        [SerializeField] 
        private GameObject clockCounter;


        private CompositeDisposable disposables = new CompositeDisposable();

        private void Awake()
        {
            Instance = this;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            disposables.Clear();

        }
        public void Init()
        {
           StartCoroutine(WaitForUnit());

        }

        private IEnumerator WaitForUnit()
        {
            //while (GameplayManager.Instance == null || BattleRewards_Campaign.Instance == null)
                yield return null;
            UpdateUI();
        }

        private void UpdateUI()
        {
            textTitleCampaign.text = "Zone 12";

            InitCoin();
            InitTiming();

            //EModeCampaign modeCurrent = Player.Instance.mapController.CurrentMode;
            //if (!Player.Instance.mapController.IsSuccessMission(modeCurrent, 0))
            //{
            //    var configMission_0 = Player.Instance.mapController.GetConfigMission(0);
            //    EMissionCampaign eMission_0 = configMission_0.eMissionCampaign;
            //    IniIcontMission(eMission_0);
            //}

            //if (!Player.Instance.mapController.IsSuccessMission(modeCurrent, 1))
            //{
            //    var configMission_1 = Player.Instance.mapController.GetConfigMission(1);
            //    EMissionCampaign eMission_1 = configMission_1.eMissionCampaign;
            //    IniIcontMission(eMission_1);
            //}
            //if (!Player.Instance.mapController.IsSuccessMission(modeCurrent, 2))
            //{
            //    var configMission_2 = Player.Instance.mapController.GetConfigMission(2);
            //    EMissionCampaign eMission_2 = configMission_2.eMissionCampaign;
            //    IniIcontMission(eMission_2);
            //}
        }

        private void InitCoin()
        {
            //var icon = Instantiate(iconPrefabs, parentMission);
            //icon.transform.localPosition = Vector3.zero;
            //icon.transform.localScale = Vector3.one;
            //icon.InitSprite(spriteCoin);
            //icon.InitDesc(BattleRewards_Campaign.Instance.TotalCoinReceive.ToString());
            //icon.Icon.transform.localScale = Vector3.one * 0.5f;

            //icon.ListenEvent_UICampaign(ICON_COIN);
        }

        public void InitTiming()
        {
            if (clockCounter != null)
            {
                clockCounter.SetActive(true);
                clockCounter.transform.SetAsLastSibling();
                Observable.EveryLateUpdate().Subscribe(_ => ShowTiming()).AddTo(disposables);
            }
        }

        //private void InitKillEnemy()
        //{
        //    var icon = Instantiate(iconPrefabs, parentMission);
        //    icon.transform.localPosition = Vector3.zero;
        //    icon.transform.localScale = Vector3.one;
        //    icon.InitSprite(spriteKillEnemy);
        //    icon.InitDesc("0%");
        //    icon.ListenEvent_UICampaign(ICON_KILL_ENEMY);
        //}

        private void ShowTiming()
        {
            textTiming.text = "0";
        }

        //public void UpdateTiming()
        //{
        //    if (TigerForge.EventManager.EventExists(EventConstant.EVENT_UPDATE_UI_CAMPAIGN))
        //        TigerForge.EventManager.EmitEventData(EventConstant.EVENT_UPDATE_UI_CAMPAIGN, ICON_TIMING);
        //}

        //public void UpdateCoin()
        //{
        //    if (TigerForge.EventManager.EventExists(EventConstant.EVENT_UPDATE_UI_CAMPAIGN))
        //        TigerForge.EventManager.EmitEventData(EventConstant.EVENT_UPDATE_UI_CAMPAIGN, ICON_COIN);
        //}

        //public void UpdateKillEnemy()
        //{
        //    if (TigerForge.EventManager.EventExists(EventConstant.EVENT_UPDATE_UI_CAMPAIGN))
        //        TigerForge.EventManager.EmitEventData(EventConstant.EVENT_UPDATE_UI_CAMPAIGN, ICON_KILL_ENEMY);

        //}
    }
}

