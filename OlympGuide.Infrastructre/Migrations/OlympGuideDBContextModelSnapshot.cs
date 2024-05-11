﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OlympGuide.Infrastructre;

#nullable disable

namespace OlympGuide.Infrastructre.Migrations
{
    [DbContext(typeof(OlympGuideDbContext))]
    partial class OlympGuideDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OlympGuide.Domain.Features.Reservation.ReservationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end");

                    b.Property<Guid>("SportFieldId")
                        .HasColumnType("uuid")
                        .HasColumnName("sport_field_id");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start");

                    b.Property<int>("State")
                        .HasColumnType("integer")
                        .HasColumnName("state");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_reservations");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_reservations_user_id");

                    b.ToTable("reservations", (string)null);
                });

            modelBuilder.Entity("OlympGuide.Domain.Features.SportField.SportFieldType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int>("Category")
                        .HasColumnType("integer")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision")
                        .HasColumnName("latitude");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision")
                        .HasColumnName("longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_sport_fields");

                    b.ToTable("sport_fields", (string)null);
                });

            modelBuilder.Entity("OlympGuide.Domain.Features.SportFieldProposal.SportFieldProposalType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("SportFieldAddress")
                        .HasColumnType("text")
                        .HasColumnName("sport_field_address");

                    b.Property<int>("SportFieldCategory")
                        .HasColumnType("integer")
                        .HasColumnName("sport_field_category");

                    b.Property<string>("SportFieldDescription")
                        .HasColumnType("text")
                        .HasColumnName("sport_field_description");

                    b.Property<double>("SportFieldLatitude")
                        .HasColumnType("double precision")
                        .HasColumnName("sport_field_latitude");

                    b.Property<double>("SportFieldLongitude")
                        .HasColumnType("double precision")
                        .HasColumnName("sport_field_longitude");

                    b.Property<string>("SportFieldName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sport_field_name");

                    b.Property<int>("State")
                        .HasColumnType("integer")
                        .HasColumnName("state");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_sport_field_proposals");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_sport_field_proposals_user_id");

                    b.ToTable("sport_field_proposals", (string)null);
                });

            modelBuilder.Entity("OlympGuide.Domain.Features.User.AuthenticationUserMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthenticationProviderId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("authentication_provider_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_authentication_user_mappings");

                    b.ToTable("authentication_user_mappings", (string)null);
                });

            modelBuilder.Entity("OlympGuide.Domain.Features.User.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("display_name");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int[]>("Roles")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("roles");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("OlympGuide.Domain.Features.Reservation.ReservationType", b =>
                {
                    b.HasOne("OlympGuide.Domain.Features.User.UserProfile", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reservations_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OlympGuide.Domain.Features.SportFieldProposal.SportFieldProposalType", b =>
                {
                    b.HasOne("OlympGuide.Domain.Features.User.UserProfile", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_sport_field_proposals_users_user_id");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
