   M S B A M L   `   `   `  ����  SWP_2011     SWP_2011.Dowinloads_Report   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6?   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6�   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6�   -   5          �Name$  Window_Down��5      $	��640��6   $	��480��6#    � Title$ File Download��6F    � ToolTip$ File Download��6\   ��60   Z�  � 	Resources 5         ButtonStyle4 �� 
TargetType �� Property �� Value �� 
TargetType F�Name	 �� Stretch
 �� EndPoint � MappingMode �� 
StartPoint � Color � Offset J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName  Storyboard_Algader �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value R� KeyTime  System.Windows.Visibility   Visible R� Value��%;  &	        &	 y    �� 5      " ��6   .�5	      ��  � �� 5
      �� 5      " ��6   .R�5      � .+�5   	   F� $
 path��6   ����������@ � � �8 � S��s��%  �?�����\���@�����!  @������� ��������s �8 �8 �8������@ �8���r@ �8 � �� � ��� Q � ��!  @S � ��\���@��r@��%  �?�����@ � 	$��0q�6  $
	 Fill=�6)  ���	#FFDEDEDE��5   
   �� 5      $
 0.506,1.258&�6   $ RelativeToBoundingBox=�66   $ 0.506,-0.373&�6Z   .��5      � $ White��6   $ 0.239Q�6'   � 5      $ White��6   $ 0.819Q�6'   � 5      $ 	#FF6B9AB2��6   $ 0.534Q�6+   5      5   
   �� 5   	   #��z��6   ��. # z 6x   #��z��6�   $��View Report��6�   5   	    5      P� 5   	    �@J�	IsFocused . 6&   P� 5   	    �@��IsDefaulted . 6(   P� 5   	    �@J�IsMouseOver . . �5   
   �� $
 path��6!    � �� �	#FFFBFBFB63   5   
   P� 5   	    � �� . . �5   
   �� $
 path��6!    � �� �	#FFF9F7F763   5    
   P� 5!   	    � {� .  6&   5#      5%      5&      �� 5'      .��5(      U� $ (UIElement.Opacity)�6#   $ WindowsFormsHost_Data��6S   .\�5)        $ 0��6   $ 0Q�6'     5*      $ 0:0:1��6   $ 1Q�6+   5+      T� 5,      $ (UIElement.Visibility)�6#   $ WindowsFormsHost_Data��6V   ..�5-      i� $ 0��6   # Z 6)   i� 5.      $ 0:0:1��6   # Z 6-   5/      U� 50      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6#   $ WindowsFormsHost_Data��6�   .\�51        $ 0��6   $ 1Q�6'     52      $ 0:0:0.5��6   $
 0.55Q�6-     53      $ 0:0:1��6   $ 1Q�6+   54      U� 55      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6#   $ WindowsFormsHost_Data��6�   .\�56        $ 0��6   $ 1Q�6'     57      $ 0:0:0.5��6   $	 0.6Q�6-     58      $ 0:0:1��6   $ 1Q�6+   59      5:      5;       � Triggers 5<      :� 5=       :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5>      �� #��[ 6   5?      .��5B      � -   5         �Name$ 
LayoutRoot��5B      
������� � RowDefinitions 5C      �� 5D      $��41.99 �6   �� 5E      $��55 �6   �� 5F      .+�5H      �� 
���   �$��0��6   $��3��61   ��5I      �� 5J      $
 0.5,1&�6   $ 0.5,0&�6+   .��5K      � $ Black��6   $ 1Q�6"   � 5L      $ White��6   $ 0.228Q�6"   � 5M      $ 	#FFC9CACA��6   $ 0Q�6&   5N      5P      �� 5Q      -   5         ��Name$ Lablel_From��5Q   
   $��	Sort By :��6   $
��Left=�63   $��10,0,0,0q�6N   
�������$��67��6s     � Cursor$  UpArrow��6~   $��14.667(�6�   $
��Bold"�6�   $��Center=�6�   ! J� Effect! 5R      3  -System.Windows.Media.Effects.DropShadowEffect  5S      "   
BlurRadius$" 10Q�6   5U      �� 5V      -   5        # ��Name$# ComboBox_Storby��5V      $��77,11.03,0,9q�6&   $ �� 
IsEditable$ . ���	#FF2D77DA$��1q�6f   % �� 
IsReadOnly% . & �� SelectedIndex$& 0��6�   $	��120��6�   $
��Left=�6�   $ Stor By Type��6�   .@�5W      �� $
��Date��6   �� 5X      $
��Type��6   5Y      �� 5Z      -   5        $ Lablel_From_Copy��5Z   
   $��Date :��6$   $��Right=�65   $��	0,0,199,0q�6Q   
�������$��54��6w   $  UpArrow��6�   $��14.667(�6�   $
��Bold"�6�   $��Center=�6�   ! 5[        5\      $" 10Q�6   5^      �� 5_      -   5        $# ComboBox_Date��5_      $��0,12.03,81,8q�6$   $ . ���	#FF2D77DA$��1q�6d   % . $& 8��6�   $��Right=�6�   $	��120��6�   $
 Date��6�   .@�5`      �� $��Today��6   �� 5a      $��Last 2 days��6   �� 5b      $��Last 3 days��6   �� 5c      $��Last 4 days��6   �� 5d      $��Last 5 days��6   �� 5e      $��Last 6 days��6   �� 5f      $��	Last week��6   �� 5g      $��
Last month��6   �� 5h      $	��All��6   5i      �� 5j      -   5        $ Lablel_From_Copy1��5j   
   $��Download Files :��6%   $
��Left=�6@   $��18,4.791,0,0q�6[   
���   �$	��101��6�   $  UpArrow��6�   $��2��6�   $��27��6�   $	��Top=�6�   ! 5k        5l      $" 10Q�6   5n      �� 5o      -   5        ' ��Name$' Button_view_report_down��5o      $�� ��6,   $��0q�67   #���   6B   $��1��6i   $��Tahoma)�6v   $��Center=�6�   $��98��6�   $ View Report��6�   $��16(�6�   $��40��6�   $��Bottom=�6�   7  1System.Windows.Forms.Integration.WindowsFormsHost  5p      -	   5        (  Name$( WindowsFormsHost_Data��5p      $��15,35.791,15,15q�64   $��2��6M   $y�Hidden=�6Z   ) J� RenderTransformOrigin$) 0.5,0.5&�6n   z�5q      V� 5r      .~�5s      �� �� 5t      �� 5u      T� 5v      5w      .  (System.Windows.Interactivity.Interaction*   Triggers* 5y      /  )System.Windows.Interactivity.EventTrigger  5z      +   	EventName$+ 
MouseEnter��6   3  -System.Windows.Interactivity.EventTriggerBase,   SourceObject, 6,   �� - �� ElementName$- Button_view_report_down��.  (System.Windows.Interactivity.TriggerBase.   Actions.. 5{      F	  @Microsoft.Expression.Interactivity.Media.ControlStoryboardAction	  5|      5~      5      5�      