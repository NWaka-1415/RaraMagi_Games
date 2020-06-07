using RaraMagi.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace RaraMagi.Ui
{
    public class MainUiController : MonoBehaviour
    {
        [SerializeField] private Image textLog = null;

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
    }
}