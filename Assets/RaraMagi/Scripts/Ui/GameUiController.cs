using System;
using System.Collections.Generic;
using RaraMagi.Scripts.Ui;
using RaraMagi.Systems.Characters;
using RaraMagi.Systems.TextSystem;
using UnityEngine;
using UnityEngine.UI;

namespace RaraMagi.Systems
{
    public class GameUiController : MonoBehaviour, ICharacterImage
    {
        [SerializeField] private Image characterImage = null;
        [SerializeField] private Image textLog = null;
        [SerializeField] private Text speakerText = null;
        [SerializeField] private Text contentText = null;

        private TextController _textController = null;

        private void Awake()
        {
            _textController = new TextController(this, contentText, speakerText);
        }

        public void SetCharacterImage(Sprite sprite)
        {
            characterImage.sprite = sprite;
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