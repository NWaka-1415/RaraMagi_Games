using System;
using RaraMagi.Systems;
using UnityEngine;

namespace RaraMagi.Scripts.Ui
{
    public interface IScenarioController
    {
        void SetNormalCharacterImage(Sprite sprite, CharacterDisplayPositions position);
        void SetSpecialCharacterImage(Sprite sprite);
        void SetBackground(Sprite sprite);
        void SetMainText(string text);
        void SetSpeakerText(string speaker);
        void SetYesChoices(bool enable, string text = "", Action<CustomButton> action = null);
        void SetNoChoices(bool enable, string text = "", Action<CustomButton> action = null);
    }
}