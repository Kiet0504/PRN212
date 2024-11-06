using AppMediaMusic.DAL.Entities;
using AppMediaMusic.DAL.Repositories;
using System;
using System.Collections.Generic;
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

        public void Add(int playlistId, string filePath)
        {
            _songRepository.Add(playlistId, filePath);
        }



        public void Delete(PlaylistSong x)
        {
            _songRepository.Delete(x);
        }
        public void GetPlaylistIdBySongId(int songId)
        {
           
            _songRepository.GetPlaylistIdBySongId(songId);
        }

    }
}
