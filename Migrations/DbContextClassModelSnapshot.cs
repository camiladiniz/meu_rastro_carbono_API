﻿// <auto-generated />
using System;
using MeuRastroCarbonoAPI.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeuRastroCarbonoAPI.Migrations
{
    [DbContext(typeof(DbContextClass))]
    partial class DbContextClassModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.AchievementEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.EvolutionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalPontuation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Evolutions");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.EvolutionHistoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EvolutionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Pontuation")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EvolutionId");

                    b.ToTable("EvolutionsHistory");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.SurveyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.UserAchievementEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("AchievementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AchievementId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAchivements");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Birthdate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EvolutionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EvolutionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.EvolutionHistoryEntity", b =>
                {
                    b.HasOne("MeuRastroCarbonoAPI.Models.Entities.EvolutionEntity", "Evolution")
                        .WithMany("EvolutionHistory")
                        .HasForeignKey("EvolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evolution");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.UserAchievementEntity", b =>
                {
                    b.HasOne("MeuRastroCarbonoAPI.Models.Entities.AchievementEntity", "Achievement")
                        .WithMany()
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeuRastroCarbonoAPI.Models.Entities.UserEntity", "User")
                        .WithMany("AchievementsAchieved")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Achievement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.UserEntity", b =>
                {
                    b.HasOne("MeuRastroCarbonoAPI.Models.Entities.EvolutionEntity", "Evolution")
                        .WithMany()
                        .HasForeignKey("EvolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evolution");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.EvolutionEntity", b =>
                {
                    b.Navigation("EvolutionHistory");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.UserEntity", b =>
                {
                    b.Navigation("AchievementsAchieved");
                });
#pragma warning restore 612, 618
        }
    }
}
