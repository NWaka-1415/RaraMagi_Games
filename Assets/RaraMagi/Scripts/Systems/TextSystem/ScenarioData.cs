using RaraMagi.Systems.BackGrounds;

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
        /// 背景の名前
        /// </summary>
        public BackGroundNames DisplayBgName { get; private set; }

        /// <summary>
        /// 背景の状態
        /// </summary>
        public BackGroundState BgState { get; private set; }

        /// <summary>
        /// 特別イラストを表示するか
        /// </summary>
        public bool IsDisplaySpecialImage { get; private set; }

        /// <summary>
        /// 表示する特別イメージのキャラ名
        /// </summary>
        public CharacterNames SpCharacterName { get; private set; }

        /// <summary>
        /// 表示する特別イメージのキャラの状態
        /// </summary>
        public CharaState SpCharaState { get; private set; }

        /// <summary>
        /// 表示する特別イメージのキャラの番号
        /// </summary>
        public int SpCharaImageIndex { get; private set; }

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
            BackGroundNames displayBgName,
            BackGroundState bgState,
            bool isDisplaySpecialImage,
            CharacterNames spCharacterName,
            CharaState spCharaState,
            int spCharaImageIndex,
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
            DisplayBgName = displayBgName;
            BgState = bgState;

            IsDisplaySpecialImage = isDisplaySpecialImage;
            SpCharacterName = spCharacterName;
            SpCharaState = spCharaState;
            SpCharaImageIndex = spCharaImageIndex;

            ChapterEnd = chapterEnd;
            IsFlashIllustration = isFlashIllustration;
            IsDisplaySecondSpecialImage = isDisplaySecondSpecialImage;
        }
    }
}