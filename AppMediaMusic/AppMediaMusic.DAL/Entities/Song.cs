using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMediaMusic.DAL.Entities;

public partial class Song
{
    public int SongId { get; set; }

    public string Title { get; set; } = null!;

    public string? Artist { get; set; }

    public string? Album { get; set; }

    public string? Genre { get; set; }

    public string FilePath { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();

    [NotMapped] // Ensures that this property is not saved to the database
    public byte[] AlbumArt { get; set; }
}
