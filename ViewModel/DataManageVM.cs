using ManageStaffDBApp.Model;
using ManageStaffDBApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ManageStaffDBApp.ViewModel
{
    /// <summary>
    /// Класс, реализующий логику работы приложения
    /// </summary>
    public class DataManageVM : INotifyPropertyChanged
    {
        // Все отделы
        private List<Department> allDepartments = DataWorker.GetAllDepartments();                   // При первом подключении данных к View, поля будут наполняться данными
        public List<Department> AllDepartments
        {
            get { return allDepartments; } // Возвращение всех отделов
            set
            {
                allDepartments = value;                                                             // Отделам присваивается новое значение
                NotifyPropertyChanged("AllDepartments");                                            // Уведомление системы об изменении данных
            }
        }

        // Все должности
        private List<Position> allPositions = DataWorker.GetAllPositions();                         // При первом подключении данных к View, поля будут наполняться данными
        public List<Position> AllPositions
        {
            get
            {
                return allPositions;                                                                // Возвращение всех должностей
            }
            private set
            {
                allPositions = value;                                                               // Должностям присваивается новое значение
                NotifyPropertyChanged("AllPositions");                                              // Уведомление системы об изменении данных
            }
        }

        // Все сотрудники
        private List<User> allUsers = DataWorker.GetAllUsers();                                     // При первом подключении данных к View, поля будут наполняться данными
        public List<User> AllUsers
        {
            get
            {
                return allUsers;                                                                    // Возвращение всех сотрудников
            }
            private set
            {
                allUsers = value;                                                                   // Сотрудникам присваивается новое значение
                NotifyPropertyChanged("AllUsers");                                                  // Уведомление системы об изменении данных
            }
        }

        // Свойства для отдела
        public static string DepartmentName { get; set; }                                           // Название 
        // Свойства для должностей  
        public static string PositionName { get; set; }                                             // Название 
        public static decimal PositionSalary { get; set; }                                          // Зарплата
        public static int PositionMaxNumber { get; set; }                                           // Максимум вакансий
        public static Department PositionDepartment { get; set; }                                   // К какому отделу относится должность

        // Свойства для сотрудника
        public static string UserName { get; set; }                                                 // Имя
        public static string UserSurName { get; set; }                                              // Фамилия
        public static string UserPhone { get; set; }                                                // Номер телефона
        public static Position UserPosition { get; set; }                                           // Какую должность занимает

        // Свойства для выделенных элементов
        public TabItem SelectedTabItem { get; set; }                                                // Выбранный элемент
        public static User SelectedUser { get; set; }                                               // Выбранный сотрудник
        public static Position SelectedPosition { get; set; }                                       // Выбранная должность
        public static Department SelectedDepartment { get; set; }                                   // Выбранный отдел


        #region COMMANDS TO ADD
        private RelayCommand addNewDepartment;                                                      // Добавить новый отдел

        /// <summary>
        /// Реализация команды добавления нового отдела
        /// </summary>
        public RelayCommand AddNewDepartment
        {
            get
            {
                return addNewDepartment ?? new RelayCommand(obj =>                                  // Проверка на пустоту поля, если пусто - возвращение
                {
                    Window wnd = obj as Window;                                                     // Окно
                    string resultStr = "";

                    if (DepartmentName == null || DepartmentName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateDepartment(DepartmentName);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewPosition;
        public RelayCommand AddNewPosition
        {
            get
            {
                return addNewPosition ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";

                    if(PositionName == null || PositionName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }

                    if (PositionSalary == 0)
                    {
                        SetRedBlockControll(wnd, "SalaryBlock");
                    }

                    if (PositionMaxNumber == 0)
                    {
                        SetRedBlockControll(wnd, "MaxNumberBlock");
                    }

                    if (PositionDepartment == null)
                    {
                        MessageBox.Show("Укажите отдел");
                    }

                    else
                    {
                        resultStr = DataWorker.CreatePosition(PositionName, PositionSalary, PositionMaxNumber, PositionDepartment);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewUser;
        public RelayCommand AddNewUser
        {
            get
            {
                return addNewUser ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";

                    if (UserName == null || UserName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }

                    if (UserSurName == null || UserSurName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "SurNameBlock");
                    }

                    if (UserPosition == null)
                    {
                        MessageBox.Show("Укажите позицию");
                    }

                    else
                    {
                        resultStr = DataWorker.CreateUser(UserName, UserSurName, UserPhone, UserPosition);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }

        #endregion

        private RelayCommand deleteItem;                                                            // Удаление элемента

        /// <summary>
        /// Команда для удаления элемента
        /// </summary>
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";                                         // Строка оповещения

                    if(SelectedTabItem.Name == "UsersTab" && SelectedUser != null)                  // Если сотрудник
                    {
                        resultStr = DataWorker.DeleteUser(SelectedUser);                            // Строке оповещения присваивается информация об удалённом сотруднике
                        UpdateAllDataView();                                                        // Обновление информации во всех окнах
                    }

                    if (SelectedTabItem.Name == "PositionsTab" && SelectedPosition != null)         // Если должность
                    {
                        resultStr = DataWorker.DeletePosition(SelectedPosition);                    // Строке оповещения присваивается информация об удалённой должности
                        UpdateAllDataView();                                                        // Обновление информации во всех окнах
                    }

                    if (SelectedTabItem.Name == "DepartmentsTab" && SelectedDepartment != null)     // Если отдел
                    {
                        resultStr = DataWorker.DeleteDepartment(SelectedDepartment);                // Строке оповещения присваивается информация об удалённом отделе
                        UpdateAllDataView();                                                        // Обновление информации во всех окнах
                    }

                    // Обновление
                    SetNullValuesToProperties();                                                    // Обнулить все свойства
                    ShowMessageToUser(resultStr);                                                   // Показать окно с уведомлением
                }
                    );
            }
        }

        #region EDIT COMMANDS
      
        private RelayCommand editUser;                                              // Редактирования сотрудника

        /// <summary>
        /// Реализация команды редактирования сотрудника
        /// </summary>
        public RelayCommand EditUser
        {
            get
            {
                return editUser ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;                                  // Окно

                    string resultStr = "Не выбран сотрудник";                       // Текст оповещения
                    string noPositionStr = "Не выбрана новая должность";            // Текст оповещения

                    if (SelectedUser != null)                                       // Если выбранный сотрудник существует
                    {
                        if(UserPosition != null)                                    // Если занятая сотрудником должность существует
                        {
                            // Информация о сотруднике изменяется
                            resultStr = DataWorker.EditUser(SelectedUser, UserName, UserSurName, UserPhone, UserPosition);

                            UpdateAllDataView();                                    // Обновление всей информации во всех окнах
                            SetNullValuesToProperties();                            // Обнуление всех свойств
                            ShowMessageToUser(resultStr);                           // Показать окно оповещения
                            window.Close();                                         // Закрыть окно
                        }
                        else ShowMessageToUser(noPositionStr);                      // Иначе показать окно оповещения об ошибке - не выбрана новая должность
                    }
                    else ShowMessageToUser(resultStr);                              // Иначе показать окно оповещения об ошибке - не выбран сотрдуник

                }
                );
            }
        }
        // Редактирование должности
        private RelayCommand editPosition;                                          // Редактирование должности

        /// <summary>
        /// Реализация команды редактирования должности
        /// </summary>
        public RelayCommand EditPosition
        {
            get
            {
                return editPosition ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;                                  // Окно

                    string resultStr = "Не выбрана позиция";                        // Текст оповещения
                    string noDepartmentStr = "Не выбран новый отдел";               // Текст оповещения

                    if (SelectedPosition != null)                                   // Если выбранная должность существует
                    {
                        if (PositionDepartment != null)                             // Если должность существует
                        {
                            // Информация о должности изменяется
                            resultStr = DataWorker.EditPosition(SelectedPosition, PositionName, PositionMaxNumber, PositionSalary, PositionDepartment);

                            UpdateAllDataView();                                    // Обновление всей информации во всех окнах
                            SetNullValuesToProperties();                            // Обнуление всех свойств
                            ShowMessageToUser(resultStr);                           // Показать окно оповещения
                            window.Close();                                         // Закрыть окно
                        }
                        else ShowMessageToUser(noDepartmentStr);                    // Иначе показать окно оповещения об ошибке - не выбран новый отдел
                    }
                    else ShowMessageToUser(resultStr);                              // Иначе показать окно оповещения об ошибке - не выбрана должность

                }
                );
            }
        }

        private RelayCommand editDepartment;                                        // Редактирование отдела

        /// <summary>
        /// Реализация команды редактирования отдела
        /// </summary>
        public RelayCommand EditDepartment
        {
            get
            {
                return editDepartment ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;

                    string resultStr = "Не выбран отдел";                           // Текст оповещения

                    if (SelectedDepartment != null)                                 // Если выбранный отдел существует
                    {
                        // Информация об отделе изменяется
                        resultStr = DataWorker.EditDepartment(SelectedDepartment, DepartmentName);

                        UpdateAllDataView();                                        // Обновление всей информации во всех окнах
                        SetNullValuesToProperties();                                // Обнулить все свойства
                        ShowMessageToUser(resultStr);                               // Показать окно оповещения
                        window.Close();                                             // Закрыть окно
                    }
                    else ShowMessageToUser(resultStr);                              // Иначе показать окно оповещения
                }
                );
            }
        }
        #endregion

        #region COMMANDS TO OPEN WINDOWS
        private RelayCommand openAddNewDepartmentWnd;                                               // Открыть окно добавления отдела

        /// <summary>
        /// Реализация команды открытия окна добавления отдела
        /// </summary>
        public RelayCommand OpenAddNewDepartmentWnd
        {
            get
            {
                return openAddNewDepartmentWnd ?? new RelayCommand(obj =>                           // Проверка на пустоту поля, если пусто - возвращение
                {
                        OpenAddDepartmentWindowMethod();                                            // Открытие окна добавления отдела
                    }
                    );
            }
        }

        private RelayCommand openAddNewPositionWnd;                                                 // Открыть окно добавления должности

        /// <summary>
        /// Реализация команды открытия окна добавления должности
        /// </summary>
        public RelayCommand OpenAddNewPositionWnd
        {
            get
            {
                return openAddNewPositionWnd ?? new RelayCommand(obj =>                             // Проверка на пустоту поля, если пусто - возвращение
                {
                    OpenAddPositionWindowMethod();                                                  // Открытие окна добавления должности
                }
                );
            }
        }

        private RelayCommand openAddNewUserWnd;                                                     // Открыть окно добавления сотрудника

        /// <summary>
        /// Реализация команды открытия окна добавления сотрудника
        /// </summary>
        public RelayCommand OpenAddNewUserWnd
        {
            get
            {
                return openAddNewUserWnd ?? new RelayCommand(obj =>                                 // Проверка на пустоту поля, если пусто - возвращение
                {
                    OpenAddUserWindowMethod();                                                      // Открытие окна добавления сотрудника
                }
                );
            }
        }

        private RelayCommand openEditItemWnd;                                                       // Открыть контекстное меню для редактирования поля

        /// <summary>
        /// Реализация команды открытия контекстного меня для редактирования поля
        /// </summary>
        public RelayCommand OpenEditItemWnd
        {
            get
            {
                return openEditItemWnd ?? new RelayCommand(obj =>                                   // Проверка на пустоту поля, если пусто - возвращение                            
                {
                    string resultStr = "Ничего не выбрано";                                         // Оповещение

                    if (SelectedTabItem.Name == "UsersTab" && SelectedUser != null)                 // Если выбран сотрудник
                    {
                        OpenEditUserWindowMethod(SelectedUser);                                     // Открыть окно редакирования сотрудника для выбранного сотрудника
                    }
                    
                    if (SelectedTabItem.Name == "PositionsTab" && SelectedPosition != null)         // Если выбрана должность
                    {
                        OpenEditPositionWindowMethod(SelectedPosition);                             // Открыть окно редактирования должности для выбранной должности
                    }
                    
                    if (SelectedTabItem.Name == "DepartmentsTab" && SelectedDepartment != null)     // Если выбран отдел
                    {
                        OpenEditDepartmentWindowMethod(SelectedDepartment);                         // Открыть окно редактирования отдела для выбранного отдела
                    }
                }
                    );
            }
        }
        #endregion

        #region METHODS TO OPEN WINDOW
        /// <summary>
        /// Открытие окна добавления отдела
        /// </summary>
        private void OpenAddDepartmentWindowMethod()
        {
            AddNewDepartmentWindow newDepartmentWindow = new AddNewDepartmentWindow();          // Окно добавления отдела
            SetCenterPositionAndOpen(newDepartmentWindow);                                      // Окно отроется посередине экрана
        }
        /// <summary>
        /// Открытие окна добавления должности
        /// </summary>
        private void OpenAddPositionWindowMethod()
        {
            AddNewPositionWindow newPositionWindow = new AddNewPositionWindow();                // Окно добавления должности
            SetCenterPositionAndOpen(newPositionWindow);                                        // Окно отроется посередине экрана
        }

        /// <summary>
        /// Открытие окна добавления сотрудника
        /// </summary>
        private void OpenAddUserWindowMethod()
        {
            AddNewUserWindow newUserWindow = new AddNewUserWindow();                            // Окно добавления сотрудника
            SetCenterPositionAndOpen(newUserWindow);                                            // Окно отроется посередине экрана
        }
        
        /// <summary>
        /// Открытие окна редактирвания отдела
        /// </summary>
        /// <param name="department">Отдел</param>
        private void OpenEditDepartmentWindowMethod(Department department)
        {
            EditDepartmentWindow editDepartmentWindow = new EditDepartmentWindow(department);   // Окно редактирования отдела
            SetCenterPositionAndOpen(editDepartmentWindow);                                     // Окно отроется посередине экрана
        }
        /// <summary>
        /// Открытие окна редактирвания должности
        /// </summary>
        /// <param name="position">Должность</param>
        private void OpenEditPositionWindowMethod(Position position)
        {
            EditPositionWindow editPositionWindow = new EditPositionWindow(position);           // Окно редактирования должности
            SetCenterPositionAndOpen(editPositionWindow);                                       // Окно отроется посередине экрана
        }

        /// <summary>
        /// Открытие окна редактирования сотрудника
        /// </summary>
        /// <param name="user">Сотрудник</param>
        private void OpenEditUserWindowMethod(User user)
        {
            EditUserWindow editUserWindow = new EditUserWindow(user);                           // Окно редактирования сотрудника
            SetCenterPositionAndOpen(editUserWindow);                                           // Окно отроется посередине экрана
        }

        /// <summary>
        /// Задание места открытия и открытия окон
        /// </summary>
        /// <param name="window">Окно</param>
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;                                      // Главное окно - главное
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;                   // Позиция - центр главоного окна
            window.ShowDialog();                                                                // Окно не закрывается, пока не выполнится действие
        }
        #endregion

        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        #region UPDATE VIEWS
        /// <summary>
        /// Обнулить все свойства
        /// </summary>
        private void SetNullValuesToProperties()
        {
            // Для сотрудника
            UserName = null;                                                // Имя
            UserSurName = null;                                             // Фамилия
            UserPhone = null;                                               // Номер телефона
            UserPosition = null;                                            // Занимаемая должность

            // Для должности
            PositionName = null;                                            // Название
            PositionSalary = 0;                                             // Зарплата
            PositionMaxNumber = 0;                                          // Число вакансий
            PositionDepartment = null;                                      // Отдел, к которому относится должность

            // Для отдела
            DepartmentName = null;                                          // Название
        }

        /// <summary>
        /// Обновление всей информации во всех окнах
        /// </summary>
        private void UpdateAllDataView()
        {
            UpdateAllDepartmentsView();                                     // Обновление информации об отделах
            UpdateAllPositionsView();                                       // Обновление информации о должностях
            UpdateAllUsersView();                                           // Обновление информации о сотрудниках
        }

        /// <summary>
        /// Обновление информации об отделах
        /// </summary>
        private void UpdateAllDepartmentsView()
        {
            AllDepartments = DataWorker.GetAllDepartments();                // Получение списка отделов
            MainWindow.AllDepartmentsView.ItemsSource = null;               // Обнулить информацию в элементах
            MainWindow.AllDepartmentsView.Items.Clear();                    // Очистить данные элементов
            MainWindow.AllDepartmentsView.ItemsSource = AllDepartments;     // Присвоить элементам информацию из списка всех отделов
            MainWindow.AllDepartmentsView.Items.Refresh();                  // Обновить значения элементов
        }

        /// <summary>
        /// Обновление информации о должностях
        /// </summary>
        private void UpdateAllPositionsView()
        {
            AllPositions = DataWorker.GetAllPositions();                    // Получение списка должностей
            MainWindow.AllPositionsView.ItemsSource = null;                 // Обнулить информацию в элементах
            MainWindow.AllPositionsView.Items.Clear();                      // Очистить данные элементов
            MainWindow.AllPositionsView.ItemsSource = AllPositions;         // Присвоить элементам информацию из списка всех должностей
            MainWindow.AllPositionsView.Items.Refresh();                    // Обновить значения элементов
        }

        /// <summary>
        /// Обновление информации о сотрудниках
        /// </summary>
        private void UpdateAllUsersView()
        {
            AllUsers = DataWorker.GetAllUsers();                            // Получение списка сотрудников
            MainWindow.AllUsersView.ItemsSource = null;                     // Обнулить информацию в элементах
            MainWindow.AllUsersView.Items.Clear();                          // Очистить данные элементов
            MainWindow.AllUsersView.ItemsSource = AllUsers;                 // Присвоить элементам информацию из списка всех сотрудников
            MainWindow.AllUsersView.Items.Refresh();                        // Обновить значения элементов
        }
        #endregion

        /// <summary>
        /// Показать окно оповещения
        /// </summary>
        /// <param name="message">Текст оповещения</param>
        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);                                     // Окно оповещений
            SetCenterPositionAndOpen(messageView);                                                  // Окно откроется по центру экрана
        }

        public event PropertyChangedEventHandler PropertyChanged;                                   // Событие изменения данных

        /// <summary>
        /// Уведомление об изменении данных
        /// </summary>
        /// <param name="propertyName">Имя свойства</param>
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)                                                            // Если данные изменены
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));                  // Событие принимает новые данные
            }
        }
    }
}
