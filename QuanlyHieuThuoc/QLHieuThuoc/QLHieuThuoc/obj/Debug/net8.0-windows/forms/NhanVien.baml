   M S B A M L   `   `   `  ����F  BQLHieuThuoc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QLHieuThuoc.formsQLHieuThuoc.forms  5           QLHieuThuoc.forms.NhanVien   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:QLHieuThuoc.forms     5        � 	Resources  5	         TextBox.Static.Border �� Color  TextBox.MouseOver.Border  TextBox.Focus.Border  TimKiem �� 
TargetType �� Property!  System.Windows.SystemColors   WindowBrushKey �� Value   ControlTextBrushKey-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name	 �� CornerRadius
 �� Padding J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value)   "InactiveSelectionHighlightBrushKey��%�  &	        &	 #     &	 F     &	 i     7   7  7  �� 5
   
   $ 	#FFABAdB3��68   �� 5   
   $ 	#FF7EB4EA��6;   �� 5   
   $ 	#FF569DE5��67   �� 5   
   " ��6    .�5      ��  � ��# �  6+   �� 5       � ��8   6,   �� 5       � ��# �  6+   �� 5       � ��$ 0q�60   �� 5       �@ TabNavigation$
 None=�6A   �� 5       � ��$
 Left=�6;   �� 5       �@�FocusVisualStyle 61   Z� �� 5       �@J�	AllowDrop$
 true��6*   �� 5       �@��PanningMode$ VerticalFirst=�69   �� 5       �@��IsFlicksEnabled$ False��67   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   $	 25��61   $
 5q�6C   #��z��6O   #��z��6y   #��z��6�   $
 True��6�   ._�5      �� $ PART_ContentHost��6+   $|�false��6E   $��Hidden=�6W   $��Hidden=�6~   5       5      P� 5       � {�$ false��6;   . �5    "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5!      P� 5"       �@J�IsMouseOver$
 true��6=   . �5#   "   �� $ border��6@   8   � ��6T   5$      P� 5%       �@J�IsKeyboardFocused$
 true��6C   . �5&   "   �� $ border��6@   8   � ��6T   5'      5)      5+       5,      ]� 5-       5.      �� 5/      + �@��#IsInactiveSelectionHighlightEnabled$
 true��6S   �� 50       �@��IsSelectionActive$ false��6A   ./�52      ��  �@��SelectionBrush# �  67   53      55      56      .��57      � ���#F7F7F7 � RowDefinitions 58   
   �� 59      $��80 �6   6*   �� 5:      6   .+�5?   
   �� $��0��6   $	 40��6   
�������._�5@      � .+�5A      ]� $��11q�6   .+�5C      �� $��  Nhân Viên��6    $��20(�5D      $��Cascadia Mono)�5E      ���#565656$
��Left=�5G      $��Center=�5H      5I      �� 5M      ���#C9C9C9$��1q�63   $	 40��6G   $��Right=�6Y   $	��230��6p   ._�5N      �� .+�5P      �� $��Tên Tài Khoản��6(   $��18(�5Q   $   $��Cascadia Mono)�5R   $   ���#565656$��Center=�5T   $   $	��Top=�5U   $   $��0 8 0 0q�5V   $   5W      �� 5Y      $��#idnv��6(   $��18(�65   $��Cascadia Mono)�6C   ���#C9C9C9$��Center=�6t   6�   5Z      5[      � 5^      $��Right=�6   $��85��62   .+�5_      A� $��58��6"   $��58��6.   ���#C9C9C9$��Center=�6H   A� 5`      $��56��6"   $��56��6.   
�������$��Center=�6F   $��Center=�6c   5a      � 5d      .+�5e      �� ���#C9C9C9$��1q�67   $	 40��6K   $	��379��6]   $��Right=�6i   ._�5f      � .+�5g   "   �� -   5         ��Name$ 
tb_TimKiem��5g   *   #���  5h   *   $��Right=�5i   *   $��Center=�5j   *   $��Tìm Kiếm...��5k   *   $��Cascadia Mono)�5l   *   $��22(�5m   *   ���#C9C9C9$	��320��5o   *   .��66   5p   #   5q      5r      5s      5t      5u      5v      5w      5x      