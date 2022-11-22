using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Data.Storage
{

    public partial class UserInfo
    {
        public long Gold;
        public int Exp;
        public int Energy;
        public int UserLevel;

        public int Attack;
        public int HealthPoint;
        public int Armor;

        public List<string[]> talents;

        public int currentWave;
        public int bestTimeLevel;

        public UserInfo()
        {
            this.Gold = 0;
            this.Exp = 0;
            this.Energy = 30;
            this.UserLevel = 1;
            this.Attack = 10;
            this.HealthPoint = 100;
            this.Armor = 0;
            this.currentWave = 1;
            this.bestTimeLevel = 0;
        }
    }
}