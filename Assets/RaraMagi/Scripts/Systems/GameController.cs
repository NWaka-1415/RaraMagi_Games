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

                int id = 0;
                string speakerName = "";
                string sentence = "";
                bool isBranch = false;
                string yesChoices = "";
                string noChoices = "";
                int gotoAfterYes = -1;
                int gotoAfterNo = -1;
                bool isSkipSentence = false;
                int skipLine = -1;
                CharacterNames characterNames = CharacterNames.Tsubasa;
                CharaState state = CharaState.Normal;
                int index = 0;
                for (int i = 0; i < contents.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            // Id
                            id = Int32.Parse(contents[i]);
                            break;
                        case 1:
                            // 話す人
                            speakerName = contents[i];
                            break;
                        case 2:
                            // 内容
                            sentence = contents[i];
                            break;
                        case 3:
                            // 選択肢あり？
                            isBranch = Convert.ToBoolean(contents[i]);
                            break;
                        case 4:
                            // 選択肢1Yes
                            yesChoices = contents[i];
                            break;
                        case 5:
                            // 選択肢2No
                            noChoices = contents[i];
                            break;
                        case 6:
                            if (isBranch) gotoAfterYes = Int32.Parse(contents[i]);
                            break;
                        case 7:
                            if (isBranch) gotoAfterNo = Int32.Parse(contents[i]);
                            break;
                        case 8:
                            isSkipSentence = Convert.ToBoolean(contents[i]);
                            break;
                        case 9:
                            if (isSkipSentence) skipLine = Int32.Parse(contents[i]);
                            break;
                        case 10:
                            Enum.TryParse(contents[i], out characterNames);
                            break;
                        case 11:
                            Enum.TryParse(contents[i], out state);
                            break;
                        case 12:
                            index = Int32.Parse(contents[i]);
                            break;
                    }
                }

                ScenarioDataList.Add(
                    new ScenarioData(
                        id,
                        speakerName,
                        sentence,
                        isBranch,
                        yesChoices,
                        noChoices,
                        gotoAfterYes,
                        gotoAfterNo,
                        isSkipSentence,
                        skipLine,
                        characterNames,
                        state,
                        index
                    )
                );
            }

            _gameUiController.SetData(ScenarioDataList);
        }
    }
}