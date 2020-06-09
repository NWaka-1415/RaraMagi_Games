using UnityEngine;
using UnityEngine.UI;

namespace RaraMagi.Systems
{
    public class GameUiController : MonoBehaviour
    {
        [SerializeField] private Image characterImage = null;

        public void SetCharacterImage(Sprite sprite)
        {
            characterImage.sprite = sprite;
        }
    }
}