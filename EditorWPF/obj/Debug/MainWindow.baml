   M S B A M L   `   `   `  ����D  @EditorWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EditorWPF	EditorWPF  5   	       EditorWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:EditorWPF     5   	     � Title$  Editor��5   	   $	��450��6   $	��800��6%   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��91* �6   �� 5      $
��305* �6   .+�5   
   o� -   5         o�Name$
 menu��5      $
��Left=�6   $��18��68   $	��Top=�6D   $	��792��6\   $��2��6h   .@�5      m� -   5         m�Name$ miFile��5      $
��File��6'   .@�5      m� -   5        $ miOpen��5      $
��Open��6+   69   m� 5      -   5        $ miSave��5      $
��Save��6+   69   m� 5      -   5        $ miSaveAs��5      $��
Save As...��6-   6A   5      m� 5      $
��Edit��6   .@�5      m� -   5        $
��Undo��5      6)   5      m� 5      $��Tools��6   .@�5      m� -   5        $ miBrush��5      $��Brush��6,   .@�5      m� -   5        $ miRectangle��5      $��	Rectangle��64   6G   m� 5      -	   5        $ 	miEllipse��5      $��Ellipse��62   6C   5      m� 5      -
   5        $ miColor��5      $��Color��6,   .@�5      m� -   5        $ miColorBlack��5      $��Black��65   6D   m� 5      -   5        $ miColorBlue��5      $
��Blue��64   6B   m� 5      -   5        $ miColorGreen��5      $��Green��65   6D   m� 5       -   5        $ 
miColorRed��5       $	��Red��63   6@   5!      m� 5"      -   5        $ miRotate��5"      $��Rotate��6-   $y�	Collapsed=�6=   .@�5#      m� -   5        $ miRotateLeft��5#      $��Rotate left��65   6J   m� 5$      -   5        $ miRotateRight��5$      $��Rotate right��66   6L   m� 5%      -   5        $ miRotate180��5%      $��
Rotate 180��64   6H   m� 5&      -   5        $ miFlipVertical��5&      $��Flip vertical��67   6N   m� 5'      -   5        $ miFlipHorizontal��5'      $��Flip horizontal��69   6R   5(      m� 5)      -   5        $ 
miContrast��5)      $��Contrast ratio��6/   6G   m� 5*      -   5        $ miBrightness��5*      $��
Brightness��61   6E   m� 5+      -   5        $ miColorBalance��5+      $��Color balance��63   .@�5,      m� -   5        $ miColorBalanceRed��5,      $	��Red��6:   6G   m� 5-      -   5        $ miColorBalanceGreen��5-      $��Green��6<   6K   m� 5.      -   5        $ miColorBalanceBlue��5.      $
��Blue��6;   6I   5/      50      51      �� 52   
   -   5         ��Name$ image��52      $
��Left=�6   $	��386��6:   $	��Top=�6G   $	��772��6_   $��2��6k   $��	10,23,0,0q�6   6�   54      55      