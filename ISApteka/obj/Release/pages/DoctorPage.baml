   M S B A M L   `   `   `  ���� C  ?ISApteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ISApteka.pagesISApteka.pages      ISApteka.pages.DoctorPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:ISApteka.pages       N� Title$  
DoctorPage��.���  � RowDefinitions �� $
��60px ��� $��1* ��� $
��55px �.+��  � ColumnDefinitions �� �� �� �� .+��� -   $��TbSearch��$��Center=�$	��3pxq�$
��45px��$��180px���� -   $��CbFilter��$��1��$	��3pxq�$
��45px��$��180px���� $��Center=�$��Center=� �� Orientation$ 
Horizontal=�$��3��.+��� -   $��TbCount��$��15(��� $��15(�$�� из ���� -   $��
TbCountAll��$��15(��� -   $��BtnAdd��$��2��$
��Left=�$��5,0,0,0q�$��Добавить���� -   $��BtnEdit��$��2��$��Right=�$��0,0,5,0q�$��Изменить���� -   $��	BtnDelete��$��2��$��Удалить���� -   $��LbDoctor��$��1��$��Stretch=�����  �� 
TargetType" ��.���  �� Property � �� �� Value �#999��  � ��$ 2q���  � ��$ 5q���  � ��$ 18(� �� 	Resources ��%9   '��       �� " ��.���  �@��CornerRadius$ 5������ .R��  �� $��120px ��� $��600px ��� $��* ��� $��200px �.+���  �� CornerRadius$ 5,5,5,5������ 	 j� Stretch$	 UniformToFill=�
 �� ImageSource
 �� *FixedImageDoctor+�� $ Vertical=�$��1��.+��� �� ��� *
DoctorName+ �� $	� | �� �� ��� *DoctorSecondName+ �� $	� | �� �� ��� *DoctorSurname+�� �� ��� *DoctorDegree.DoctorDegreeName+