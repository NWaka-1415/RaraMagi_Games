using System;
using System.Collections.Generic;
using RaraMagi.Systems;
using RaraMagi.Systems.Characters;
using RaraMagi.Systems.TextSystem;
using UnityEngine;
using UnityEngine.UI;

namespace RaraMagi.Ui
{
    public class MainUiController : MonoBehaviour
    {
        [SerializeField] private Image textLog = null;
        [SerializeField] private Text speakerText = null;
        [SerializeField] private Text contentText = null;

        private TextController _textController = null;

        private void Awake()
        {
            _textController = new TextController(contentText, speakerText);
        }

        public void SetUi(RoomController.Room room)
        {
            switch (room)
            {
                case RoomController.Room.Title:
                    AppController.SetActive(textLog, false);
                    break;
                case RoomController.Room.Game:
                    AppController.SetActive(textLog, true);
                    break;
            }
        }

        public void SetData(List<ScenarioData> scenarioDataList)
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