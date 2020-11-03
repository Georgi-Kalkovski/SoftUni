namespace ShoutsShare.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ShoutsShare.Data.Common.Models;
    using ShoutsShare.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Creator> Creators { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<VideoCreator> VideoCreators { get; set; }

        public DbSet<VideoCountry> VideoCountries { get; set; }

        public DbSet<VideoReview> VideoReviews { get; set; }

        public DbSet<VideoGenre> VideoGenres { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Review> Reviews { get; set; }

        //public DbSet<ReviewAuthor> ReviewAuthors { get; set; }

        public DbSet<Setting> Settings { get; set; } // Default from template

        //public DbSet<ContactFormEntry> ContactFormEntries { get; set; }

        //public DbSet<AdminContactFromEntry> AdminContactFormEntries { get; set; }

        //public DbSet<FaqEntry> FaqEntries { get; set; }

        public DbSet<ShoutsRating> ShoutsRatings { get; set; }

        //public DbSet<Privacy> Privacies { get; set; }

        public DbSet<VideoComment> VideoComments { get; set; }

        public DbSet<NewsComment> NewsComments { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for many-to-many relationships
            builder.Entity<VideoCreator>()
                .HasKey(vc => new { vc.VideoId, vc.CreatorId });

            builder.Entity<VideoCountry>()
                .HasKey(vc => new { vc.VideoId, vc.CountryId });

            builder.Entity<VideoReview>()
                .HasKey(vr => new { vr.VideoId, vr.ReviewId });

            builder.Entity<VideoGenre>()
                .HasKey(vg => new { vg.VideoId, vg.GenreId });

            //builder.Entity<ReviewAuthor>()
            //    .HasKey(ra => new { ra.ReviewId, ra.AuthorId });

            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));

            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
