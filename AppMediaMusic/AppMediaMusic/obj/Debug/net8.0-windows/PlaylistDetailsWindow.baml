   M S B A M L   `   `   `  ����H  DAppMediaMusic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AppMediaMusicAppMediaMusic  5   	   )    #AppMediaMusic.PlaylistDetailsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AppMediaMusic     5   	   -   5          � Title$  PlaylistDetailsWindow��5   	   $	��470��6'   $	��800��64    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � .+�5   
   r� -   5         r�Name$ mediaPlayer��5      $��41��6,   $	��718��68   $
��Left=�6D   $	��Top=�6_    r� LoadedBehavior$ Manual=�5       r� UnloadedBehavior$
 Stop=�6/   $��	39,10,0,0q�6G   6Z   �� 5   
   -   5         ��Name$ 
timeSlider��5      $	��Top=�6%   $��20��6=   $��39,367,39,0q�5       � Minimum$ 0Q�6&    � Maximum$	 100Q�62   6@   �� 5   
   -   5         ��Name$ timeDisplay��5      $
��Left=�6)   $	��Top=�6D   $��
39,340,0,0q�6\   $	��100��6p   $��22��6|   $��00:00��6�   �� 5   
   -   5        	 ��Name$	 
track_list��5      $��Center=�6&   $	��101��6C   $��	0,261,0,0q�6P   $	��Top=�6c   $	��392��6{   
���   ����	#FFFCFF005   <   � 5   
   $��Center=�6   $��Bottom=�61   $��0,0,0,10q�6L   .+�5      �� -   5        
 ��Name$
 btn_previous��5   (   $��Previous��6   $	��100��6>   $��5q�6J   6U   �� 5      -   5        $
 PlayPauseButton��5      $��⏯ Play��6.   $��5q�6?   $��75��6J   $��30��6U   6a   �� 5      -   5        $
 btn_next��5   $   $
��Next��6   $	��100��66   $��5q�6B   6M   �� 5      -	   5        $
 
btn_delete��5   &   $��Delete��6   $	��100��6:   $��5q�6F   6Q   �� 5       -
   5        $
 btn_open_home��5    .   $��Open from Home��6   $	��100��6E   $��5q�6Q   6\   �� 5!      -   5        $
 btn_open��5!   .   $��Open from file��6   $	��100��6@   $��5q�6L   6W   5"      &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ PlaylistSongDataGrid��5%      $��Center=�61   $	��200��6N   $��0,56,0,0q�6[   $	��Top=�6m   $	��722��6�      AutoGenerateColumns$ False��6�      CanUserAddRows$ False��5&         Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ PlaylistsongId��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *PlaylistsongId+  5)      $ 
PlaylistId��6%   $ 60 69    6D   �� *
PlaylistId+  5*      $ Title��6%   $	 200 64    6@   �� *
Song.Title+  5+      $ Artist��6%   $ 70 65    6@   �� *	AddedAt+4  .System.Windows.Controls.DataGridTemplateColumn  5-      $
 Play��6)      CellTemplate 5.      �� 5/      .R�50      �� -   5        $
��Play��50   %   $��50��6k   
 � Tag 6M   �� *Song.FilePath+6k   51      53      55      56      57      