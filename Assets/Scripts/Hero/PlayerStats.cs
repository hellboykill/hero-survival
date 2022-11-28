using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Storage;

namespace WE.Unit
{
    public class PlayerStats : MonoBehaviour
    {
        public UnitBaseAttribute AttackAttribute;
        public UnitBaseAttribute HpAttribute;
        public UnitBaseAttribute MovespeedAttribute;
        public UnitBaseAttribute Reward_Increase;

        public UnitSubAttribute Hp_Recovery_Increase;
        public UnitSubAttribute Cooldown_Increase;
        public UnitSubAttribute Bullet_Speed_Increase;
        public UnitSubAttribute Effect_Area_Increase;
        public UnitSubAttribute Effect_Duration_Increase;
        public UnitSubAttribute Push_Back_Force_Increase;
        public UnitSubAttribute Crit_Rate_Increase;
        public UnitSubAttribute Projectile_Number_Add;
        public UnitSubAttribute Item_Absorb_Range_Increase;
        public UnitSubAttribute Luck_Increase;
        public UnitSubAttribute Exp_Increase;
        public UnitSubAttribute Damage_Reviced_Reduction_Increase;
        public UnitSubAttribute Revial;
        Player player => Player.Instance;

        UserInfo playerData => Player.Instance.PlayerData;
    }

    public class UnitBaseAttribute
    {
        public UnitBaseAttribute()
        {
            ValueCount = 0;
            ValuePercentGlobal = 0;
            ValuePercentLocal = 0;
        }
        public float Value { get => ValueCount * ValuePercent; }
        public float ValuePercent { get => (1 + ValuePercentGlobal / 100) * (1 + ValuePercentLocal / 100); }
        public float ValueCount { get; private set; }
        public float ValuePercentGlobal { get; private set; }
        public float ValuePercentLocal { get; private set; }

        public void SetValueCount(float v)
        {
            ValueCount = v;
            if (ValueCount < 0)
            {
                ValueCount = 0;
            }
        }
        public void AddValueCount(float v)
        {
            ValueCount += v;
            if (ValueCount < 0)
            {
                ValueCount = 0;
            }
        }
        public void SetValuePercentGlobal(float v)
        {
            ValuePercentGlobal = v;
        }
        public void AddValuePercentGlobal(float v)
        {
            ValuePercentGlobal += v;
        }
        public void SetValuePercentLocal(float v)
        {
            ValuePercentLocal = v;
        }
        public void AddValuePercentLocal(float v)
        {
            ValuePercentLocal += v;
        }
    }
    public class UnitSubAttribute
    {
        public int Value { get; private set; }
        public void AddValue(float val)
        {
            Value += (int)val;
        }
    }

}

