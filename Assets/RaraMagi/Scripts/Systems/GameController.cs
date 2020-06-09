using RaraMagi.Systems.Characters;
using RaraMagi.Systems.TextSystem;
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
            _gameUiController.SetCharacterImage(CharaImageCreator.Create(8, CharacterNames.Tsubasa, CharaState.Kiss));
            foreach (string text in TextLoader.Load(CharacterNames.Tsubasa, CharaState.Kiss))
            {
               
            }
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