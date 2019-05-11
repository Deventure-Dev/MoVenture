using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Moventure.DataLayer.Models
{
    public partial class Entities : DbContext
        //IdentityDbContext<LoginModel, Role, int, IdentityUserClaim<int>,
        //UserRole, IdentityUserLogin<int>,
        //IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public Entities()
        {

        }

        public Entities(DbContextOptions<Entities> options)
            : base(options)
        {
        }

        public virtual DbSet<ActorMovieAssignments> ActorMovieAssignments { get; set; }
        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<PlaylistMovieAssignments> PlaylistMovieAssignments { get; set; }
        public virtual DbSet<Playlists> Playlists { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<TagsMovieAssignments> TagsMovieAssignments { get; set; }
        public virtual DbSet<UserMovieAssignments> UserMovieAssignments { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppConfiguration.ConnectionString);

            }
            //TODO: fix this
            optionsBuilder.UseLazyLoadingProxies();
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

                entity.Property(e => e.PictureUrl).HasMaxLength(255);

                entity.Property(e => e.SavedAt).HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
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

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Movies_Category");
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

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SavedAt).HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<TagsMovieAssignments>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.MovieId });

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TagsMovieAssignments)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryMovieAssignments_Category");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.TagsMovieAssignments)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryMovieAssignments_Movie");
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
