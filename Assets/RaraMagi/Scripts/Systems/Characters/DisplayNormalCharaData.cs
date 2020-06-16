namespace RaraMagi.Systems
{
    public class DisplayNormalCharaData
    {
        public CharacterNames Name { get; private set; }
        public CharaState State { get; private set; }
        public CharacterDisplayPositions Position { get; private set; }
        public int Index { get; private set; }

        public DisplayNormalCharaData(CharacterNames name, CharaState state, CharacterDisplayPositions position,
            int index)
        {
            Name = name;
            State = state;
            Position = position;
            Index = index;
        }
    }
}