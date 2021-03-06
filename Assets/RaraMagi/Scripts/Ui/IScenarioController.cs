﻿using System;
using RaraMagi.Systems;
using UnityEngine;

namespace RaraMagi.Ui
{
    public interface IScenarioController
    {
        void SetNormalCharacterImage(Sprite sprite, CharacterDisplayPositions position);
        void HideNormalCharacterImage(CharacterDisplayPositions position);
        void HideAllNormalCharacterImage();
        void HideNormalCharacterImage();
        void SetSpecialCharacterImage(Sprite sprite);
        void HideSpecialCharacterImage();
        void SetBackground(Sprite sprite);
        void HideBackground();
        void SetMainText(string text);
        void SetSpeakerText(string speaker);
        void SetYesChoices(bool enable, string text = "", Action<CustomButton> action = null);
        void SetNoChoices(bool enable, string text = "", Action<CustomButton> action = null);
        void ShowMessageWindow();
        void HideMessageWindow();
        void Flash();
    }
}