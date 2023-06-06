using Microsoft.EntityFrameworkCore;

namespace OscarLeonardoPerdomoGonzalez.Models
{
    public class HalterofiliaContext : DbContext
    {
        public DbSet<Deportista> Deportistas { get; set; }
        public DbSet<Halterofilia> Halterofilias { get; set; }

        public HalterofiliaContext(DbContextOptions<HalterofiliaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //IConfigurationRoot configuration = new ConfigurationBuilder()
                //    .SetBasePath(Directory.GetCurrentDirectory())
                //    .AddJsonFile("appsettings.json")
                //    .Build();
                //string connectionString = configuration.GetConnectionString("LocalProductsDB");
                //optionsBuilder.UseSqlServer(connectionString);
                //optionsBuilder.UseSqlServer("Data Source=LEONARDOPC\\SQLEXPRESS;Initial Catalog=ProductsDB;user id=leonardoPC; password=LeonardoWS1PC; Encrypt=False");
                optionsBuilder.UseInMemoryDatabase(databaseName: "HalterofiliaDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Deportista carlos = new() { DeportistaId = 1, Nombre = "Calor Alviz" };
            Deportista andres = new() { DeportistaId = 2, Nombre = "Andres Sabogal" };
            Deportista jorge = new() { DeportistaId = 3, Nombre = "Jorge Ortega" };
            Deportista pablo = new() { DeportistaId = 4, Nombre = "Pablo Velasco" };

            var halterofilias = new List<Halterofilia>()
            {
                new Halterofilia{ HalterofiliaId = 1, Pais = "AUS", DeportistaId = carlos.DeportistaId, ArranqueKg = 134, EnvionKg = 177, TotalPeso = 311 },
                new Halterofilia{ HalterofiliaId = 2, Pais = "CHN", DeportistaId = andres.DeportistaId, ArranqueKg = 130, EnvionKg = 180, TotalPeso = 310 },
                new Halterofilia{ HalterofiliaId = 3, Pais = "FRA", DeportistaId = jorge.DeportistaId, ArranqueKg = 125, EnvionKg = 184, TotalPeso = 309 },
                new Halterofilia{ HalterofiliaId = 4, Pais = "ALE", DeportistaId = pablo.DeportistaId, ArranqueKg = 0, EnvionKg = 150, TotalPeso = 150 }
            };

            modelBuilder.Entity<Deportista>(dep =>
            {
                dep.ToTable("Deportista");
                dep.HasKey(d => d.DeportistaId);
                dep.Property(d => d.DeportistaId).UseIdentityColumn().ValueGeneratedOnAdd();
                dep.Property(d => d.Nombre).IsRequired().HasMaxLength(25);
                dep.Ignore(d => d.Halterofilias);
                dep.HasData(new List<Deportista> { carlos, andres, jorge, pablo});
            });

            modelBuilder.Entity<Halterofilia>(hal =>
            {
                hal.HasKey(h => h.HalterofiliaId);
                hal.Property(h => h.HalterofiliaId).UseIdentityColumn().ValueGeneratedOnAdd();
                hal.Property(h => h.Pais).IsRequired().HasMaxLength(4);
                hal.HasOne(h => h.Deportista).WithMany(d => d.Halterofilias).HasForeignKey(h => h.DeportistaId);
                hal.Ignore(h => h.Deportista);
                hal.Property(h => h.ArranqueKg).IsRequired();
                hal.Property(h => h.EnvionKg).IsRequired();
                hal.Property(h => h.TotalPeso).IsRequired();
                hal.HasData(halterofilias);
            });
        }
    }
}
