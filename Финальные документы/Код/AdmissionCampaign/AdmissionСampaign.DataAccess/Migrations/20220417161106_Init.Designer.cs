﻿// <auto-generated />
using AdmissionСampaign.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdmissionCampaign.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220417161106_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdmissionСampaign.DataAccess.Entities.Entrant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DocumentsReturned")
                        .HasColumnType("bit");

                    b.Property<string>("EducationCompetitions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationProgram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntryYear")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IndividualAchievementScore")
                        .HasColumnType("int");

                    b.Property<int>("InformaticsUSE")
                        .HasColumnType("int");

                    b.Property<bool>("IsDormitoryNeeded")
                        .HasColumnType("bit");

                    b.Property<int>("MathUSE")
                        .HasColumnType("int");

                    b.Property<string>("PreemptiveRight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegistrationNumber")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationRegion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RussianLanguageUSE")
                        .HasColumnType("int");

                    b.Property<long>("SNILS")
                        .HasColumnType("bigint");

                    b.Property<bool>("SpecialQuota")
                        .HasColumnType("bit");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TargetQuota")
                        .HasColumnType("bit");

                    b.Property<string>("WithoutExamsReason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entrants");
                });
#pragma warning restore 612, 618
        }
    }
}
