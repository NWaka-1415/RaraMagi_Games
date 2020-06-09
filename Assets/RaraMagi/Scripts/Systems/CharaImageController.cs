using System.Collections.Generic;
using UnityEngine;

namespace RaraMagi.Systems
{
    public class CharaImageController
    {
        private const string ImagePath = "Images";

        private static Dictionary<Characters, string> _charaPath = new Dictionary<Characters, string>()
        {
            {Characters.Tsubasa, "Tsubasa"},
        };

        private static Dictionary<CharaState, string> _charaStatePath = new Dictionary<CharaState, string>()
        {
            {CharaState.Normal, "Normal"},
            {CharaState.Kiss, "Kiss"}
        };

        public static Sprite Create(Characters characters, CharaState charaState = CharaState.Normal)
        {
            Sprite sprite = Resources.Load<Sprite>(
                $"{ImagePath}/{_charaPath[characters]}/{_charaStatePath[charaState]}"
            );
            return sprite;
        }
    }
}