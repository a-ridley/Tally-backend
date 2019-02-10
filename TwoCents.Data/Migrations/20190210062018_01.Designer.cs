﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TwoCents.Data;

namespace TwoCents.Data.Migrations
{
    [DbContext(typeof(TwoCentsDbContext))]
    [Migration("20190210062018_01")]
    partial class _01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TwoCents.Data.Entities.PetitionCommentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<Guid>("PetitionEntityId");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("PetitionEntityId");

                    b.ToTable("PetitionCommentEntity");
                });

            modelBuilder.Entity("TwoCents.Data.Entities.PetitionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DownVotes");

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.Property<int>("UpVotes");

                    b.HasKey("Id");

                    b.ToTable("Petitions");
                });

            modelBuilder.Entity("TwoCents.Data.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TwoCents.Data.Entities.PetitionCommentEntity", b =>
                {
                    b.HasOne("TwoCents.Data.Entities.PetitionEntity", "PetitionEntity")
                        .WithMany("PetitionCommentEntities")
                        .HasForeignKey("PetitionEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
