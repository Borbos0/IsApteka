   M S B A M L   `   `   `  ����C  ?ISApteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ISAptekaISApteka  5   	       ISApteka.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ISApteka     5   	     � Title$,  &ООО Аптека «Ромашка»��5   	   $	��750��6&   $
��1000��63    � Icon$ logo/icon.ico��6@    � WindowStartupLocation$ CenterScreen=�6U   $	��750��5	   	   $
��1000��6   .��5
      �  � RowDefinitions 5   
   �� 5      $
��80px �6   �� 5      $��1* �6   �� 5      $
��35px �6   .+�5   
   � ���#990000.+�5      �� $��logo/logo.png��6   $
��Left=�6+   6H   �� 5      $%��Аптека «Ромашка»��6   $��Center=�60   $��Center=�6K   6j   5       � 5   
   -   5        $��	MainFrame��5      $��1��6     � NavigationUIVisibility$ Hidden=�6.   6|   �� 5   
   $��1��6    J� Opacity$ .1Q�6    K� ZIndex$ -1��6*   $��logo/logo.png��6<   6U   �� 5   
   -   5        $��BtnBack��5      $��
Назад��66   $��Right=�6F   $��0,0,5,0q�6b    �� IsCancel . 6�   � 5   
   $��2��6   
�������.+�5      �� -   5        $��Login��5   A   $
��Left=�6   $��650px��63   $��Center=�6N   $��3,0,0,0q�6i   Пользователь6�   �� 5      -   5        $��BtnExit��5      $��
Выйти��6:   $��Right=�6J   $
��30px��6f   $��0,0,3,0q�6t   6�   5      5      5      