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
   �� 59      $��65 �6   6*   �� 5:      6   .+�5?   
   �� $��0��6   $	 40��6   
�������._�5@      � .+�5A      ]� $��11q�6   .+�5C      �� -   5         ��Name$ tbl_TenBang��5C       $��	Nhan Vien��5D      $��22(�5E      $��Cascadia Mono)�5F      ���#565656$
��Left=�5H      $��Center=�5I      5J      �� 5N      ���#C9C9C9$��1q�63   $	 20��6G   $��Right=�6Y   $	��230��6p   ._�5O      �� .+�5Q      �� -   5        $" tbl_TenNhanVienThanhTiemKiem��5Q   (   $��Tên Tài Khoản��6N   $��15(�5R      $��Cascadia Mono)�5S      ���#565656$��Center=�5U      $	��Top=�5V      $��0 8 0 0q�5W      5X      �� 5Z      -   5        $  tbl_IdNhanVienThanhTimKiem��5Z   (   $��#idnv��6L   $��14(�6Y   $��Cascadia Mono)�6g   ���#C9C9C9$��Center=�6�   6�   5[      5\      � 5_      $��Right=�6   $��85��62   .+�5`      A� $��40��6"   $��40��6.   ���#C9C9C9$��Center=�6H   A� 5a      $��38��6"   $��38��6.   
�������$��Center=�6F   $��Center=�6c   5b      � 5e      5t      5u      5v      5w      5x      5y      