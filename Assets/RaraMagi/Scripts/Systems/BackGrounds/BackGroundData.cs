using System.Collections.Generic;

namespace RaraMagi.Systems.BackGrounds
{
    public static class BackGroundData
    {
        public static readonly Dictionary<BackGroundNames, string> BackGroundPath =
            new Dictionary<BackGroundNames, string>()
            {
                {BackGroundNames.Home, "Home"},
                {BackGroundNames.School, "School"},
            };

        public static readonly Dictionary<BackGroundState, string> BackGroundStatePath =
            new Dictionary<BackGroundState, string>()
            {
                {BackGroundState.Morning, "Morning"},
                {BackGroundState.Noon, "Noon"},
                {BackGroundState.Afternoon, "Afternoon"},
                {BackGroundState.Night, "Night"},
            };
    }
}