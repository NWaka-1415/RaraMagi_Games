namespace RaraMagi.Systems.TextSystem
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
        /// 次の会話をスキップするのかどうか
        /// 選択肢による分岐後に合流する際などに使用
        /// </summary>
        public bool IsSkipSentence { get; private set; }

        /// <summary>
        /// 次の会話をスキップする際にスキップする先の会話Id
        /// </summary>
        public int SkipLine { get; private set; }

        /// <summary>
        /// チャプター最後の会話かどうか
        /// </summary>
        public bool ChapterEnd { get; private set; }

        /// <summary>
        /// 表示する固有イメージのキャラ名
        /// </summary>
        public CharacterNames DisplayCharacterName { get; private set; }

        /// <summary>
        /// 表示する固有イメージのキャラの状態
        /// </summary>
        public CharaState CharaState { get; private set; }

        /// <summary>
        /// 表示する固有イメージのキャラの番号
        /// </summary>
        public int CharaImageIndex { get; private set; }

        /// <summary>
        /// 射精時のフラッシュなどをするのかどうか
        /// </summary>
        public bool IsFlashIllustration { get; private set; }

        /// <summary>
        /// 二枚目の固有イメージを表示するのかどうか
        /// </summary>
        public bool IsDisplaySecondImage { get; private set; }

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
            bool isSkipSentence,
            int skipLine,
            bool chapterEnd,
            CharacterNames characterDisplayCharacterNames,
            CharaState charaState,
            int charaImageIndex,
            bool isFlashIllustration
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
            IsSkipSentence = isSkipSentence;
            SkipLine = skipLine;
            ChapterEnd = chapterEnd;
            DisplayCharacterName = characterDisplayCharacterNames;
            CharaState = charaState;
            CharaImageIndex = charaImageIndex;
            IsFlashIllustration = isFlashIllustration;
        }
    }
}