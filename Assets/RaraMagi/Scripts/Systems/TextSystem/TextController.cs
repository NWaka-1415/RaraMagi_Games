﻿using UnityEngine;
using UnityEngine.UI;

namespace RaraMagi.Systems.TextSystem
{
    public class TextController : MonoBehaviour
    {
        private readonly string[] _sentences; // 文章を格納する

        private float intervalForCharDisplay = 0.05f; // 1文字の表示にかける時間

        private int _currentLineIndex = 0; //現在表示している文章番号
        private string _currentLine = string.Empty; // 現在の文字列
        private float _timeUntilDisplay = 0; // 表示にかかる時間
        private float _timeBeganDisplay = 1; // 文字列の表示を開始した時間
        private int _lastUpdateCharCount = -1; // 表示中の文字数

        public bool IsCompletedAllSentences { get; private set; }

        private readonly Text _uiText;

        public TextController(Text uiText, string[] sentences)
        {
            this._sentences = sentences;
            this._uiText = uiText;
            IsCompletedAllSentences = false;

            SetNextLine();
        }

        public string TextUpdate(bool isPush)
        {
            if (IsCompletedAllSentences) return "";
            // 文章の表示完了 / 未完了
            if (IsCompletedDisplay())
            {
                //最後の文章ではない & ボタンが押された
                if (_currentLineIndex < _sentences.Length && isPush)
                {
                    SetNextLine();
                }
                // 初期に戻る
                else if (_currentLineIndex >= _sentences.Length)
                {
                    _currentLineIndex = 0;
                    IsCompletedAllSentences = true;
                }
            }
            else
            {
                if (isPush)
                {
                    _timeUntilDisplay = 0; //※1
                }
            }

            //表示される文字数を計算
            int displayCharCount = (int) (Mathf.Clamp01((Time.time - _timeBeganDisplay) / _timeUntilDisplay) *
                                          _currentLine.Length);
            //表示される文字数が表示している文字数と違う
            if (displayCharCount != _lastUpdateCharCount)
            {
                string result = _currentLine.Substring(0, displayCharCount);
                //表示している文字数の更新
                _lastUpdateCharCount = displayCharCount;
                return result;
            }

            return "";
        }

        // 次の文章をセットする
        void SetNextLine()
        {
            _currentLine = _sentences[_currentLineIndex];
            _timeUntilDisplay = _currentLine.Length * intervalForCharDisplay;
            _timeBeganDisplay = Time.time;
            _currentLineIndex++;
            _lastUpdateCharCount = 0;
        }

        bool IsCompletedDisplay()
        {
            return Time.time > _timeBeganDisplay + _timeUntilDisplay;
        }
    }
}