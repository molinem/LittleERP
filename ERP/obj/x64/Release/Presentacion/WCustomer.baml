   M S B A M L   `   `   `  ���� >  :ERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ERPERP      ERP.WCustomer   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:ERP       � Title$  Nuevo Cliente��$��694.592��$��1392.359�� � WindowStartupLocation$ CenterScreen=����	#FFB0D2EE � 
ResizeMode$ NoResize=�.��� $��	0,0,-6,-3q� J� RenderTransformOrigin$ 0.525,0.518&� � ColumnDefinitions �� $	��85* ��� $��0* ��� $��0* ��� $	��89* �.+��� -    ��Name$ txtTitle��$��    NUEVO CLIENTE��$��72(�$��Center=�$��Center=�$��Times New Roman)�$	��761��$��351,61,280,515q�$��4���� -   $ lblName��$��Nombre :��$��20(�$��Center=�$��Center=�$��Times New Roman)�$��47,304,549,329q�$��36��$��84��$
��Bold"��� -    ��Name$ txtName��$��0��$��Center=�$��Center=�$��Times New Roman)�$��20(�$	��234��$��40��$��171,297,275,332q�$��40���� -   $ 
lblAddress��$��Dirección :��$��20(�$��Center=�$��Center=�$��Times New Roman)�$��45,422,535,215q�$��32��$	��100��$
��Bold"��� -   $ 
txtAddress��$��0��$��Center=�$��Center=�$��Times New Roman)�$��20(�$	��234��$��40��$��171,417,275,212q�$��40���� -   $ lblEmail��$��Email :��$��20(�$��Center=�$��Center=�$��Times New Roman)�$��45,546,551,91q�$��32��$��84��$ 0.528,0.683&�$
��Bold"��� -   $ txtEmail��$��0��$��Center=�$��Center=�$��Times New Roman)�$��20(�$	��234��$��40��$��171,542,275,87q�$��40��$��Center=��� -   $ 	lbSurname��$��
Apellido :��$��20(�$��Center=�$��Center=�$��Times New Roman)�$��47,361,535,274q�$��34��$��98��$
��Bold"��� -	   $ 
txtSurname��$��0��$��Center=�$��Center=�$��Times New Roman)�$��20(�$	��234��$��40��$��171,356,275,273q�$��40���� -
   $ lblPhone��$��Móvil :��$��20(�$��Center=�$��Center=�$��Times New Roman)�$��45,482,537,153q�$��34��$��98��$ 0.968,0.591&�$
��Bold"��� -   $ txtPhone��$��0��$��Center=�$��Center=�$��Times New Roman)�$��20(�$	��234��$��40��$��171,477,275,152q�$��40���� -   #��[" �$��549,520,61,77q�$��0��$��0��
������ $��70��$��72��.���� $'��!/ERP;component/Resources/save.png��$ 3.246,3.152&��� -   #��[" �$��452,520,158,77q�$��0��$��0��
������ $��70��$��72��.���� $(��"/ERP;component/Resources/clean.png��$ 3.246,3.152&��� -   #��[" �$��362,304,280,293q�$��0��$��3��
������ $��70��$��72��.���� -    ��Name$ btnSelected��$+��%/ERP;component/Resources/selected.png��$ 3.246,3.152&��� -   #��[" �$��362,434,280,163q�$��0��$��3��
������ $��70��$��72��$ 	0.495,0.5&�.���� -   $ btnNotSelected��$/��)/ERP;component/Resources/not_selected.png��$ 3.246,3.152&��� -   $ lblDni��$��DNI :��$��20(�$��Center=�$��Center=�$��Times New Roman)�$��50,239,546,394q�$��36��$��84��$
��Bold"��� -   $ txtDni��$��0��$��Center=�$��Center=�$��Times New Roman)�$��20(�$	��234��$��40��$��171,235,275,393q��� -    ��Name$ 	cboRegion��$
��Left=�$��579,239,0,0q�$	��Top=�$	��204��$��30��$��20(�$��Times New Roman)�$��4���� -   $ 	lblRegion��$��	Región :��$��20(�$��Right=�$��Center=�$��Times New Roman)�$��0,237,144,396q�$��36��$��84��$
��Bold"��� -   $ cboState��$
��Left=�$��579,302,0,0q�$	��Top=�$	��204��$��30��$��20(�$��Times New Roman)�$��4���� -   $ lblState��$��Provincia :��$��20(�$��Center=�$��Center=�$��Times New Roman)�$��449,300,126,333q�$��36��$	��105��$
��Bold"��� -   $ cboCity��$��579,362,0,0q�$	��Top=�$��30��$��20(�$��Times New Roman)�$
��Left=�$	��204��$��4���� -   $ lblCity��$��Ciudad :��$��20(�$��Center=�$��Center=�$��Times New Roman)�$��449,361,126,272q�$��36��$	��105��$
��Bold"��� -   $ 
cboZipCode��$��579,422,0,0q�$	��204��$��30��$
��Left=�$	��Top=�$��20(�$��Times New Roman)�$��4���� -   $ 
lblZipCode��$
��CP :��$��20(�$��Center=�$��Center=�$��Times New Roman)�$��450,420,183,213q�$��36��$��47��$
��Bold"��� -   	 ��Name$	 listTagsOriginal��$
��Left=�$	��274��$��149,287,0,0q�$	��Top=�$	��193��$��20(�$��Times New Roman)�$��1��$��3���� -   $	 listTagsSelected��$
��Left=�$	��274��$��454,287,0,0q�$	��Top=�$	��193��$��20(�$��Times New Roman)�$��1��$��3���� -   $ lblTagsSelected��$��Tags Seleccionadas��$��20(�$��Right=�$��Center=�$��Times New Roman)�$��0,233,75,400q�$��36��$	��172��$��3��$
��Bold"��� -   $ lblTagsSelected_Copy��$��Tags disponibles��$��20(�$��Right=�$��Center=�$��Times New Roman)�$��0,233,395,400q�$��36��$	��143��$��3��$
��Bold"�