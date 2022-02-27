using Blazor.FacileBudget.DataAccess.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blazor.FacileBudget.DataAccess.Models.Services.Infrastructure
{
    public partial class FacileBudgetDbContext : DbContext
    {
        public FacileBudgetDbContext(DbContextOptions<FacileBudgetDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Spesa> Spese { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Spesa>(entity =>
            {
                entity.ToTable("Spese");
                entity.HasKey(spesa => spesa.SpesaId);

                //Mapping per gli owned types
                entity.OwnsOne(spesa => spesa.Importo, builder =>
                {
                    builder.Property(money => money.Currency)
                           .HasColumnName("Importo_Currency")
                           .HasConversion<string>(); //Questo indica al meccanismo delle migration che la colonna della tabella dovrà essere creata di tipo string
                    builder.Property(money => money.Amount)
                           .HasColumnName("Importo_Amount")
                           .HasConversion<float>(); //Questo indica al meccanismo delle migration che la colonna della tabella dovrà essere creata di tipo numerico
                });
            });
        }
    }
}