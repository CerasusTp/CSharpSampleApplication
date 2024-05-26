using Microsoft.EntityFrameworkCore;

using SampleApplication.Models.DB;

namespace SampleApplication.Models
{
    public class DBModelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // テスト環境なのでパスワード等も記載
            optionsBuilder.UseNpgsql("Host=center-db.local.cerasustp.com;Port=5432;User Id=admin;Password=admin;Database=develop");
        }

        public DbSet<SampleTB> SampleDBs { get; set; }
        public DbSet<Streamer> Streamers { get; set; }
        public DbSet<StreamerURL> StreamerURLs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sample");

            modelBuilder.Entity<Streamer>(entity =>
            {
                entity.ToTable("streamers");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("id");

                entity.Property(e => e.Name)
                .HasColumnName("name");

                entity.Property(e => e.Explanation)
                .HasColumnName("explanation");

                entity.HasMany(e => e.StreamerURLs)
                .WithOne(s => s.Streamer)
                .HasForeignKey(e => e.Id);
            });

            modelBuilder.Entity<StreamerURL>(entity =>
            {
                entity.ToTable("streamer_urls");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("id");

                entity.Property(e => e.StreamerId)
                .HasColumnName("streamer_id");

                entity.Property(e => e.Site)
                .HasColumnName("site");

                entity.Property(e => e.Url)
                .HasColumnName("url");

                entity.HasOne(e => e.Streamer)
                .WithMany(s => s.StreamerURLs)
                .HasForeignKey(e => e.StreamerId);
            });
        }
    }
}
