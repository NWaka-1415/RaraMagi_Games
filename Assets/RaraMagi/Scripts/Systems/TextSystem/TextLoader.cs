using RaraMagi.Systems.TextSystem;
using UnityEngine;

namespace RaraMagi.Systems.TextSystem
{
    public static class TextLoader
    {
        private const string TextPath = "Texts";

        public static string[] Load(int chapter, CharacterNames characters)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(
                $"{TextPath}/{CharacterData.CharaPath[characters]}/{CharacterData.CharaPath[characters]}{chapter}"
            );
            string result = textAsset.text;
            return result.Replace("\r\n", "\n").Split(new[] {'\n', '\r'});
        }
    }
}