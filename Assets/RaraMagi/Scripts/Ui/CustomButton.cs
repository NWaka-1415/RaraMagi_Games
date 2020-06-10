using System;
using UnityEngine;
using UnityEngine.UI;

namespace RaraMagi.Scripts.Ui
{
    public class CustomButton : MonoBehaviour
    {
        [SerializeField] private Button button = null;
        [SerializeField] private Text text = null;

        private event Action<CustomButton> ActionEvent = null;

        private void Awake()
        {
            if (button == null) button = GetComponent<Button>();
            if (text == null) text = GetComponentInChildren<Text>();
        }

        public void SetActive(bool enable)
        {
            gameObject.SetActive(enable);
        }

        public void SetButtonAction(Action<CustomButton> action)
        {
            ActionEvent += action;
            button.onClick.AddListener((() => ActionEvent.Invoke(this)));
        }

        public void ResetAction()
        {
            ActionEvent = null;
        }

        public void SetText(string message)
        {
            text.text = message;
        }
    }
}