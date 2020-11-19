using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace schedule_api_database.models
{
    [Table("users_settings")]
    public class Settings
    {
        [Column("settings_id"), Key]
        public string Id { get; set; }

        [Column("gibbon_acc_id"), Required]
        public string GibbonAccountId { get; set; }

        [Column("group_name"), Required]
        public string GroupName { get; set; }

        [Column("group_link"), Required]
        public string GroupLink { get; set; }

        [Column("accent_color"), Required]
        public int AccentColor { get; set; }

        [Column("custom_accent_color"),MaybeNull]
        public string CustomAccentColor { get; set; }

        [Column("theme_state"), Required]
        public int ThemeState { get; set; }

        [Column("backdrop"), Required]
        public int BackDrop { get; set; }

        [Column("last_sync_unix_time")]
        public uint LastSyncUnixTime { get; set; }

        [Column("device")]
        public string Device { get; set; }


        public Settings()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}