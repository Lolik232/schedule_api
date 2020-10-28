﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using schedule_api_database;

namespace schedule_api_database.Migrations
{
    [DbContext(typeof(MsSqlContext))]
    [Migration("20201028161120_custom_accent_color")]
    partial class custom_accent_color
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("schedule_api_database.models.Settings", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("settings_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccentColor")
                        .HasColumnName("accent_color")
                        .HasColumnType("int");

                    b.Property<int>("BackDrop")
                        .HasColumnName("backdrop")
                        .HasColumnType("int");

                    b.Property<string>("CustomAccentColor")
                        .HasColumnName("custom_accent_color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GibbonAccountId")
                        .IsRequired()
                        .HasColumnName("gibbon_acc_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupLink")
                        .IsRequired()
                        .HasColumnName("group_link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnName("group_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThemeState")
                        .HasColumnName("theme_state")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("users_settings");
                });
#pragma warning restore 612, 618
        }
    }
}