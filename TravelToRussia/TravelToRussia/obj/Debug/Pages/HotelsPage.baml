   M S B A M L   `   `   `  ����I  ETravelToRussia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TravelToRussia.PagesTravelToRussia.Pages  5      %    TravelToRussia.Pages.HotelsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:TravelToRussia.Pages     5      -   5          N� Title$  
HotelsPage��5	      .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $��* �6    �� 5      $��70 �6    .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DBGrid��5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$! Название отеля��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Name+6Z     5      $% Количество звезд��6)   $ * 6d    6C   �� *CountOfStars+6d     5      $ Страна��6)   $ * 6Z    69   �� *Country.Name+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 auto 6-   	   CellTemplate	 5      �� 5      .R�5   "   �� 
 ��Name$
 editData��6)   -   5        $��Изменить��5   ;   6N   5      5      5       �� 5"      -   5        $
 addData��5"      $��Добавить��6&   $��1��6O   $
��Left=�6\   �� 5#      -   5        $
 
deleteData��5#      $��Удалить��6)   $��1��6T   $��Right=�6a   � 5%      $��1��6   $��Center=�6%   $��Center=�6@   .+�5&      �� -   5         ��Name$ 
Pagination��5&       �� Orientation$ 
Horizontal=�61   .+�5'      �� -   5        $
 GoFirstPage��5'      $��20��62   $��<<��6=   6P   �� 5(      -   5        $
 GoBack��5(      $��20��6-   $��<��68   6G   �� 5)      -	   5         ��Name$ txtCurrentNumber��5)       �� 
IsReadOnly . $��40��6u   �� 5*      -
   5        $��labelTotalPage��5*       �� 5+      -   5        $
 GoNext��5+      $��>��6-   $��20��6Q   �� 5,      -   5        $
 GoLast��5,      $��>>��6-   $��20��6U   5-      5.      50      52      53      