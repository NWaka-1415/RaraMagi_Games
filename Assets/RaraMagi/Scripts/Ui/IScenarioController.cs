using System;
using UnityEngine;

namespace RaraMagi.Scripts.Ui
{
    public interface IScenarioController
    {
        void SetCharacterImage(Sprite sprite);
        void SetMainText(string text);
        void SetSpeakerText(string speaker);
        void SetYesChoices(bool enable, string text = "", Action<CustomButton> action = null);
        void SetNoChoices(bool enable, string text = "", Action<CustomButton> action = null);
    }
}