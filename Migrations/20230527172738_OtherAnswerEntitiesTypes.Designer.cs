﻿// <auto-generated />
using System;
using MeuRastroCarbonoAPI.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeuRastroCarbonoAPI.Migrations
{
    [DbContext(typeof(DbContextClass))]
    [Migration("20230527172738_OtherAnswerEntitiesTypes")]
    partial class OtherAnswerEntitiesTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.Surveys.ElectronicSurveyAnswerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("CarbonEmissionInKgCO2e")
                        .HasColumnType("float");

                    b.Property<double>("CellphoneUsageInHours")
                        .HasColumnType("float");

                    b.Property<string>("ComputerAvailableMemory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComputerCPUModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComputerCoreType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ComputerCoresAmount")
                        .HasColumnType("int");

                    b.Property<string>("ComputerGPUModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ComputerTurnedOnInMinutes")
                        .HasColumnType("float");

                    b.Property<DateTime>("ConsumptionDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("LampType")
                        .HasColumnType("float");

                    b.Property<double>("LampsOperationTime")
                        .HasColumnType("float");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("StreamingUsageInMinutes")
                        .HasColumnType("float");

                    b.Property<int>("SurveyType")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ElectronicSurveyAnswers");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.Surveys.FoodSurveyAnswerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("CarbonEmissionInKgCO2e")
                        .HasColumnType("float");

                    b.Property<DateTime>("ConsumptionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MealPortionsAmount")
                        .HasColumnType("int");

                    b.Property<int>("MealsAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SurveyType")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FoodSurveyAnswers");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.Surveys.LocomotionSurveyAnswerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarElectricFuel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarFuel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("CarHybridAutonomy")
                        .HasColumnType("float");

                    b.Property<string>("CarHybridFuel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarMotor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CarbonEmissionInKgCO2e")
                        .HasColumnType("float");

                    b.Property<DateTime>("ConsumptionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MotorCycleMotor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotorcycleFuel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SurveyType")
                        .HasColumnType("int");

                    b.Property<int>("TransportType")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LocomotionSurveyAnswers");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.Surveys.WaterSurveyAnswerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("CarbonEmissionInKgCO2e")
                        .HasColumnType("float");

                    b.Property<DateTime>("ConsumptionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EachShowerDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShowersAmount")
                        .HasColumnType("int");

                    b.Property<int>("SurveyType")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WaterSurveyAnswers");
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

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.Surveys.ElectronicSurveyAnswerEntity", b =>
                {
                    b.HasOne("MeuRastroCarbonoAPI.Models.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.Surveys.FoodSurveyAnswerEntity", b =>
                {
                    b.HasOne("MeuRastroCarbonoAPI.Models.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.Surveys.LocomotionSurveyAnswerEntity", b =>
                {
                    b.HasOne("MeuRastroCarbonoAPI.Models.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MeuRastroCarbonoAPI.Models.Entities.Surveys.WaterSurveyAnswerEntity", b =>
                {
                    b.HasOne("MeuRastroCarbonoAPI.Models.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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
