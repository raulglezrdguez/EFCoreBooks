using System;
using System.Reflection;
using EFCoreBooks.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreBooks.Data
{
    public class ApplicationDBContext : DbContext
    {
        private readonly ILogger<ApplicationDBContext> _logger;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = "server=localhost;user=root;password=todoporlaurita;database=EFCoreBooks";
            //var connectionString1 = configurationRoot.GetConnectionString("DefaultConnection");
            _logger.LogInformation(connectionString);
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
            optionsBuilder.UseMySql(connectionString, serverVersion);
            base.OnConfiguring(optionsBuilder);
        }

        public ApplicationDBContext(ILogger<ApplicationDBContext> logger) {
            _logger = logger;
        }

        public ApplicationDBContext(DbContextOptions options, ILogger<ApplicationDBContext> logger) : base(options)
        {
            _logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Kind>().HasKey(k => k.Id);
            //modelBuilder.Entity<Kind>().Property(k => k.Name).HasMaxLength(150);

            //modelBuilder.Entity<Author>().Property(a => a.Name).HasMaxLength(150);
            //modelBuilder.Entity<Author>().Property(a => a.BirthDate).HasColumnType("date");
            //modelBuilder.Entity<Author>().Property(a => a.Fortune).HasPrecision(8, 2);

            //modelBuilder.Entity<Book>().Property(f => f.Title).HasMaxLength(150);
            //modelBuilder.Entity<Book>().Property(f => f.PremiereDate).HasColumnType("date");

            //modelBuilder.Entity<Comment>().Property(c => c.Content).HasMaxLength(500);

            // para aplicar las configuraciones que estan en: Entities/Configs
            // y no tener que hacer las configuraciones como estan comentadas arriba de esta linea
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        public DbSet<Kind> Kinds => Set<Kind>();
        public DbSet<Author> Autors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Comment> Comments => Set<Comment>();
    }
}

