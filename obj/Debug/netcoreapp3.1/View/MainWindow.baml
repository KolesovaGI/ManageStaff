   M S B A M L   `   `   `  ����K  GManageStaffDBApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ManageStaffDBApp.ViewManageStaffDBApp.View  5   	   &     ManageStaffDBApp.View.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ManageStaffDBApp.View     5   	     � Title$  ManageStaff��5   	   $	��450��6   $	��800��6*   $	��450��66   $	��800��6F    � WindowStartupLocation$ CenterScreen=�6U    � Icon$ /View/logo.png��6z   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��0��6    �� SelectedItem 6"   �� *SelectedTabItem+.@�5      �� -   5        $��UsersTab��5      ��5      �� 5      $��СОТРУДНИКИ��6    ���#B39EB5$
��Bold"�6G    � ContextMenu 5      �� 5      .@�5      m� $ ��Редактировать��6#    m� Command 6:   �� *OpenEditItemWnd+m� 5      $��Удалить��6#    64   �� *
DeleteItem+5      .��5      �� -   5         ��Name$ ViewAllUsers��5      ��61   �� *
AllUsers+ 5      �� *SelectedUser+ �� View 5      �� 5      .P�5      �� $��Имя��6-   	 �� DisplayMemberBinding	 5   -   �� 
 �� Path$

 Name��� 5      $��Фамилия��6-   	 5    -   �� $
 SurName��� 5!      $��Телефон��6-   	 5"   -   �� $
 Phone��� 5#      $��Зарплата��6-   	 5$   -   �� $
 UserPosition.Salary��� 5%      $��Должность��6-   	 5&   -   �� $
 UserPosition.Name��� 5'      $��
Отдел��6-   	 5(   -   �� $*
 $UserPosition.PositionDepartment.Name�5)      5+      5,      �� 5-      -   5        $��PositionsTab��5-      ��5.      �� 5/      $��ДОЛЖНОСТИ��6    ���#B39EB5$
��Bold"�6F    51      �� 52      .@�53      m� $ ��Редактировать��6#    6:   �� *OpenEditItemWnd+m� 54      $��Удалить��6#    64   �� *
DeleteItem+55      .��57      �� -   5        $ ViewAllPositions��57      ��65   �� *AllPositions+ 58      �� *SelectedPosition+ 59      �� 5:      .P�5;      �� $��Название��6-   	 5<   -   �� $

 Name��� 5=      $��Зарплата��6-   	 5>   -   �� $
 Salary��� 5?      $1��+Количество сотрудников��6-   	 5@   -   �� $
 PositionUsers.Count��� 5A      $'��!Максимум вакансий��6-   	 5B   -   �� $
 	MaxNumber��� 5C      $��
Отдел��6-   	 5D   -   �� $
 PositionDepartment.Name�5E      5G      5H      �� 5I      -   5        $��DepartmentsTab��5I      ��5J      �� 5K      $��ОТДЕЛЫ��6    ���#B39EB5$
��Bold"�6C    5M      �� 5N      .@�5O      m� $ ��Редактировать��6#    6:   �� *OpenEditItemWnd+m� 5P      $��Удалить��6#    64   �� *
DeleteItem+5Q      .��5S      �� -   5        $ ViewAllDepartments��5S      ��67   �� *AllDepartments+ 5T      �� *SelectedDepartment+ 5U      �� 5V      .P�5W      �� $��Название��6-   	 5X   -   �� $

 Name��� 5Y      $'��!Максимум вакансий��6-   	 5Z   -   �� $
 DepartmentPositions.Count�5[      5]      5^      5_      �� 5`   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�5a      .+�5b      �� $+��%ДОБАВИТЬ СОТРУДНИКА��6   $	��200��63   $
��Bold"�6?   $��15(�6Q   ���#B39EB5��5c   *   Z� ��6@   Z� ��5d      �� *OpenAddNewUserWnd+�� 5e      $)��#ДОБАВИТЬ ДОЛЖНОСТЬ��6   $	��200��62   $
��Bold"�6>   $��15(�6P   ���#B39EB5��5f   *   Z� ��6@   Z� ��5g      �� *OpenAddNewPositionWnd+�� 5h      $!��ДОБАВИТЬ ОТДЕЛ��6   $	��200��6.   $
��Bold"�6:   $��15(�6L   ���#B39EB5��5i   *   Z� ��6@   Z� ��5j      �� *OpenAddNewDepartmentWnd+5k      5l      5m      