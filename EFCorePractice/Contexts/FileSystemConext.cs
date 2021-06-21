using EFCorePractice.Entities;

using EfPractice.Date.Core.MappingConfigs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPractice.Date.Core.Contexts
{
    public class FileSystemConext:DbContext
    {
        
        public DbSet<DirectoryPermission> DirectoryPermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Directorie> Directories { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<TextFile> TextFiles { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<VideoFile> VideoFiles { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<FilePermission> FilePermissions { get; set; }

        public FileSystemConext()
        {
            Database.EnsureDeleted();   // удаляем бд со старой схемой
            
        }
        //Настройки контекста бд
       public FileSystemConext(DbContextOptions<FileSystemConext> options) : base(options)
        {

        }

        //Настройки сборки бд
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQL Server or Azure SQL локальный 
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");

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
        }

    }
}
