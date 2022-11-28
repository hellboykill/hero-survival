using Data.User;
using System.Collections;
using System.Collections.Generic;
using TigerForge;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace WE.Manager
{
    public class GamePlayManager : MonoBehaviour
    {
        private static GamePlayManager _instance;
        public static GamePlayManager Instance => _instance;

        //public UIHomeManager uIHome;


        public GameState State { get; private set; }

        public GameType CurrentGameplayType { get; private set; }

        int maxMapTime;
        int currentCoinCount;
        int currentKillCount;
        int currentTimePlay;
        int currentLevel;
        int currentExpDrop;
        int cachedExp;

        bool isEndGameWave;
        bool lockExp;
        public int enemyDropExpPerSec;

        public int MaxTimePlay => maxMapTime;
        public int CurrentCoinCount => currentCoinCount;
        public int CurrentKillCount => currentKillCount;
        public int CurrentTimePlay => currentTimePlay;
        public int CurrentLevel => currentLevel;    
        public float CurrentTimeEvaluate => (float)currentTimePlay / MaxTimePlay;


        private void Awake()
        {
            _instance = this;
            State = GameState.Gameplay;
            Application.targetFrameRate = 300;
        }
        private void Start()
        {
            EventManager.StartListening(WE.Support.Constant.TIMER_TICK_EVENT, OnTick);
        }
        public void StartGame(GameType type)
        {
            CurrentGameplayType = type;
            State = GameState.Gameplay;
            isEndGameWave = false;
            currentTimePlay = 0;
            currentCoinCount = 0;
            currentKillCount = 0;

            currentLevel = 1;
            currentExpDrop = 0;
            cachedExp = 0;
        }

        public void OnTick()
        {
            if (State == GameState.Gameplay)
            {
                if (CurrentGameplayType == GameType.Campaign)
                {
                    if (!isEndGameWave)
                    {
                        if (currentTimePlay < maxMapTime)
                        {
                            currentTimePlay++;
                        }
                        else
                        {
                            isEndGameWave = true;
                            SpawnLastWave();
                        }
                    }
                }
                else
                {
                    currentTimePlay++;
                }

                currentExpDrop = 0;
               // Player.Instance.AutoRecovery();
                EventManager.EmitEvent(WE.Support.Constant.GAME_TICK_EVENT);
            }
        }

        public void SpawnLastWave()
        {
          //  EnemySpawner.Instance.SpawnLastWave();
        }
        public float GetCoinMultiple()
        {
            if (CurrentGameplayType == GameType.Campaign)
                return 2;

            return 1;
        }

        public void SetState(GameState _state)
        {
            State = _state;
        }
    }

}
