using System;
using System.Collections.Generic;
using RaraMagi.Scripts.Ui;
using RaraMagi.Systems.Characters;
using RaraMagi.Systems.TextSystem;
using UnityEngine;
using UnityEngine.UI;

namespace RaraMagi.Systems
{
    public class GameUiController : MonoBehaviour, IScenarioController
    {
        [SerializeField] private Image characterImage = null;
        [SerializeField] private Image textLog = null;
        [SerializeField] private Text speakerText = null;
        [SerializeField] private Text contentText = null;
        [SerializeField] private CustomButton yesButton = null;
        [SerializeField] private CustomButton noButton = null;

        private TextController _textController = null;

        private void Awake()
        {
            _textController = new TextController(this);
        }

        public void SetCharacterImage(Sprite sprite)
        {
            characterImage.sprite = sprite;
        }

        public void SetMainText(string text)
        {
            contentText.text = text;
        }

        public void SetSpeakerText(string speaker)
        {
            speakerText.text = speaker;
        }

        public void SetYesChoices(bool enable, string text = "", Action<CustomButton> action = null)
        {
            yesButton.SetActive(enable);
            yesButton.SetText(text);
            yesButton.ResetAction();
            if (action != null) yesButton.SetButtonAction(action);
        }

        public void SetNoChoices(bool enable, string text = "", Action<CustomButton> action = null)
        {
            noButton.SetActive(enable);
            noButton.SetText(text);
            noButton.ResetAction();
            if (action != null) noButton.SetButtonAction(action);
        }

        public void SetData(Dictionary<int, ScenarioData> scenarioDataList)
        {
            _textController.SetData(scenarioDataList);
        }

        public void ShowText()
        {
            _textController.ShowText();
        }

        public void PushText(bool isPush)
        {
            _textController.TextUpdate(isPush);
        }
    }
}