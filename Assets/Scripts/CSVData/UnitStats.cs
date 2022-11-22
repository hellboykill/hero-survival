using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor;
using System;

[CreateAssetMenu(fileName = "UnitStats", menuName = "We/UnitStats", order = 0)]
public class UnitStats : SerializedScriptableObject
{
    public string nameUnit;
    public Sprite icon;

    [SerializeField]
    private string Url;
    public Dictionary<int, Stats> level = new Dictionary<int, Stats>();

#if UNITY_EDITOR
    [Button("Get Data")]
    public void GetUnitTypeData()
    {
        string url = Url;
        level = new Dictionary<int, Stats>();

        System.Action<string> actionComplete = new System.Action<string>((string str) =>
        {
            var data = CSVReader.ReadCSV(str);

            nameUnit = name = data[1][0];

            for (int i = data.Count - 1; i > 0; i--)
            {
                var _data = data[i];
                Stats unitStats = new Stats();
                unitStats.damage = int.Parse(_data[2]);
                unitStats.attackSpeed = int.Parse(_data[3]);
                unitStats.attackRange = int.Parse(_data[4]);
                unitStats.bulletCapacity = int.Parse(_data[5]);
                unitStats.timeReload = int.Parse(_data[6]);

                level.Add(int.Parse(_data[1]), unitStats);
            }
            AssetDatabase.SaveAssets();
            UnityEditor.EditorUtility.SetDirty(this);
        });
        EditorCoroutine.start(Helper.IELoadData(url, actionComplete));
    }
#endif


    public class Stats
    {
        public float damage;
        public float attackSpeed;
        public float attackRange;
        public int bulletCapacity;
        public float timeReload;
    }
}