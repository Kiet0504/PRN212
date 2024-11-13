using AppMediaMusic.DAL;
using AppMediaMusic.DAL.Entities;
using AppMediaMusic.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMediaMusic.BLL.Services
{
    public class PlaylistSongService
    {
        private PlaylistSongRepository _songRepository = new();
        public List<PlaylistSong> GetSongsByPlaylistId(int playListId)
        {
            return _songRepository.GetSongsByPlaylistId(playListId);
        }

        public void Add(int playlistId, string songName, string artist, string filePath)
        {
            _songRepository.Add(playlistId, songName, artist, filePath);
        }



        public void Delete(PlaylistSong x)
        {
            _songRepository.Delete(x);
        }
        public void GetPlaylistIdBySongId(int songId)
        {

            _songRepository.GetPlaylistIdBySongId(songId);
        }

        // PlaylistSongService.cs
        public IEnumerable<PlaylistSong> GetSongsByPlaylistId2(int playlistId)
        {
            using var context = new AssignmentPrnContext();
            return context.PlaylistSongs
                          .Include(ps => ps.Song) // Eager load the Song entity
                          .Where(ps => ps.PlaylistId == playlistId)
                          .ToList();
        }


    }
}
