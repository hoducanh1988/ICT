   M S B A M L   `   `   `  ����J  FAppTestICT_Ver1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AppTestICT_Ver1AppTestICT_Ver1  5   	   "    AppTestICT_Ver1.Keithley2110   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:AppTestICT_Ver1     5   	     � Title$  Keithley2110��5   	   $	��550��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�67   .��5
      �� $��5,5,0,0q�6   .+�5   
   � .+�5      �� $��Visa Address:��6   �� 5      -   5         ��Name$ txt_visaaddress��5      $��Center=�6/   $	��300��6Q   $*��$USB0::0x05E6::0x2110::8009790::INSTR��6]   5      �� 5   
   -   5        $��80,5,0,0q�5   &   $��Connect��68   $	��100��6J   $
��Left=�6V   $��30��6q   �� 5   
   $��List Commnad��6   �� 5   
   -   5         ��Name$ rtb_command��5      $	��200��6+    �� 
LineHeight$ 1��68   �� 5   
   -   5        $��80,5,0,0q�5   &   $
��Send��68   $	��100��6G   $
��Left=�6S   $��30��6n   �� 5   
   $��FeedBack��6   �� 5   
   -   5        $ 
rtb_result��5      $	��150��6*   $ 1��67   5      5      