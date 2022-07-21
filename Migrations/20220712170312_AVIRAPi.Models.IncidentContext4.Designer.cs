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
    [Migration("20220712170312_AVIRAPi.Models.IncidentContext4")]
    partial class AVIRAPiModelsIncidentContext4
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentEncoding")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IncidentReportID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ref")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
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
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ref")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EngineStatus")
                        .HasColumnType("bit");

                    b.Property<string>("GPSDirection")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SW")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleStatus")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hostname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IP4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IP6")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IncidentReportID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Netname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IP4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IncidentReportID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Spoofed")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IncidentReportID");

                    b.ToTable("Target");
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

            modelBuilder.Entity("AVIRApi.Models.IncidentReport", b =>
                {
                    b.Navigation("Attach");

                    b.Navigation("Node")
                        .IsRequired();

                    b.Navigation("Source");

                    b.Navigation("Target");
                });
#pragma warning restore 612, 618
        }
    }
}