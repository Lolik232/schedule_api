using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Column("theme_state"), Required]
        public int ThemeState { get; set; }

        [Column("backdrop"), Required]
        public int BackDrop { get; set; }


        public Settings()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}