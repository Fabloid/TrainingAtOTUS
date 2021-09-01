using Data.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models {
    public class MyAppContext : DbContext {
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public MyAppContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AvitoDB;Username=postgres;Password=admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(new List<User> {
                new User { Id=1, FullName="Иванов Иван Иванович"},
                new User { Id=2, FullName="Петров Петр Петрович"},
                new User { Id=3, FullName="Сидоров Сидр Сидорович"},
                new User { Id=4, FullName="Александров Александр Александрович"},
                new User { Id=5, FullName="Николаев Николай Николаевич"}
            });

            modelBuilder.Entity<Category>().HasData(new List<Category> {
                new Category{Id=1,Name="Авто"},
                new Category{Id=2,Name="Техника"},
                new Category{Id=3,Name="Телефоны"},
                new Category{Id=4,Name="Компьютеры"},
                new Category{Id=5,Name="Одежда"},
            });

            modelBuilder.Entity<Ad>().HasData(new List<Ad> {
                new Ad {Id=1, CategoryId = 1, UserId=1, Title="Продам авто", Description="Машина огонь"},
                new Ad {Id=2, CategoryId = 2, UserId=1, Title="Продам холодильник", Description="Холодильник самсунг новый"},
                new Ad {Id=3, CategoryId = 2, UserId=2, Title="Продам кондиционер", Description="Новый хороший"},
                new Ad {Id=4, CategoryId = 3, UserId=3, Title="S20", Description="Новый на гарантии или поменяю на S21 с доплатой"},
                new Ad {Id=5, CategoryId = 4, UserId=4, Title="Игровой комп", Description="Зверь машина"},
                new Ad {Id=6, CategoryId = 5, UserId=5, Title="Отдам свадебное платье", Description="Новое не пригодилось"}
            });
        }
    }
}
