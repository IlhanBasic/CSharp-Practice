   M S B A M L   `   `   `  ����A  =igrica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:igricaigrica  5   	       igrica.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:igrica     5   	     � Title$  
MainWindow��5   	   $	��800��6    � 
ResizeMode$ NoResize=�6)   $	��800��6?    � 	Resources 5	       �� 
TargetType �� Property �� Value��%W   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 10q�6'   64   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��podloga��5      |�. .+�5      �� -   5         ��Name$ igrac1��5   7   
 �� Top$ 0��6   	 �� Left$	 0��6'   $��30��6G   $	��200��6R   
���   �6_   �� 5      -   5        $ igrac2��5   *   $	 300��6   $��30��6:   $	��200��6E   
�������$		 760��6^   A� 5      -   5        
 A�Name$	
 pak��5      $��30��6#   $��30��6.   
����  �$	 30��6F   $ 20��6W   5      �� 5   
   -   5         ��Name$ controlPanel��5      $��1��6+   $��Center=�68    �� Orientation$ 
Horizontal=�6U   .+�5      �� -   5        $��btnStart��5      $��start��6:   �� 5      -   5         ��Name$ btnStop��5      $
��stop��6>   5      5      5      