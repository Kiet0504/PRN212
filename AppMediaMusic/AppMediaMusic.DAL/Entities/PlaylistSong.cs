using System;
using System.Collections.Generic;

namespace AppMediaMusic.DAL.Entities;

public partial class PlaylistSong
{
    public int PlaylistsongId { get; set; }

    public int PlaylistId { get; set; }

    public int SongId { get; set; }

    public DateTime? AddedAt { get; set; }

    public virtual Playlist Playlist { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;

    private void SaveSongToPlaylist(int playlistId, int songId)
    {
        using (var context = new AssignmentPrnContext())
        {
            var playlistSong = new PlaylistSong
            {
                PlaylistId = playlistId,
                SongId = songId,
                AddedAt = DateTime.Now
            };

            context.PlaylistSongs.Add(playlistSong);
            context.SaveChanges();
        }
    }

}
