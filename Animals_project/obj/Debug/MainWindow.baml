   M S B A M L   `   `   `  ����Q  MExamen_JorenVanCalster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Examen_JorenVanCalsterExamen_JorenVanCalster  5   	   '    !Examen_JorenVanCalster.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Examen_JorenVanCalster     5   	     � Title$  
MainWindow��5   	   $	��750��6   $	��800��6)   .��5	      ��  �� Orientation$ Vertical=�6   $��5q�6(   .+�5
   
   �� $ 
Horizontal=�6   $��5q�6.   .+�5      �� $
��Name��6   $	��100��6#   �� 5      -   5        $
��Name��5   1   $	��100��6=   ��6   �� *	InputName+6=   �� 5      $��Weight��6   $	��100��6%   �� 5      -   5        $��Weight��5   3   $	��100��6A   ��6   �� *InputWeight+6A   5      �� 5   
   $ 
Horizontal=�6   $��5q�6.   .+�5      �� $
��Fish��6   $	��200��6#   �� 5      -   5        $��AddShark��5   Y   $��	Add Shark��6   $��5q�6N   ��6)   �� *MyButtonAddShark+6Y   �� 5      -   5        $��AddClownfish��5   a   $��Add Clownfish��6   $��5q�6V   ��6-   �� *MyButtonAddClownfish+6a   5      �� 5   
   $ 
Horizontal=�6   $��5q�6.   .+�5      �� $��Mammal��6   $	��200��6%   �� 5      -   5        $��AddBat��5   U   $��Add Bat��6   $��5q�6J   ��6'   �� *MyButtonAddBat+6U   �� 5      -   5        $��AddLion��5   W   $��Add Lion��6   $��5q�6L   ��6(   �� *MyButtonAddLion+6W   5      �� 5   
   $ 
Horizontal=�6   $��5q�6.   .+�5      �� $��Employee��6   $	��200��6'   �� 5      $	��Age��6   $��50��6"   �� 5      -   5        $��EmployeeAge��5   0   $��50��6C   ��6   �� *
InputAge+6C   �� 5      -   5        $��AddEmployee��5   _   $��Add Employee��6   $��5q�6T   ��6,   �� *MyButtonAddEmployee+6_   5      �� 5    
   $ 
Horizontal=�6   $��5q�6.   .+�5!      �� -	   5        $
��List��5!   m   $	��450��6y   $	��200��6�   ��6   �� *ShowedListOfAnimals+ �� SelectedItem 6C   �� *SelectionChanged+ �� View 5"      �� 5#      .P�5$      �� -
   5        	XName�� �� Width$	 160��5$   8   $
��Name��6D    �� DisplayMemberBinding 6R   �� *Name+�� 5%      -   5        XWeight��$	 160��5%   :   $��Weight��6F    6V   �� *Weight+5&      5(      5)      �� 5+   
   $ 
Horizontal=�6   $��5q�6.   .+�5,      �� $��Info:��6   �� 5-      -   5        $
��Info��5-   2   ��6   �� *	InfoLabel+62   �� 5.      -   5        $
��Feed��5.   $   $
��Feed��6   6$   �� 5/      -   5        $��NameTimesAge��5/   2   $��Calculate Name*Age��6   62   50      �� 52   
   $ 
Horizontal=�6   $��5q�6.   .+�53      �� -   5        $��TotalWeight��53   r   $��Calculate Total Weight��6   $��5q�6g   ��66   �� *MyButtonCalculateTotalWeight+6r   54      �� 56   
   $ 
Horizontal=�6   $��5q�6.   .+�57      �� -   5        $��ShowAll��57   ]   $��Show all��6   $��5q�6R   ��6(   �� *MyButtonShowAllButton+6]   �� 58      -   5        $��
ShowOver10��58   q   $��Show Animals over 10kg��6   $��5q�6f   ��66   �� *MyButtonShowAnimalsOver10kg+6q   �� 59      -   5        $��
ShowOver20��59   q   $��Show Animals over 20kg��6   $��5q�6f   ��66   �� *MyButtonShowAnimalsOver20kg+6q   5:      �� 5;   
   $ 
Horizontal=�6   $��5q�6.   .+�5<      �� -   5        $��ShowUnder50��5<   s   $��Show Animals under 50kg��6   $��5q�6h   ��67   �� *MyButtonShowAnimalsUnder50kg+6s   �� 5=      -   5        $��ShowHungryAnimals��5=   t   $ ��Show Hungry Animals (>80%)��6   $��5q�6i   ��6:   �� *MyButtonShowHungryAnimal80+6t   5>      �� 5@   
   $ 
Horizontal=�6   $��5q�6.   .+�5A      �� $��Search by name��6   �� 5B      -   5        $��
SearchName��5B      $��50��6E   ��6(   �� *InputSearch+6E   �� 5C      -   5        $��Search��5C   Z   $��Search��6   $��5q�6O   ��6&   �� *MyButtonSearchButton+6Z   5D      �� 5F   
   $ 
Horizontal=�6   $��5q�6.   .+�5G      �� -   5        $��SortWeightASC��5G   h   $��Sort By Weight ASC��6   $��5q�6]   ��62   �� *MyButtonOrderAscButton+6h   �� 5H      -   5        $��SortWeightDESC��5H   j   $��Sort By Weight DESC��6   $��5q�6_   ��63   �� *MyButtonOrderDescButton+6j   5I      �� 5K   
   $ 
Horizontal=�6   $��5q�6.   .+�5L      �� -   5        $��	SaveToTXT��5L   6   $��Save to TXT��6   $��5q�6+   66   �� 5M      -   5        $��RestoreFromTXT��5M   ;   $��Restore from TXT��6   $��5q�60   6;   5N      5O      5P      