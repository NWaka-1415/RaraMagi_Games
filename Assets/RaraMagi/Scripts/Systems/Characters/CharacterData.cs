using System.Collections.Generic;

namespace RaraMagi.Systems
{
    public static class CharacterData
    {
        public static readonly Dictionary<CharacterNames, string> CharaPath = new Dictionary<CharacterNames, string>()
        {
            {CharacterNames.All, "All"},
            {CharacterNames.Tsubasa, "Tsubasa"},
            {CharacterNames.Tomomi, "Tomomi"},
            {CharacterNames.Nanami, "Nanami"},
            {CharacterNames.Saaya, "Saaya"}
        };

        public static readonly Dictionary<CharaState, string> CharaStatePath = new Dictionary<CharaState, string>()
        {
            {CharaState.Naked, "Naked"},
            {CharaState.Uniform, "Uniform"},
            {CharaState.UniformOnJacket, "UniformOnJacket"},
            {CharaState.Clothes, "Clothes"},
        };

        public static readonly Dictionary<CharaStateOnSpecial, string> CharaStateSpecialPath =
            new Dictionary<CharaStateOnSpecial, string>()
            {
                {CharaStateOnSpecial.Normal, "Normal"},
                {CharaStateOnSpecial.Kiss, "Kiss"},
                {CharaStateOnSpecial.BedIn, "BedIn"},
                {CharaStateOnSpecial.Fellatio, "Fellatio"}
            };
    }
}