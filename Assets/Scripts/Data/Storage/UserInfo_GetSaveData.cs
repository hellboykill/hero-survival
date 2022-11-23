using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Data.Storage
{

    public partial class UserInfo
    {

        public const string PREF_USER_DEVICE_ID = "PREF_USER_DEVICE_ID";
        public const string PREF_USER_NAME = "PREF_USER_NAME";
        public const string PREF_USER_INFO_GOLD = "PREF_USER_GOLD";
        public const string PREF_EXP = "PREF_USER_EXP";
        public const string PREF_ENERGY = "PREF_USER_ENERGY";
        public const string PREF_USER_LEVEL = "PREF_USER_LEVEL";
        public const string PREF_CURRENT_ATK = "PREF_CURRENT_ATK";
        public const string PREF_CURRENT_HP = "PREF_CURRENT_HP";
        public const string PREF_USER_INFO_TALENT = "PREF_USER_INFO_TALENT";
        public const string PREF_CURRENT_WAVE = "PREF_CURRENT_WAVE";

        public static void SaveData(UserInfo user)
        {
            SaveGold(user);
            SaveExp(user);
            SaveEnergy(user);
        }

        public static void SaveGold(UserInfo user)
        {
            CPlayerPrefs.SetInt(PREF_USER_INFO_GOLD, (int)user.Gold);
        }

        public static void SaveGold(int gold)
        {
            CPlayerPrefs.SetInt(PREF_USER_INFO_GOLD, gold);
        }

        public static int GetGold()
        {
            return CPlayerPrefs.GetInt(PREF_USER_INFO_GOLD);
        }

        public static void SaveExp(UserInfo user)
        {
            CPlayerPrefs.SetInt(PREF_EXP, (int)user.Exp);
        }

        public static int GetExp()
        {
            return CPlayerPrefs.GetInt(PREF_EXP);
        }

        public static void SaveEnergy(UserInfo user)
        {
            CPlayerPrefs.SetInt(PREF_ENERGY, (int)user.Energy);
        }

        public static int GetEnergy()
        {
            return CPlayerPrefs.GetInt(PREF_ENERGY, 30);
        }

    }
}