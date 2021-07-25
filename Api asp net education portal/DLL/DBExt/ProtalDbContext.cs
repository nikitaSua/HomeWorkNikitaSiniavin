using DAL.Entities;
using DAL.MappingConfigs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DAL.DBExt
{
    public class ProtalDbContext : DbContext
    {
        //Настройки контекста бд
        public ProtalDbContext(DbContextOptions<ProtalDbContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<AutorBook> AutorBooks { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseMaterial> CourseMaterials { get; set; }
        public virtual DbSet<CourseUser> CourseUsers { get; set; }
        public virtual DbSet<MaterialSkill> MaterialSkills { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Video> Videos { get; set; }




        //public ProtalDbContext()
        //{
        //    Database.EnsureDeleted();   // удаляем бд со старой схемой
        //}
        
        //Настройки сборки бд
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQL Server or Azure SQL локальный 
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDbForEP");

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MaterialMappingConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MaterialSkillConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkillMappingConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserSkillMappingConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VideoConfig).Assembly);
        }
    }
}
