using System.Linq;
using System.Windows;
using WMPLib;
using System.IO;
using AppMediaMusic.BLL.Services;
using AppMediaMusic.DAL.Entities;

namespace AppMediaMusic
{
    public partial class MainWindow : Window
    {
        private SongsService _songService = new SongsService();
        private WindowsMediaPlayer _player = new WindowsMediaPlayer();
        private int _currentSongIndex = 0;
        private bool isDraggingSlider = false;

        public MainWindow()
        {
            InitializeComponent();
            SongDataGrid.ItemsSource = _songService.GetAllSongs();
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
            SongDataGrid.ItemsSource = null;
            SongDataGrid.ItemsSource = song;
        }

        private void DeleteSongButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = SongDataGrid.SelectedItem as Song;

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

                        _songService.Add(songName, artist, filePath, dateAdded);
                    }
                }

                FillDataGrid();
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (SongDataGrid.SelectedItem is Song selectedSong)
            {
                _player.URL = selectedSong.FilePath;
                _player.controls.play();
                // Đặt tổng thời gian của bài hát khi bắt đầu phát
                _player.PlayStateChange += Player_PlayStateChange;
                StartTimer();
            }
        }
        private void Player_PlayStateChange(int NewState)
        {
            if (NewState == (int)WMPLib.WMPPlayState.wmppsPlaying)
            {
                TotalTimeText.Text = TimeSpan.FromSeconds(_player.currentMedia.duration).ToString(@"mm\:ss");
                TimelineSlider.Maximum = _player.currentMedia.duration;
            }
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

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            _player.controls.pause();
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
            var songs = _songService.GetAllSongs();
            _currentSongIndex = (_currentSongIndex + 1) % songs.Count;
            PlaySong(songs[_currentSongIndex]);
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            var songs = _songService.GetAllSongs();
            _currentSongIndex = (_currentSongIndex - 1 + songs.Count) % songs.Count;
            PlaySong(songs[_currentSongIndex]);
        }

        private void PlaySong(Song song)
        {
            _player.URL = song.FilePath;
            _player.controls.play();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            SongDataGrid.ItemsSource = _songService.GetAllSongs();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
