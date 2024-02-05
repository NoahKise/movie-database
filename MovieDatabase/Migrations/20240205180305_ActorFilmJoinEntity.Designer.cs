﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieDatabase.Models;

#nullable disable

namespace MovieDatabase.Migrations
{
    [DbContext(typeof(MovieDatabaseContext))]
    [Migration("20240205180305_ActorFilmJoinEntity")]
    partial class ActorFilmJoinEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MovieDatabase.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("UrlImage")
                        .HasColumnType("longtext");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MovieDatabase.Models.ActorFilm", b =>
                {
                    b.Property<int>("ActorFilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("ActorFilmId");

                    b.HasIndex("ActorId");

                    b.HasIndex("FilmId");

                    b.ToTable("ActorFilms");
                });

            modelBuilder.Entity("MovieDatabase.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Director")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReleaseDate")
                        .HasColumnType("longtext");

                    b.Property<string>("UrlImage")
                        .HasColumnType("longtext");

                    b.HasKey("FilmId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("MovieDatabase.Models.ActorFilm", b =>
                {
                    b.HasOne("MovieDatabase.Models.Actor", "Actor")
                        .WithMany("JoinEntities")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieDatabase.Models.Film", "Film")
                        .WithMany("JoinEntities")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("MovieDatabase.Models.Actor", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("MovieDatabase.Models.Film", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
