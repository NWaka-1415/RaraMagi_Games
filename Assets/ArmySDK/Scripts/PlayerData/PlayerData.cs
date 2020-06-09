using System.Collections;
using System.Collections.Generic;
using ArmySDK;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static string DataPath
    {
        get { return Application.persistentDataPath + "/data.game"; }
    }

    private static SaveData data = null;


    public static SaveData Data
    {
        get
        {
            if (data == null)
            {
                Load();
            }

            return data;
        }
    }


    public static void Load()
    {
        data = SaveSystem.Load<SaveData>(DataPath);
        if (data == null)
        {
            data = new SaveData();
        }
    }


    public static void Save()
    {
        if (data != null)
        {
            SaveSystem.Save(DataPath, data);
        }
    }


    public static void SetLastClearedStage(int lastClearedStage, bool save = true)
    {
        Data.lastClearedStage = lastClearedStage;
        if (save)
        {
            Save();
        }
    }

    public static void SetLastPlayStage(int lastPlayStage, bool save = true)
    {
        Data.lastPlayStage = lastPlayStage;
        if (save)
        {
            Save();
        }
    }

    public static void SetVibrate(bool vibrate, bool save = true)
    {
        Data.vibrate = vibrate;
        if (save)
        {
            Save();
        }
    }


    /// <summary>
    /// 保存されるデータ
    /// </summary>
    [System.Serializable]
    public class SaveData
    {
        public int ver;

        // クリア済みの最終ステージ
        public int lastClearedStage;

        // 最後にプレイしたステージ
        public int lastPlayStage;

        /// <summary>
        /// 振動機能をONにしているか
        /// </summary>
        public bool vibrate;


        public SaveData()
        {
            ver = 0;
            lastClearedStage = 0;
            lastPlayStage = 0;
            vibrate = true;
        }
    }
}