using System.Collections.Generic;
using RaraMagi.Scripts.Ui;
using RaraMagi.Systems.Characters;
using UnityEngine;

namespace RaraMagi.Systems.TextSystem
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
        private void SetNextLine(bool choice = false, bool yesChoice = false)
        {
            _currentScenario = _scenarioDataList[_currentLineIndex];
            _parent.SetCharacterImage(
                CharaImageCreator.Create(
                    index: _currentScenario.CharaImageIndex,
                    characters: _currentScenario.DisplayCharacterName,
                    charaState: _currentScenario.CharaState
                )
            );

            _parent.SetSpeakerText(_currentScenario.Speaker);
            _parent.SetYesChoices(_currentScenario.IsBranchChoices, _currentScenario.YesChoices);
            _parent.SetNoChoices(_currentScenario.IsBranchChoices, _currentScenario.NoChoices);

            _timeUntilDisplay = _currentScenario.Sentence.Length * intervalForCharDisplay;
            _timeBeganDisplay = Time.time;
            if (_currentScenario.IsSkipSentence) _currentLineIndex = _currentScenario.SkipLine;
            else if (choice)
                _currentLineIndex = yesChoice ? _currentScenario.GotoAfterYes : _currentScenario.GotoAfterNo;
            else _currentLineIndex++;
            _lastUpdateCharCount = 0;
        }

        private void Choice(bool yes)
        {
            SetNextLine(choice: true, yesChoice: yes);
        }

        private bool IsCompletedDisplay()
        {
            return Time.time > _timeBeganDisplay + _timeUntilDisplay;
        }
    }
}