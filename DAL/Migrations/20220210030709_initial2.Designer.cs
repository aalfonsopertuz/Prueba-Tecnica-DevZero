﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20220210030709_initial2")]
    partial class initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Author", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Code = "1",
                            Name = "Robi Shama"
                        },
                        new
                        {
                            Code = "2",
                            Name = "Stephen W Hawking"
                        },
                        new
                        {
                            Code = "3",
                            Name = "Robert T. Kiyosaki"
                        });
                });

            modelBuilder.Entity("Entity.Book", b =>
                {
                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodeAuthor")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodePublisher")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Reference");

                    b.HasIndex("CodeAuthor");

                    b.HasIndex("CodePublisher");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Reference = "0000",
                            CodeAuthor = "1",
                            CodePublisher = "1",
                            Genre = "Fiction",
                            Price = 141.0,
                            Title = "The Monk Who Sold His Ferrari"
                        },
                        new
                        {
                            Reference = "0001",
                            CodeAuthor = "2",
                            CodePublisher = "2",
                            Genre = "Engineering & Technology",
                            Price = 149.0,
                            Title = "The Theory Of Everything"
                        },
                        new
                        {
                            Reference = "0002",
                            CodeAuthor = "3",
                            CodePublisher = "3",
                            Genre = "Personal Finance",
                            Price = 288.0,
                            Title = "Rich Dad Poor Dad"
                        });
                });

            modelBuilder.Entity("Entity.Publisher", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Code = "1",
                            Name = "Jaiko Publishing House"
                        },
                        new
                        {
                            Code = "2",
                            Name = "Jaiko Publishing House"
                        },
                        new
                        {
                            Code = "3",
                            Name = "Plata Publishing"
                        });
                });

            modelBuilder.Entity("Entity.Book", b =>
                {
                    b.HasOne("Entity.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("CodeAuthor");

                    b.HasOne("Entity.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("CodePublisher");

                    b.Navigation("Author");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Entity.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Entity.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}