using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesLib;

namespace CopyArtistToAlbumArtist
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var app = new iTunesApp();
            var tracks = app.LibraryPlaylist.Tracks;
            foreach (dynamic track in tracks)
            {
                if (string.IsNullOrWhiteSpace(track.AlbumArtist))
                {
                    if (track.Compilation)
                    {
                        track.AlbumArtist = track.Album;
                    }
                    else
                    {
                        track.AlbumArtist = track.Artist;
                    }
                    Console.WriteLine("Track: {0}, Artist {1}, Album Artist {2}",
                        track.Name, track.Artist, track.AlbumArtist);
                }
            }
            Console.ReadKey();
        }
    }
}
