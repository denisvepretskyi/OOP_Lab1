using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab_1
{
    public class Song
    {
        private string _title; 
        private string _artist; 
        private Genre _genre; 
        private TimeSpan _duration; 
        private int _playCount;
        private DateTime _lastPlayed;
        public bool _isFavorite = false;


        public int PlayCount
        {
            get { return _playCount; }
        }

        public DateTime LastPlayed
        {
            get { return _lastPlayed; }
        }

        public Genre Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
            }
        }

        public string Duration
        {
            get => _duration.ToString(@"m\:ss");
            set
            {
                if (!TimeSpan.TryParseExact(value, new[] { @"m\:ss", @"mm\:ss" }, CultureInfo.InvariantCulture, out var ts) || value == "00:00" || value == "0:00")
                {
                    throw new FormatException("Тривалість повинна бути у форматі mm:ss");
                }
                _duration = ts;
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value.Length > 20 || value.Length < 3)
                   throw new FormatException("Помилкa: можна вводити 3-20 символів");
                else _title = value;
            }
        }

        public string Artist
        {
            get { return _artist; }
            set
            {
                if (value.Length > 20 || value.Length < 3)
                    throw new FormatException("Помилкa: можна вводити 3-20 символів");
                else _artist = value;
            }
        }

        public void Play()
        {
            _playCount++;
            _lastPlayed = DateTime.Now;
            Console.WriteLine($"\n ---  Відтворюється «{_title}» — {_artist} [{Duration:mm\\:ss}]  ---\n");

            Console.Write("00:00  ");
            for (int s = 0; s < 40; s++)
            {
                Console.Write("■");
                Thread.Sleep(100); 
            }
            Console.Write($"  {Duration}");
            Console.WriteLine("");
        }

        public string AddFavorite()
        {
            _isFavorite = true;
            return "Додано до обраного.";
        }

        public string DeleteFavorite()
        {
            _isFavorite = false;
            return "Видалено з обраного.";
        }
    }
}


