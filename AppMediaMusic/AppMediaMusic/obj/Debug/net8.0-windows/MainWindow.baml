   M S B A M L   `   `   `  ����H  DAppMediaMusic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AppMediaMusic.UserControlsAppMediaMusic.UserControls  5   	       AppMediaMusic.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   3uc(clr-namespace:AppMediaMusic.UserControls   5   	   $	��700��5   
   $
��1050��6     � 
ResizeMode$  NoResize=�6$    � AllowsTransparency$
 True��6:    � WindowStartupLocation$ CenterScreen=�6T    � WindowStyle$
 None=�6y   
������ .��5      �� -   5        
������� �� CornerRadius$ 40��5       ._�5   
   �  � ColumnDefinitions 5	      �� 5
      $	��220 �6#   �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $	��100 �6    .+�5      �� 
�������$ 	40 0 0 40��6(   $��2��6A   ._�5      �� $��0 30 0 0q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $
��Left=�6:   $��
63 10 0 10q�6U   .+�5      A� ���#ff6258$��10��61   $��10��6<   A� 5      ���#ffbf2f$��10��61   $��10��6<   $	��7 0q�6H   A� 5      ���#2acb42$��10��61   $��10��6<   5      �� 5      $��LIBRARY��6       	menuTitle#��[  6/   �� 5        
menuButton#��[ 6   ���#02be68
�������.��5       � .+�5!      �� $
��Home��6(   .  (MahApps.Metro.IconPacks.PackIconMaterial  5"        menuButtonIcon#��[ 64   $y�Visible=�6\   5#      5$      �� 5&      -   5         ��Name$ PlaylistButton��5&      #��[ 65   .��5(      � .+�5)      �� $��	Playlists��6(   $��0 0 0 2q�69     5*      #��[ 64   5+      5,      �� 5-      -   5        $��Delete ��5-      #��[ 6/   6T   �� 5.      -   5        $
��Add ��5.      #��[ 6,   6Q   52      54      �� 57      $��1��6   
�������$��
40 60 10 0q�6<   .+�58      �� $
��Home��6     	titelText#��[ 6(   �� 5:      $ 20��6   $��0 20 0 0q�6+   ��5;      �� 5<      .��5=      � 	 � Color$	 #30ad9a��6+   
 � Offset$
 0Q�6;   � 5>      $	 #18c274��6+   $
 1Q�6;   5?       J� Effect 5B      3  -System.Windows.Media.Effects.DropShadowEffect  5C         
BlurRadius$ 20Q�6+      ShadowDepth$ 0Q�6;      Opacity$	 0.4Q�6K      Color$ #1fae7e��6Y   ._�5F      � .+�5G      ��  J� Opacity$
 0.07Q�6!   $ 20��60   ��5H      �� 5I   "    �� ImageSource$ /Images/Music.png��6-   5K      �� 5N      $��30q�6%   .+�5O      �� $��	Song List��6(   
�������$��26(�6L   $
��Bold"�6Z   &   System.Windows.Controls.DataGrid  5R      -   5          Name$ SongDataGrid��5R   '      AutoGenerateColumns$ False��6=      CanUserAddRows$ False��6Y   
������ 
���   �   Columns 5S   "   0  *System.Windows.Controls.DataGridTextColumn  5T   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Song ID��69      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *SongId+6e     5U   &   $ Title��69   $ * 6b    6H   �� *Title+6b     5V   &   $ Artist��69   $ * 6d    6I   �� *Artist+6d   5X      5Y      5Z      5\      5^      �� 5_      -   5         ��Name$ HelloMsgLabel��5_      $��2��6+   $��Label��6;   $
��Left=�6K   $��49��6f   $��
207,42,0,0q�6r   $	��Top=�6�   $	��142��6�   5a      5c      5d      