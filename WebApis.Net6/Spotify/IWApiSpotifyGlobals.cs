namespace WebApis.Net6.Spotify
{
    public interface IWApiSpotifyGlobals
    {
        SpotifyAccessToken? SpotifyAccessToken { get; set; }
        string? SpotifyClientId { get; set; }
        string? SpotifyClientSecret { get; set; }
    }
}