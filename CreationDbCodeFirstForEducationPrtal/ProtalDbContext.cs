using CreationDbCodeFirstForEducationPrtal.Entities;
using CreationDbCodeFirstForEducationPrtal.MappingConfigs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CreationDbCodeFirstForEducationPrtal
{
    class ProtalDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public ProtalDbContext()
        {
            Database.EnsureDeleted();   // удаляем бд со старой схемой
        }
        //Настройки контекста бд
        public ProtalDbContext(DbContextOptions<ProtalDbContext> options) : base(options)
        {

        }
        //Настройки сборки бд
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQL Server or Azure SQL локальный 
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDbForEP");

            //настройка подключения
            //памяти 
            //и тд

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // создает схему бд
            modelBuilder.HasDefaultSchema("shc");

            //загружаем настройки из вынесенных настроек 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMappingConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleMappingConfig).Assembly);
        }
    }
}
