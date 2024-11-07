using AppMediaMusic.DAL.Entities;
using AppMediaMusic.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMediaMusic.BLL.Services
{
    public class SongsService
    {
        private SongsRepository _repo = new SongsRepository();

        public void Delete(Song selected)
        {
            _repo.Delete(selected);
        }

        public List<Song> GetAllSongs()
        {
            return _repo.GetAll();
        }
        public void Add(string songName, string artist, string filePath)
        {
            _repo.Add(songName, artist, filePath);
        }


    }
}
