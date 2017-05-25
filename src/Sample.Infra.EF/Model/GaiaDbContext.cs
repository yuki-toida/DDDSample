using Microsoft.EntityFrameworkCore;
using Sample.Infra.Interface.Data.Transaction;

namespace Sample.Infra.EF.Model
{
    public partial class GaiaDbContext : DbContext
    {
        public GaiaDbContext(DbContextOptions<GaiaDbContext> options) : base(options)
        {
        }

        public virtual DbSet<GiftTranOpen> GiftTranOpen { get; set; }
        public virtual DbSet<GiftTranUnopen> GiftTranUnopen { get; set; }
        public virtual DbSet<UserTranBase> UserTranBase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiftTranOpen>(entity =>
            {
                entity.HasKey(e => e.GiftId)
                    .HasName("PK_GiftTranOpen");

                entity.HasIndex(e => new { e.Uid, e.AddDate })
                    .HasName("CIX_GiftTranOpen");

                entity.Property(e => e.GiftId).ValueGeneratedNever();

                entity.Property(e => e.Word).HasMaxLength(50);
            });

            modelBuilder.Entity<GiftTranUnopen>(entity =>
            {
                entity.HasKey(e => e.GiftId)
                    .HasName("PK_GiftTranUnopen");

                entity.HasIndex(e => new { e.Uid, e.AddDate })
                    .HasName("CIX_GiftTranUnopen");

                entity.Property(e => e.Word).HasMaxLength(50);
            });

            modelBuilder.Entity<UserTranBase>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_UserTranBase");

                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}