   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5       SWP_2011   SWP_2011.Feedback1   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     5      @d2http://schemas.microsoft.com/expression/blend/2008     6q   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�     � Title$  	Feedback1��5      $	��400��6   $	��484��6$    � AllowsTransparency .  � WindowStyle$
 None=�6J   ��6]   Z� ��6s   Z�  � 	Resources 5         ButtonStyle4 �� 
TargetType �� Property �� Value �� 
TargetType+   %Microsoft.Windows.Themes.ButtonChrome  Name	 J� IsMouseOver
   RenderMouseOver   RenderPressed �� IsDefaulted   RenderDefaulted J� SnapsToDevicePixels   BorderBrush   
Background �� EndPoint �� 
StartPoint � Color � Offset J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   RenderingBias   
BlurRadius �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5      " ��6   .�5      ��  � ��$ 1q�6'   �� 5       � ��# � ��6"   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�60   �� 5       � ��$ 1q�6   �� 5       � �� 5      �� 5      " ��6   .R�5        $ Chrome��6.   #
 z	 6>   # z��6n   # z 6�    .  �	#FF181818 5   	   �� 5   
   $ 0.5,1&�6   $ 0.5,0&�6/   .��5      � $ 	#FFE0ADAD��6   $ 0Q�6*   � 5      $ 	#FFC03737��6   $ 1Q�6*   5      ._�5   	   �� #��z��6   #��z��6]   ��. # z 6�   #��z��6�    5   
     5      $ 0Q�6   $ Quality=�6,   $ 2Q�6D   5   
   5   	    5       P� 5!   	    �@J�IsMouseOver . . �5"   
   �� $ Chrome��6'    �@ 
Background 5#      �� 5$      $ 0.5,1&�6    $ 0.5,0&�61   .��5%      � $ 	#FFE0ADAD��6   $ 0Q�6,   � 5&      $ 	#FFC80000��6   $ 0.843Q�6,   5'      5)      5*   
   P� 5+   	    �@d�	IsChecked$
 trueY�63   . �5,   
   �� $ Chrome��6'    �@ 
Background 5-      �� 5.      $ 0.5,1&�6    $ 0.5,0&�61   .��5/      � $ 	#FFE0ADAD��6   $ 0Q�6,   � 50      $ 	#FFC03737��6   $ 1Q�6,   � 51      $ 	#FF2B0E0E��6   $ 0.502Q�6,   52      54      55   
   P� 56   	    � {� .  . �57   
   ��  � �� �#ADADAD6'   58   
   5:      5<      5=      5>      .��5?      � $��0q�6    � RowDefinitions 5@      �� 5A      $��40 �6   �� 5B      .+�5D      �� 
���   �$��3��6    �� RadiusX$ 11��61    �� RadiusY$ 11��6>     J� Opacity$	  0.7Q�6K   $��0q�6Y   $��2��6d   ��5E      �� 5F      $ 0.5,1&�6   ! � MappingMode$! RelativeToBoundingBox=�6+   $ 0.5,0&�6O   .��5G      � $ 	#FFC2C2C2��6   $ 0.108Q�6&   � 5H      $ White��6   $ 0.048Q�6"   � 5I      $ 	#FF726D6D��6   � 5J      $ White��6   $ 0.064Q�6"   5K      5M      �� 5N      -   5        " ��Name$" 
Rectangle1��5N   �   $��8,-2.872,8,0q�6   
���   �$��0��63   
�������$ 7.316��6T   $ 7.316��6d   $��321.223��6t   $	��Top=�6�   $��1��6�   �� 5O      -   5        # ��Name$# Button_Close��5O      $��X��6!   $��0,7.795,12,8.5q�6-   $��Right=�6E   $��25.998��6a   #���   6p   
�������$��InvisibleKiller)�6�   $ � ToolTip$$ Close��6  �� 5P      -   5        % ��Name$% Lablel_title��5P   
   $��Feedback��6    $
��Left=�63   $��9.778,1.916,0,2.872q�6N   
���   �$	��121��6~   & � Cursor$& UpArrow��6�   $��16(�6�   $
��Bold"�6�    5Q        5R      $ 10Q�6   5T      �� 5U      -   5        $% Lablel_Email��5U   
   $��Email :��6    $
��Left=�62   $��19.778,53.959,0,0q�6M   
���   �$��55��6{   $& UpArrow��6�   $��24��6�   $	��Top=�6�   $��1��6�    5V        5W      $ 10Q�6   5Y      �� 5Z      -   5        $% Lablel_Name��5Z   
   $
��Name��6   $
��Left=�6.   $��19.778,19.959,0,0q�6I   
���   �$��55��6w   $& UpArrow��6�   $��24��6�   $	��Top=�6�   $��1��6�    5[        5\      $ 10Q�6   5^      �� 5_      -   5        $% Lablel_Note��5_   
   $��Note :��6   $
��Left=�60   $��19.778,92.959,0,0q�6K   
���   �$��55��6y   $& UpArrow��6�   $��1��6�   $��24��6�   $	��Top=�6�    5`        5a      $ 10Q�6   5c      �� 5d      -   5        ' ��Name$' TextBox_Body��5d      $!��78.778,92.959,24.547,49.945q�6"   $��1��6G   ( �� TextWrapping$
( Wrap=�6T   ") �� VerticalScrollBarVisibility$) Visible=�6h   $$ Message Text��6�   �� 5e      -   5        $# Button_Cancel��5e      $��Cancel��6"   $��0,0,10,8q�63   $��1��6E   $��Right=�6R   $��75��6n   $��20.804��6y   $��Bottom=�6�   $$ Cancel��6�   �� 5f      -	   5        $# 	Button_Ok��5f      $
��Send��6   $��306.431,0,102.569,8q�6-   * J� RenderTransformOrigin$* 0.5,0.5&�6J   $��75��6j   $��1��6u   $��20.804��6�   $��Bottom=�6�   $
$ Send��6�   �� 5g      -
   5        $' TextBox_email��5g      $��78.778,53.959,24.547,0q�6#   $
( Wrap=�6C   $�� ��6W   $	��Top=�6_   $��24��6w   $��1��6�   $$ Sender Email��6�   �� 5h      -   5        $' TextBox_Name��5h      $��74.778,19.959,24.547,0q�6"   $
( Wrap=�6B   $�� ��6V   $	��Top=�6^   $��24��6v   $��1��6�   $$ Sender Name��6�   5i      5j      