using RaraMagi.Systems.TextSystem;
using UnityEngine;

namespace RaraMagi.Systems.TextSystem
{
    public static class TextLoader
    {
        private const string TextPath = "Texts";

        public static string[] Load(int chapter, CharacterNames characters, bool isSkipFirstLine = false)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(
                $"{TextPath}/{CharacterData.CharaPath[characters]}/{CharacterData.CharaPath[characters]}{chapter}"
            );
            string result = textAsset.text;
            string[] resultArray = result.Replace("\r\n", "\n").Split(new[] {'\n', '\r'});
            if (isSkipFirstLine)
            {
                string[] newResult = new string[resultArray.Length - 1];
                for (int i = 0; i < newResult.Length; i++)
                {
                    newResult[i] = resultArray[i + 1];
                }

                return newResult;
            }

            return resultArray;
        }
    }
}