   M S B A M L   `   `   `  ����?  ;v8z4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:v8z4v8z4  5   	       v8z4.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:v8z4     5   	     � Title$  
MainWindow��5	   	   $	��600��6   $	��800��6)    � DataContext 5   	   ��  �� RelativeSource �� *Self+ � 	Resources 5       �� 
TargetType �� Property �� Value   SpecijalnoDugme  SpecijalnoDugme2 �� BasedOn��%�  '��       '�� �     '�� �    &	  �    &	 e    7   �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � �� �#3333336+   �� 5       � ��$ 5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$ 5q�6'   �� 5       � ��$ 10q�6(   �� 5       � �� �#4A4A4A6,   �� 5       � ��$ 1q�60   �� 5       � �� �#F9F9F96+   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$ 5q�6'   �� 5       � ��$ 10q�6(   �� 5       � ��
 �����6+   �� 5        � �� �#007ACC6+   �� 5!       � �� �#005A9E6,   �� 5"       � ��$ 1q�60   �� 5#       �@�Cursor$
 Hand��6'   5$      �� 5&   
   " ��6(   .�5'      ��  � �� �#007ACC6,   �� 5(       � ��$ 2q�60   5)      �� 5+   
   " ��6)   8   .�5,      ��  � �� �#007ACC6+   5-      5.      .��50      �  � RowDefinitions 51   
   �� 52      $
��Auto �6   �� 53      $
��Auto �6   �� 54      $��* �6   .+�57   
   �� $��0��6   $��Phone Directory App��6!   $��30(�58      
����������#005A9E$��Center=�59   )   	 �� Padding$	 10q�5:      � 5<   
   $��1��6   
 � ColumnDefinitions
 5=      �� 5>      $
��Auto �6#   �� 5?      $��* �6#   �� 5@      $
��Auto �6#   .+�5C      �� $��0��6   $��10q�6)   .+�5D      �� $��First name:��6   �� 5E      $��
Last name:��6   �� 5F      $��Phone number:��6   �� 5G      $��Email:��6   5H      �� 5J      $��1��6   $��10q�6)   .+�5K      �� $	��250��6I   ��6   �� *Person.FirstName+ �� Mode$ TwoWay=�6I   �� 5L      $	��250��6H   ��6   �� *Person.LastName+$ TwoWay=�6H   �� 5M      $	��250��6K   ��6   �� *Person.PhoneNumber+$ TwoWay=�6K   �� 5N      $	��250��6E   ��6   �� *Person.Email+$ TwoWay=�6E   5O      � 5Q      $��2��6   $��10q�6(    � Orientation$ Vertical=�64   .+�5R      �� -   5        $	��Add��5R      #��[ 6<   �� 5S      -   5        $��Update��5S      6*   �� 5T      -   5        $��Delete��5T      6*   �� 5U      -   5        $
��Load��5U      6(   5V      5W      &   System.Windows.Controls.DataGrid  5Y   
   $��2��6      AutoGenerateColumns .  $��10q�5[         AlternatingRowBackground �#F5F5F5
����������#4A4A4A$��1q�5_      ��5Y       �� *	Persons+ �� SelectedItem 5Z   /   �� *Person+   Columns 5`      0  *System.Windows.Controls.DataGridTextColumn  5a      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ 
First name��6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6/   �� *	FirstName+6M     5b      $ * 6%   $ 	Last name��6L    6/   �� *
LastName+6L     5c      $ * 6%   $ Mobile number��6O    6/   �� *PhoneNumber+6O     5d      $ * 6%   $ Email��6I    6/   �� *Email+6I   5f      5g      5h      