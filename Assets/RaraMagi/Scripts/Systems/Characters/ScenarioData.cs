namespace RaraMagi.Systems.Characters
{
    public class ScenarioData
    {
        public int Id { get; private set; }

        public string Speaker { get; private set; }

        public string Sentence { get; private set; }

        public bool IsBranchChoices { get; private set; }

        public string YesChoices { get; private set; }

        public string NoChoices { get; private set; }

        public int GotoAfterYes { get; private set; }

        public int GotoAfterNo { get; private set; }

        public bool IsSkipSentence { get; private set; }

        public int SkipLine { get; private set; }

        public CharacterNames DisplayCharacterName { get; private set; }

        public CharaState CharaState { get; private set; }

        public int CharaImageIndex { get; private set; }

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
            CharacterNames characterDisplayCharacterNames,
            CharaState charaState,
            int charaImageIndex
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
            DisplayCharacterName = characterDisplayCharacterNames;
            CharaState = charaState;
            CharaImageIndex = charaImageIndex;
        }
    }
}