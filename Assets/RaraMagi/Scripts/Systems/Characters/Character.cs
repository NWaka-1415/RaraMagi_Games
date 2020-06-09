namespace RaraMagi.Systems.Characters
{
    public class Character
    {
        public CharacterNames name { get; private set; }

        public Character(CharacterNames characterNames)
        {
            name = characterNames;
        }
    }
}