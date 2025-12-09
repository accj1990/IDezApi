using IDezApi.Domain.Entity;

using Microsoft.EntityFrameworkCore;

namespace IDezApi.Storage.PostgreSQL.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public AppDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Converte nomes de tabela e colunas pra snake_case (padrão PostgreSQL)
            //modelBuilder.UseSnakeCaseNamingConvention();

            // Garante que a entidade User será mapeada
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user"); // nome da tabela no banco
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .HasColumnName("Id"); // respeita PascalCase do banco
                entity.Property(e => e.Email)
                      .HasColumnName("Email");
                entity.Property(e => e.Picture)
                      .HasColumnName("Picture");
                entity.Property(e => e.IsAdmin)
                      .HasColumnName("IsAdmin");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
