﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sevriukoff.Gwalt.Infrastructure;

#nullable disable

namespace Sevriukoff.Gwalt.Infrastructure.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20240519064826_EntityPlaylistAdded")]
    partial class EntityPlaylistAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AlbumUser", b =>
                {
                    b.Property<int>("AlbumId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("AlbumId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AlbumsUsers", (string)null);
                });

            modelBuilder.Entity("GenreTrack", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("integer");

                    b.Property<int>("TrackId")
                        .HasColumnType("integer");

                    b.HasKey("GenresId", "TrackId");

                    b.HasIndex("TrackId");

                    b.ToTable("GenreTrack");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Base.Metric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlbumId")
                        .HasColumnType("integer");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LikeById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("TrackId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Metric");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Metric");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("IsSingle")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<int>("TrackId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(650)
                        .HasColumnType("character varying(650)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.PlaylistTrack", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("integer");

                    b.Property<int>("TrackId")
                        .HasColumnType("integer");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.HasKey("PlaylistId", "TrackId");

                    b.HasIndex("TrackId");

                    b.ToTable("PlaylistTrack");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("integer");

                    b.Property<string>("AudioUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("DurationInSeconds")
                        .HasColumnType("integer");

                    b.Property<bool>("IsExplicit")
                        .HasColumnType("boolean");

                    b.Property<int>("Likes")
                        .HasColumnType("integer");

                    b.Property<int>("Plays")
                        .HasColumnType("integer");

                    b.Property<int>("Shares")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasMaxLength(650)
                        .HasColumnType("character varying(650)");

                    b.Property<string>("BackgroundUrl")
                        .IsRequired()
                        .HasMaxLength(650)
                        .HasColumnType("character varying(650)");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("PasswordSalt")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Like", b =>
                {
                    b.HasBaseType("Sevriukoff.Gwalt.Infrastructure.Base.Metric");

                    b.Property<int?>("CommentId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("integer");

                    b.Property<int?>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasIndex("AlbumId");

                    b.HasIndex("CommentId");

                    b.HasIndex("LikeById");

                    b.HasIndex("TrackId");

                    b.HasIndex("UserProfileId");

                    b.HasDiscriminator().HasValue("Like");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Listen", b =>
                {
                    b.HasBaseType("Sevriukoff.Gwalt.Infrastructure.Base.Metric");

                    b.Property<int>("Quality")
                        .HasColumnType("integer");

                    b.HasIndex("AlbumId");

                    b.HasIndex("LikeById");

                    b.HasIndex("TrackId");

                    b.HasDiscriminator().HasValue("Listen");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Share", b =>
                {
                    b.HasBaseType("Sevriukoff.Gwalt.Infrastructure.Base.Metric");

                    b.Property<int?>("CommentId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("integer");

                    b.Property<string>("ShareToUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("AlbumId");

                    b.HasIndex("CommentId");

                    b.HasIndex("LikeById");

                    b.HasIndex("TrackId");

                    b.HasDiscriminator().HasValue("Share");
                });

            modelBuilder.Entity("AlbumUser", b =>
                {
                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreTrack", b =>
                {
                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Track", null)
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Comment", b =>
                {
                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Playlist", b =>
                {
                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.PlaylistTrack", b =>
                {
                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Playlist", "Playlist")
                        .WithMany()
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Track", b =>
                {
                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Like", b =>
                {
                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Album", "Album")
                        .WithMany("TotalLikes")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Comment", "Comment")
                        .WithMany("TotalLikes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.User", "LikeBy")
                        .WithMany("TotalLikes")
                        .HasForeignKey("LikeById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Track", "Track")
                        .WithMany("TotalLikes")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.User", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileId");

                    b.Navigation("Album");

                    b.Navigation("Comment");

                    b.Navigation("LikeBy");

                    b.Navigation("Track");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Listen", b =>
                {
                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Album", "Album")
                        .WithMany("TotalListens")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.User", "LikeBy")
                        .WithMany()
                        .HasForeignKey("LikeById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Track", "Track")
                        .WithMany("TotalListens")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Album");

                    b.Navigation("LikeBy");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Share", b =>
                {
                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Album", "Album")
                        .WithMany("TotalShares")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Comment", "Comment")
                        .WithMany("TotalShares")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.User", "LikeBy")
                        .WithMany()
                        .HasForeignKey("LikeById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sevriukoff.Gwalt.Infrastructure.Entities.Track", "Track")
                        .WithMany("TotalShares")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Album");

                    b.Navigation("Comment");

                    b.Navigation("LikeBy");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Album", b =>
                {
                    b.Navigation("TotalLikes");

                    b.Navigation("TotalListens");

                    b.Navigation("TotalShares");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Comment", b =>
                {
                    b.Navigation("TotalLikes");

                    b.Navigation("TotalShares");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.Track", b =>
                {
                    b.Navigation("TotalLikes");

                    b.Navigation("TotalListens");

                    b.Navigation("TotalShares");
                });

            modelBuilder.Entity("Sevriukoff.Gwalt.Infrastructure.Entities.User", b =>
                {
                    b.Navigation("TotalLikes");
                });
#pragma warning restore 612, 618
        }
    }
}
