   M S B A M L   `   `   `  ����G  CtrkaPlivanje, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:trkaPlivanjetrkaPlivanje  5   	       trkaPlivanje.bazenTrka   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:trkaPlivanje     5   	     � Title$  	bazenTrka��5	   	   $	��500��6   $	��800��6+   $	��500��6:   $	��800��6J    � DataContext 5   	   ��  �� RelativeSource �� *Self+.��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5         ��Name$ tbPrvi��5      $��0��6X   $��20(�6e   $y�Hidden=�6s   $��Center=�6�   $��Bottom=�6�   ��6%   �� *
Prvi.Ime+ �� StringFormat$ 	Prvi: {0}��6�   �� 5   
   -   5         ��Name$ bazen��5      $��1��6    �� 5   
   -   5        $ tbPobeda��5      $��2��6&   $��
Pobednik: ��63   $��20(�6E   $y�Hidden=�6S   $��Right=�6h   $��Bottom=�6�   $��	0,0,48,10q�6�   5      5      