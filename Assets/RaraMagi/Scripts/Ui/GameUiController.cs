using System;
using System.Collections.Generic;
using RaraMagi.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace RaraMagi.Ui
{
    public class GameUiController : MonoBehaviour, IScenarioController
    {
        [SerializeField] Image[] characterNormalImages = new Image[5];
        [SerializeField] private Image characterSpImage = null;
        [SerializeField] private Image textLog = null;
        [SerializeField] private Image background = null;
        [SerializeField] private Text speakerText = null;
        [SerializeField] private Text contentText = null;
        [SerializeField] private CustomButton yesButton = null;
        [SerializeField] private CustomButton noButton = null;
        [SerializeField] private Image normalCenter = null;
        [SerializeField] private Image normalMidR = null;
        [SerializeField] private Image normalMidL = null;
        [SerializeField] private Image normalRight = null;
        [SerializeField] private Image normalLeft = null;
        [SerializeField] private Animator flashPanelAnimator = null;

        private TextController _textController = null;

        private static readonly int IsFlash = Animator.StringToHash("isFlash");

        private void Awake()
        {
            _textController = new TextController(this);
        }


        public void SetNormalCharacterImage(Sprite sprite, CharacterDisplayPositions position)
        {
            switch (position)
            {
                case CharacterDisplayPositions.Center:
                    AppController.SetActive(normalCenter, true);
                    normalCenter.sprite = sprite;
                    break;
                case CharacterDisplayPositions.MidRight:
                    AppController.SetActive(normalMidR, true);
                    normalMidR.sprite = sprite;
                    break;
                case CharacterDisplayPositions.MidLeft:
                    AppController.SetActive(normalMidL, true);
                    normalMidL.sprite = sprite;
                    break;
                case CharacterDisplayPositions.Right:
                    AppController.SetActive(normalRight, true);
                    normalRight.sprite = sprite;
                    break;
                case CharacterDisplayPositions.Left:
                    AppController.SetActive(normalLeft, true);
                    normalLeft.sprite = sprite;
                    break;
            }
        }

        public void HideNormalCharacterImage(CharacterDisplayPositions position)
        {
            switch (position)
            {
                case CharacterDisplayPositions.Center:
                    AppController.SetActive(normalCenter, false);
                    break;
                case CharacterDisplayPositions.MidRight:
                    AppController.SetActive(normalMidR, false);
                    break;
                case CharacterDisplayPositions.MidLeft:
                    AppController.SetActive(normalMidL, false);
                    break;
                case CharacterDisplayPositions.Right:
                    AppController.SetActive(normalRight, false);
                    break;
                case CharacterDisplayPositions.Left:
                    AppController.SetActive(normalLeft, false);
                    break;
            }
        }

        public void HideAllNormalCharacterImage()
        {
            AppController.SetActive(normalCenter, false);
            AppController.SetActive(normalMidR, false);
            AppController.SetActive(normalMidL, false);
            AppController.SetActive(normalRight, false);
            AppController.SetActive(normalLeft, false);
        }

        public void HideNormalCharacterImage()
        {
        }

        public void SetSpecialCharacterImage(Sprite sprite)
        {
            characterSpImage.gameObject.SetActive(true);
            characterSpImage.sprite = sprite;
        }

        public void HideSpecialCharacterImage()
        {
            characterSpImage.gameObject.SetActive(false);
        }

        public void SetBackground(Sprite sprite)
        {
            background.gameObject.SetActive(true);
            background.sprite = sprite;
        }

        public void HideBackground()
        {
            background.gameObject.SetActive(false);
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

        public void ShowText(int startLine = 0)
        {
            _textController.ShowText(startLine);
        }

        public void PushText(bool isPush)
        {
            _textController.TextUpdate(isPush);
        }

        public void ShowMessageWindow()
        {
            textLog.gameObject.SetActive(true);
        }

        public void HideMessageWindow()
        {
            textLog.gameObject.SetActive(false);
        }

        public void Flash()
        {
            flashPanelAnimator.SetTrigger(IsFlash);
        }
    }
}