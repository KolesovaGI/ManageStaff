   M S B A M L   `   `   `  ����K  GManageStaffDBApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ManageStaffDBApp.ViewManageStaffDBApp.View  5   	   0    *ManageStaffDBApp.View.AddNewPositionWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ManageStaffDBApp.View     5   	   -   5        $��AddNewPositionWnd��5	   	     � Title$)  #Добавить должность��5   	   $	��300��6$   $	��300��61    � 
ResizeMode$ NoResize=�5	   "    � WindowStartupLocation$ CenterScreen=�68    � Icon$ /View/logo.png��6]   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   $��Center=�5      $��Center=�5      $	��200��5      .+�5      �� $��НАЗВАНИЕ��6   $
��Bold"�6)   
�������6;   �� 5      -   5        $��	NameBlock��5      ��6'   �� *PositionName+�� 5      $��ЗАРПЛАТА��6   $
��Bold"�6)   
�������6;   �� 5      -   5        $��SalaryBlock��5      ��6M   �� *PositionSalary+�� 5      $'��!МАКСИМУМ ВАКАНСИЙ��6   $
��Bold"�62   
�������6D   �� 5      -   5        $��MaxNumberBlock��5      ��6Q   �� *PositionMaxNumber+�� 5      $��
ОТДЕЛ��6   $
��Bold"�6%   
�������67   �� 5       �� DisplayMemberPath$
 Name��5      ��5      �� *AllDepartments+ �� SelectedItem 5      �� *PositionDepartment+5      �� 5   
   $��1��6   $��СОХРАНИТЬ��6   $
��Bold"�5!      $��15(�6#   ���#B39EB5��5      �� *AddNewPosition+��5       ��  �� ElementName$ AddNewPositionWnd����5"      Z� ��6'   Z� 5#      5$      