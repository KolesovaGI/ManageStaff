using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ManageStaffDBApp.Model
{
    /// <summary>
    /// Модель, описывающая отдел
    /// </summary>
    public class Department
    {
        public int Id { get; set; }                     // Первичный ключ
        public string Name { get; set; }                // Название
        public List<Position> Positions { get; set; }   // Список должностей

        [NotMapped]                                     // Поле не участвует в базе данных
        public List<Position> DepartmentPositions       // Список должностей в отделе
        {
            get
            {
                // Возвращает метод поиска должностей по первичному ключу отдела
                return DataWorker.GetAllPositionsByDepartmentId(Id);
            }
        }
    }
}
