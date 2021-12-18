using ManageStaffDBApp.Model.Data;
using System.Collections.Generic;
using System.Linq;

namespace ManageStaffDBApp.Model
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public static class DataWorker
    {
        /// <summary>
        /// Получение всех отделов
        /// </summary>
        /// <returns>Список отделов</returns>
        public static List<Department> GetAllDepartments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Departments.ToList();                               // Результат - возврат списка отделов
                return result;
            }
        }

        /// <summary>
        /// Получение всех должностей
        /// </summary>
        /// <returns>Список должностей</returns>
        public static List<Position> GetAllPositions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Positions.ToList();                                 // Результат - возврат списка должностей
                return result;
            }
        }
        
        /// <summary>
        /// Получение всех сотрудников
        /// </summary>
        /// <returns>Список всех сотрудников</returns>
        public static List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Users.ToList();                                     // Результат - вовзрат списка сотрудников
                return result;
            }
        }
        
        /// <summary>
        /// Создание отдела
        /// </summary>
        /// <param name="name">Название отдела</param>
        /// <returns>Сообщение об успешном выполнении операции</returns>
        public static string CreateDepartment(string name)
        {
            string result = "Уже существует";                                       // Оповещение

            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Departments.Any(el => el.Name == name);      // Проверка на существование отдела

                if (!checkIsExist)                                                  // Если отдел не существует
                {
                    Department newDepartment = new Department { Name = name };      // Новый отдел
                    db.Departments.Add(newDepartment);                              // Добавление отдела в таблицу отделов
                    db.SaveChanges();                                               // Сохранение изменений
                    result = "Сделано!";                                            // Оповещение
                }
                return result;
            }
        }

        /// <summary>
        /// Создание должности
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="maxNumber">Максимум вакансий</param>
        /// <param name="department">Отдел</param>
        /// <returns>Сообщение об успешном выполнении операции</returns>
        public static string CreatePosition(string name, decimal salary, int maxNumber, Department department)
        {
            string result = "Уже существует";                                       // Оповещение

            using (ApplicationContext db = new ApplicationContext())
            {
                // Проверка на существование должности
                bool checkIsExist = db.Positions.Any(el => el.Name == name && el.Salary == salary);

                if (!checkIsExist)                                                  // Если должность не существует
                {
                    Position newPosition = new Position                             // Новая должность
                    {
                        Name = name,                                                // Название
                        Salary = salary,                                            // Зарплата
                        MaxNumber = maxNumber,                                      // Число вакансий
                        DepartmentId = department.Id                                // первичный ключ отдела
                    };

                    db.Positions.Add(newPosition);                                  // Добавление должности в таблицу должностей
                    db.SaveChanges();                                               // Сохранение изменений
                    result = "Сделано!";                                            // Оповещение
                }
                return result;
            }
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surName">Фамилия</param>
        /// <param name="phone">Телефон</param>
        /// <param name="position">Должность</param>
        /// <returns>Сообщение об успешном выполнении операции</returns>
        public static string CreateUser(string name, string surName, string phone, Position position)
        {
            string result = "Уже существует";                                       // Оповещение

            using (ApplicationContext db = new ApplicationContext())
            {
                // Проверка на существование сотрудника
                bool checkIsExist = db.Users.Any(el => el.Name == name && el.SurName == surName && el.Position == position);

                if (!checkIsExist)                                                  // Если сотрудник не существует
                {
                    User newUser = new User                                         // Новый сотрудник
                    {
                        Name = name,                                                // Имя
                        SurName = surName,                                          // Фамилия
                        Phone = phone,                                              // Номер телефона
                        PositionId = position.Id                                    // Первичный ключ занимаемой должности
                    };

                    db.Users.Add(newUser);                                          // Добавление сотрудника в таблицу сотрудников
                    db.SaveChanges();                                               // Сохранение изменений
                    result = "Сделано!";                                            // Оповещение
                }
                return result;
            }
        }

        /// <summary>
        /// Удаление отдела
        /// </summary>
        /// <param name="department">Отдел</param>
        /// <returns>Сообщение об успешном выполнении операции</returns>
        public static string DeleteDepartment(Department department)
        {
            string result = "Такого отела не существует";                   // Оповещение

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Departments.Remove(department);                          // Удаление отдела
                db.SaveChanges();                                           // Сохранение изменений
                result = "Сделано! Отдел " + department.Name + " удален";   // Оповещение
            }
            return result;
        }

        /// <summary>
        /// Удаление должности
        /// </summary>
        /// <param name="position">Должность</param>
        /// <returns>Сообщение об успешном выполнении операции</returns>
        public static string DeletePosition(Position position)
        {
            string result = "Такой должности не существует";                    // Оповещение

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Positions.Remove(position);                                  // Удаление должности
                db.SaveChanges();                                               // Сохранение изменений
                result = "Сделано! Должность " + position.Name + " удалена";    // Оповещение
            }
            return result;
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="user">Сотрудник</param>
        /// <returns>Сообщение об успешном выполнении операции</returns>
        public static string DeleteUser(User user)
        {
            string result = "Такого сотрудника не существует";              // Оповещение

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);                                      // Удаление сотрудника
                db.SaveChanges();                                           // Сохранение изменений
                result = "Сделано! Сотрудник " + user.Name + " уволен";     // Оповещение
            }
            return result;
        }

        /// <summary>
        /// Редактирование отдела
        /// </summary>
        /// <param name="oldDepartment">Старая информация</param>
        /// <param name="newName">Новое название</param>
        /// <returns>Сообщение об успешном выполнении операции</returns>
        public static string EditDepartment(Department oldDepartment, string newName)
        {
            string result = "Такого отела не существует";                       // Оповещение
                                
            using (ApplicationContext db = new ApplicationContext())
            {
                // Проверка на существование отдела
                Department department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                department.Name = newName;                                      // Присваивание нового названия
                db.SaveChanges();                                               // Сохранение изменений
                result = "Сделано! Отдел " + department.Name + " изменен";      // Оповещение
            }
            return result;
        }

        /// <summary>
        /// Редактирование должности
        /// </summary>
        /// <param name="oldPosition">Старая информация</param>
        /// <param name="newName">Новое название</param>
        /// <param name="newMaxNumber">Новый максимум вакансий</param>
        /// <param name="newSalary">Новая зарплата</param>
        /// <param name="newDepartment">Изменённая должность</param>
        /// <returns>Сообщение об успешном выполнении операции</returns>
        public static string EditPosition(Position oldPosition, string newName, int newMaxNumber, decimal newSalary, Department newDepartment)
        {
            string result = "Такой должности не существует";                    // Оповещение
                    
            using (ApplicationContext db = new ApplicationContext())
            {
                // Проверка на существование должности
                Position position = db.Positions.FirstOrDefault(p => p.Id == oldPosition.Id);
                position.Name = newName;                                        // Присваивание нового названия
                position.Salary = newSalary;                                    // Присваивание новой зарплаты
                position.MaxNumber = newMaxNumber;                              // Присваивание нового числа вакансий
                position.DepartmentId = newDepartment.Id;                       // Присваивание нового первичного ключа
                db.SaveChanges();                                               // Сохранение изменений
                result = "Сделано! Должность " + position.Name + " изменена";   // Оповещение
            }
            return result;
        }

        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        /// <param name="oldUser">Старая информация о сотруднике</param>
        /// <param name="newName">Новое имя</param>
        /// <param name="newSurName">Новая фамилия</param>
        /// <param name="newPhone">Новый телефон</param>
        /// <param name="newPosition">Новая должность</param>
        /// <returns>Сообщение об успешном выполнении операции</returns>
        public static string EditUser(User oldUser, string newName, string newSurName, string newPhone, Position newPosition)
        {
            string result = "Такого сотрудника не существует";                  // Оповещение

            using (ApplicationContext db = new ApplicationContext())
            {
                // Проверка на существование сотрудника
                User user = db.Users.FirstOrDefault(p => p.Id == oldUser.Id);

                if (user != null)                                               // Если сотрудник существует
                {
                    user.Name = newName;                                        // Присваивание нового имени
                    user.SurName = newSurName;                                  // Присваивание новой фамилии
                    user.Phone = newPhone;                                      // Присваивание нового номера телефона
                    user.PositionId = newPosition.Id;                           // Присваивание нового первичного ключа
                    db.SaveChanges();                                           // Сохранение изменений
                    result = "Сделано! Сотрудник " + user.Name + " изменен";    // Оповещение
                }
            }
            return result;
        }

        /// <summary>
        /// Получение должности по первичному ключу
        /// </summary>
        /// <param name="id">Первичный ключ</param>
        /// <returns>Должность</returns>
        public static Position GetPositionById(int id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Position pos = db.Positions.FirstOrDefault(p => p.Id == id);    // Поиск должности по первичному ключу
                return pos;
            }
        }

        /// <summary>
        /// Получение отдела по первичному ключу
        /// </summary>
        /// <param name="id">Первичный ключ</param>
        /// <returns>Отдел</returns>
        public static Department GetDepartmentById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Department pos = db.Departments.FirstOrDefault(p => p.Id == id); // Поиск отдела по первичному ключу
                return pos;
            }
        }

        /// <summary>
        /// Получение всех сотрудников по первичному ключу должности
        /// </summary>
        /// <param name="id">Первичный ключ</param>
        /// <returns>Сотрудники</returns>
        public static List<User> GetAllUsersByPositionId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Выбрать сотрудников из списка сотрудников, которые относятся к конкретной должности
                List<User> users = (from user in GetAllUsers() where user.PositionId == id select user).ToList();
                return users;
            }
        }

        /// <summary>
        /// Получение всех должностей по первичному ключу отдела
        /// </summary>
        /// <param name="id">Первичный ключ</param>
        /// <returns>Должности</returns>
        public static List<Position> GetAllPositionsByDepartmentId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Выбрать должности из списка должностей, которые относятся к конкретному отделу
                List<Position> positions = (from position in GetAllPositions() where position.DepartmentId == id select position).ToList();
                return positions;
            }
        }
    }
}
