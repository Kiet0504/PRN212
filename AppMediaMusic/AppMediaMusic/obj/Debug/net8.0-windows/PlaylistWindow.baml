   M S B A M L   `   `   `  ����H  DAppMediaMusic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AppMediaMusicAppMediaMusic  5   	   "    AppMediaMusic.PlaylistWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AppMediaMusic     5   	     � Title$  Playlist��5   	   $	��450��6   $	��800��6'   .��5
      �� -   5        
������� �� CornerRadius$ 40��5
       ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��220 �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $	��100 �6    .+�5      �� 
�������$ 	40 0 0 40��6(   $��2��6A   ._�5      �� $��0 30 0 0q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $
��Left=�6:   $��
63 10 0 10q�6U   .+�5      A� ���#ff6258$��10��61   $��10��6<   A� 5      ���#ffbf2f$��10��61   $��10��6<   $	��7 0q�6H   A� 5      ���#2acb42$��10��61   $��10��6<   5      �� 5      $��LIBRARY��6       	menuTitle#��[  6/   �� 5!        
menuButton#��[ 6   .��5"      � .+�5#      �� $
��Home��6(   5$      5%      �� 5'      -   5         ��Name$ PlaylistButton��5'      #��[ 65   ���#02be68
�������.��5(      � .+�5)      �� $��	Playlists��6(   $��0 0 0 2q�69   5*      5+      �� 5,      -   5        $��Add Playlist��5,      #��[ 64   6Y   �� 5-      -   5        $��Delete Playlist��5-      #��[ 67   6\   �� 5.      -   5        $��Update Playlist��5.      #��[ 67   6\   5/      50      �� 53      $��1��6   
�������$��40 20 10 10q�6<   $��2��6Q   .+�54      �� $��	Playlists��6     	titelText#��[ 6-   $��0 0 0 20q�6P   &   System.Windows.Controls.DataGrid  55      -   5          Name$ PlayListDataGrid��55         AutoGenerateColumns$ False��56      $��Stretch=�57      $��Stretch=�58      $��Disabled=�59         CanUserAddRows$ False��5:      	   Columns	 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
PlaylistId��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *
PlaylistId+6`     5>      $

 Name��6-   $ * 6T    6;   �� *Name+6T     5?      $

 Date��6-   $ * 6[    6;   �� *CreatedDate+6[   4  .System.Windows.Controls.DataGridTemplateColumn  5@      $
 Actions��61   $	 100 6B      CellTemplate 5A      �� 5B   "   .R�5C   &   �� $ 
ViewButton��6-   -   5        $
��View��5C   A   6P   5D   #   5F      5H      �� 5J      -   5         ��Name$ AddPlaylistPopup��5J      ���	#AAFFFFFF
���   �$��1q�6^   $ 8��6r    �� Padding$ 10q�5K      $	��300��6   $	��200��6*   $��Center=�67   $��Center=�6R   $y�	Collapsed=�6o   ._�5L      �� .+�5M      �� $��New Playlist��6$   $
��Bold"�68   $��16(�6J   $��0,0,0,10q�6X   �� 5O      -	   5         ��Name$ PlaylistNameTextBox��5O   "   $��0,0,0,10q�6@   �� 5Q      $ 
Horizontal=�6%   $��Right=�6>   .+�5R      �� -
   5        $
��Save��5R   %   $��0,0,5,0q�6R   �� 5S      -   5        $��Cancel��5S   %   66   5T      5U      5V      �� 5X      -   5        $ UpdatePlaylistPopup��5X      ���	#AAFFFFFF
���   �$��1q�6a   $ 8��6u   $ 10q�5Y      $	��300��6   $	��200��6*   $��Center=�67   $��Center=�6R   $y�	Collapsed=�6o   ._�5Z      �� .+�5[      �� $��UpdatePlaylist��6$   $
��Bold"�6:   $��16(�6L   $��0,0,0,10q�6Z   �� 5]      -   5        $ UpdatePlaylistNameTextBox��5]   "   $��0,0,0,10q�6F   �� 5_      $ 
Horizontal=�6%   $��Right=�6>   .+�5`      �� -   5        $
��Save��5`   %   $��0,0,5,0q�6V   �� 5a      -   5        $��Cancel��5a   %   66   5b      5c      5d      �� 5f      $ 20��6   $��0 20 0 0q�6+   ��5g      �� 5h      .��5i      �  � Color$ #30ad9a��6+    � Offset$ 0Q�6;   � 5j      $ #18c274��6+   $ 1Q�6;   5k       J� Effect 5n      3  -System.Windows.Media.Effects.DropShadowEffect  5o         
BlurRadius$ 20Q�6+      ShadowDepth$ 0Q�6;      Opacity$	 0.4Q�6K      Color$ #1fae7e��6Y   ._�5r      � .+�5s      ��  J� Opacity$
 0.07Q�6!   $ 20��60   ��5t      �� 5u   "    �� ImageSource$ /Images/Music.png��6-   5w      5x      5y      5z      5|      5}      5~      