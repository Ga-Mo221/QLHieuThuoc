   M S B A M L   `   `   `  ����F  BQLHieuThuoc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QLHieuThuoc.formsQLHieuThuoc.forms  5      b ^PresentationFramework.Aero2, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5	          QLHieuThuoc.forms.CaiDat   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:QLHieuThuoc.forms     5      ]themeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5	        � 	Resources  5
         FocusVisual �� Property �� Value �� StrokeDashArray!  System.Windows.SystemColors   ControlTextBrushKey J� SnapsToDevicePixels  TextBox.Static.Background �� Color  ComboBoxEditableTextBox �� 
TargetType �� 
TargetType	 ��Name  ComboBox.Static.Background
 �� EndPoint �� 
StartPoint � Color � Offset  ComboBox.Static.Border  ComboBox.Static.Glyph ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background *	 &ComboBox.Static.Editable.Button.Border !
 ComboBox.MouseOver.Background  ComboBox.MouseOver.Border  ComboBox.MouseOver.Glyph * &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Background  ComboBox.Pressed.Border  ComboBox.Pressed.Glyph ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border   ComboBox.Disabled.Background  ComboBox.Disabled.Border  ComboBox.Disabled.Glyph ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBoxToggleButton ��Name �� CornerRadius F�Name �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� Mode �� 
TargetName P� Property P� Value   ComboBoxEditableTemplate �Name � ColumnDefinitions �Name � AllowsTransparency5  /Microsoft.Windows.Themes.SystemDropShadowChrome  Name    Color! �� MaxDropDownHeight" �� ElementName#   WindowBrushKey$   WindowFrameBrushKey% �� ClearTypeHint& ��Name' ��Name( ��Name-  'System.Windows.Input.KeyboardNavigation)   DirectionalNavigation* d�Name+ d� 	IsChecked, �� Mode- ��Name. �� 
IsReadOnly/ P� 
SourceName0 ]� 
Conditions1 �� Property ! ComboBoxTemplate2 ��Name#3 �� SelectionBoxItemStringFormat4 �� ContentStringFormat5 �� SelectionBoxItemTemplate6 �� SelectionBoxItem7 J� IsHitTestVisible " ComboBoxStyle18   WindowTextBrushKey9 �� Triggers��% /  &	        &	 �     &	 �     &	     &	 �    &	 �    &	 �    &	     &	 5    &		 Z    &	
     &	     &	 >    &	 a    &	 �    &	 �    &	 C    &	 f    &	     &	 %    &	 H    &	 k    &	 �    &	 *    &	 M    &	 p    &	 �    &	 �    &	 �    &	 �    &	 !	    &	 F	    7  7  7  7  7  7 	 7  7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	  �    7  7  7  &	! �!    7  &	" `*    7   7  7  7 ! 7   �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #���  6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFFFFFFF��6<   �� 5   
   " ��60   .�5      ��  �@�OverridesDefaultStyle$
 true��66   �� 5       �@J�	AllowDrop$
 true��6*   �� 5       � ��$ 0��6)   �� 5       � ��$ 0��6*   �� 5       �@�FocusVisualStyle 61   Z� �� 5       �@��PanningMode$ VerticalFirst=�69   �� 5       �@��IsFlicksEnabled$ False��67   �� 5       � �� 5      �� 5      " ��6&   .R�5       �� $	 PART_ContentHost��6'   
������ $|�false��6Z   $��Hidden=�6l   $��Hidden=�6�   5!      5#      5$      �� 5%   
   $	
 0,1&�6A   $	 0,0&�6P   .��5&      � $ 	#FFF0F0F0��6   $	 0.0Q�6-   � 5'      $ 	#FFE5E5E5��6   $	 1.0Q�6-   5(      �� 5)   
   $ 	#FFACACAC��69   �� 5*   
   $ 	#FF606060��68   �� 5+   
   $ 	#FFFFFFFF��6F   �� 5,   
   $ 	#FFABADB3��6B   �� 5-   
   $ Transparent��6M   �� 5.   
   $ Transparent��6I   �� 5/   
   $	
 0,1&�6D   $	 0,0&�6S   .��50      � $ 	#FFECF4FC��6   $	 0.0Q�6-   � 51      $ 	#FFDCECFC��6   $	 1.0Q�6-   52      �� 53   
   $ 	#FF7EB4EA��6<   �� 54   
   $ 	#FF000000��6;   �� 55   
   $ 	#FFFFFFFF��6I   �� 56   
   $ 	#FF7EB4EA��6E   �� 57   
   $	
 0,1&�6T   $	 0,0&�6c   .��58      � $ 	#FFEBF4FC��6   $	 0.0Q�6-   � 59      $ 	#FFDCECFC��6   $	 1.0Q�6-   5:      �� 5;   
   $ 	#FF7EB4EA��6L   �� 5<   
   $	
 0,1&�6B   $	 0,0&�6Q   .��5=      � $ 	#FFDAECFC��6   $	 0.0Q�6-   � 5>      $ 	#FFC4E0FC��6   $	 1.0Q�6-   5?      �� 5@   
   $ 	#FF569DE5��6:   �� 5A   
   $ 	#FF000000��69   �� 5B   
   $ 	#FFFFFFFF��6G   �� 5C   
   $ 	#FF569DE5��6C   �� 5D   
   $	
 0,1&�6R   $	 0,0&�6a   .��5E      � $ 	#FFDAEBFC��6   $	 0.0Q�6-   � 5F      $ 	#FFC4E0FC��6   $	 1.0Q�6-   5G      �� 5H   
   $ 	#FF569DE5��6J   �� 5I   
   $ 	#FFF0F0F0��6?   �� 5J   
   $ 	#FFD9D9D9��6;   �� 5K   
   $ 	#FFBFBFBF��6:   �� 5L   
   $ 	#FFFFFFFF��6H   �� 5M   
   $ 	#FFBFBFBF��6D   �� 5N   
   $ Transparent��6O   �� 5O   
   $ Transparent��6K   �� 5P   
   " d�6-   .�5Q      ��  �@�OverridesDefaultStyle$
 true��66   �� 5R       � ��$ false��6*   �� 5S       � |�$ false��6*   �� 5T       �@��	ClickMode$ Press=�6*   �� 5U       � �� 5V      �� 5W      " d�6&   .R�5X      �� $ templateRoot��6!   $ 8��67   ���#E2895A8��  #��z��6�   $
 true��6�   ._�5Y      �� $ splitBorder��6%   
������ $��1q�6T   $��Right=�6h   $��0q�6�   $
 true��6�   #��� r�6�   ._�5Z   "   F� $ arrow��6'   F����        ���( ��( јaQ     јaQ P����̰( � �    P����        8�� $��Center=�6�   $��0q�6�   $��Center=�6�   5[      5\       5]      ^� 5^       5_   "   �� 5`   &    60   �� *
IsEditable+ �� " �� true6�   �� 5a   &    60   �� *IsMouseOver+ �� $
 Self=�	 false6{   �� 5b   &    60   �� *	IsPressed+ �� $
 Self=�	 false6y   �� 5c   &    60   �� *	IsEnabled+ �� $
 Self=� true6y   .0�5e   "   �� $ templateRoot��6?   8   � ��6Y   �� 5f   "   $ templateRoot��6@   8   � ��6Z   �� 5g   "   $ splitBorder��6?   8   � ��6X   �� 5h   "   $ splitBorder��6@   8   � ��6Y   5i      P� 5j       �@J�IsMouseOver$
 true��6=   . �5k   "   �� $ arrow��69   8   � ��6L   5l      ^� 5m       5n   "   �� 5o   &    60   �� *IsMouseOver+ �� $
 Self=� true6{   �� 5p   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5r   "   �� $ templateRoot��6?   8   � ��6Y   �� 5s   "   $ templateRoot��6@   8   � ��6Z   5t      ^� 5u       5v   "   �� 5w   &    60   �� *IsMouseOver+ �� $
 Self=� true6{   �� 5x   &    60   �� *
IsEditable+ �� " �� true6�   .0�5z   "   �� $ templateRoot��6?   8 	  � ��6Y   �� 5{   "   $ templateRoot��6@   8 
  � ��6Z   �� 5|   "   $ splitBorder��6?   8   � ��6X   �� 5}   "   $ splitBorder��6@   8   � ��6Y   5~      P� 5       � ��$
 true��6;   . �5�   "   �� $ arrow��69   8   � ��6L   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsPressed+ �� $
 Self=� true6y   �� 5�   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsPressed+ �� $
 Self=� true6y   �� 5�   &    60   �� *
IsEditable+ �� " �� true6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   �� 5�   "   $ splitBorder��6?   8   � ��6X   �� 5�   "   $ splitBorder��6@   8   � ��6Y   5�      P� 5�       � {�$ false��6;   . �5�   "   �� $ arrow��69   8   � ��6L   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� $
 Self=�	 false6y   �� 5�   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� $
 Self=�	 false6y   �� 5�   &    60   �� *
IsEditable+ �� " �� true6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   �� 5�   "   $ splitBorder��6?   8   � ��6X   �� 5�   "   $ splitBorder��6@   8   � ��6Y   5�      5�      5�      5�      �� 5�   
   " ��6;   .R�5�      � $ templateRoot��6   $
 true��6)    5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6   $
 true��6,   $��2��6F   $��Bottom=�6�   #��� .�6�   ��6Z   �� *IsDropDownOpen+ �� $ TemplatedParent=�.��5�        $ shadow��63   $  Transparent��6C   #��z! 6�   ��6W   �� *ActualWidth+$" templateRoot��._�5�      �� $ dropDownBorder��6!   #��� # 69   #��� $ 6   $��1q�6�   ._�5�      �� $	 DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $% Enabled=�65   .+�5�   &   �� $& canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $' 
opaqueRect��64   ��6H   �� *
Background+$" dropDownBorder����6�   �� *ActualHeight+$" dropDownBorder����6�   �� *ActualWidth+$" dropDownBorder��5�   '   �� 5�   &   $( ItemsPresenter��65   $) 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $* toggleButton��6   #��z��65   #��z��6_   #��z��6�   $��2��6�   8��  + 6�   �� *IsDropDownOpen+$, TwoWay=� �� $ TemplatedParent=�6;  �� 5�      $ border��6   8�� #��z��6a   ._�5�      �� $- PART_EditableTextBox��6   #��z��6<   #��z��6�   8�� #��z��62  . 6�   �� *
IsReadOnly+ �� $ TemplatedParent=�62  5�      5�       5�      P� 5�       � {�$ false��6/   . �5�      �� $ border��60    �@J�Opacity$
 0.56Q�6D   5�      P� 5�       �@J�IsKeyboardFocusWithin$
 true��6;   . �5�      ��  � ��
 �   �63   5�      P� 5�      $/ 
PART_Popup��63    �@�HasDropShadow$
 true��6K   . �5�      �� $ shadow��6/    � ��$ 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$ 	#71000000��6B   5�      P� 5�       �@��HasItems$ false��6.   . �5�      �� $ dropDownBorder��6/    � ��$ 95��6K   5�      ]� 5�      0 5�      �� 5�      1 �@��
IsGrouping$
 true��6:   �� 5�      "1 �@%�IsVirtualizingWhenGrouping$ false��6\   ./�5�      ��  � ��$ false��6F   5�      P� 5�      $/ DropDownScrollViewer��6C    � ��$ false��6e   . �5�      �� $ 
opaqueRect��63    6K   �� *VerticalOffset+$" DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��64    6L   �� *HorizontalOffset+$" DropDownScrollViewer�� �@��Left5�      5�      �� 5�   
   " ��63   .R�5�      � $ templateRoot��6   $
 true��6)    5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6   $
 true��6,   $��2��6F   $��1q�6�   $��Bottom=�6�   #��� .�6�   ��6Z   �� *IsDropDownOpen+$, TwoWay=� �� $ TemplatedParent=�.��5�        $ shadow��63   $  Transparent��6C   #��z! 6�   ��6W   �� *ActualWidth+$" templateRoot��._�5�      �� $ dropDownBorder��6!   #��� # 69   #��� $ 6   $��1q�6�   ._�5�      �� $	 DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $% Enabled=�65   .+�5�   &   �� $& canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $' 
opaqueRect��64   ��6H   �� *
Background+$" dropDownBorder����6�   �� *ActualHeight+$" dropDownBorder����6�   �� *ActualWidth+$" dropDownBorder��5�   '   �� 5�   &   $( ItemsPresenter��65   $) 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $* toggleButton��6   #��z��65   #��z��6_   #��z��6�   $��2��6�   8��  + 6�   �� *IsDropDownOpen+$, TwoWay=� �� $ TemplatedParent=�6;  �� 5�      $2 contentPresenter��6#   #4 z3 6=   #��z5 6�   #��z6 6�   #��z��6�   #��z��6-  $7 false��6p  #��z��6�  # z 6�  $��Center=�6�  5�       5�      P� 5�      $/ 
PART_Popup��63    �@�HasDropShadow$
 true��6K   . �5�      �� $ shadow��6/    � ��$ 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$ 	#71000000��6B   5�      P� 5�       �@��HasItems$ false��6.   . �5�      �� $ dropDownBorder��6/    � ��$ 95��6K   5      ]� 5     0 5     �� 5     1 �@��
IsGrouping$
 true��6:   �� 5     "1 �@%�IsVirtualizingWhenGrouping$ false��6\   ./�5     ��  � ��$ false��6F   5     P� 5     $/ DropDownScrollViewer��6C    � ��$ false��6e   . �5	     �� $ 
opaqueRect��63    6K   �� *VerticalOffset+$" DropDownScrollViewer�� �@��Top�� 5
     $ 
opaqueRect��64    6L   �� *HorizontalOffset+$" DropDownScrollViewer�� �@��Left5     5     �� 5  
   " ��6'   .�5     ��  �@�FocusVisualStyle8   61   �� 5      � ��8  6+   �� 5      � ��8  6,   �� 5      � ��# � 8 6+   �� 5      � ��$ 1q�60   �� 5      � ��$
 Auto=�6K   �� 5      � ��$
 Auto=�6I   �� 5      � ��$ 6,3,5,3q�6(   �� 5      � ��$
 true��6>   �� 5      �@��PanningMode$
 Both=�69   �� 5      �@��IsFlicksEnabled$ False��67   �� 5      � ��8  6)   9 5     P� 5      �@��
IsEditable$
 true��60   . �5     ��  � ��$ false��62   �� 5      � ��$ 2q�60   �� 5      � ��8  61   5      5"     5#     .��5$     � ���#F7F7F7: � RowDefinitions: 5%  
   �� 5&     $��65 �6   6*   �� 5'     $��20 �6   6*   �� 5(     6   .+�5-  
   �� $��0��6   $ 40��6   
�������._�5.     � .+�5/     ]� $��11q�6   .+�51     �� -   5        ; ��Name$; tbl_TenBang��51      $��Cai Dat��52     $��22(�53     $��Cascadia Mono)�54     ���#565656$
��Left=�56     $��Center=�57     58     �� 5<     ���#C9C9C9$��1q�63   $ 20��6G   $��Right=�6Y   $	��230��6p   ._�5=     �� .+�5?     �� -   5        $"; tbl_TenNhanVienThanhTiemKiem��5?  (   $��Tên Tài Khoản��6N   $��15(�5@     $��Cascadia Mono)�5A     ���#565656$��Center=�5C     $	��Top=�5D     $��0 8 0 0q�5E     5F     �� 5H     -   5        $ ; tbl_IdNhanVienThanhTimKiem��5H  (   $��#idnv��6L   $��14(�6Y   $��Cascadia Mono)�6g   ���#C9C9C9$��Center=�6�   6�   5I     5J     � 5M     $��Right=�6   $��85��62   .+�5N     A� $��40��6"   $��40��6.   ���#C9C9C9$��Center=�6H   A� 5O     $��38��6"   $��38��6.   
�������$��Center=�6F   $��Center=�6c   5P     � 5S     5b     5c     5d     5e     �� 5g  
   $��2��6   .+�5h     �� ���#D9D9D9$��50��6*   $ 9��66   ._�5i     �  5j     �� 5k     $��25 �6+   �� 5l     �� 5m     �� 5n     $	��150 �6+   �� 5o     $��25 �6+   .+�5q     �� -   5        $; tbl_LoaiNgonNgu��5q      $��20(�5r      $��Cascadia Mono)�5s      ���#565656$��Center=�5u      $
��Left=�5v      $��1��5w      
Ngon Ngu5y     �� 5{     -   5        < ��Name$< cbb_NgonNgu��5{  H   #��� " 6   $��3��5|     $��35��5}     $��17(�5~     $��Cascadia Mono)�5     ���#565656���#E2895A5�  Q   5�     5�     5�     5�     5�     