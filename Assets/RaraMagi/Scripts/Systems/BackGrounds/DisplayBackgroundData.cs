namespace RaraMagi.Systems.BackGrounds
{
    public class DisplayBackgroundData
    {
        public BackGroundNames Name { get; private set; }
        public BackGroundState State { get; private set; }

        public DisplayBackgroundData(BackGroundNames name, BackGroundState state)
        {
            Name = name;
            State = state;
        }

        public bool IsAbleToShow()
        {
            return Name != BackGroundNames.Null;
        }
    }
}