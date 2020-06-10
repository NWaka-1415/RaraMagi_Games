using System;
using System.Collections.Generic;
using RaraMagi.Systems.Characters;
using RaraMagi.Systems.TextSystem;
using UnityEngine;

namespace RaraMagi.Systems
{
    public class GameController : MonoBehaviour
    {
        private GameUiController _gameUiController = null;

        public List<ScenarioData> ScenarioDataList { get; private set; }

        private void Awake()
        {
            _gameUiController = FindObjectOfType<GameUiController>();
            ScenarioDataList = new List<ScenarioData>();
        }

        private void Start()
        {
            SetScenarioData(CharacterNames.Tsubasa, CharaState.Kiss);
            _gameUiController.SetCharacterImage(CharaImageCreator.Create(8, CharacterNames.Tsubasa, CharaState.Kiss));
            _gameUiController.ShowText();
        }

        private void Update()
        {
            _gameUiController.PushText(Input.GetMouseButtonDown(0));
        }

        private void SetScenarioData(CharacterNames character, CharaState charaState)
        {
            foreach (string text in TextLoader.Load(character, charaState))
            {
                string[] contents = text.Split(',');
                string speakerName = "";
                string sentence = "";
                CharacterNames characterNames = CharacterNames.Tsubasa;
                CharaState state = CharaState.Normal;
                int index = 0;
                for (int i = 0; i < contents.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            speakerName = contents[i];
                            break;
                        case 1:
                            sentence = contents[i];
                            break;
                        case 2:
                            Enum.TryParse(contents[i], out characterNames);
                            break;
                        case 3:
                            Enum.TryParse(contents[i], out state);
                            break;
                        case 4:
                            index = Int32.Parse(contents[i]);
                            break;
                    }
                }

                ScenarioDataList.Add(new ScenarioData(speakerName, sentence, characterNames, state, index));
            }

            _gameUiController.SetData(ScenarioDataList);
        }
    }
}