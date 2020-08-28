using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace de_mol.Data
{
    public partial class de_molContext : DbContext
    {
        public de_molContext()
        {
        }

        public de_molContext(DbContextOptions<de_molContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppPlayers> AppPlayers { get; set; }
        public virtual DbSet<AppVotes> AppVotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=54320;Database=de_mol;Username=homestead;Password=secret");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppPlayers>(entity =>
            {
                entity.ToTable("app_players");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(1);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(120);

                entity.Property(e => e.Profession)
                    .HasColumnName("profession")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<AppVotes>(entity =>
            {
                entity.ToTable("app_votes");

                entity.HasIndex(e => new { e.PlayerId, e.UserId, e.Episode })
                    .HasName("unique_vote")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Episode).HasColumnName("episode");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
