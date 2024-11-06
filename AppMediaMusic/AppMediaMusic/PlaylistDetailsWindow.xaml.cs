using AppMediaMusic.BLL.Services;
using AppMediaMusic.DAL.Entities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Win32; 
using System.Collections.ObjectModel;
using WMPLib;

namespace AppMediaMusic
{
    public partial class PlaylistDetailsWindow : Window
    {
        
        private PlaylistService _playlistService = new PlaylistService();
        private PlaylistSongService _playlistSongService = new PlaylistSongService();
        public int PlaylistId { get; set; }
        private DispatcherTimer timer;
        private int currentIndex = 0;
        private bool isPaused = false;

        public PlaylistDetailsWindow(int playlistId)
        {
            InitializeComponent();
            PlaylistId = playlistId;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PlaylistSongDataGrid.ItemsSource = _playlistSongService.GetSongsByPlaylistId(PlaylistId);
            var songs = _playlistSongService.GetSongsByPlaylistId(PlaylistId);
            foreach (var song in songs)
            {
                //songList.Add(song);
            }
        }

        private void btn_open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp4;*.mp3)|*.mp4;*.mp3|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                track_list.Items.Clear();

                foreach (string filename in openFileDialog.FileNames)
                {
                    track_list.Items.Add(filename);
                }

                if (openFileDialog.FileNames.Length > 0)
                {
                    currentIndex = 0;
                    PlayTrackAtIndex(currentIndex);
                }
            }
        }

        public TimeSpan GetMediaDurationAsTimeSpan(string filePath)
        {
            WindowsMediaPlayer wmp = new WindowsMediaPlayer();
            IWMPMedia mediaInfo = wmp.newMedia(filePath);
            double durationInSeconds = mediaInfo.duration;

            // Convert duration to TimeSpan
            TimeSpan duration = TimeSpan.FromSeconds(durationInSeconds);
            return duration;
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            
            if (currentIndex >= PlaylistSongDataGrid.Items.Count - 1)
            {
                currentIndex = 0; 
            }
            else
            {
                currentIndex++; 
            }
            PlayTrackAtIndex(currentIndex);
        }

        private void btn_previous_Click(object sender, RoutedEventArgs e)
        {
           
            if (currentIndex <= 0)
            {
                currentIndex = PlaylistSongDataGrid.Items.Count - 1; 
            }
            else
            {
                currentIndex--; 
            }
            PlayTrackAtIndex(currentIndex);
        }

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            if (isPaused)
            {
                mediaPlayer.Play();
                isPaused = false;
                timer.Start();
            }
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            isPaused = true;
            timer.Stop();
        }

        private void PlaylistSongDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentIndex = PlaylistSongDataGrid.SelectedIndex;
            PlayTrackAtIndex(currentIndex);
        }

        private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            btn_next_Click(sender, e); 
        }

        private void PlayTrackAtIndex(int index)
        {
            if (index >= 0 && index < PlaylistSongDataGrid.Items.Count)
            {
                var selectedSong = PlaylistSongDataGrid.Items[index] as Song;
                if (selectedSong != null && !string.IsNullOrEmpty(selectedSong.FilePath))
                {
                    mediaPlayer.Source = new Uri(selectedSong.FilePath, UriKind.RelativeOrAbsolute);
                    mediaPlayer.Play();
                    timer.Start();
                    isPaused = false;

                }
              
            }
            if (index >= 0 && index < track_list.Items.Count)
            {
                string? filePath = track_list.Items[index].ToString();
                TimeSpan duration = GetMediaDurationAsTimeSpan(filePath); 


                MessageBox.Show($"Duration: {duration} seconds");

                mediaPlayer.Source = new Uri(filePath);
                mediaPlayer.Play();
                timer.Start();
                track_list.SelectedIndex = index;
                _playlistSongService.Add(PlaylistId, filePath);
                FillDataGrid();

            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Button playButton = sender as Button;
            string filePath = playButton?.Tag as string;

            if (!string.IsNullOrEmpty(filePath))
            {
                mediaPlayer.Source = new Uri(filePath, UriKind.RelativeOrAbsolute);
                mediaPlayer.Play();
                isPaused = false;
                timer.Start();
            }
            
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
         
            var selectedItem = PlaylistSongDataGrid.SelectedItem;
            MessageBox.Show($"Selected item type: {selectedItem?.GetType().ToString() ?? "null"}");

            var selectedSong = selectedItem as PlaylistSong;

           
            if (selectedSong == null)
            {
                MessageBox.Show("No song selected. Please select a song to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

        
            int songId = selectedSong.SongId;
            int playlistId = selectedSong.PlaylistId;

            // check select
            var result = MessageBox.Show(
                $"Are you sure you want to delete this song from the playlist? \nPlaylist ID: {playlistId}, Song ID: {songId}",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
               
                _playlistSongService.Delete(selectedSong);  
                FillDataGrid();
            }
        }

        private void FillDataGrid()
        {
            var songs = _playlistSongService.GetSongsByPlaylistId(PlaylistId);
            PlaylistSongDataGrid.ItemsSource = null; // Xóa dữ liệu cũ
           PlaylistSongDataGrid.ItemsSource = songs; // Gán dữ liệu mới vào DataGrid
        }


    }
}
