   M S B A M L   `   `   `  ����F  BQLHieuThuoc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:QLHieuThuoc.forms.CaiDatQLHieuThuoc.forms.CaiDat  5   	   )    #QLHieuThuoc.forms.CaiDat.DoiMatKhau   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:QLHieuThuoc.forms.CaiDat     5   	     � WindowStyle$
  None=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ 
DoiMatKhau��5
   	   $	��320��6   $	��300��6)    � 	Resources 5         TextBox.Static.Border �� Color  TextBox.MouseOver.Border  TextBox.Focus.Border  PasswordBoxStyle1 �� 
TargetType �� Property �� Value!  System.Windows.SystemColors   WindowBrushKey	   ControlTextBrushKey-  'System.Windows.Input.KeyboardNavigation
 �� 
TargetType ��Name J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value)   "InactiveSelectionHighlightBrushKey  FocusVisual �� StrokeDashArray  Button.Static.Background  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border 	 Button.Pressed.Background 
 Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  ButtonStyle1 �� CornerRadius ��Name   HighlightBrushKey��%�  &	        &	 #     &	 F     &	 i     7   7  7  &	 �    &	 �    &	 �    &	 �    &	 �    &		     &	
 7    &	 Z    &	 }    &	 �    &	 �    7  7  7  7  7  7 	 7 
 7  7  7  �� 5   
   $ 	#FFABAdB3��68   �� 5   
   $ 	#FF7EB4EA��6;   �� 5   
   $ 	#FF569DE5��67   �� 5   
   " G�6*   .�5      ��  �@G�PasswordChar$	 ●��6-   �� 5       � ��# �  6+   �� 5       � ��8   6,   �� 5       � ��# � 	 6+   �� 5       � ��$ 1q�60   �� 5       �@ TabNavigation$
 None=�6A   �� 5       � ��$
 Left=�6;   �� 5       �@�FocusVisualStyle 61   Z� �� 5       �@J�	AllowDrop$
 true��6*   �� 5       �@��PanningMode$ VerticalFirst=�69   �� 5       �@��IsFlicksEnabled$ False��67   �� 5       � �� 5      �� 5      "
 G�6&   .R�5      �� $ border��6!   #��z��61   #��z��6[   $��0q�6�   $
 True��6�   ._�5      �� $ PART_ContentHost��6+   $|�false��6E   $��Hidden=�6W   $��Hidden=�6~   5        5!      P� 5"       � {�$ false��6;   . �5#   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5$      P� 5%       �@J�IsMouseOver$
 true��6=   . �5&   "   �� $ border��6@   8   � ��6T   5'      P� 5(       �@J�IsKeyboardFocused$
 true��6C   . �5)   "   �� $ border��6@   8   � ��6T   5*      5,      5.       5/      ]� 50       51      �� 52      + �@G�#IsInactiveSelectionHighlightEnabled$
 true��6S   �� 53       �@G�IsSelectionActive$ false��6A   ./�55      ��  �@G�SelectionBrush# �  67   56      58      �� 59   
   .�5:      ��  � �� 5;      �� 5<      .R�5=      �� $��2q�6$   $	 1 2R�6/   #��� 	 6E   $
 true��6�   $��1��6�   5>      5@      5A      �� 5B   
   $ 	#FFDDDDDD��6;   �� 5C   
   $ 	#FF707070��67   �� 5D   
   $ 	#FFBEE6FD��6>   �� 5E   
   $ 	#FF3C7FB1��6:   �� 5F   
   $ 	#FFC4E5F6��6<   �� 5G   
   $ 	#FF2C628B��68   �� 5H   
   $ 	#FFF4F4F4��6=   �� 5I   
   $ 	#FFADB2B5��69   �� 5J   
   $ 	#FF838383��6=   �� 5K   
   " ��6%   .�5L      ��  �@�FocusVisualStyle8   61   �� 5M       � ��8  6+   �� 5N       � ��8  6,   �� 5O       � ��# � 	 6+   �� 5P       � ��$ 0q�60   �� 5Q       � ��$ Center=�6;   �� 5R       � ��$ Center=�69   �� 5S       � ��$ 1q�6(   �� 5T       � �� 5U      �� 5V      "
 ��6&   .R�5W      �� $ border��6!   $ 20��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5X      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5Y       5Z      P� 5[       �@��IsDefaulted$
 true��6=   . �5\   "   �� $ border��6@   # �  6T    � ��5]      P� 5^       �@J�IsMouseOver$
 true��6=   . �5_   "   �� $ border��6?   8   � ��6S   �� 5`   "   $ border��6@   8   � ��6T   5a      P� 5b       � ��$
 true��6;   . �5c   "   �� $ border��6?   8   � ��6S   �� 5d   "   $ border��6@   8   � ��6T   5e      P� 5f       � {�$ false��6;   . �5g   "   �� $ border��6?   8   � ��6S   �� 5h   "   $ border��6@   8   � ��6T   �� 5i   "   $ contentPresenter��6K   8 	  � ��6i   5j      5l      5n      5o      5p      .��5q      � ���#E2895A 5r   
   ��%V  '��       '�� �     �� 5s      " ��6   .�5t      ��  � �� �#5656566/   �� 5u       � ��$ Cascadia Mono)�6/   �� 5v       � ��$ 13(�6-   5w      �� 5x      " ��6   .�5y      ��  � �� �#5656566/   �� 5z       � ��$ Cascadia Mono)�6/   �� 5{       � ��$ 20(�6-   5|      5}       � RowDefinitions 5   
   �� 5�      $��25 �6   �� 5�      $��* �6   .+�5�   
   �  � ColumnDefinitions 5�      �� 5�      $��20 �6#   �� 5�      .+�5�      �� -   5         ��Name$ tbl_TenBang��5�      $��1��6-   $��20(�6=   doi mat khau6Y   5�      �� 5�   
   ���#F7F7F7$��2��6&   $ 5��63    �� Padding$ 20q�6D   ._�5�      �  5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � �� �#D9D9D967   �� 5�       �@��CornerRadius$ 5��69   5�      5�       5�      �� 5�      �� 5�      $��10 �6$   �� 5�      �� 5�      $��10 �6$   �� 5�      �� 5�      $��20 �6$   �� 5�      $��40 �6$   .+�5�      ]� $��0��6   .+�5�      �� -   5        $ tbl_MKCu��5�       $	��Top=�62   mat khau cu6T   �� 5�      ._�5�      �  5�      �� 5�   "   $��10 �63   �� 5�   "   .+�5�      G� -   5         G�Name$ pw_cu��5�   V   #���  6*   $��1��6e   $��25��6u   ���#D9D9D96�   5�      5�      5�      ]� 5�      $��2��6   .+�5�      �� -   5        $ 	tbl_MKMoi��5�       $	��Top=�63   mat khau moi6V   �� 5�      ._�5�      �  5�      �� 5�   "   $��10 �63   �� 5�   "   .+�5�      G� -   5        $ pw_moi1��5�   V   #���  6*   $��1��6g   $��25��6w   ���#D9D9D96�   5�      5�      5�      ]� 5�      $��4��6   .+�5�      �� -   5        $ tbl_NhapLaiMK��5�       $	��Top=�67   nhap lai mat khau6_   �� 5�      ._�5�      �  5�      �� 5�   "   $��10 �63   �� 5�   "   .+�5�      G� -   5        $ pw_moi2��5�   V   #���  6*   $��1��6g   $��25��6w   ���#D9D9D96�   5�      5�      5�      � 5�      $��6��6   $	��220��6$   .+�5�      �� -   5        #���  5�      $
��Left=�6D   $	��100��6_   ���#E2895A��5�      �� 5�      -	   5        $ tbl_Huy��5�   (   $��20(�69   huy6L   5�      �� 5�      -
   5        #���  5�      $��Right=�6D   $	��100��6`   ���#E2895A��5�      �� 5�      -   5        $ tbl_Doi��5�   (   $��20(�69   doi6L   5�      5�      5�      5�      5�      5�      