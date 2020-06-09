using System.Collections.Generic;
using UnityEngine;

namespace RaraMagi.Systems
{
    public static class CharaImageCreator
    {
        private const string ImagePath = "Images";

        private static readonly Dictionary<Characters, string> CharaPath = new Dictionary<Characters, string>()
        {
            {Characters.Tsubasa, "Tsubasa"},
        };

        private static readonly Dictionary<CharaState, string> CharaStatePath = new Dictionary<CharaState, string>()
        {
            {CharaState.Normal, "Normal"},
            {CharaState.Kiss, "Kiss"}
        };

        public static Sprite Create(int index, Characters characters, CharaState charaState = CharaState.Normal)
        {
            Sprite sprite = Resources.Load<Sprite>(
                $"{ImagePath}/{CharaPath[characters]}/{CharaStatePath[charaState]}/{index}"
            );
            return sprite;
        }
    }
}