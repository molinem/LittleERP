   M S B A M L   `   `   `  ���� H  DGridExtra.Wpf, Version=0.4.0.0, Culture=neutral, PublicKeyToken=nullT:clr-namespace:SourceChord.GridExtra;assembly=GridExtra.WpfSourceChord.GridExtra  > :ERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ERPERP    ERP.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Ige:clr-namespace:SourceChord.GridExtra;assembly=GridExtra.Wpf     #localclr-namespace:ERP       � Title$  	LittleERP��$	��450��$	��800�� � WindowState$ 	Maximized=�.��]� .+��� -    ��Name$ 
tabControl�����	#FFB0D2EE.@��� $��Clientes��.���� $
��Auto=�.���  � ColumnDefinitions �� $	��30* ��� $	��70* � � RowDefinitions �� $	��10* ��� $	��20* ��� $	��70* �.+�(� $��0��$��0��$��2��$	��100��$��
0,71,0,122q�$��2��.���� -   $��	txtTitulo��$��CLIENTES��$��72(�$��Center=�$��Center=�$��Times New Roman)�(� $��1��$��0��$��1��$��70��$
��Left=�$��0,0,5,0q�$��Bottom=�.���  �� $	��33* ��� $	��33* ��� $	��33* � �� $
��100* �.+��� -   #��[" �$��5,0,0,0q�$��0��$��0��
������ .���� $��/Resources/add.png���� -   #��[" �$��5,0,0,0q�$��0��$��1��
������ .���� $��/Resources/modify.png���� -   #��[" �$��5,0,0,0q�$��0��$��2��
������ .���� $��/Resources/remove.png��� $��1��$��1��$��Right=�$��5,0,0,0q�$��Bottom=� �� $	��33* ��� $	��33* ��� $	��33* � �� $	��33* ��� $	��66* �.+�(�  (� Stretch$ Uniform=�$
��Left=�$��50��.���� -   $��lblFiltroNombre��$��NOMBRE:��$��10(�$
��Left=�$��Center=�$��Times New Roman)�$��65��(� $ Uniform=�$��1��$��0��$
��Left=�$��50��.���� -   $��lblFiltroApellidos��$��
APELLIDOS:��$��10(�$
��Left=�$��Center=�$��Times New Roman)�$��1���� -    ��Name$ txtFilterName��$��0��$��1��$��Center=�$��Center=�$��Times New Roman)�$��13(�$	��345��$��40��$��	5,10,10,0q��� -	   $��txtFiltroApellidos��$��1��$��1��$��Center=�$��Center=�$��Times New Roman)�$��16(�$	��345��$��40��$��5,8,10,2q�&   System.Windows.Controls.DataGrid  -
     Name$ 
dgCustomer��$��2��$��0��$��2��   AutoGenerateColumns .  	   CanUserAddRows	 .  
   CanUserReorderColumns
 .     CanUserSortColumns .     CanUserResizeColumns .  $��Stretch=�$��Stretch=�   
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * $��Times New Roman)�$��16(���. $
��Auto=�$
��Auto=�$��5,5,5,0q�   CanUserResizeRows .     SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	IdCliente��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IDCUSTOMER+  $	 DNI�� �� *DNI+  $ Nombre�� �� *NAME+  $ 	Apellidos�� �� *	SURNAME+  $ 
Dirección�� �� *	ADDRESS+  $ 	Teléfono�� �� *PHONE+  $ Email�� �� *EMAIL+  $ Ciudad�� �� *STATE+�� -    ��Name$ tabProducts��$��	Productos��.���� $
��Auto=�.��� ���	#FFB0D2EE �� $	��30* ��� $	��70* � �� $	��10* ��� $	��20* ��� $	��70* �.+�(� $��0��$��0��$��2��$	��100��$��
0,71,0,122q�$��2��.���� -   $��txtTitleProducts��$��	PRODUCTOS��$��72(�$��Center=�$��Center=�$��Times New Roman)�(� $��1��$��0��$��1��$��70��$
��Left=�$��0,0,5,0q�$��Bottom=�.���  �� $	��33* ��� $	��33* ��� $	��33* � �� $
��100* �.+��� -   $��btnAddProduct��#��[" �$��5,0,0,0q�$��0��$��0��
������ .���� -    ��Name$ btnNewProduct��$��/Resources/add.png���� -   $��btnModifyProduct��#��[" �$��5,0,0,0q�$��0��$��1��
������ .���� $��/Resources/modify.png���� -   $��btnDeleteProduct��#��[" �$��5,0,0,0q�$��0��$��2��
������ .���� $��/Resources/remove.png��� $��1��$��1��$��Right=�$��5,0,0,0q�$��Bottom=� �� $	��33* ��� $	��33* ��� $	��33* � �� $	��33* ��� $	��66* �.+�(� $ Uniform=�$
��Left=�$��50��.���� -   $��lblFilterName��$��NOMBRE:��$��10(�$
��Left=�$��Center=�$��Times New Roman)�$��65��(� $ Uniform=�$��1��$��0��$
��Left=�$��50��.���� -   $��lblFilterTags��$��TAGS:��$��10(�$
��Left=�$��Center=�$��Times New Roman)�$��1���� -   $ txtFilterNameProduct��$��0��$��1��$��Center=�$��Center=�$��Times New Roman)�$��13(�$	��345��$��40��$��	5,10,10,0q��� -   $��txtFilterTagsProduct��$��1��$��1��$��Center=�$��Center=�$��Times New Roman)�$��16(�$	��345��$��40��$��5,8,10,2q�  -   $ 
dgProducts��$��2��$��0��$��2�� .  	 .  
 .   .   .  $��Stretch=�$��Stretch=� . $ * $��Times New Roman)�$��16(���. $
��Auto=�$
��Auto=�$��5,5,5,0q� .  $ Single=�   $ 	IdProduct�� �� *	IDPRODUCT+  $ Nombre�� �� *NAME+  $ Composición�� �� *COMPOSITION+  $ Talla�� �� *
SIZENAME+  $ Precio�� �� *PRICE+  $ Cantidad�� �� *AMOUNT+