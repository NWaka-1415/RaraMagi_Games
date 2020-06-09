using System.Collections.Generic;

namespace RaraMagi.Systems.Characters
{
    public static class CharacterController
    {
        public static readonly Dictionary<CharacterNames, string> CharaPath = new Dictionary<CharacterNames, string>()
        {
            {CharacterNames.Tsubasa, "Tsubasa"},
        };

        public static readonly Dictionary<CharaState, string> CharaStatePath = new Dictionary<CharaState, string>()
        {
            {CharaState.Normal, "Normal"},
            {CharaState.Kiss, "Kiss"}
        };
    }
}