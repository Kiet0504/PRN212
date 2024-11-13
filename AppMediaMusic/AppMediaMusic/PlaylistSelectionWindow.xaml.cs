using AppMediaMusic.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppMediaMusic
{
    public partial class PlaylistSelectionWindow : Window
    {
        public string SelectedPlaylist { get; private set; }

        public PlaylistSelectionWindow()
        {
            InitializeComponent();
            LoadPlaylists();
        }

        private void LoadPlaylists()
        {
            using (var context = new AssignmentPrnContext())
            {
                var playlists = context.Playlists
                                       .Select(p => new { p.PlaylistId, p.Name })
                                       .ToList();

                PlaylistComboBox.ItemsSource = playlists;
                PlaylistComboBox.DisplayMemberPath = "Name"; 
                PlaylistComboBox.SelectedValuePath = "PlaylistId";
            }
        }


        private void AddToPlaylist_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlaylist = PlaylistComboBox.SelectedItem;
            if (selectedPlaylist != null)
            {
                int playlistId = (int)PlaylistComboBox.SelectedValue;
                SelectedPlaylist = playlistId.ToString();

                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please select a playlist.");
            }
        }

    }
}
