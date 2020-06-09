using System.Collections.Generic;
using UnityEngine;

namespace RaraMagi.Systems.Characters
{
    public static class CharaImageCreator
    {
        private const string ImagePath = "Images";


        public static Sprite Create(int index, CharacterNames characters, CharaState charaState = CharaState.Normal)
        {
            Sprite sprite = Resources.Load<Sprite>(
                $"{ImagePath}/{CharacterController.CharaPath[characters]}/{CharacterController.CharaStatePath[charaState]}/{index}"
            );
            return sprite;
        }
    }
}