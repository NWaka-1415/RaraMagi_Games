using System.IO;
using UnityEngine;

namespace Systems.SaveSystems
{
    public static class SaveSystem
    {
        public static void Save<T>(string dataPath, T data)
        {
            FileStream stream = new FileStream(dataPath, FileMode.Create);
            StreamWriter sw = new StreamWriter(stream);

            var jsonStr = JsonUtility.ToJson(data);
            sw.Write(jsonStr);

            sw.Close();
            stream.Close();

            Debug.Log("SaveSystem.Save() dataPath:" + dataPath);
        }


        public static T Load<T>(string dataPath) where T : class
        {
            if (File.Exists(dataPath))
            {
                FileStream stream = new FileStream(dataPath, FileMode.Open);
                StreamReader sr = new StreamReader(stream);

                var jsonStr = sr.ReadToEnd();
                T data = JsonUtility.FromJson<T>(jsonStr);

                sr.Close();
                stream.Close();

                Debug.Log("SaveSystem.Load() dataPath:" + dataPath);
                return data;
            }

            Debug.LogWarning("SaveSystem.Load() Not found data file. dataPath:" + dataPath);
            return null;
        }


        public static void DeleteData(string dataPath)
        {
            if (File.Exists(dataPath))
            {
                File.Delete(dataPath);
                Debug.Log("SaveSystem.DeleteData() dataPath:" + dataPath);
            }
        }
    }
}