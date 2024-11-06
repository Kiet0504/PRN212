using AppMediaMusic.DAL.Entities;
using AppMediaMusic.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMediaMusic.BLL.Services
{
    public class PlaylistService
    {
        private PlaylistRepository _playlistRepository = new PlaylistRepository();
        public List<Playlist> GetPlaylistsByUserId(int userId)
        {
            return _playlistRepository.GetPlaylistsByUserId(userId);
        }
        public void CreatePlaylist(int UserId, string playlistName)
        {
            _playlistRepository.Add(UserId, playlistName);
        }
        public void UpdatePlaylist(Playlist x)
        {
            _playlistRepository.Update(x);
        }
        public void DeletePlaylist(Playlist x)
        {
            _playlistRepository.Delete(x);
        }
    }
}
