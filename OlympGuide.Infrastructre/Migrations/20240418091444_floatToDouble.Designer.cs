﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OlympGuide.Infrastructre;

#nullable disable

namespace OlympGuide.Infrastructre.Migrations
{
    [DbContext(typeof(OlympGuideDbContext))]
    [Migration("20240418091444_floatToDouble")]
    partial class floatToDouble
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OlympGuide.Domain.Features.SportField.SportFieldType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Description")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sport_field_address");

                    b.Property<string>("SportFieldDescription")
                        .IsRequired()
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
#pragma warning restore 612, 618
        }
    }
}
