using System;
using UnityEngine;
using UnityEngine.UI;

namespace RaraMagi.Systems
{
    public class TitleController : MonoBehaviour
    {
        [SerializeField] private Button touchButton = null;

        private void Awake()
        {
            touchButton.onClick.AddListener((OnclickGoToGame));
        }

        private void OnclickGoToGame()
        {
            AppController.Instance.GoTo(RoomController.Room.Game);
        }
    }
}