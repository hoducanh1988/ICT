   M S B A M L   `   `   `  ����J  FAppTestICT_Ver1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AppTestICT_Ver1AppTestICT_Ver1  5   	   ,    &AppTestICT_Ver1.ProductOptional_Window   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:AppTestICT_Ver1     5   	     � Title$  ProductOptional_Window��5   	   $	��250��6(   $	��500��65      customWindow#��[  6A    � WindowStartupLocation$ CenterScreen=�6g   .��5
      �� -   5          colorBackground#��[ 5
   *    �� CornerRadius$ 5��6X     colorBorder#��[ 6i   $��1q�6�   ._�5   
   � $��5q�6    � RowDefinitions 5      �� 5      $	��100 �6    �� 5      $��80 �6    �� 5      $��50 �6    .+�5      �� $��0��6   .+�5      � .+�5      �� $��17(�6   $
��Bold"�6*   $$��CHỌN SẢN PHẨM TEST I.C.T��6<   �� 5      
���  ��$ 5��6.   $��	218,0,0,0q�6?   ._�5      �� -   5        $��X��5   <   $��17(�6H   $
��Bold"�6V   $��30��6h   $��Center=�6s   
�������6�   5      5      �� 5      $��5q�6   $
��Wrap=�6'   $��yVui lòng chọn sản phẩm test I.C.T trước. Sản phẩm test được load từ folder Script của phần mềm.��6;   �� 5      $��5q�6   $
��Wrap=�6'   �� 6<   .�6A   Các bước thực hiện:6V   '% chọn sản phẩm => Click nút OK6{   5      �� 5       $��0,0,0,0q�6   $��1��6*   .+�5!      �� $��17(�6   $
��Bold"�6&   
����  �$��Danh sách sản phẩm:��6J   �� 5"      -   5         ��Name$ cbblistProduct��5"      $��Center=�63   $��20(�6U   $
��Bold"�6c   $��5,0,0,0q�6u   ���#f2ee60$��0,10,0,0q�6�   $��35��6�   5$      � 5&      $��2��6   .+�5'      �� $��0,10,0,0q�6    �� Orientation$ 
Horizontal=�6/   $��Center=�6H   $
��Left=�6c   .+�5(      �� -   5        $��40��5(   2   #��[ 6>   
�������$��20(�6{   $��OK��6�   $��90��6�   �� 5)      -   5        $��40��5)   2   $��20,0,0,0q�6>   #��[ 6P   
�������$��20(�6�   $
��Exit��6�   $��90��6�   5*      5+      5.      5/      51      