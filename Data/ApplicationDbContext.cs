using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using TechnoAcademyApi.DataSeeder;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IServiceProvider _serviceProvider;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IServiceProvider serviceProvider)
            : base(options)
        {
            _serviceProvider = serviceProvider;
        }
        public DbSet<FormRegister> FormRegisters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProgramCategory> ProgramCategories { get; set; }
        public DbSet<ProgramEntity> ProgramEntities { get; set; }
        public DbSet<AppliedProgram> AppliedPrograms{ get; set; }
        public DbSet<StatusLog> StatusLogs{ get; set; }
        public DbSet<GCMEntity> GCMEntities{ get; set; }
        public DbSet<MentorEntity> MentoryEntities{ get; set; }
        public DbSet<GalleryEntity> GalleriesEntites{ get; set; }
        public DbSet<BannerEntity> BannerEntities{ get; set; }
        public DbSet<TestimonyEntity> TestimonyEntities{ get; set; }
        public DbSet<EventEntity> EventEntities{ get; set; }
        public DbSet<UserEntity> UserEntities{ get; set; }
        public DbSet<TokenEntity> TokenEntities{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<FormRegister>(ConfigureFormRegister);
            modelBuilder.Entity<AppliedProgram>(ConfigureAppliedProgram);
            modelBuilder.Entity<StatusLog>(ConfigureStatusLog);
        }
        public void SeedData()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Memanggil metode SeedData dari DataSeeder
                DataSeeders.SeedData(scope.ServiceProvider);
                // Tambahkan kode lain yang diperlukan di sini
            }
        }
        private void ConfigureFormRegister(EntityTypeBuilder<FormRegister> builder)
        {
            //builder.Property(f => f.IdProgramEntity)
            //    .HasConversion(
            //        v => string.Join(',', v),
            //          v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            //builder.Property(f => f.IdProgramCategory)
            //   .HasConversion(
            //       v => string.Join(',', v),
            //         v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            builder.HasIndex(f => f.Email)
                .IsUnique();
        }
        private void ConfigureAppliedProgram(EntityTypeBuilder<AppliedProgram> builder)
        {
            builder.Property(x => x.IdProgramEntity)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }

        private void ConfigureStatusLog(EntityTypeBuilder<StatusLog> builder)
        {
            builder.Property(x => x.Status)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
                
             builder.Property(x => x.Sequence)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)); 
            builder.Property(x => x.DateHistory)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            builder.Property(x => x.Notes)
               .HasConversion(
                   v => string.Join(',', v),
                   v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is BaseEntity entity)
                {
                    entity.UpdatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }

}
