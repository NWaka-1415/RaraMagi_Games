namespace RaraMagi.Systems.Characters
{
    public class ScenarioData
    {
        public string Speaker { get; private set; }

        public string Sentence { get; private set; }
        public CharacterNames DisplayCharacterName { get; private set; }
        public CharaState CharaState { get; private set; }

        public int Index { get; private set; }

        public ScenarioData(
            string speaker,
            string sentence,
            CharacterNames characterDisplayCharacterNames,
            CharaState charaState,
            int index
        )
        {
            Speaker = speaker;
            Sentence = sentence;
            DisplayCharacterName = characterDisplayCharacterNames;
            CharaState = charaState;
            Index = index;
        }
    }
}