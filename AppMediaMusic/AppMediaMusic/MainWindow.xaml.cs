using AppMediaMusic.BLL.Services;
using AppMediaMusic.DAL.Entities;
using System.Windows;
using System.Windows.Input;

namespace AppMediaMusic
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        public User AuthenticatedUser { get; set; }
        public int UserId => AuthenticatedUser?.UserId ?? 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            HelloMsgLabel.Content = "Hello, " + AuthenticatedUser.UserId;
        }

        private void PlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            PlaylistWindow playlist = new PlaylistWindow(UserId);
            playlist.ShowDialog();

        }
     
    }
}