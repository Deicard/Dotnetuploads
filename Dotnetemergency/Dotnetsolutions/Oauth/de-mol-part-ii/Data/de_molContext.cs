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

        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Votes> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;Password=northwind19-20;Database=de_mol;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Players>(entity =>
            {
                entity.ToTable("players");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(1);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasMaxLength(250);

                entity.Property(e => e.Profession)
                    .IsRequired()
                    .HasColumnName("profession")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Votes>(entity =>
            {
                entity.ToTable("votes");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_votes")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Episode).HasColumnName("episode");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
