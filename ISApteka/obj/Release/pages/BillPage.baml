   M S B A M L   `   `   `  ���� C  ?ISApteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ISApteka.pagesISApteka.pages      ISApteka.pages.BillPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:ISApteka.pages       N� Title$  BillPage��.���  � RowDefinitions �� $
��60px ��� $��1* ��� $
��55px �.+��  � ColumnDefinitions �� �� �� �� .+��� -   $��TbSearch��$��Center=��� -   $��CbFilter��$��1��$	��3pxq�$
��45px��$��180px���� -   $��CbSort��$��2��$	��3pxq�$
��45px��$��180px���� $��Center=�$��Center=� �� Orientation$ 
Horizontal=�$��3��.+��� -   $��TbCount��$��15(��� $��15(�$�� из ���� -   $��
TbCountAll��$��15(��� $��Center=�$��Center=�$ 
Horizontal=�$��3��$��0,30,0,0q�.+��� $��15(�$!��Всего на сумму:���� -   $��TbPrice��$��15(��� -   $��BtnAdd��$��2��$
��Left=�$��5,0,0,0q�$��Добавить���� -   $��BtnEdit��$��2��$��Right=�$��0,0,5,0q�$��Изменить���� -	   $��	BtnDelete��$��2��$��Удалить���� -
   $��LbBill��$��1��$��Stretch=�����  �� 
TargetType" ��.���  �� Property � �� �� Value �#999��  � ��$ 2q���  � ��$ 5q���  � ��$ 18(� �� 	Resources ��%9   '��       �� " ��.���  �@��CornerRadius$ 5������ .R��  �� $��120px ��� $��* ��� $��200px �.+���  �� CornerRadius$ 5,5,5,5������ 	 j� Stretch$	 UniformToFill=�
 �� ImageSource
 �� *FixedImageBill+�� $ Vertical=�$��1��$��20,0,0,0q�.+��� �� ��� *Doctor.DoctorName+ �� $	� | �� �� ��� *Stock.DrugName+ �� $	� | �� �� ��� *
ClientName+�� �� ��� *Description+�� �� $�	Цена:�� �� ��� *Price+�� �� $�Дата заказа:�� �� ��� *	DateBeg+