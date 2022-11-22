using Sirenix.OdinInspector.Editor.Validation;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public static class CPlayerPrefs
{
    #region SavePref
    public static void SetInt(string key, int val)
    {
        PlayerPrefs.SetInt(key, val);
        Save();
    }

    public static void SetLong(string key, long val)
    {
        PlayerPrefs.SetString(key, val.ToString());
        Save();
    }

    public static void SetFloat(string key, float val)
    {
        PlayerPrefs.SetFloat(key, val);
        Save();
    }

    public static void SetString(string key, string val)
    {
        PlayerPrefs.SetString(key, val);
        Save();
    }

    public static void SetBool(string key, bool val)
    {
        PlayerPrefs.SetInt(key, val ? 1 : 0);
        Save();
    }

    #endregion

    #region GetPref

    public static int GetInt(string key, int defaultVal)
    {
        if (!HasKey(key)) return defaultVal;
        
        return PlayerPrefs.GetInt(key); 
    }

    public static int GetInt(string key)
    {
        return GetInt(key, 0);
    }

    #endregion

    public static bool HasKey(string key)
    {
      return PlayerPrefs.HasKey(key);
    }

    public static void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void Save()
    {
        PlayerPrefs.Save();
    }
}
