﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TasksAPI.Data;

#nullable disable

namespace TasksAPI.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20231019134630_Note-Picture-Relation-Employee")]
    partial class NotePictureRelationEmployee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeToDo", b =>
                {
                    b.Property<Guid>("EmployeesEmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ToDosToDoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeesEmployeeId", "ToDosToDoId");

                    b.HasIndex("ToDosToDoId");

                    b.ToTable("EmployeeToDo");
                });

            modelBuilder.Entity("TasksAPI.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TasksAPI.Models.Note", b =>
                {
                    b.Property<Guid>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UploadedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NoteId");

                    b.HasIndex("SubTaskId");

                    b.HasIndex("UploadedBy");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("TasksAPI.Models.Picture", b =>
                {
                    b.Property<Guid>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UploadedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PictureId");

                    b.HasIndex("SubTaskId");

                    b.HasIndex("UploadedBy");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("TasksAPI.Models.SubTask", b =>
                {
                    b.Property<Guid>("SubTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NotesCountToBeCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("PicturesCountToBeCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ToDoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SubTaskId");

                    b.HasIndex("ToDoId");

                    b.ToTable("SubTasks");
                });

            modelBuilder.Entity("TasksAPI.Models.ToDo", b =>
                {
                    b.Property<Guid>("ToDoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ToDoId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("EmployeeToDo", b =>
                {
                    b.HasOne("TasksAPI.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TasksAPI.Models.ToDo", null)
                        .WithMany()
                        .HasForeignKey("ToDosToDoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TasksAPI.Models.Note", b =>
                {
                    b.HasOne("TasksAPI.Models.SubTask", "SubTask")
                        .WithMany("Notes")
                        .HasForeignKey("SubTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TasksAPI.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("UploadedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubTask");
                });

            modelBuilder.Entity("TasksAPI.Models.Picture", b =>
                {
                    b.HasOne("TasksAPI.Models.SubTask", "SubTask")
                        .WithMany("Pictures")
                        .HasForeignKey("SubTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TasksAPI.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("UploadedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubTask");
                });

            modelBuilder.Entity("TasksAPI.Models.SubTask", b =>
                {
                    b.HasOne("TasksAPI.Models.ToDo", "Todo")
                        .WithMany("SubTasks")
                        .HasForeignKey("ToDoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Todo");
                });

            modelBuilder.Entity("TasksAPI.Models.SubTask", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("TasksAPI.Models.ToDo", b =>
                {
                    b.Navigation("SubTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
