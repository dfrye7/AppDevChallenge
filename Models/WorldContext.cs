using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AppDevChallenge.Models
{
    public partial class WorldContext : DbContext
    {
        public WorldContext()
        {
        }

        public WorldContext(DbContextOptions<WorldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Countrylanguage> Countrylanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.CountryCode, "CountryCode");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(35)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Population).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("country");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Capital).HasColumnType("int(11)");

                entity.Property(e => e.Code2)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Continent)
                    .IsRequired()
                    .HasColumnType("enum('Asia','Europe','North America','Africa','Oceania','Antarctica','South America')")
                    .HasDefaultValueSql("'Asia'");

                entity.Property(e => e.Gnp)
                    .HasPrecision(10, 2)
                    .HasColumnName("GNP");

                entity.Property(e => e.Gnpold)
                    .HasPrecision(10, 2)
                    .HasColumnName("GNPOld");

                entity.Property(e => e.GovernmentForm)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.HeadOfState)
                    .HasMaxLength(60)
                    .IsFixedLength(true);

                entity.Property(e => e.IndepYear).HasColumnType("smallint(6)");

                entity.Property(e => e.LifeExpectancy).HasPrecision(3, 1);

                entity.Property(e => e.LocalName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(52)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Population).HasColumnType("int(11)");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.SurfaceArea).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Countrylanguage>(entity =>
            {
                entity.HasKey(e => new { e.CountryCode, e.Language })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("countrylanguage");

                entity.HasIndex(e => e.CountryCode, "CountryCode");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Language)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.IsOfficial)
                    .IsRequired()
                    .HasColumnType("enum('T','F')")
                    .HasDefaultValueSql("'F'");

                entity.Property(e => e.Percentage).HasPrecision(4, 1);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Countrylanguages)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("countryLanguage_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
