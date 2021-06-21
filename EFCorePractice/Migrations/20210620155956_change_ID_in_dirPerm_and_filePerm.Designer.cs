﻿// <auto-generated />
using System;
using EfPractice.Date.Core.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCorePractice.Migrations
{
    [DbContext(typeof(FileSystemConext))]
    [Migration("20210620155956_change_ID_in_dirPerm_and_filePerm")]
    partial class change_ID_in_dirPerm_and_filePerm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("shc")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCorePractice.Entities.Directorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentDirectory")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id")
                        .HasName("PK_Direktory")
                        .IsClustered();

                    b.ToTable("Directorie", "sch");
                });

            modelBuilder.Entity("EFCorePractice.Entities.DirectoryPermission", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("CanRead")
                        .HasColumnType("bit");

                    b.Property<bool>("CanWrite")
                        .HasColumnType("bit");

                    b.HasKey("Id", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("DirectoryPermissions", "sch");
                });

            modelBuilder.Entity("EFCorePractice.Entities.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DirectoryId")
                        .HasColumnType("int");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Size")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("DirectoryId");

                    b.ToTable("File", "sch");
                });

            modelBuilder.Entity("EFCorePractice.Entities.FilePermission", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("CanRead")
                        .HasColumnType("bit");

                    b.Property<bool>("CanWrite")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("FilePermissions", "sch");
                });

            modelBuilder.Entity("EFCorePractice.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("Email");

                    b.Property<string>("PaswordHash")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("PaswordHash");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("UserName");

                    b.HasKey("Id")
                        .HasName("PK_Users")
                        .IsClustered();

                    b.ToTable("Users", "sch");
                });

            modelBuilder.Entity("EFCorePractice.Entities.AudioFile", b =>
                {
                    b.HasBaseType("EFCorePractice.Entities.File");

                    b.Property<string>("Bitrate")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("Bitrate");

                    b.Property<int>("ChannelCount")
                        .HasColumnType("int")
                        .HasColumnName("ChannelCount");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time")
                        .HasColumnName("Duration");

                    b.Property<string>("SampleRate")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("SampleRate");

                    b.ToTable("AudioFile");
                });

            modelBuilder.Entity("EFCorePractice.Entities.ImageFile", b =>
                {
                    b.HasBaseType("EFCorePractice.Entities.File");

                    b.Property<int>("Heigth")
                        .HasColumnType("int")
                        .HasColumnName("Heigth");

                    b.Property<int>("Width")
                        .HasColumnType("int")
                        .HasColumnName("Width");

                    b.ToTable("ImageFile");
                });

            modelBuilder.Entity("EFCorePractice.Entities.TextFile", b =>
                {
                    b.HasBaseType("EFCorePractice.Entities.File");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("ContentDB");

                    b.ToTable("TextFile");
                });

            modelBuilder.Entity("EFCorePractice.Entities.VideoFile", b =>
                {
                    b.HasBaseType("EFCorePractice.Entities.File");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time")
                        .HasColumnName("Duration");

                    b.Property<int>("Height")
                        .HasColumnType("int")
                        .HasColumnName("Height");

                    b.Property<int>("Width")
                        .HasColumnType("int")
                        .HasColumnName("Width");

                    b.ToTable("VideoFile");
                });

            modelBuilder.Entity("EFCorePractice.Entities.DirectoryPermission", b =>
                {
                    b.HasOne("EFCorePractice.Entities.Directorie", "Directorie")
                        .WithMany("DirectoryPermissions")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_DeirectoryPermsissions_Directory")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EFCorePractice.Entities.User", "User")
                        .WithMany("DirectoryPermissions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_DeirectoryPermsissions_User")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Directorie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFCorePractice.Entities.File", b =>
                {
                    b.HasOne("EFCorePractice.Entities.Directorie", "Directorie")
                        .WithMany("Files")
                        .HasForeignKey("DirectoryId")
                        .HasConstraintName("FK_Deirectory_file")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Directorie");
                });

            modelBuilder.Entity("EFCorePractice.Entities.FilePermission", b =>
                {
                    b.HasOne("EFCorePractice.Entities.File", "File")
                        .WithMany("FilePermissions")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_FilePermsissions_File")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EFCorePractice.Entities.User", "User")
                        .WithMany("FilePermissions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_FilePermsissions_User")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFCorePractice.Entities.AudioFile", b =>
                {
                    b.HasOne("EFCorePractice.Entities.File", null)
                        .WithOne()
                        .HasForeignKey("EFCorePractice.Entities.AudioFile", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCorePractice.Entities.ImageFile", b =>
                {
                    b.HasOne("EFCorePractice.Entities.File", null)
                        .WithOne()
                        .HasForeignKey("EFCorePractice.Entities.ImageFile", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCorePractice.Entities.TextFile", b =>
                {
                    b.HasOne("EFCorePractice.Entities.File", null)
                        .WithOne()
                        .HasForeignKey("EFCorePractice.Entities.TextFile", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCorePractice.Entities.VideoFile", b =>
                {
                    b.HasOne("EFCorePractice.Entities.File", null)
                        .WithOne()
                        .HasForeignKey("EFCorePractice.Entities.VideoFile", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCorePractice.Entities.Directorie", b =>
                {
                    b.Navigation("DirectoryPermissions");

                    b.Navigation("Files");
                });

            modelBuilder.Entity("EFCorePractice.Entities.File", b =>
                {
                    b.Navigation("FilePermissions");
                });

            modelBuilder.Entity("EFCorePractice.Entities.User", b =>
                {
                    b.Navigation("DirectoryPermissions");

                    b.Navigation("FilePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
