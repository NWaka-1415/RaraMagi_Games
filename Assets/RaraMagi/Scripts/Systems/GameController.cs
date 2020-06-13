﻿using System;
using System.Collections.Generic;
using RaraMagi.Systems;
using RaraMagi.Systems.BackGrounds;
using UnityEngine;

namespace RaraMagi.Systems
{
    public class GameController : MonoBehaviour
    {
        private GameUiController _gameUiController = null;

        public Dictionary<int, ScenarioData> ScenarioDataList { get; private set; }

        private void Awake()
        {
            _gameUiController = FindObjectOfType<GameUiController>();
            ScenarioDataList = new Dictionary<int, ScenarioData>();
        }

        private void Start()
        {
            SetScenarioData(0, CharacterNames.Tsubasa);
            _gameUiController.SetCharacterImage(ImageCreator.Create(8, CharacterNames.Tsubasa, CharaState.Kiss));
            _gameUiController.ShowText();
        }

        private void Update()
        {
            _gameUiController.PushText(Input.GetMouseButtonDown(0));
        }

        private void SetScenarioData(int chapter, CharacterNames character)
        {
            foreach (string text in TextLoader.Load(chapter, character))
            {
                Debug.Log($"Load:{text}");
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
                
                bool isDisplayBg = true;
                BackGroundNames backGroundNames = BackGroundNames.Home;
                BackGroundState backGroundState = BackGroundState.Morning;
                
                bool isDisplaySpImage = false;
                CharacterNames characterNames = CharacterNames.Tsubasa;
                CharaState state = CharaState.Normal;
                int charaImageIndex = 0;
                
                bool chapterEnd = false;
                bool isFlash = false;

                // データなしと判断
                bool isBlank = false;

                for (int i = 0; i < contents.Length; i++)
                {
                    if (isBlank) break;
                    switch (i)
                    {
                        case 0:
                            // Id
                            try
                            {
                                id = Int32.Parse(contents[i]);
                            }
                            catch (Exception e)
                            {
                                Debug.Log($"Except:{e}");
                                isBlank = true;
                            }

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
                            try
                            {
                                isBranch = Convert.ToBoolean(contents[i]);
                            }
                            catch (Exception e)
                            {
                                Debug.Log($"IsBranch Except:{e}");
                                isBlank = true;
                            }

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
                            charaImageIndex = Int32.Parse(contents[i]);
                            break;
                        case 14:
                            chapterEnd = Convert.ToBoolean(contents[i]);
                            break;
                        case 15:
                            isFlash = Convert.ToBoolean(contents[i]);
                            break;
                    }
                }

                if (!isBlank)
                {
                    ScenarioDataList.Add(
                        id,
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
                            chapterEnd,
                            characterNames,
                            state,
                            charaImageIndex,
                            isFlash
                        )
                    );
                }
            }

            _gameUiController.SetData(ScenarioDataList);
        }
    }
}