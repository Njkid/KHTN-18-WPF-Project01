   M S B A M L   `   `   `  ����M  IFluent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent  5   	   E Afoodrecipe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:foodrecipe
foodrecipe 5   	      foodrecipe.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7Fluent$clr-namespace:Fluent;assembly=Fluent     5   	   *localclr-namespace:foodrecipe     5   	     � Title$  Food Recipe��5	   	   $��800px��6   $��1105px��6,   $��1105px��5
   	   $��1105px��5   	   $��800px��5   	   $��800px��5   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#444444���#333333 � 	Resources 5      "  foodrecipe.BtnColorConverter   BtnColorConverter#  foodrecipe.DirectoryConverter  DirectoryConverter��%:   &	        &	        5   
   6>     5   
   6@   5      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $��0,20,0,0q�6,   .+�5         Fluent.Ribbon  $
��45px��6      Menu 5         Fluent.Backstage  5         Fluent.RibbonControl   Header$	 ☰��6'   $
��24pt(�62      Content. 5          Fluent.BackstageTabControl  .@�5         Fluent.BackstageTabItem     Header$
 Info��66   $
��14pt(�6D   .��5   "   �� .+�5   &   �� .��6,   ID: 181203336:   �� 5    &   .��6,   Name: NGUYEN QUOC DUNG6D   5!   #   5#        5%      $
 Exit��66   $
��14pt(�6D   5(      5*      5+      5.      ]� 50      ��. .+�51      �� $ 
Horizontal=�6   $��Center=�66   $��10q�6S   $	��Top=�6_   .+�52      �� -   5        $��searchTextBox��52   ,   $��500px��6    �� TextAlignment$
 Left=�6A   $
��10pxq�6V   $
��12pt(�6e   ���#b9e8ff���#333333���#1ba1e255   2   �� 56      -   5        	 ��Name$	 searchButton��56   (   $��50��6   $
��22pt(�6>   ���#1ba1e2���#1ba1e2.��6�   ⌕6�   �� 58      -   5        
 ��Name$
 filterComboBox��58      ���#1ba1e2$	��100��6L   $��20,0,0,0q�6X   $
��14pt(�6j   $��Center=�6z   ��5;      �� 5<       �� 
TargetType" ��6$   .�5=   "   ��  �� Property � �� �� Value �#1ba1e26?   �� 5>   "    � �� �#1ba1e26@   5?      .@�5A      �� -   5        $��sortAZNameSelection��5A   '    �� 
IsSelected . .��5B      �� 
↓ Tên6/   5C      �� 5D      -   5        $��sortZANameSelection��5D   '   .��5E      �� 
↑ Tên6/   5F      �� 5G      -   5        $��sortAZDateSelection��5G   '   .��5H      �� 	↓ Ngày61   5I      �� 5J      -   5        $��sortZADateSelection��5J   '   .��5K      �� 	↑ Ngày60   5L      5M      �� 5O      $ 
Horizontal=�6!   $��50,0,0,0q�6:   .+�5P      �� -   5        $��favoriteFilter��5P   $   ���#efefef$��Center=�6P   6�   �� 5Q      $��15,0,0,0q�6$   $
��14pt(�66   $��Center=�6F   ���#efefefYêu thích6�   5R      �� 5T      $ 
Horizontal=�6!   $��Center=�6:   $��50,0,0,0q�6U   .+�5U      �� -	   5        $	 createRecipeButton��5U   !   $
��16pt(�6=   $��	10,0,10,0q�6M   ���#1ba1e2���#1ba1e2���#efefef.��6�   + Tạo mới6�   5V      5Y      �� 5[      $ 
Horizontal=�6   $��Bottom=�66   $��Center=�6N   .+�5\      �� -
   5        $
��14pt(�5\   >   
����������#333333���#333333$��60��6�   .��6�   <6�   �� 5]      -   5         ��Name$ numPageTextBlock��5]       $
��1/10��6:   $��25(�6F   
������� �� TextAlignment$ Center=�6k    �� Padding$ 10q�6�   ���#3333336�   �� 5^      -   5        $
��14pt(�5^   :   
����������#333333���#333333$��60��6�   .��6�   >6�   5_      �� 5a      $ 
Horizontal=�6   $��Center=�66   .+�5b      �� -   5        $��previousPageButton��5b   (   $��50��6   ���#efefef���#afafaf$��0q�6l   $
��30pt(�6�   $
��Bold"�6�   6�   �� 5c      -   5        $��foodsListView��5c   Q   $��580px��6   $��990px��6.   ���#efefef
��� E��$��0q�6~   $��Disabled=�6�   $��Stretch=�6�   ��5d      �� 5e      .R�5f   "   �  � Orientation$ 
Horizontal=�6,   $
��10pxq�6E   5g      ��5i      �� 5j      .R�5k   "   �� $
��20pxq�6)   ._�5l   &   �� $ Vertical=�61   $
��10pxq�6H   .+�5m   *   �� $��230px��6�   $��150px��6�   $
��10pxq�6�   ��60   ��  �� Path$ RecipeImagePath� �� 	Converter# [ 5n   +   �� 5o   *   $ 
Horizontal=�65   $��205px��6N   $
��10pxq�6\   .+�5p   .   �� -   5        $��40��5p   5   $��0q�5q   1   $��15(�6E   ���#efefef��5p   @   �� $ Liked�# [   �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5r   F   ♥5t   /   �� 5u   .   $
��12pt(�6T   $
��Bold"�6d   ���#333333$	��150��5v   3   $ Center=�6?   ��5u   8   �� *
RecipeName+5v   ?   5w   +   5x   '   5y   #   5z      ��5|      �� 5}      " ��6$   .�5~   "   -   5        5      5�      �� 5�      -   5        $��nextPageButton��5�   (   $��50��6   ���#efefef���#afafaf$��0q�6h   $
��30pt(�6|   $
��Bold"�6�   6�   5�      5�      5�      5�      5�      