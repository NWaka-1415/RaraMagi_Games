namespace RaraMagi.Systems
{
    public class DisplaySpecialCharaData
    {
        public CharacterNames Name { get; private set; }
        public CharaStateOnSpecial StateOnSpecial { get; private set; }
        public int Index { get; private set; }

        public DisplaySpecialCharaData(CharacterNames name, CharaStateOnSpecial stateOnSpecial, int index)
        {
            Name = name;
            StateOnSpecial = stateOnSpecial;
            Index = index;
        }

        public bool IsAbleToShow()
        {
            return Name != CharacterNames.Null;
        }
    }
}