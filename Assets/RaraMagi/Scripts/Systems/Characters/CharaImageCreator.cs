using System.Collections.Generic;
using UnityEngine;

namespace RaraMagi.Systems.TextSystem
{
    public static class CharaImageCreator
    {
        private const string ImagePath = "Images";

        public static Sprite Create(int index, CharacterNames characters, CharaState charaState = CharaState.Normal)
        {
            Sprite sprite = Resources.Load<Sprite>(
                $"{ImagePath}/{CharacterData.CharaPath[characters]}/{CharacterData.CharaStatePath[charaState]}/{index}"
            );
            return sprite;
        }
    }
}