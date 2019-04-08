using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Moventure.WebApi.Models
{
    public partial class moVentureContext : DbContext
    {
        public moVentureContext()
        {
        }

        public moVentureContext(DbContextOptions<moVentureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActorMovieAssignments> ActorMovieAssignments { get; set; }
        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CategoryMovieAssignments> CategoryMovieAssignments { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<PlaylistMovieAssignments> PlaylistMovieAssignments { get; set; }
        public virtual DbSet<Playlists> Playlists { get; set; }
        public virtual DbSet<UserMovieAssignments> UserMovieAssignments { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=deventure.database.windows.net;Database=moVenture;User ID=developer;Password=123456aA!;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovieAssignments>(entity =>
            {
                entity.HasKey(e => new { e.ActorId, e.MovieId });

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorMovieAssignments)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorMovieAssignments_Actor");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.ActorMovieAssignments)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorMovieAssignments_Movie");
            });

            modelBuilder.Entity<Actors>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SavedAt).HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SavedAt).HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<CategoryMovieAssignments>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.MovieId });

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryMovieAssignments)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryMovieAssignments_Category");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.CategoryMovieAssignments)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryMovieAssignments_Movie");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CommentMessage)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.SavedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.SavedByNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.SavedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Movie");
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LaunchDate).HasColumnType("datetime");

                entity.Property(e => e.PictureUrl)
                    .IsRequired()
                    .HasColumnName("PictureURL")
                    .HasMaxLength(250);

                entity.Property(e => e.SavedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.TrailerUrl)
                    .HasColumnName("TrailerURL")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<PlaylistMovieAssignments>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.MovieId });

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.PlaylistMovieAssignments)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistMovieAssignments_Movies");
            });

            modelBuilder.Entity<Playlists>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SavedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Playlists_User");
            });

            modelBuilder.Entity<UserMovieAssignments>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.UserId });

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.UserMovieAssignments)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMovieAssignments_UserMovieAssignments");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMovieAssignments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMovieAssignments_User");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SavedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });
        }
    }
}
