using RaraMagi.Systems.Characters;
using UnityEngine;
using CharacterController = RaraMagi.Systems.Characters.CharacterController;

namespace RaraMagi.Systems.TextSystem
{
    public static class TextLoader
    {
        private const string TextPath = "Texts";

        public static string[] Load(int chapter, CharacterNames characters)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(
                $"{TextPath}/{CharacterController.CharaPath[characters]}/{chapter}"
            );
            string result = textAsset.text;
            return result.Replace("\r\n", "\n").Split(new[] {'\n', '\r'});
        }
    }
}