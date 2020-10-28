using schedule_api_database.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace schedule_api_core.dto_s
{
    public class SettingsDto
    {
        [JsonPropertyName("acc_id")]
        public string GibbonAccountId { get; set; }

        [JsonPropertyName("group_name")]
        public string GroupName { get; set; }

        [JsonPropertyName("group_link")]
        public string GroupLink { get; set; }

        [JsonPropertyName("accent_color")]
        public int AccentColor { get; set; }

        [JsonPropertyName("custom_accent_color")]
        public string CustomAccentColor { get; set; }

        [JsonPropertyName("theme_state")]
        public int ThemeState { get; set; }

        [JsonPropertyName("backdrop")]
        public int BackDrop { get; set; }
        public SettingsDto()
        {
        }
        public SettingsDto(string gibbonAccountId, string groupName, string groupLink, int accentColor, string customAccentColor, int themeState, int backDrop)
        {
            GibbonAccountId = gibbonAccountId;
            GroupName = groupName;
            GroupLink = groupLink;
            AccentColor = accentColor;
            CustomAccentColor = customAccentColor;
            ThemeState = themeState;
            BackDrop = backDrop;
        }
        internal Settings ToModel()
        {
            return new Settings
            {
                GibbonAccountId = GibbonAccountId,
                GroupName = GroupName,
                GroupLink = GroupLink,
                AccentColor = AccentColor,
                CustomAccentColor = CustomAccentColor,
                ThemeState = ThemeState,
                BackDrop = BackDrop
            };
        }
    }
}
