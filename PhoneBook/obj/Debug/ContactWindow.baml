   M S B A M L   `   `   `  ����D  @PhoneBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PhoneBook	PhoneBook  5   	       PhoneBook.ContactWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PhoneBook     5   	     � Title$  ContactWindow��5   	   $	��200��6   $	��300��6,    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       '�� G     �� 5
   
   " ��6   .�5      ��  � ��$ 8q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 8q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      .+�5   
   �� $
��Name��6   �� 5   
   $��Surname��6   $��1��6#   �� 5   
   $��Phone number��6   $��2��6(   �� 5    
   $��Email��6   $��3��6!   �� 5"   
   $��1��6   $��0��6"   .��6/   .��5#      ��  �� Path$
 Name�6    �� ValidationRules 5$      5  /System.Windows.Controls.DataErrorValidationRule  5%      5'      5(      �� 5)   
   $��1��6   $��1��6"   .��6/   .��5*      �� $ Surname�6    5+        5,      5.      5/      �� 50   
   $��1��6   $��2��6"   .��6/   .��51      �� $ Number�6    52        53      55      56      �� 57   
   $��1��6   $��3��6"   .��6/   .��58      �� $ Email�6    59        5:      5<      5=      �� 5?   
   $��Center=�6   	 �� Orientation$	 
Horizontal=�62   $��4��6K   $��1��6X   .+�5@      �� -   5        
 �� 	IsDefault
 . $��60��5@   ;   $��5q�6I   .��6T   OK6X   �� 5A       �� IsCancel . $��60��6%   $��5q�63   .��6>   Cancel6F   5B      5C      5D      