using System.ComponentModel.DataAnnotations.Schema;

namespace ManageStaffDBApp.Model
{
    /// <summary>
    /// Модель, описывающая сотрудника
    /// </summary>
    public class User
    {
        public int Id { get; set; }                     // Первичный ключ
        public string Name { get; set; }                // Имя
        public string SurName { get; set; }             // Фамилия
        public string Phone { get; set; }               // Телефон
        public int PositionId { get; set; }             // Первичный ключ должности
        public virtual Position Position { get; set; }  // Должность

        [NotMapped]                                     // Поле не участвует в базе данных
        public Position UserPosition
        {
            get
            {
                // Возвращает метод получения должности по первичному ключу
                return DataWorker.GetPositionById(PositionId);
            }
        }
    }
}
