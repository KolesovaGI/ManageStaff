   M S B A M L   `   `   `  ����K  GManageStaffDBApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ManageStaffDBApp.ViewManageStaffDBApp.View  5   	   ,    &ManageStaffDBApp.View.AddNewUserWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ManageStaffDBApp.View     5   	   -   5        $��AddNewUserWnd��5	   	     � Title$+  %Добавить сотрудника��5   	   $	��300��6%   $	��300��62    � 
ResizeMode$ NoResize=�5	       � Icon$ /View/logo.png��64    � WindowStartupLocation$ CenterScreen=�6J   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   $��Center=�5      $��Center=�5      $	��200��5      .+�5      �� $��ИМЯ��6   $
��Bold"�6#   
�������65   �� 5      -   5        $��	NameBlock��5      ��6'   �� *
UserName+�� 5      $��ФАМИЛИЯ��6   $
��Bold"�6'   
�������69   �� 5      -   5        $��SurNameBlock��5      ��6*   �� *UserSurName+�� 5      $��ТЕЛЕФОН��6   $
��Bold"�6'   
�������69   �� 5      -   5        $��
PhoneBlock��5      ��6L   �� *	UserPhone+�� 5      $��ДОЛЖНОСТЬ��6   $
��Bold"�6)   
�������6;   �� 5       �� DisplayMemberPath$
 Name��5      ��5      �� *AllPositions+ �� SelectedItem 5      �� *UserPosition+5      �� 5   
   $��1��6   $��СОХРАНИТЬ��6   $
��Bold"�5!      $��15(�6#   ���#B39EB5��5      �� *
AddNewUser+��5       ��  �� ElementName$ AddNewUserWnd����5"      Z� ��6'   Z� 5#      5$      