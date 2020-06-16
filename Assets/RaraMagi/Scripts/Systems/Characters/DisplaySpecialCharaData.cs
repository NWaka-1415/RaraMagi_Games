namespace RaraMagi.Ui
{
    public class DisplaySpecialCharaData
    {
        public CharacterNames Name { get; private set; }
        public CharaState State { get; private set; }
        public int Index { get; private set; }

        public DisplaySpecialCharaData(CharacterNames name, CharaState state, int index)
        {
            Name = name;
            State = state;
            Index = index;
        }

        public bool IsAbleToShow()
        {
            return Name != CharacterNames.Null;
        }
    }
}