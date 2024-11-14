using System.Linq;
using System.Windows;
using WMPLib;
using System.IO;
using AppMediaMusic.BLL.Services;
using AppMediaMusic.DAL.Entities;
using System.Windows.Controls;
using System.Windows.Media;

namespace AppMediaMusic
{
    public partial class MainWindow : Window
    {
        private SongsService _songService = new SongsService();
        private WindowsMediaPlayer _player = new WindowsMediaPlayer();
        private int _currentSongIndex = 0;
        private bool isDraggingSlider = false;
        private PlaylistService _playlistService = new PlaylistService();
        private bool isSongAutoChanging = false;





        public MainWindow()
        {
            InitializeComponent();
            SongListView.ItemsSource = _songService.GetAllSongs();
            _player.settings.volume = (int)(VolumeSlider.Value * 100);
            _player.PlayStateChange += Player_PlayStateChange;
        }

        public User AuthenticatedUser { get; set; }
        public int UserId => AuthenticatedUser?.UserId ?? 0;

        private void PlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            PlaylistWindow playlist = new PlaylistWindow(UserId);
            playlist.ShowDialog();
        }

        private void FillDataGrid()
        {
            var song = _songService.GetAllSongs();
            SongListView.ItemsSource = null;
            SongListView.ItemsSource = song;
        }

        private void DeleteSongButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = SongListView.SelectedItem as Song;

            if (selectedItem == null)
            {
                MessageBox.Show("Please select a song before delete", "Select one", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult answer = MessageBox.Show("Do you want to delete this song?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No) return;

            _songService.Delete(selectedItem);
            FillDataGrid();
        }

        private void AddSongButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp4;*.mp3)|*.mp4;*.mp3|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;


            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string[] parts = fileName.Split('-');
                    string songName = parts.Length > 0 ? parts[0] : "";
                    string artist = parts.Length > 1 ? parts[1] : "";
                    DateTime dateAdded = DateTime.Now;


                    var existingSong = _songService.GetAllSongs().FirstOrDefault(s => s.Title == songName);

                    if (existingSong != null)
                    {

                        MessageBox.Show("This song already exists in the database.", "Duplicate Song", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {

                        _songService.AddSong(filePath);
                    }
                }

                FillDataGrid();
            }
        }

        private void SongListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SongListView.SelectedItem is Song selectedSong)
            {
                // Play the selected song
                _player.URL = selectedSong.FilePath;
                _player.controls.play();

                // Update the total time for the new song
                if (_player.currentMedia != null)
                {
                    TotalTimeText.Text = FormatTime(_player.currentMedia.duration);
                    TimelineSlider.Maximum = _player.currentMedia.duration;
                }

                PauseButton.Content = "⏸ Pause";
                StartTimer();
            }
        }
        private string FormatTime(double seconds)
        {
            var timeSpan = TimeSpan.FromSeconds(seconds);
            return timeSpan.ToString(@"mm\:ss");
        }

        private bool isPlaying = false;

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            Song? selected = SongListView.SelectedItem as Song;
            if (selected == null)
            {
                MessageBox.Show("Please select a Song", "Select one", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (isPlaying)
            {
                PauseMusic();
                PauseButton.Content = "⏯ Play";
            }
            else
            {
                // Phát nhạc
                PlayMusic();
                PauseButton.Content = "⏸ Pause";
            }
            isPlaying = !isPlaying;
        }
        private void PlayMusic()
        {
            if (_player.playState == WMPPlayState.wmppsPaused)
            {
                // Nếu đang tạm dừng, tiếp tục phát
                _player.controls.play();
            }
            else if (SongListView.SelectedItem is Song selectedSong)
            {
                // Nếu là một bài hát mới, thiết lập lại URL và phát từ đầu
                _player.URL = selectedSong.FilePath;
                _player.controls.play();
                StartTimer();
            }
        }

        private void PauseMusic()
        {
            {
                if (_player.playState == WMPPlayState.wmppsPlaying)
                {
                    _player.controls.pause();
                }
            }
        }

        //THỜI LƯỢNG NHẠC
        private bool isChangingState = false;

        private void Player_PlayStateChange(int NewState)
        {
            if (isChangingState) return;
            isChangingState = true;

            if (NewState == (int)WMPPlayState.wmppsPlaying)
            {
                TotalTimeText.Text = TimeSpan.FromSeconds(_player.currentMedia.duration).ToString(@"mm\:ss");
                TimelineSlider.Maximum = _player.currentMedia.duration;
            }
            else if (NewState == (int)WMPPlayState.wmppsStopped)
            {
                isSongAutoChanging = true; // Đánh dấu tự động thay đổi bài hát

                if (isRepeatOneEnabled)
                {
                    _player.controls.currentPosition = 0;
                    _player.controls.play();
                }
                else if (isShuffleEnabled)
                {
                    Application.Current.Dispatcher.InvokeAsync(() => PlayRandomSong(), System.Windows.Threading.DispatcherPriority.Background);
                }
                else
                {
                    // Chuyển bài hát tiếp theo theo thứ tự
                    NextButton_Click(null, null);
                }

                isSongAutoChanging = false; // Reset lại cờ
            }

            isChangingState = false;
        }

        private List<int> _recentlyPlayedIndexes = new List<int>(); // Danh sách các chỉ số bài hát đã phát gần đây
        private int _maxRecentlyPlayed = 3; // Số lượng bài hát tối đa được lưu trong danh sách gần đây

        private void PlayRandomSong()
        {
            var songs = _songService.GetAllSongs();
            int totalSongs = songs.Count;

            if (totalSongs == 0) return; // Thoát nếu không có bài hát nào

            var random = new Random();
            int randomIndex;

            // Đảm bảo không phát lại bài hát hiện tại hoặc các bài đã phát gần đây
            do
            {
                randomIndex = random.Next(totalSongs);
            }
            while (_recentlyPlayedIndexes.Contains(randomIndex) || randomIndex == _currentSongIndex);

            // Thêm chỉ số bài hát vào danh sách gần đây
            _recentlyPlayedIndexes.Add(randomIndex);
            if (_recentlyPlayedIndexes.Count > _maxRecentlyPlayed)
            {
                _recentlyPlayedIndexes.RemoveAt(0); // Xóa bài hát cũ nhất khỏi danh sách nếu vượt quá giới hạn
            }

            _currentSongIndex = randomIndex; // Cập nhật chỉ số bài hát hiện tại
            PlaySong(songs[_currentSongIndex]); // Phát bài hát ngẫu nhiên đã chọn
        }
        private void StartTimer()
        {
            var timer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (s, e) =>
            {
                if (_player.playState == WMPPlayState.wmppsPlaying && !isDraggingSlider)
                {
                    TimelineSlider.Value = _player.controls.currentPosition;
                    CurrentTimeText.Text = TimeSpan.FromSeconds(_player.controls.currentPosition).ToString(@"mm\:ss");
                }
            };
            timer.Start();
        }

        private void TimelineSlider_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDraggingSlider = true;
        }

        private void TimelineSlider_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDraggingSlider = false;
            _player.controls.currentPosition = TimelineSlider.Value;
        }

        private void TimelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isDraggingSlider)
            {
                CurrentTimeText.Text = TimeSpan.FromSeconds(TimelineSlider.Value).ToString(@"mm\:ss");
            }
        }

        //ĐIỀU CHỈNH VOLUME
        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_player != null)
            {
                _player.settings.volume = (int)(VolumeSlider.Value * 100);
            }
        }

        private void FastForwardButton_Click(object sender, RoutedEventArgs e)
        {
            _player.controls.currentPosition += 10;
        }

        private void RewindButton_Click(object sender, RoutedEventArgs e)
        {
            _player.controls.currentPosition -= 10;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isSongAutoChanging)
            {
                _currentSongIndex = (_currentSongIndex + 1) % _songService.GetAllSongs().Count;
            }
            PlaySong(_songService.GetAllSongs()[_currentSongIndex]);
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isSongAutoChanging)
            {
                _currentSongIndex = (_currentSongIndex - 1 + _songService.GetAllSongs().Count) % _songService.GetAllSongs().Count;
            }
            PlaySong(_songService.GetAllSongs()[_currentSongIndex]);
        }


        private void PlaySong(Song song)
        {
            _player.URL = song.FilePath;
            _player.controls.currentPosition = 0; // Đặt lại vị trí phát về đầu
            _player.controls.play();

            // Đặt lại thanh timeline và cập nhật tổng thời gian
            TimelineSlider.Value = 0;
            CurrentTimeText.Text = "0:00";

            // Thiết lập hiển thị tổng thời gian khi bài hát bắt đầu phát
            _player.PlayStateChange += (newState) =>
            {
                if (newState == (int)WMPPlayState.wmppsPlaying)
                {
                    TotalTimeText.Text = TimeSpan.FromSeconds(_player.currentMedia.duration).ToString(@"mm\:ss");
                    TimelineSlider.Maximum = _player.currentMedia.duration;
                }
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            SongListView.ItemsSource = _songService.GetAllSongs();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void AddToPlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Tag != null)
            {
                string filePath = button.Tag.ToString();

                PlaylistSelectionWindow selectionWindow = new PlaylistSelectionWindow();
                if (selectionWindow.ShowDialog() == true)
                {
                    // Get the selected playlist's ID
                    int selectedPlaylistId;
                    if (int.TryParse(selectionWindow.SelectedPlaylist, out selectedPlaylistId))
                    {
                        // Save the FilePath to the selected playlist
                        SaveSongToPlaylist(filePath, selectedPlaylistId);
                        MessageBox.Show($"Song added to the playlist successfully!");
                    }
                }
            }
        }

        private void SaveSongToPlaylist(string filePath, int playlistId)
        {
            try
            {
                _playlistService.AddSongToPlaylist(filePath, playlistId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding song to playlist: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool isShuffleEnabled = false;
        private bool isRepeatOneEnabled = false;
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            isShuffleEnabled = !isShuffleEnabled;
            ShuffleButton.Background = isShuffleEnabled ? Brushes.LightGreen : Brushes.LightGray;
        }

        private void RepeatOneButton_Click(object sender, RoutedEventArgs e)
        {
            isRepeatOneEnabled = !isRepeatOneEnabled;
            RepeatOneButton.Background = isRepeatOneEnabled ? Brushes.LightGreen : Brushes.LightGray;
        }

    }
}
