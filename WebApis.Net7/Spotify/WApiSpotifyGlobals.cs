namespace WebApis.Net7.Spotify;

public class WApiSpotifyGlobals : IWApiSpotifyGlobals
{
    public const string ApiUrl = "https://api.spotify.com/v1";

    public string? SpotifyClientId { get; set; }
    public string? SpotifyClientSecret { get; set; }

    public SpotifyAccessToken? SpotifyAccessToken { get; set; }

    #region Enums

    public enum Scopes
    {
        user_read_playback_position, user_read_email, user_library_read, user_top_read, playlist_modify_public,
        user_follow_read, user_read_playback_state, user_modify_playback_state, user_read_private, playlist_read_private,
        user_library_modify, playlist_read_collaborative, playlist_modify_private, user_follow_modify,
        user_read_currently_playing, user_read_recently_played
    }

    public enum ArtistOrUser { artist, user }

    public enum ArtistsOrTracks { artists, tracks }

    public enum TimeRanges { long_term, medium_term, short_term }

    public enum IncludeGroups { album, single, appears_on, compilation }

    public enum TrackOrEpisode { track, episode }

    #endregion
}
