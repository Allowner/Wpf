   M S B A M L   `   `   `  ����D  @PhoneBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PhoneBook	PhoneBook  5   	       PhoneBook.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PhoneBook     5   	     � Title$  
MainWindow��5   	   $��368.133��6   $	��425��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $
��85.6 �6   .+�5   
   �� -   5         ��Name$ 
phonesList��5      $��0,0,0.4,85.4q�6G   $��2��6]   ��6&   �� *
Contacts+��5      �� 5      .R�5      �� .+�5      �� 6&   �� 5      $��16(�6W   ��6$   ��  �� StringFormat$ 	Name: {0}�� �� Path$
 Name�6W   �� 5      $��16(�6]   ��6$   �� $ Surname: {0}��$ Surname�6]   �� 5      $��16(�6[   ��6$   �� $ Number: {0}��$ Number�6[   �� 5      $��16(�6Y   ��6$   �� $ 
Email: {0}��$ Email�6Y   5      5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��82,0.2,82,36.4q�6X   $	��254��6p   .+�5      �� $	��Add��6   $��10,10,10,9.8q�6#   $��65��69   ��6D   �� *
AddCommand+�� 5      $��Update��6   $��10,10,10,9.8q�6&   $��65��6<   ��6G   �� *EditCommand+��5      ��  �� ElementName$ 
phonesList��$ SelectedItem��� 5      $��Delete��6   $��10,10,10,9.8q�6&   $��65��6<   ��6G   �� *DeleteCommand+��5       �� $ 
phonesList��$ SelectedItem�5!      �� 5"   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   $	��168��6X   $��126,39.2,124.4,0.4q�6d   .+�5#      �� $��
Find by id��6   $��Center=�6*   $��10,10,10,9.6q�6G   $��78��5$      ��6    �� *FindCommand+��5%      �� *Text+$ tbxName���� 5&      -   5         ��Name$ tbxName��5&      $��
0,10,0,9.6q�6'   $��60��6;   $��18(�6F   5'      5(      5)      