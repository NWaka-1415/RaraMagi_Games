using System.Collections.Generic;
using RaraMagi.Ui;
using UnityEngine;

namespace RaraMagi.Systems
{
    public class TextController
    {
        private float intervalForCharDisplay = 0.05f; // 1文字の表示にかける時間

        private int _currentLineIndex = 0; //現在表示している文章番号
        private ScenarioData _currentScenario = null; // 現在のシナリオデータ
        private float _timeUntilDisplay = 0; // 表示にかかる時間
        private float _timeBeganDisplay = 1; // 文字列の表示を開始した時間
        private int _lastUpdateCharCount = -1; // 表示中の文字数

        private Dictionary<int, ScenarioData> _scenarioDataList = null;

        private IScenarioController _parent;

        public bool IsCompletedAllSentences { get; private set; }

        public TextController(IScenarioController parent)
        {
            this._parent = parent;

            IsCompletedAllSentences = false;
        }

        public void SetData(Dictionary<int, ScenarioData> scenario)
        {
            _scenarioDataList = scenario;
        }

        public void ShowText()
        {
            SetNextLine();
        }

        public void TextUpdate(bool isPush)
        {
            if (IsCompletedAllSentences) return;
            // 文章の表示完了
            if (IsCompletedDisplay())
            {
                //最後の文章ではない & ボタンが押された
                if (_currentLineIndex < _scenarioDataList.Count && isPush)
                {
                    if (!_currentScenario.IsBranchChoices) SetNextLine();
                }
                // 初期に戻る
                else if (_currentLineIndex >= _scenarioDataList.Count)
                {
                    _currentLineIndex = 0;
                    IsCompletedAllSentences = true;
                }
            }
            // 未完
            else
            {
                if (isPush)
                {
                    _timeUntilDisplay = 0;
                }
            }

            //表示される文字数を計算
            int displayCharCount = (int) (Mathf.Clamp01((Time.time - _timeBeganDisplay) / _timeUntilDisplay) *
                                          _currentScenario.Sentence.Length);
            //表示される文字数が表示している文字数と違う
            if (displayCharCount != _lastUpdateCharCount)
            {
                _parent.SetMainText(_currentScenario.Sentence.Substring(0, displayCharCount));
                //表示している文字数の更新
                _lastUpdateCharCount = displayCharCount;
            }
        }

        // 次の文章をセットする
        private void SetNextLine()
        {
            Debug.Log($"CurrentLineIndex:{_currentLineIndex}");
            _currentScenario = _scenarioDataList[_currentLineIndex];

            // いったん全部Hide
            _parent.HideAllNormalCharacterImage();

            if (_currentScenario.IsDisplayNormalImages)
            {
                // 通常イラスト表示
                foreach (DisplayNormalCharaData displayNormalCharaData in _currentScenario.DisplayNormalCharaDataList)
                {
                    if (displayNormalCharaData.IsAbleToShow())
                    {
                        _parent.SetNormalCharacterImage(
                            ImageCreator.CreateChara(
                                displayNormalCharaData.Index,
                                displayNormalCharaData.Name,
                                displayNormalCharaData.State
                            ),
                            displayNormalCharaData.Position
                        );
                    }
                    else _parent.HideNormalCharacterImage(displayNormalCharaData.Position);
                }
            }
            else _parent.HideNormalCharacterImage();

            if (_currentScenario.IsDisplaySpecialImage && _currentScenario.DisplaySpecialChara.IsAbleToShow())
            {
                // 特別イラスト表示
                _parent.SetSpecialCharacterImage(
                    ImageCreator.CreateChara(
                        index: _currentScenario.DisplaySpecialChara.Index,
                        characters: _currentScenario.DisplaySpecialChara.Name,
                        charaStateOnSpecial: _currentScenario.DisplaySpecialChara.StateOnSpecial
                    )
                );
            }
            else _parent.HideSpecialCharacterImage();


            if (_currentScenario.IsDisplayBackground && _currentScenario.DisplayBackgroundData.IsAbleToShow())
            {
                // 背景表示
                _parent.SetBackground(
                    ImageCreator.CreateBackground(
                        0,
                        _currentScenario.DisplayBackgroundData.Name,
                        _currentScenario.DisplayBackgroundData.State
                    )
                );
            }
            else _parent.HideBackground();


            _parent.SetSpeakerText(_currentScenario.Speaker);
            if (_currentScenario.IsBranchChoices)
            {
                _parent.SetYesChoices(_currentScenario.IsBranchChoices, _currentScenario.YesChoices,
                    (button => Choice(true)));
                _parent.SetNoChoices(_currentScenario.IsBranchChoices, _currentScenario.NoChoices,
                    (button => Choice(false)));
            }
            else
            {
                _parent.SetYesChoices(_currentScenario.IsBranchChoices);
                _parent.SetNoChoices(_currentScenario.IsBranchChoices);
            }


            _timeUntilDisplay = _currentScenario.Sentence.Length * intervalForCharDisplay;
            _timeBeganDisplay = Time.time;
            if (_currentScenario.IsSkipSentence) _currentLineIndex = _currentScenario.SkipLine;
            else _currentLineIndex++;

            _lastUpdateCharCount = 0;
        }

        private void Choice(bool yes)
        {
            _currentLineIndex = yes ? _currentScenario.GotoAfterYes : _currentScenario.GotoAfterNo;
            SetNextLine();
        }

        private bool IsCompletedDisplay()
        {
            return Time.time > _timeBeganDisplay + _timeUntilDisplay;
        }
    }
}