using UnityEngine;
using WakanyanStudio.Systems.ConstantsValues;

namespace Systems.SaveSystems
{
    public abstract class AbstractSaveDataController
    {
        public static string DataPath => Application.persistentDataPath + "/data.game";

        protected static SaveData data = null;

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
            if (data == null) data = new SaveData();
        }

        public static void Save()
        {
            if (data != null) SaveSystem.Save(DataPath, data);
        }
    }
}