   M S B A M L   `   `   `  ����D  @igraJurke, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:igraJurke	igraJurke  5   	       igraJurke.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:igraJurke     5   	     � Title$  
MainWindow��5	   	   $	��800��6   $	��800��6)    � DataContext 5   	   ��  �� RelativeSource �� *Self+.��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ sp��5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��20q�6O   .+�5      �� -   5         ��Name$ btnStart��5      $��Start��6B   $��20(�6R   $��5q�6`   $��10q�6l   �� 5      -   5        $ btnStop��5      $
��Stop��6@   $��20(�6O   $��5q�6]   $��10q�6i   5      �� 5      $��20(�6O   $��Center=�6]   $��10q�6z   ��6   �� *Score+ �� StringFormat$ Propusteno: {0}��6z   5      �� 5   
   -   5         ��Name$ podloga��5      |�. $��1��63   $��10q�6@   .+�5      A� -   5        	 A�Name$	 kuglica��5      $��20��6'   $��20��62   
 �� Left$
 30��6>   
 �� Top$ 30��6O   
����+��6_   A� 5      -   5        $	 kugla��5      $	��100��6%   $	��100��61   $	
 340��6>   $	 275��6P   
���   �$
��Left=�6n   $	��Top=�6�   5      5      5      