using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BienAPI.Models
{
    public partial class f1Context : DbContext
    {
        public f1Context()
        {
        }

        public f1Context(DbContextOptions<f1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Circuit> Circuits { get; set; }
        public virtual DbSet<Constructor> Constructors { get; set; }
        public virtual DbSet<ConstructorResult> ConstructorResults { get; set; }
        public virtual DbSet<ConstructorStanding> ConstructorStandings { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverStanding> DriverStandings { get; set; }
        public virtual DbSet<LapTime> LapTimes { get; set; }
        public virtual DbSet<PitStop> PitStops { get; set; }
        public virtual DbSet<Qualifying> Qualifyings { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=r18020109;database=f1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Circuit>(entity =>
            {
                entity.ToTable("circuits");

                entity.Property(e => e.CircuitId).HasColumnName("circuitId");

                entity.Property(e => e.CircuitRef)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("circuitRef");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.Lat)
                    .HasColumnType("decimal(10,5)")
                    .HasColumnName("lat");

                entity.Property(e => e.Lng)
                    .HasColumnType("decimal(10,6)")
                    .HasColumnName("lng");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Constructor>(entity =>
            {
                entity.ToTable("constructors");

                entity.Property(e => e.ConstructorId).HasColumnName("constructorId");

                entity.Property(e => e.ConstructorRef)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("constructorRef");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nationality");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<ConstructorResult>(entity =>
            {
                entity.HasKey(e => e.ConstructorResultsId)
                    .HasName("PRIMARY");

                entity.ToTable("constructor_results");

                entity.HasIndex(e => e.ConstructorId, "constructorId");

                entity.HasIndex(e => e.RaceId, "raceId");

                entity.Property(e => e.ConstructorResultsId).HasColumnName("constructorResultsId");

                entity.Property(e => e.ConstructorId).HasColumnName("constructorId");

                entity.Property(e => e.Points)
                    .HasColumnType("decimal(3,1)")
                    .HasColumnName("points");

                entity.Property(e => e.RaceId).HasColumnName("raceId");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .HasColumnName("status");

                entity.HasOne(d => d.Constructor)
                    .WithMany(p => p.ConstructorResults)
                    .HasForeignKey(d => d.ConstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constructor_results_ibfk_2");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.ConstructorResults)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constructor_results_ibfk_1");
            });

            modelBuilder.Entity<ConstructorStanding>(entity =>
            {
                entity.HasKey(e => e.ConstructorStandingsId)
                    .HasName("PRIMARY");

                entity.ToTable("constructor_standings");

                entity.HasIndex(e => e.ConstructorId, "constructorId");

                entity.HasIndex(e => e.RaceId, "raceId");

                entity.Property(e => e.ConstructorStandingsId).HasColumnName("constructorStandingsId");

                entity.Property(e => e.ConstructorId).HasColumnName("constructorId");

                entity.Property(e => e.Points)
                    .HasColumnType("decimal(5,1)")
                    .HasColumnName("points");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.PositionText).HasColumnName("positionText");

                entity.Property(e => e.RaceId).HasColumnName("raceId");

                entity.Property(e => e.Wins).HasColumnName("wins");

                entity.HasOne(d => d.Constructor)
                    .WithMany(p => p.ConstructorStandings)
                    .HasForeignKey(d => d.ConstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constructor_standings_ibfk_2");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.ConstructorStandings)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("constructor_standings_ibfk_1");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("drivers");

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .HasColumnName("code");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.DriverRef)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("driverRef");

                entity.Property(e => e.Forename)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("forename");

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nationality");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("surname");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<DriverStanding>(entity =>
            {
                entity.HasKey(e => e.DriverStandingsId)
                    .HasName("PRIMARY");

                entity.ToTable("driver_standings");

                entity.HasIndex(e => e.DriverId, "driverId");

                entity.HasIndex(e => e.RaceId, "raceId");

                entity.Property(e => e.DriverStandingsId).HasColumnName("driverStandingsId");

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.Points)
                    .HasColumnType("decimal(5,2)")
                    .HasColumnName("points");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.PositionText).HasColumnName("positionText");

                entity.Property(e => e.RaceId).HasColumnName("raceId");

                entity.Property(e => e.Wins).HasColumnName("wins");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.DriverStandings)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("driver_standings_ibfk_2");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.DriverStandings)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("driver_standings_ibfk_1");
            });

            modelBuilder.Entity<LapTime>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lap_times");

                entity.HasIndex(e => e.DriverId, "driverId");

                entity.HasIndex(e => e.RaceId, "raceId");

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.Lap).HasColumnName("lap");

                entity.Property(e => e.Milliseconds).HasColumnName("milliseconds");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.RaceId).HasColumnName("raceId");

                entity.Property(e => e.Time)
                    .HasMaxLength(11)
                    .HasColumnName("time");

                entity.HasOne(d => d.Driver)
                    .WithMany()
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lap_times_ibfk_2");

                entity.HasOne(d => d.Race)
                    .WithMany()
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lap_times_ibfk_1");
            });

            modelBuilder.Entity<PitStop>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pit_stops");

                entity.HasIndex(e => e.DriverId, "driverId");

                entity.HasIndex(e => e.RaceId, "raceId");

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.Duration)
                    .HasColumnType("decimal(9,3)")
                    .HasColumnName("duration");

                entity.Property(e => e.Lap).HasColumnName("lap");

                entity.Property(e => e.Milliseconds).HasColumnName("milliseconds");

                entity.Property(e => e.RaceId).HasColumnName("raceId");

                entity.Property(e => e.Stop).HasColumnName("stop");

                entity.Property(e => e.Time)
                    .HasMaxLength(8)
                    .HasColumnName("time");

                entity.HasOne(d => d.Driver)
                    .WithMany()
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pit_stops_ibfk_2");

                entity.HasOne(d => d.Race)
                    .WithMany()
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pit_stops_ibfk_1");
            });

            modelBuilder.Entity<Qualifying>(entity =>
            {
                entity.HasKey(e => e.QualifyId)
                    .HasName("PRIMARY");

                entity.ToTable("qualifying");

                entity.HasIndex(e => e.ConstructorId, "constructorId");

                entity.HasIndex(e => e.DriverId, "driverId");

                entity.HasIndex(e => e.RaceId, "raceId");

                entity.Property(e => e.QualifyId).HasColumnName("qualifyId");

                entity.Property(e => e.ConstructorId).HasColumnName("constructorId");

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.Q1)
                    .HasMaxLength(9)
                    .HasColumnName("q1");

                entity.Property(e => e.Q2)
                    .HasMaxLength(9)
                    .HasColumnName("q2");

                entity.Property(e => e.Q3)
                    .HasMaxLength(9)
                    .HasColumnName("q3");

                entity.Property(e => e.RaceId).HasColumnName("raceId");

                entity.HasOne(d => d.Constructor)
                    .WithMany(p => p.Qualifyings)
                    .HasForeignKey(d => d.ConstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("qualifying_ibfk_3");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Qualifyings)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("qualifying_ibfk_2");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Qualifyings)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("qualifying_ibfk_1");
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.ToTable("races");

                entity.HasIndex(e => e.CircuitId, "circuitId");

                entity.Property(e => e.RaceId).HasColumnName("raceId");

                entity.Property(e => e.CircuitId).HasColumnName("circuitId");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Round).HasColumnName("round");

                entity.Property(e => e.Time)
                    .HasMaxLength(8)
                    .HasColumnName("time");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Circuit)
                    .WithMany(p => p.Races)
                    .HasForeignKey(d => d.CircuitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("races_ibfk_1");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("results");

                entity.HasIndex(e => e.ConstructorId, "constructorId");

                entity.HasIndex(e => e.DriverId, "driverId");

                entity.HasIndex(e => e.RaceId, "raceId");

                entity.HasIndex(e => e.StatusId, "statusId");

                entity.Property(e => e.ResultId).HasColumnName("resultId");

                entity.Property(e => e.ConstructorId).HasColumnName("constructorId");

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.FastestLap).HasColumnName("fastestLap");

                entity.Property(e => e.FastestLapSpeed)
                    .HasColumnType("decimal(7,3)")
                    .HasColumnName("fastestLapSpeed");

                entity.Property(e => e.FastestLapTime)
                    .HasMaxLength(8)
                    .HasColumnName("fastestLapTime");

                entity.Property(e => e.Grid).HasColumnName("grid");

                entity.Property(e => e.Laps).HasColumnName("laps");

                entity.Property(e => e.Milliseconds).HasColumnName("milliseconds");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Points)
                    .HasColumnType("decimal(4,2)")
                    .HasColumnName("points");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.PositionOrder).HasColumnName("positionOrder");

                entity.Property(e => e.PositionText)
                    .HasMaxLength(2)
                    .HasColumnName("positionText");

                entity.Property(e => e.RaceId).HasColumnName("raceId");

                entity.Property(e => e.Ranks).HasColumnName("ranks");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.Time)
                    .HasMaxLength(11)
                    .HasColumnName("time");

                entity.HasOne(d => d.Constructor)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.ConstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("results_ibfk_3");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("results_ibfk_2");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("results_ibfk_1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("results_ibfk_4");
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.HasKey(e => e.Year)
                    .HasName("PRIMARY");

                entity.ToTable("seasons");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.Status1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
