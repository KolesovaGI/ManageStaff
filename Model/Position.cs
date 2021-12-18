using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;

namespace ManageStaffDBApp.Model
{
    /// <summary>
    /// Модель, описывающая должность
    /// </summary>
    public class Position
    {
        public int Id { get; set; }                         // Первичный ключ
        public string Name { get; set; }                    // Название
        public decimal Salary { get; set; }                 // Зарплата
        public int MaxNumber { get; set; }                  // Максимум вакансий
        public List<User> Users { get; set; }               // Список сотрудников
        public int DepartmentId { get; set; }               // Первичный ключ отдела
        public virtual Department Department { get; set; }  // Отдел

        [NotMapped]                                         // Поле не участвует в базе данных
        public Department PositionDepartment
        {
            get
            {
                // Возвращает метод получения отдела по первичному ключу
                return DataWorker.GetDepartmentById(DepartmentId);
            }
        }

        [NotMapped]                                         // Поле не участвует в базе данных
        public List<User> PositionUsers                     // Список с должностями сотрудников
        {
            get
            {
                // Возвращает метод получения всех сотрудников по первичному ключу должности
                return DataWorker.GetAllUsersByPositionId(Id);
            }
        }
    }
}
