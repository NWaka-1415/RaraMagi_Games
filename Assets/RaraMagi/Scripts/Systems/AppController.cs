using System;
using System.Collections.Generic;
using RaraMagi.Systems.Characters;
using RaraMagi.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace RaraMagi.Systems
{
    public class AppController : MonoBehaviour
    {
        [SerializeField] private RoomController roomController = null;

        private MainUiController _mainUiController = null;

        public static AppController Instance { get; private set; }

        public GameState CurrentGameState { get; private set; }

        #region UnityCycles

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(gameObject);

            AwakeInit();
        }

        #endregion

        private void AwakeInit()
        {
            if (roomController == null) roomController = FindObjectOfType<RoomController>();
            roomController.Initialize();

            _mainUiController = FindObjectOfType<MainUiController>();
            _mainUiController.SetUi(roomController.CurrentRoom);
        }

        private void StartInit()
        {
        }

        public void GoTo(RoomController.Room room)
        {
            roomController.GoToRoom(room);
            _mainUiController.SetUi(roomController.CurrentRoom);
        }

        public void GoToGame(GameState gameState)
        {
            GoTo(RoomController.Room.Game);
            CurrentGameState = gameState;
        }

        public void SetData(List<ScenarioData> scenarioData)
        {
            _mainUiController.SetData(scenarioData);
        }

        public void ShowText()
        {
            _mainUiController.ShowText();
        }

        public void PushText(bool isPush)
        {
            _mainUiController.PushText(isPush);
        }

        public static void SetActive(MaskableGraphic maskableGraphic, bool enable)
        {
            maskableGraphic.gameObject.SetActive(enable);
        }
    }
}