   M S B A M L   `   `   `  ����F  BQLHieuThuoc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:QLHieuThuoc.forms.NhanVienQLHieuThuoc.forms.NhanVien  5      )    #QLHieuThuoc.forms.NhanVien.NhanVien   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:QLHieuThuoc.forms.NhanVien     5        � 	Resources  5	         TextBox.Static.Border �� Color  TextBox.MouseOver.Border  TextBox.Focus.Border  TimKiem �� 
TargetType �� Property!  System.Windows.SystemColors   WindowBrushKey �� Value   ControlTextBrushKey-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name	 �� CornerRadius
 �� Padding J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value)   "InactiveSelectionHighlightBrushKey  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background 	 Button.Disabled.Border 
 Button.Disabled.Foreground  ButtonTemplate1 ��Name   HighlightBrushKey��%  &	        &	 #     &	 F     &	 i     7   7  7  &	 �    &	 �    &	     &	 &    &	 I    &		 l    &	
 �    &	 �    7  7 	 7 
 �� 5
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
 true��6S   �� 50       �@��IsSelectionActive$ false��6A   ./�52      ��  �@��SelectionBrush# �  67   53      55      �� 56   
   $ 	#FFBEE6FD��6>   �� 57   
   $ 	#FF3C7FB1��6:   �� 58   
   $ 	#FFC4E5F6��6<   �� 59   
   $ 	#FF2C628B��68   �� 5:   
   $ 	#FFF4F4F4��6=   �� 5;   
   $ 	#FFADB2B5��69   �� 5<   
   $ 	#FF838383��6=   �� 5=   
   " ��62   .R�5>      �� $ border��6   $	 15��6%   #��z��67   #��z��6a   $��0q�6�   $
 true��6�   ._�5?      �� $ contentPresenter��6#   $|�False��6=   #��z��6O   #��z��6�   $
��True��6�   # z 6�   #��z��6  5@       5A      P� 5B       �@��IsDefaulted$
 true��68   . �5C      �� $ border��64   # �  6H    � ��5D      P� 5E       �@J�IsMouseOver$
 true��61   . �5F      �� $ border��63    � �� �#FF9A9A6G   �� 5G      $ border��64    � �� �#E2895A6H   5H      P� 5I       � ��$
 true��6/   . �5J      �� $ border��63    � �� �#E2895A6G   �� 5K      $ border��64    � �� �#E2895A6H   5L      P� 5M       � {�$ false��6/   . �5N      �� $ border��63   8    � ��6G   �� 5O      $ border��64   8   � ��6H   �� 5P      $ contentPresenter��6?   8   � ��6]   5Q      5S      5T      .��5U      � ���#F7F7F7 � RowDefinitions 5V   
   �� 5W      $��65 �6   6*   �� 5X      $��20 �6   6*   �� 5Y      $��50 �6   6*   �� 5Z      $��10 �6   6*   �� 5[      6   .+�5`   
   �� $��0��6   $	 40��6   
�������._�5a      � .+�5b      ]� $��11q�6   .+�5d      �� -   5         ��Name$ tbl_TenBang��5d       $��	Nhan Vien��5e      $��22(�5f      $��Cascadia Mono)�5g      ���#565656$
��Left=�5i      $��Center=�5j      5k      �� 5o      ���#C9C9C9$��1q�63   $	 20��6G   $��Right=�6Y   $	��230��6p   ._�5p      �� .+�5r      �� -   5        $" tbl_TenNhanVienThanhTiemKiem��5r   (   $��Tên Tài Khoản��6N   $��15(�5s      $��Cascadia Mono)�5t      ���#565656$��Center=�5v      $	��Top=�5w      $��0 8 0 0q�5x      5y      �� 5{      -   5        $  tbl_IdNhanVienThanhTimKiem��5{   (   $��#idnv��6L   $��14(�6Y   $��Cascadia Mono)�6g   ���#C9C9C9$��Center=�6�   6�   5|      5}      � 5�      $��Right=�6   $��85��62   .+�5�      A� $��40��6"   $��40��6.   ���#C9C9C9$��Center=�6H   A� 5�      $��38��6"   $��38��6.   
�������$��Center=�6F   $��Center=�6c   5�      � 5�      5�      5�      5�      5�      � 5�   
   $��2��6     5�      ��%x  '��       '�� �     �� 5�      " ��6   .�5�      ��  � ��$ Cascadia Mono)�63   �� 5�       � ��$ 20(�61   �� 5�       � �� �#56565663   �� 5�       � ��$ Center=�6:   �� 5�       � ��$ Center=�6<   5�      �� 5�      " ��6   .�5�      ��  � ��$	 270��6.   �� 5�       � �� �#EEB99D63   5�      5�       � ColumnDefinitions 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� -   5         ��Name$ 
bt_LichLam��5�   B   #���  6   $��Right=�6V   ��5�      �� 5�      -   5        $ tbl_bt_LichLam��5�       
Lich Lam6B   5�      �� 5�      -   5        $ bt_ThoiGian��5�   B   #���  6   $��1��6W   $��Center=�6g   ��5�      �� 5�      -   5        $ tbl_bt_ThoiGian��5�       Quan Ly Thoi Gian6L   5�      �� 5�      -   5        $ bt_Luong��5�   B   #���  6   $��2��6T   $
��Left=�6d   ��5�      �� 5�      -	   5        $ tbl_bt_Luong��5�       
Bang Luong6B   5�      5�      � 5�   
   -
   5         �Name$ Grid_NoiDung��5�      $��4��6%   64   5�      5�      