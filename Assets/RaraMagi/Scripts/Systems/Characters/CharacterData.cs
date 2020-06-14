using System.Collections.Generic;

namespace RaraMagi.Systems
{
    public static class CharacterData
    {
        public static readonly Dictionary<CharacterNames, string> CharaPath = new Dictionary<CharacterNames, string>()
        {
            {CharacterNames.All, "All"},
            {CharacterNames.Tsubasa, "Tsubasa"},
        };

        public static readonly Dictionary<CharaState, string> CharaStatePath = new Dictionary<CharaState, string>()
        {
            {CharaState.Normal, "Normal"},
            {CharaState.Kiss, "Kiss"},
            {CharaState.BedIn, "BedIn"},
        };
    }
}