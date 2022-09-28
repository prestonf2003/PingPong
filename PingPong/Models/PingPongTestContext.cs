using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PingPong.Models
{
    public partial class PingPongTestContext : DbContext
    {
        public PingPongTestContext()
        {
        }

        public PingPongTestContext(DbContextOptions<PingPongTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MatchHistory> MatchHistories { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PingPongTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchHistory>(entity =>
            {
                entity.ToTable("MatchHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Player1name)
                    .HasMaxLength(20)
                    .HasColumnName("player1name");

                entity.Property(e => e.Player2name)
                    .HasMaxLength(20)
                    .HasColumnName("player2name");

                entity.Property(e => e.Score).HasMaxLength(10);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.Elo).HasColumnName("elo");

                entity.Property(e => e.Loss).HasColumnName("loss");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Wins).HasColumnName("wins");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
