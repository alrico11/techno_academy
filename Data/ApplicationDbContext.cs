using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        public DbSet<FormRegister> Mst_user { get; set; }
        public DbSet<Comment> Mst_comment_section { get; set; }
        public DbSet<ProgramCategory> Mst_program { get; set; }
        public DbSet<ProgramEntity> Mst_applied_program { get; set; }
        public DbSet<AppliedProgram> Trn_applied_program{ get; set; }
        public DbSet<StatusLog> Log_status{ get; set; }
        public DbSet<GCMEntity> Mst_GCM_Academy{ get; set; }
        public DbSet<MentorEntity> Mst_mentor{ get; set; }
        public DbSet<GalleryEntity> Mst_gallery{ get; set; }
        public DbSet<BannerEntity> Mst_banner{ get; set; }
        public DbSet<TestimonyEntity> Mst_testimony{ get; set; }
        public DbSet<EventEntity> Mst_event{ get; set; }
        public DbSet<UserEntity> Mst_user_cms{ get; set; }
        public DbSet<TokenEntity> Mst_token{ get; set; }
        public DbSet<RoleEntity> Mst_role{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<FormRegister>(ConfigureFormRegister);
        }
        public void SeedData()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                DataSeeders.SeedData(scope.ServiceProvider);
            }
        }
        private void ConfigureFormRegister(EntityTypeBuilder<FormRegister> builder)
        {
            builder.HasIndex(f => f.Email)
                .IsUnique();
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
