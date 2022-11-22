using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool IsCheckLv1;
    public int level;
    public ulong TotalGold;
    public float GoldEarn;
    public float GoldTank;
    public float GoldHelicop;
    public int PressNumberTank;
    public int PressNumberHelicop;
    public int MuntiPlayer;
    public List<Vector2> UnitPosList;
    public List<int> UnitIdList;
    public Dictionary<string, bool> TileChecker;

    public GameData()
    {
        IsCheckLv1 = false;
        this.level = 1;
        this.TotalGold = 0;
        this.GoldEarn = 40f;
        this.GoldTank = 10f;
        this.GoldHelicop = 10f;
        this.PressNumberTank = 0;
        this.PressNumberHelicop = 0;
        this.MuntiPlayer = 1;
        this.UnitPosList = new List<Vector2>();
        this.UnitIdList = new List<int>();
        this.TileChecker = new Dictionary<string, bool>();
        this.GoldEarn = 0;
    }
}
