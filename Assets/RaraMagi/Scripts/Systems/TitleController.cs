using System;
using RaraMagi.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace RaraMagi.Systems
{
    public class TitleController : MonoBehaviour
    {
        [SerializeField] private Button newGameButton = null;
        [SerializeField] private Button dataLoadButton = null;
        [SerializeField] private Button continueButton = null;
        [SerializeField] private Button extraButton = null;
        [SerializeField] private Button exitButton = null;

        private void Awake()
        {
            newGameButton.onClick.AddListener((OnclickGoToNewGame));
            dataLoadButton.onClick.AddListener(OnclickDataLoad);
            continueButton.onClick.AddListener(OnclickGoToContinue);
            extraButton.onClick.AddListener(OnclickExtra);
        }

        private void OnclickGoToNewGame()
        {
            AppController.Instance.GoToGame(GameState.New);
        }

        private void OnclickDataLoad()
        {
        }

        private void OnclickGoToContinue()
        {
            AppController.Instance.GoToGame(GameState.Continue);
        }

        private void OnclickExtra()
        {
        }

        private void OnclickExit()
        {
            AppController.ExitApplication();
        }
    }
}