using AppMediaMusic.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMediaMusic.DAL.Repositories
{
    public class SongsRepository
    {
        private AssignmentPrnContext _context;

        public void Delete(Song selected)
        {

            _context = new AssignmentPrnContext();
            _context.Songs.Remove(selected);
            _context.SaveChanges();
        }

        public List<Song> GetAll()
        {
            _context = new();
            return _context.Songs.ToList();
            //                                 
        }
        public void Add(string songName, string artist, string filePath)
        {
            var existingSong = _context.Songs.FirstOrDefault(s => s.Title == songName);

            if (existingSong != null)
            {

                return;
            }

            Song song = new Song
            {
                Title = songName,
                Artist = artist,
                FilePath = filePath
            };
            _context.Songs.Add(song);
            _context.SaveChanges();

        }
    }
}
