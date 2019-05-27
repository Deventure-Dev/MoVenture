using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using Moventure.BusinessLogic.Models;
using Moventure.DataLayer.Models;
using System;

namespace Moventure.DataLayer.Context
{
    public class Entities : IdentityDbContext<IdentityUser>
    {
        public Entities(DbContextOptions<Entities> options) : base(options)
        {

        }

        public Entities()
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(AppConfiguration.ConnectionString);

        //    }
        //    //TODO: fix this
        //    optionsBuilder.UseLazyLoadingProxies();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            #region "Seed Data"

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            #endregion

            modelBuilder.Entity<Actor>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Movie>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<MovieActorIntermediate>()
                .HasKey(x => new { x.ActorId, x.MovieId });
            modelBuilder.Entity<MovieActorIntermediate>()
                .HasOne(x => x.Actor)
                .WithMany(m => m.MovieList)
                .HasForeignKey(x => x.ActorId);
            modelBuilder.Entity<MovieActorIntermediate>()
                .HasOne(x => x.Movie)
                .WithMany(e => e.ActorList)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<Playlist>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Movie>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<MoviePlaylistIntermediate>()
                .HasKey(x => new { x.PlaylistId, x.MovieId });
            modelBuilder.Entity<MoviePlaylistIntermediate>()
                .HasOne(x => x.Playlist)
                .WithMany(m => m.MovieList)
                .HasForeignKey(x => x.PlaylistId);
            modelBuilder.Entity<MoviePlaylistIntermediate>()
                .HasOne(x => x.Movie)
                .WithMany(e => e.PlaylistList)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<Tag>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Movie>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<MovieTagIntermediate>()
                .HasKey(x => new { x.TagId, x.MovieId });
            modelBuilder.Entity<MovieTagIntermediate>()
                .HasOne(x => x.Tag)
                .WithMany(m => m.MovieList)
                .HasForeignKey(x => x.TagId);
            modelBuilder.Entity<MovieTagIntermediate>()
                .HasOne(x => x.Movie)
                .WithMany(e => e.TagList)
                .HasForeignKey(x => x.MovieId);
        }
    }
}
