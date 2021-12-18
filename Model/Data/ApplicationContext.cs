using Microsoft.EntityFrameworkCore;

namespace ManageStaffDBApp.Model.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }              // Таблица сотрудников
        public DbSet<Position> Positions { get; set; }      // Таблица должностей
        public DbSet<Department> Departments { get; set; }  // Таблица отделов

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ApplicationContext()
        {
            Database.EnsureCreated();                       // Если база данных не существует, метод создаст её
        }

        /// <summary>
        /// Подключение базы данных
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ManageStaffDBAppDB;Trusted_Connection=True;");
        }
    }
}
