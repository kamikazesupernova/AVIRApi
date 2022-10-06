﻿// <auto-generated />
using System;
using AVIRApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AVIRApi.Migrations
{
    [DbContext(typeof(IncidentContext))]
    [Migration("20221002160126_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AVIRApi.Models.Attach", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentEncoding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Handle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IncidentReportID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ref")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IncidentReportID");

                    b.ToTable("Attach");
                });

            modelBuilder.Entity("AVIRApi.Models.IncidentReport", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CeaseTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ConnCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DetectTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ref")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("IncidentReports");
                });

            modelBuilder.Entity("AVIRApi.Models.Node", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AggrWin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EngineStatus")
                        .HasColumnType("bit");

                    b.Property<string>("GPSDirection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GPSLatitude")
                        .HasColumnType("float");

                    b.Property<double>("GPSLongitude")
                        .HasColumnType("float");

                    b.Property<long>("GPSSpeed")
                        .HasColumnType("bigint");

                    b.Property<Guid>("IncidentReportID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SW")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IncidentReportID")
                        .IsUnique();

                    b.ToTable("Node");
                });

            modelBuilder.Entity("AVIRApi.Models.Source", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AttachHand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hostname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IP4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IP6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IncidentReportID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Netname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IncidentReportID");

                    b.ToTable("Source");
                });

            modelBuilder.Entity("AVIRApi.Models.Target", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Anonymised")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IP4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IncidentReportID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Spoofed")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IncidentReportID");

                    b.ToTable("Target");
                });

            modelBuilder.Entity("AVIRApi.Models.ThreatProfile", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Age")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(24L);

                    b.Property<Guid>("IncidentReportID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("LastSeen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(6L);

                    b.Property<int>("LocationFrequency")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("NumOccurences")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(4);

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("ThreatProfiles");
                });

            modelBuilder.Entity("AVIRApi.Models.Attach", b =>
                {
                    b.HasOne("AVIRApi.Models.IncidentReport", null)
                        .WithMany("Attach")
                        .HasForeignKey("IncidentReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AVIRApi.Models.Node", b =>
                {
                    b.HasOne("AVIRApi.Models.IncidentReport", null)
                        .WithOne("Node")
                        .HasForeignKey("AVIRApi.Models.Node", "IncidentReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AVIRApi.Models.Source", b =>
                {
                    b.HasOne("AVIRApi.Models.IncidentReport", null)
                        .WithMany("Source")
                        .HasForeignKey("IncidentReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AVIRApi.Models.Target", b =>
                {
                    b.HasOne("AVIRApi.Models.IncidentReport", null)
                        .WithMany("Target")
                        .HasForeignKey("IncidentReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AVIRApi.Models.ThreatProfile", b =>
                {
                    b.HasOne("AVIRApi.Models.IncidentReport", null)
                        .WithOne("ThreatProfile")
                        .HasForeignKey("AVIRApi.Models.ThreatProfile", "IncidentReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AVIRApi.Models.IncidentReport", b =>
                {
                    b.Navigation("Attach");

                    b.Navigation("Node");

                    b.Navigation("Source");

                    b.Navigation("Target");

                    b.Navigation("ThreatProfile");
                });
#pragma warning restore 612, 618
        }
    }
}