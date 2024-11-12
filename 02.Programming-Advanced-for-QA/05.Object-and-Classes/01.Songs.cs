using System.ComponentModel;

namespace NewExercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int songs = int.Parse(Console.ReadLine());
            List<Song> songList = new List<Song>();
            for (int i = 0; i < songs; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("_")
                    .ToArray();
                Song currentSong = new Song { TypeList = input[0], Name = input[1], Time = input[2] };
                songList.Add(currentSong);
            }
            string wantedTypeList = Console.ReadLine();

            if (wantedTypeList == "all")
            {
                foreach (Song song in songList)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> filteredSongs = songList
                    .Where(s => s.TypeList == wantedTypeList)
                    .ToList();

                foreach (Song song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
