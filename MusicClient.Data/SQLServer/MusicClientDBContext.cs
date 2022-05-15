using Microsoft.EntityFrameworkCore;
using MusicClient.Data.SQLServer.Models.Billboard;
using MusicClient.Data.SQLServer.Models.Spotify;

namespace MusicClient.Data.SQLServer
{
    public class MusicClientDBContext : DbContext
    {
        public static string ConnectionString { get; set; } = string.Empty;

        #region Spotify
        internal virtual DbSet<SpotifyAlbum>? SpotifyAlbums { get; set; }
        internal virtual DbSet<SpotifyArtist>? SpotifyArtists { get; set; }
        internal virtual DbSet<SpotifyPlaylist>? SpotifyPlaylists { get; set; }
        internal virtual DbSet<SpotifyTrack>? SpotifyTracks { get; set; }
        internal virtual DbSet<SpotifyPlaylistTrack>? SpotifyPlaylistTracks { get; set; }
        internal virtual DbSet<SpotifyTrackAlbum>? SpotifyTrackAlbums { get; set; }
        internal virtual DbSet<SpotifyTrackArtist>? SpotifyTrackArtists { get; set; }
        #endregion

        #region Billboard
        internal virtual DbSet<BillboardSong>? BillboardSongs { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<SpotifyPlaylist>(entity => { entity.HasIndex(e => e.PlaylistID).IsUnique(); });

            //builder.Entity<SpotifyTrack>(entity => { entity.HasIndex(e => e.TrackID).IsUnique(); });

            //builder.Entity<SpotifyArtist>(entity => { entity.HasIndex(e => e.ArtistID).IsUnique(); });

            //builder.Entity<SpotifyAlbum>(entity => { entity.HasIndex(e => e.AlbumID).IsUnique(); });
        }
    }
}
