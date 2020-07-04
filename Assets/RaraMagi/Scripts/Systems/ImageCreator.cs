using RaraMagi.Systems.BackGrounds;
using RaraMagi.Ui;
using UnityEngine;

namespace RaraMagi.Systems
{
    public static class ImageCreator
    {
        private const string ImagePath = "Images";
        private const string BackgroundPath = "Backgrounds";

        public static Sprite CreateChara(int index, CharacterNames characters,
            CharaState charaState = CharaState.Naked)
        {
            Sprite sprite = Resources.Load<Sprite>(
                $"{ImagePath}/{CharacterData.CharaPath[characters]}/{CharacterData.CharaStatePath[charaState]}/{index}"
            );
            return sprite;
        }

        public static Sprite CreateChara(int index, CharacterNames characters,
            CharaStateOnSpecial charaStateOnSpecial = CharaStateOnSpecial.Normal)
        {
            Sprite sprite = Resources.Load<Sprite>(
                $"{ImagePath}/{CharacterData.CharaPath[characters]}/{CharacterData.CharaStateSpecialPath[charaStateOnSpecial]}/{index}"
            );
            return sprite;
        }

        public static Sprite CreateBackground(
            int index, BackGroundNames backGroundNames,
            BackGroundState backGroundState = BackGroundState.Morning
        )
        {
            Sprite sprite = Resources.Load<Sprite>(
                $"{ImagePath}/{BackgroundPath}/{BackGroundData.BackGroundPath[backGroundNames]}/{BackGroundData.BackGroundStatePath[backGroundState]}/{index}"
            );
            return sprite;
        }
    }
}