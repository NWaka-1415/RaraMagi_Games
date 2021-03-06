﻿using System.Collections.Generic;
using RaraMagi.Systems.BackGrounds;
using RaraMagi.Ui;

namespace RaraMagi.Systems
{
    public class ScenarioData
    {
        public int Id { get; private set; }

        /// <summary>
        /// テキストログに表示する話者
        /// </summary>
        public string Speaker { get; private set; }

        /// <summary>
        /// 話している内容
        /// </summary>
        public string Sentence { get; private set; }

        /// <summary>
        /// 選択肢を伴うか
        /// </summary>
        public bool IsBranchChoices { get; private set; }

        /// <summary>
        /// 選択肢を伴う際の選択肢1
        /// 好感度上昇側
        /// </summary>
        public string YesChoices { get; private set; }

        /// <summary>
        /// 選択肢を伴う際の選択肢2
        /// 好感度下降側
        /// </summary>
        public string NoChoices { get; private set; }

        /// <summary>
        /// 選択肢1を選択した際に飛ぶ会話のId
        /// </summary>
        public int GotoAfterYes { get; private set; }

        /// <summary>
        /// 選択肢2を選択した際に飛ぶ会話のId
        /// </summary>
        public int GotoAfterNo { get; private set; }

        /// <summary>
        /// Yes選択後の好感度上昇キャラ
        /// </summary>
        public CharacterNames AfterYesIncreasedFavorability { get; private set; }

        /// <summary>
        /// 次の会話をスキップするのかどうか
        /// 選択肢による分岐後に合流する際などに使用
        /// </summary>
        public bool IsSkipSentence { get; private set; }

        /// <summary>
        /// 次の会話をスキップする際にスキップする先の会話Id
        /// </summary>
        public int SkipLine { get; private set; }

        /// <summary>
        /// 背景を表示するか
        /// </summary>
        public bool IsDisplayBackground { get; private set; }

        /// <summary>
        /// 表示する背景データの詳細
        /// </summary>
        public DisplayBackgroundData DisplayBackgroundData { get; private set; }

        /// <summary>
        /// 通常イラストを表示するか
        /// </summary>
        public bool IsDisplayNormalImages { get; private set; }

        /// <summary>
        /// 通常イラストの詳細データ群
        /// </summary>
        public readonly List<DisplayNormalCharaData> DisplayNormalCharaDataList;

        /// <summary>
        /// 特別イラストを表示するか
        /// </summary>
        public bool IsDisplaySpecialImage { get; private set; }

        /// <summary>
        /// 特別イラストの詳細情報
        /// </summary>
        public DisplaySpecialCharaData DisplaySpecialChara { get; private set; }

        /// <summary>
        /// チャプター最後の会話かどうか
        /// </summary>
        public bool ChapterEnd { get; private set; }

        /// <summary>
        /// 射精時のフラッシュなどをするのかどうか
        /// </summary>
        public bool IsFlashIllustration { get; private set; }

        /// <summary>
        /// 二枚目の固有イメージを表示するのかどうか
        /// </summary>
        public bool IsDisplaySecondSpecialImage { get; private set; }

        //TODO:上記2枚目表示機能はそのうち実装。射精時フラッシュ機能を優先

        public ScenarioData(
            int id,
            string speaker,
            string sentence,
            bool isBranchChoices,
            string yesChoices,
            string noChoices,
            int gotoAfterYes,
            int gotoAfterNo,
            CharacterNames afterYesIncreasedFavorability,
            bool isSkipSentence,
            int skipLine,
            bool isDisplayBackground,
            DisplayBackgroundData displayBackgroundData,
            bool isDisplayNormalImages,
            List<DisplayNormalCharaData> displayNormalCharaDataList,
            bool isDisplaySpecialImage,
            DisplaySpecialCharaData displaySpecialChara,
            bool chapterEnd,
            bool isFlashIllustration,
            bool isDisplaySecondSpecialImage
        )
        {
            Id = id;

            Speaker = speaker;
            Sentence = sentence;

            IsBranchChoices = isBranchChoices;
            YesChoices = yesChoices;
            NoChoices = noChoices;
            GotoAfterYes = gotoAfterYes;
            GotoAfterNo = gotoAfterNo;
            AfterYesIncreasedFavorability = afterYesIncreasedFavorability;

            IsSkipSentence = isSkipSentence;
            SkipLine = skipLine;

            IsDisplayBackground = isDisplayBackground;
            this.DisplayBackgroundData = displayBackgroundData;

            IsDisplayNormalImages = isDisplayNormalImages;
            DisplayNormalCharaDataList = displayNormalCharaDataList;

            IsDisplaySpecialImage = isDisplaySpecialImage;
            DisplaySpecialChara = displaySpecialChara;

            ChapterEnd = chapterEnd;
            IsFlashIllustration = isFlashIllustration;
            IsDisplaySecondSpecialImage = isDisplaySecondSpecialImage;
        }
    }
}