﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moventure.DataLayer.Context;

namespace Moventure.DataLayer.Migrations
{
    [DbContext(typeof(Entities))]
    [Migration("20190529153216_added pictureurl to actor")]
    partial class addedpictureurltoactor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.Actor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PictureUrl");

                    b.Property<DateTime>("SavedAt");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("SavedAt");

                    b.Property<Guid>("Savedby");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentMessage");

                    b.Property<DateTime>("SavedAt");

                    b.Property<Guid?>("SavedAtMovieId");

                    b.Property<Guid?>("SavedByNavigationId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("SavedAtMovieId");

                    b.HasIndex("SavedByNavigationId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryId");

                    b.Property<DateTime>("LaunchDate");

                    b.Property<string>("PictureUrl");

                    b.Property<double>("Rating");

                    b.Property<int>("RatingCount");

                    b.Property<DateTime>("SavedAt");

                    b.Property<Guid?>("SavedById");

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.Property<string>("TrailerUrl");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SavedById");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.MovieActorAssignment", b =>
                {
                    b.Property<Guid>("ActorId");

                    b.Property<Guid>("MovieId");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieActorAssignment");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.Playlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("SavedAt");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.PlaylistMovieAssignment", b =>
                {
                    b.Property<Guid>("PlaylistId");

                    b.Property<Guid>("MovieId");

                    b.HasKey("PlaylistId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("PlaylistMovieAssignment");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("SavedAt");

                    b.Property<Guid?>("SavedById");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("SavedById");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.TagsMovieAssignment", b =>
                {
                    b.Property<Guid>("TagId");

                    b.Property<Guid>("MovieId");

                    b.HasKey("TagId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("TagsMovieAssignment");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("SavedAt");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.Comment", b =>
                {
                    b.HasOne("Moventure.DataLayer.Models.Movie", "SavedAtMovie")
                        .WithMany()
                        .HasForeignKey("SavedAtMovieId");

                    b.HasOne("Moventure.DataLayer.Models.User", "SavedByNavigation")
                        .WithMany("Comments")
                        .HasForeignKey("SavedByNavigationId");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.Movie", b =>
                {
                    b.HasOne("Moventure.DataLayer.Models.Category", "Category")
                        .WithMany("MovieList")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Moventure.DataLayer.Models.User", "SavedBy")
                        .WithMany("MovieList")
                        .HasForeignKey("SavedById");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.MovieActorAssignment", b =>
                {
                    b.HasOne("Moventure.DataLayer.Models.Actor", "Actor")
                        .WithMany("MovieList")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Moventure.DataLayer.Models.Movie", "Movie")
                        .WithMany("ActorList")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.Playlist", b =>
                {
                    b.HasOne("Moventure.DataLayer.Models.User", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.PlaylistMovieAssignment", b =>
                {
                    b.HasOne("Moventure.DataLayer.Models.Movie", "Movie")
                        .WithMany("PlaylistList")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Moventure.DataLayer.Models.Playlist", "Playlist")
                        .WithMany("MovieList")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.Tag", b =>
                {
                    b.HasOne("Moventure.DataLayer.Models.User", "SavedBy")
                        .WithMany()
                        .HasForeignKey("SavedById");
                });

            modelBuilder.Entity("Moventure.DataLayer.Models.TagsMovieAssignment", b =>
                {
                    b.HasOne("Moventure.DataLayer.Models.Movie", "Movie")
                        .WithMany("TagList")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Moventure.DataLayer.Models.Tag", "Tag")
                        .WithMany("MovieList")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
