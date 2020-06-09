using UnityEngine;

namespace RaraMagi.Systems
{
    public class GameController : MonoBehaviour
    {
        private GameUiController _gameUiController = null;

        private void Awake()
        {
            _gameUiController = FindObjectOfType<GameUiController>();
        }

        private void Start()
        {
            _gameUiController.SetCharacterImage(CharaImageCreator.Create(8, Characters.Tsubasa, CharaState.Kiss));
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                
            }
        }

        private void NextText()
        {
            
        }
    }
}