   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5       SWP_2011   SWP_2011.Download   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     5      @d2http://schemas.microsoft.com/expression/blend/2008     6n   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   -   5          �Name$  Window��5       � Title$ Download��5      $	��464��5      $	��326��6    � AllowsTransparency .  � WindowStyle$
 None=�65   ��6H   Z�  � 	Resources 5
         ButtonStyle4 �� 
TargetType �� Property �� Value �� 
TargetType+   %Microsoft.Windows.Themes.ButtonChrome	  Name
 J� IsMouseOver   RenderMouseOver   RenderPressed �� IsDefaulted   RenderDefaulted J� SnapsToDevicePixels   BorderBrush   
Background �� EndPoint �� 
StartPoint � Color � Offset J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   RenderingBias   
BlurRadius �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5      " ��6   .�5      ��  � ��$ 1q�6'   �� 5       � ��# � ��6"   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�60   �� 5       � ��$ 1q�6   �� 5       � �� 5      �� 5      " ��6   .R�5        $	 Chrome��6.   # z
 6>   # z��6n   # z 6�    .  �	#FF181818 5   	   �� 5   
   $ 0.5,1&�6   $ 0.5,0&�6/   .��5      � $ 	#FFE0ADAD��6   $ 0Q�6*   � 5      $ 	#FFC03737��6   $ 1Q�6*   5      ._�5   	   �� #��z��6   #��z��6]   ��. # z 6�   #��z��6�    5   
     5      $ 0Q�6   $ Quality=�6,   $ 2Q�6D   5   
   5    	    5!      P� 5"   	    �@J�IsMouseOver . . �5#   
   �� $ Chrome��6'    �@ 
Background 5$      �� 5%      $ 0.5,1&�6    $ 0.5,0&�61   .��5&      � $ 	#FFE0ADAD��6   $ 0Q�6,   � 5'      $ 	#FFC80000��6   $ 0.843Q�6,   5(      5*      5+   
   P� 5,   	    �@d�	IsChecked$
 trueY�63   . �5-   
   �� $ Chrome��6'    �@ 
Background 5.      �� 5/      $ 0.5,1&�6    $ 0.5,0&�61   .��50      � $ 	#FFE0ADAD��6   $ 0Q�6,   � 51      $ 	#FFC03737��6   $ 1Q�6,   � 52      $ 	#FF2B0E0E��6   $ 0.502Q�6,   53      55      56   
   P� 57   	    � {� .  . �58   
   ��  � �� �#ADADAD6'   59   
   5;      5=      5>      5?      .��5A      � -   5         �Name$ 
LayoutRoot��5A      .+�5B      �� 
���   �$��3��6    �� RadiusX$ 11��61     �� RadiusY$  11��6>   ! J� Opacity$	! 0.7Q�6K   $��0q�6Y   ��5C      �� 5D      $ 0.5,1&�6   " � MappingMode$" RelativeToBoundingBox=�6+   $ 0.5,0&�6O   .��5E      � $ 	#FFC2C2C2��6   $ 0.108Q�6&   � 5F      $ White��6   $ 0.048Q�6"   � 5G      $ 	#FF726D6D��6   � 5H      $ White��6   $ 0.064Q�6"   5I      5K      �� 5L      $��8,43.325,8,40q�6   
���   �$��0��64   
�������$  7.316��6U   $ 7.316��6e   �� 5M      -   5        # ��Name$# Button_Close��5M      $��X��6!   $��0,11.718,18.292,0q�6-   $��Right=�6H   $��28.59��6d   #���   6r   
�������$��InvisibleKiller)�6�   $��24.607��6�   $	��Top=�6�   $ � ToolTip$$ Close��6  �� 5N      -   5        $# Button_Cancel��5N      $��Cancel��6"   $��0,0,21.578,8.506q�63   $��Right=�6M   $��75��6i   $��25.004��6t   $��Bottom=�6�   $$ Cancel Download��6�   �� 5O      -   5        $# Button_Download��5O      $��Download��6$   $��278.862,0,110.138,8.506q�67   % J� RenderTransformOrigin$% 0.5,0.5&�6X   $��75��6x   $��25.004��6�   $��Bottom=�6�   $$ Stare Download��6�   �� 5P      -   5        & ��Name$& 	Label_url��5P   
   $	��URL��6   $
��Left=�6+   $��	14,47,0,0q�6F   $	��Top=�6Y   $��13.333(�6q   ���	#000C43EB���	#FF1331DC6�   F� 5Q      ������#�A�����A	���	#FFF4F4F5$��1��67   $��51.413,60.04,18.292,0q�6B   ' �� Stretch$
' Fill=�6a   
���   �$	��Top=�6   �� 5R      -   5        ( ��Name$( TextBox_url��5R      ) �� TextWrapping$
) Wrap=�6!   $	��Top=�65   $��16,83,16.292,0q�6M   $��24.96��6e   $��13.333(�6t   �� 5S      -   5        $& 	Label_loc��5S   
   $��Location��6   $
��Left=�60   $��
14,126,0,0q�6K   $��13.333(�6_   ���	#000C43EB���	#FF1331DC$��28.734��6�   $	��Top=�6�   F� 5T      ������#�A�����A	���	#FFF4F4F5$��1��67   $��76.413,139.04,18.292,0q�6B   $
' Fill=�6b   
���   �$	��Top=�6�   �� 5U      -	   5        $( TextBox_loc��5U      $
) Wrap=�6!   $��46,0,38.292,133.04q�65   $��13.333(�6Q   $��24.96��6c   $��Bottom=�6r   * �� 
IsReadOnly* . 6�   �� 5V   
   -
   5        $& 	Label_pro��5V      $��Progress��6#   $
��Left=�66   $��14,0,0,87.266q�6Q   $��13.333(�6h   ���	#000C43EB���	#FF1331DC$��Bottom=�6�   F� 5W      ������#�A�����A	���	#FFF4F4F5$��76.413,0,18.292,100.96q�67   $
' Fill=�6W   
���   �$��1��6u   $��Bottom=�6�   � 5X      -   5        $��ProgressBar_download��5X   K   $��
21,0,22,56q�6   $��20��6$   $��Bottom=�60   $$ 	Progress ��6g   �� 5Y      -   5        $& Lablel_Name��5Y   
   $��Download��6   $
��Left=�62   $��18.778,9.916,0,0q�6M   
���   �$	��100��6z   + � Cursor$+ UpArrow��6�   $��16(�6�   $
��Bold"�6�   $��28.341��6�   $	��Top=�6�    5Z        5[      $ 10Q�6   5]      5^      5_      