   M S B A M L   `   `   `  ����  SWP_2011    SWP_2011.Most_visited   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6?   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6�   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6�   -   5          �Name$  Window��5       � Title$ Most Visited��5      $	��640��5      $	��480��6    � ToolTip$ Most Visited��6    � 	Resources 5	         ButtonStyle4 �� 
TargetType �� Property �� Value �� 
TargetType F�Name	 �� Stretch
 �� EndPoint � MappingMode �� 
StartPoint � Color � Offset J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5
      " ��6   .�5      ��  � �� 5      �� 5      " ��6   .R�5      � .+�5   	   F� $
 path��6   ����������@ � � �8 � S��s��%  �?�����\���@�����!  @������� ��������s �8 �8 �8������@ �8���r@ �8 � �� � ��� Q � ��!  @S � ��\���@��r@��%  �?�����@ � 	$��0q�6  $
	 Fill=�6)  ���	#FFDEDEDE��5   
   �� 5      $
 0.506,1.258&�6   $ RelativeToBoundingBox=�66   $ 0.506,-0.373&�6Z   .��5      � $ White��6   $ 0.239Q�6'   � 5      $ White��6   $ 0.819Q�6'   � 5      $ 	#FF6B9AB2��6   $ 0.534Q�6+   5      5   
   �� 5   	   #��z��6   ��. # z 6x   #��z��6�   $��View Report��6�   5   	    5      P� 5   	    �@J�	IsFocused . 6&   P� 5   	    �@��IsDefaulted . 6(   P� 5   	    �@J�IsMouseOver . . �5   
   �� $
 path��6!    � �� �	#FFFBFBFB63   5   
   P� 5    	    � �� . . �5!   
   �� $
 path��6!    � �� �	#FFF9F7F763   5"   
   P� 5#   	    � {� .  6&   5%      5'      5(      5)      .��5+      � -   5         �Name$ 
LayoutRoot��5+       � RowDefinitions 5,      �� 5-      $��41.106 �6   �� 5.      $��55 �6   �� 5/      .+�51      �� 
���   �$��0��6   $��3��61   ��52      �� 53      $
 0.5,1&�6   $ 0.5,0&�6+   .��54      � $ Black��6   $ 1Q�6"   � 55      $ White��6   $ 0.228Q�6"   � 56      $ 	#FFC9CACA��6   $ 0Q�6&   57      59      �� 5:      -   5         ��Name$ Lablel_From��5:   
   $��Top :��6   $
��Left=�6/   $��22,0,0,0q�6J   
�������$��55.51��6o    � Cursor$ UpArrow��6}   $��16(�6�   $
��Bold"�6�    J� Effect 5;      3  -System.Windows.Media.Effects.DropShadowEffect  5<         
BlurRadius$ 10Q�6   5>      �� 5?      -   5        $ Lablel_From_Copy��5?   
   $��Date :��6$   $��Right=�65   $��	0,0,186,0q�6Q   
�������$��55.304��6w   $ UpArrow��6�   $��33.052��6�   $��Center=�6�   $��16(�6�   $
��Bold"�6�    5@        5A      $ 10Q�6   5C      �� 5D      -   5         ��Name$ ComboBox_datee��5D      $��
0,10,66,10q�6%    �� 
IsEditable . ���	#FF2D77DA$��1q�6c    �� 
IsReadOnly .  �� SelectedIndex$ 8��6�   $��Right=�6�   $	��120��6�   $��Center=�6�   $
 Date��6�   .@�5E      �� $��Today��6   �� 5F      $��Last 2 days��6   �� 5G      $��Last 3 days��6   �� 5H      $��Last 4 days��6   �� 5I      $��Last 5 days��6   �� 5J      $��Last 6 days��6   �� 5K      $��	Last week��6   �� 5L      $��
Last month��6   �� 5M      $	��All��6   5N      �� 5O      -   5        $ Lablel_From_Copy1��5O   
   $��Most Visited :��6%   $
��Left=�6>   $��8,8,0,0q�6Y   
���   �$	��101��6}   $ UpArrow��6�   $��24��6�   $	��Top=�6�   $��2��6�    5P        5Q      $ 10Q�6   5S      �� 5T      -   5         ��Name$ Button_view_report��5T      $�� ��6'   $��0q�62   #���   6=   $��1��6d   $��Tahoma)�6q   $��Center=�6�   $��98��6�   $ View Report��6�   $��16(�6�   $��40��6�   $��Bottom=�6�   �� 5U      -   5         ��Name$ TextBox__Top_N��5U      $
��Left=�6$   $��68,0,0,0q�6?     �� TextWrapping$
  Wrap=�6Q   $��80��6e   $��Center=�6p   $��13.333(�6�   $  Number Of Top Visited Page��6�   7  1System.Windows.Forms.Integration.WindowsFormsHost  5V      -	   5        !  Name$"! WindowsFormsHost_Most_Visted��5V      $��15,36,15,15q�6;   $��2��6P   z�5W      V� 5X      .~�5Y      �� �� 5Z      �� 5[      T� 5\      5]      5_      5`      5a      