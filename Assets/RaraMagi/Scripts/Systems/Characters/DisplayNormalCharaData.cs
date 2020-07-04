namespace RaraMagi.Systems
{
    public class DisplayNormalCharaData
    {
        public CharacterNames Name { get; private set; }
        public CharaState StateOnSpecial { get; private set; }
        public CharacterDisplayPositions Position { get; private set; }
        public int Index { get; private set; }

        public DisplayNormalCharaData(CharacterNames name, CharaState stateOnSpecial, CharacterDisplayPositions position,
            int index)
        {
            Name = name;
            StateOnSpecial = stateOnSpecial;
            Position = position;
            Index = index;
        }

        public bool IsAbleToShow()
        {
            return Name != CharacterNames.Null && Position != CharacterDisplayPositions.Null;
        }
    }
}