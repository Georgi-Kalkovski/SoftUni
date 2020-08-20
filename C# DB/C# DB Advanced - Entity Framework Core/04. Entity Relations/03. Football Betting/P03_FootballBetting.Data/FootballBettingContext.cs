namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options) 
            : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity
                    .HasKey(t => t.TeamId);

                entity
                    .Property(t => t.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(50);

                entity
                    .Property(t => t.LogoUrl)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity
                    .Property(t => t.Initials)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(3);

                entity
                    .HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(t => t.Town)
                    .WithMany(to => to.Teams)
                    .HasForeignKey(t => t.TownId);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity
                    .HasKey(c => c.ColorId);

                entity
                    .Property(c => c.Name)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .HasKey(c => c.UserId);

                entity
                    .Property(u => u.Username)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(50);

                entity
                    .Property(u => u.Password)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(256);

                entity
                    .Property(u => u.Email)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(50);

                entity
                    .Property(u => u.Name)
                    .IsRequired(false)
                    .IsUnicode(true)
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity
                    .HasKey(t => t.TownId);

                entity
                    .Property(t => t.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(50);

                entity
                    .HasOne(t => t.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(t => t.CountryId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity
                    .HasKey(c => c.CountryId);

                entity
                    .Property(c => c.Name)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity
                    .HasKey(p => p.PlayerId);

                entity
                    .Property(p => p.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(80);

                entity
                    .HasOne(p => p.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TeamId);

                entity
                    .HasOne(p => p.Position)
                    .WithMany(po => po.Players)
                    .HasForeignKey(p => p.PositionId);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity
                    .HasKey(c => c.PositionId);

                entity
                    .Property(c => c.Name)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity
                    .HasKey(ps => new { ps.PlayerId, ps.GameId });

                entity
                    .HasOne(ps => ps.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(p => p.PlayerId);

                entity
                    .HasOne(ps => ps.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(p => p.GameId);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                    .HasKey(g => g.GameId);

                entity
                    .Property(g => g.Result)
                    .IsRequired(false)
                    .IsUnicode(false)
                    .HasMaxLength(7);

                entity
                    .HasOne(g => g.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(g => g.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity
                    .HasKey(c => c.BetId);

                entity
                    .HasOne(b => b.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(b => b.UserId);

                entity
                    .HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId);
            });
        }
    }
}
