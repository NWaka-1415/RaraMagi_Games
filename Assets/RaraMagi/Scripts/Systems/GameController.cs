using System;
using System.Collections.Generic;
using RaraMagi.Systems.BackGrounds;
using RaraMagi.Ui;
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
            int chapter = 0;
            CharacterNames chapterChara = CharacterNames.All;
            switch (AppController.Instance.CurrentGameState)
            {
                case GameState.New:
                    chapter = 0;
                    chapterChara = CharacterNames.All;
                    break;
                case GameState.Continue:
                    break;
            }

            // SetScenarioData(chapter, chapterChara);

            SetScenarioData(0, CharacterNames.Tsubasa);
            _gameUiController.SetSpecialCharacterImage(ImageCreator.CreateChara(8, CharacterNames.Tsubasa,
                CharaState.Kiss));
            _gameUiController.ShowText();
        }

        private void Update()
        {
            _gameUiController.PushText(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return));
        }

        private void SetScenarioData(int chapter, CharacterNames character)
        {
            foreach (string text in TextLoader.Load(chapter, character, true))
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
                CharacterNames afterYesIncreasedFavorability = CharacterNames.Null;

                bool isSkipSentence = false;
                int skipLine = -1;

                bool isDisplayBg = true;
                BackGroundNames backGroundNames = BackGroundNames.Null;
                BackGroundState backGroundState = BackGroundState.Morning;

                bool isDisplayNormalImages = false;
                List<DisplayNormalCharaData> displayNormalCharas = new List<DisplayNormalCharaData>();
                CharacterDisplayPositions position = CharacterDisplayPositions.Null;
                CharacterNames normalCharacterName = CharacterNames.Null;
                CharaState normalCharaState = CharaState.Normal;
                int normalIndex = 0;

                bool isDisplaySpImage = false;
                CharacterNames spCharacterName = CharacterNames.Null;
                CharaState spCharaState = CharaState.Normal;
                int spCharaImageIndex = 0;

                bool chapterEnd = false;
                bool isFlash = false;

                bool isDisplaySecondSpImage = false;

                // データなしと判断
                bool isBlank = false;

                for (int i = 0; i < contents.Length; i++)
                {
                    if (isBlank) break;
                    switch (i)
                    {
                        case 0:
                            // Id
                            Debug.Log($"case 0:Convert int => Id:{contents[i]}");
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
                            Debug.Log($"case 1:=>Speaker:{contents[i]}");
                            speakerName = contents[i];
                            break;
                        case 2:
                            // 内容
                            Debug.Log($"case 2:=>Sentence:{contents[i]}");
                            sentence = contents[i];
                            break;
                        case 3:
                            // 選択肢あり？
                            Debug.Log($"case 3:Convert bool => isBranch:{contents[i]}");
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
                            Debug.Log($"case 4:=> YesChoices:{contents[i]}");
                            yesChoices = contents[i];
                            break;
                        case 5:
                            // 選択肢2No
                            Debug.Log($"case 5:=> NoChoices:{contents[i]}");
                            noChoices = contents[i];
                            break;
                        case 6:
                            // YesSkip先Id
                            Debug.Log($"case 6:Convert int => gotoAfterYes:{contents[i]}");
                            if (isBranch) gotoAfterYes = Int32.Parse(contents[i]);
                            break;
                        case 7:
                            // NoSkip先Id
                            Debug.Log($"case 7:Convert int => gotoAfterNo:{contents[i]}");
                            if (isBranch) gotoAfterNo = Int32.Parse(contents[i]);
                            break;
                        case 8:
                            // Yes選択時に好感度が上昇するキャラ
                            Enum.TryParse(contents[i], out afterYesIncreasedFavorability);
                            break;
                        case 9:
                            // 次の会話をスキップする
                            isSkipSentence = Convert.ToBoolean(contents[i]);
                            break;
                        case 10:
                            // Skip先Id
                            if (isSkipSentence) skipLine = Int32.Parse(contents[i]);
                            break;
                        case 11:
                            // 背景表示の有無
                            isDisplayBg = Convert.ToBoolean(contents[i]);
                            break;
                        case 12:
                            // 背景種類
                            Enum.TryParse(contents[i], out backGroundNames);
                            break;
                        case 13:
                            // 背景状態
                            Debug.Log($"case 13: Convert Enum => backGroundState:{contents[i]}");
                            Enum.TryParse(contents[i], out backGroundState);
                            break;
                        case 14:
                            // 通常イラストの表示
                            Debug.Log($"case 14:Convert bool {contents[i]}");
                            isDisplayNormalImages = Convert.ToBoolean(contents[i]);
                            break;
                        case 15:
                        case 19:
                        case 23:
                        case 27:
                        case 31:
                            // 通常イラスト表示位置
                            if (isDisplayNormalImages) Enum.TryParse(contents[i], out position);
                            break;
                        case 16:
                        case 20:
                        case 24:
                        case 28:
                        case 32:
                            // 通常イラストのキャラ
                            if (isDisplayNormalImages) Enum.TryParse(contents[i], out normalCharacterName);
                            break;
                        case 17:
                        case 21:
                        case 25:
                        case 29:
                        case 33:
                            // 通常イラストキャラの状態
                            if (isDisplayNormalImages) Enum.TryParse(contents[i], out normalCharaState);
                            break;
                        case 18:
                        case 22:
                        case 26:
                        case 30:
                        case 34:
                            // 通常イラストキャラインデックス
                            if (isDisplayNormalImages)
                            {
                                normalIndex = Int32.Parse(contents[i]);

                                displayNormalCharas.Add(
                                    new DisplayNormalCharaData(
                                        normalCharacterName,
                                        normalCharaState,
                                        position,
                                        normalIndex
                                    )
                                );
                            }

                            break;
                        case 35:
                            // 特別イラストを表示するか
                            isDisplaySpImage = Convert.ToBoolean(contents[i]);
                            break;
                        case 36:
                            // 特別イラストのキャラの名前
                            if (isDisplaySpImage) Enum.TryParse(contents[i], out spCharacterName);
                            break;
                        case 37:
                            // 特別イラストのキャラ状態
                            if (isDisplaySpImage) Enum.TryParse(contents[i], out spCharaState);
                            break;
                        case 38:
                            // 特別イラストインデックス
                            if (isDisplaySpImage) spCharaImageIndex = Int32.Parse(contents[i]);
                            break;
                        case 39:
                            // チャプター最後の会話か
                            chapterEnd = Convert.ToBoolean(contents[i]);
                            break;
                        case 40:
                            // フラッシュ演出ありか
                            isFlash = Convert.ToBoolean(contents[i]);
                            break;
                        case 41:
                            // 特別イラストの二枚目の有無
                            isDisplaySecondSpImage = Convert.ToBoolean(contents[i]);
                            break;
                    }
                }

                if (!isBlank)
                {
                    ScenarioDataList.Add(
                        id,
                        new ScenarioData(
                            id: id,
                            speaker: speakerName,
                            sentence: sentence,
                            isBranchChoices: isBranch,
                            yesChoices: yesChoices,
                            noChoices: noChoices,
                            gotoAfterYes: gotoAfterYes,
                            gotoAfterNo: gotoAfterNo,
                            afterYesIncreasedFavorability: afterYesIncreasedFavorability,
                            isSkipSentence: isSkipSentence,
                            skipLine: skipLine,
                            isDisplayBackground: isDisplayBg,
                            displayBackgroundData: new DisplayBackgroundData(backGroundNames, backGroundState),
                            isDisplayNormalImages: isDisplayNormalImages,
                            displayNormalCharaDataList: displayNormalCharas,
                            isDisplaySpecialImage: isDisplaySpImage,
                            displaySpecialChara: new DisplaySpecialCharaData(spCharacterName, spCharaState,
                                spCharaImageIndex),
                            chapterEnd: chapterEnd,
                            isFlashIllustration: isFlash,
                            isDisplaySecondSpecialImage: isDisplaySecondSpImage
                        )
                    );
                }
            }

            _gameUiController.SetData(ScenarioDataList);
        }
    }
}