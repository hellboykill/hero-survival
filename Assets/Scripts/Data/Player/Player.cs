using Data.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.User
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;

        private void Awake()
        {
            Instance = this;
        }

        private float _exp;

        public float TotalAtk
        {
            get;
            private set;
        }
        public float TotalHp
        {
            get;
            private set;
        }
        public int Gold
        {
            get => UserInfo.GetGold();
        }

        public void AddGold(int goldBonus)
        {
            int preGold  = UserInfo.GetGold();
            int currentGold = (int)(preGold + goldBonus);
            UserInfo.SaveGold(currentGold);
        }

        public int Energy
        {
            get => UserInfo.GetEnergy();
        }
    }
}

