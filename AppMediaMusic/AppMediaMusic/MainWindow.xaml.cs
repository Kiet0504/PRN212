using AppMediaMusic.BLL.Services;
using AppMediaMusic.DAL.Entities;
using System.Windows;
using System.Windows.Input;
using System.IO;
using WMPLib;
using Microsoft.Win32;

namespace AppMediaMusic
{

    public partial class MainWindow : Window
    {
        private SongsService _songService= new SongsService();
        public MainWindow()
        {
            InitializeComponent();
        }
        public User AuthenticatedUser { get; set; }
        public int UserId => AuthenticatedUser?.UserId ?? 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            HelloMsgLabel.Content = "Hello, " + AuthenticatedUser.UserId;
            SongDataGrid.ItemsSource = _songService.GetAllSongs();
        }

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
            var selectedItem = SongDataGrid.SelectedItem;

            Song? selected = selectedItem as Song;

            if (selected == null)
            {
                MessageBox.Show("Please select a song before delete", "Select one", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult answer = MessageBox.Show("Do you want to delete this song?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No) return;

            _songService.Delete(selected);
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

                   
                    var existingSong = _songService.GetAllSongs().FirstOrDefault(s => s.Title == songName);

                    if (existingSong != null)
                    {
                       
                        MessageBox.Show("This song already exists in the database.", "Duplicate Song", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                       
                        _songService.Add(songName, artist, filePath);
                    }
                }

                FillDataGrid();
            }
        }
    }
}