   M S B A M L   `   `   `  ����C  ?ICT_VNPT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ICT_VNPT.UI.UserControlsICT_VNPT.UI.UserControls  5      )    #ICT_VNPT.UI.UserControls.TestResult   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ICT_VNPT.UI.UserControls     5      ���#F0F0F0  � 	Resources  5
      ��%    5      .��5      �� .@�5   
   �� ��5      �� 5      $��ICT Test Results��6   $��90��64   .��5"      �  � ColumnDefinitions 5#      �� 5$      $	��100 �6'   �� 5%      $��* �6'   .+�5(      �� $��0��6   .+�5)      �� $��Export to -------��6   �� 5*      $y�	Collapsed=�6   $��25��64   $��Excel��6@   $��5,5,5,0q�6P   �� 5+      -   5        $��25��5+   2   $	��CSV��6>   $��5,5,5,0q�6L   �� 5,      -   5        $��25��5,   2   $	��XML��6>   $��5,5,5,0q�6L   �� 5-      -   5        $��25��5-   2   $��
Clear Grid��6>   $��5,5,5,0q�6S   5.      &   System.Windows.Controls.DataGrid  50      -   5          Name$ 
gridResult��50   +   $��1��6      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserResizeColumns .    CanUserResizeRows .     CanUserSortColumns .  	   CanUserReorderColumns	 .  "
   VerticalScrollBarVisibility$

 Auto=�51   �   $   HorizontalScrollBarVisibility$
 Auto=�6�      GridLinesVisibility$	 All=�52         HorizontalGridLinesBrush �#e9efe6   VerticalGridLinesBrush �#e9efe6   HeadersVisibility$ Column=�55      $��Center=�56      $��Center=�57         SelectionUnit$ FullRow=�58         SelectionMode$ Single=�63   $��5q�59      ��50   ?   ��  � ContextMenu 5=      �� 5>      .@�5?      m� -   5        $��Refresh��5?   '   68   5@         Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ SN��6�      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *SerialNumber+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�     5F      $ ItemName��6|   $ 1* 6�      
FontWeight$ SemiBold"�6�    6-   �� *
ItemName+$ PropertyChanged=�$ TwoWay=�6�     5H      $
 Unit��6|   $
 0.5* 6�    6-   �� *
ItemUnit+$ PropertyChanged=�$ TwoWay=�6�     5J      $ Retry��6}   $
 0.5* 6�    6-   �� *	RetryTime+$ PropertyChanged=�$ TwoWay=�6�     5L      $ LL��6~   $
 0.5* 6�    6-   �� *
LowerLimit+$ PropertyChanged=�$ TwoWay=�6�     5N      $ Actual��6|   $
 0.7* 6�    6-   �� *
NumValue+$ PropertyChanged=�$ TwoWay=�   ElementStyle 5O      �� 5P   "    �� 
TargetType" ��6(    �� Triggers 5Q   &   P� 5R   *    P� Property � �� P� Value$  ��6B   . �5S   .   ��  �� Property � ��  �� Value  �#e5a68b6K   5T   +   5V   #   5X        5Z      $ UL��6~   $
 0.5* 6�    6-   �� *
UpperLimit+$ PropertyChanged=�$ TwoWay=�6�     5\      $	 UOM��6w   $
 0.5* 6�    6-   �� *UOM+$ PropertyChanged=�$ TwoWay=�6�     5^      $ Result��6~   $
 0.5* 6�    6-   �� *
ItemResult+$ PropertyChanged=�$ TwoWay=� 5_      �� 5`   "   " ��6(    5a   &   P� 5b   *    � ��$ failed��6B   . �5c   .   ��  � ��  �#e5a68b6K   5d   +   5f   #   5h        5j      $
 Time��6|   $
 0.5* 6�    6-   �� *
TestTime+$ PropertyChanged=�$ TwoWay=�6�     5l      $
 Code��6}   $
 0.5* 6�    6-   �� *	ErrorCode+$ PropertyChanged=�$ TwoWay=�6�     5n      $ Message��6   $
 1.5* 6�    6-   �� *ItemMessage+$ PropertyChanged=�$ TwoWay=�6�   5q      5s      5u      5w      5y      