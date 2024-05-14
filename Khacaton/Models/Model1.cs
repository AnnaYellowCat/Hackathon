using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Khacaton.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Achievements> Achievements { get; set; }
        public virtual DbSet<Awards> Awards { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentsAndAchievements> StudentsAndAchievements { get; set; }
        public virtual DbSet<StudentsAndAwards> StudentsAndAwards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts>()
                .HasMany(e => e.StudentsAndAchievements)
                .WithRequired(e => e.Accounts)
                .HasForeignKey(e => e.idAccount);

            modelBuilder.Entity<Accounts>()
                .HasMany(e => e.StudentsAndAwards)
                .WithRequired(e => e.Accounts)
                .HasForeignKey(e => e.idAccount);

            modelBuilder.Entity<Achievements>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Achievements>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Achievements>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<Achievements>()
                .HasMany(e => e.StudentsAndAchievements)
                .WithRequired(e => e.Achievements)
                .HasForeignKey(e => e.idAchievement);

            modelBuilder.Entity<Awards>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Awards>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Awards>()
                .HasMany(e => e.StudentsAndAwards)
                .WithRequired(e => e.Awards)
                .HasForeignKey(e => e.idAward);

            modelBuilder.Entity<Groups>()
                .Property(e => e.direction)
                .IsUnicode(false);

            modelBuilder.Entity<Groups>()
                .Property(e => e.spec)
                .IsUnicode(false);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Groups)
                .HasForeignKey(e => e.idGroup);

            modelBuilder.Entity<Students>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Students)
                .HasForeignKey(e => e.idStudent);

            modelBuilder.Entity<StudentsAndAwards>()
                .Property(e => e.promocode)
                .IsUnicode(false);
        }
    }
}
