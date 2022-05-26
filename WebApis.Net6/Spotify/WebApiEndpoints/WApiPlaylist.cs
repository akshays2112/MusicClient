using WApiGlobals = WebApis.Net6.Globals;
using WApiSpotifyGlobals = WebApis.Net6.Spotify.Globals;
using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints;

public class WApiPlaylist
{
    ///<summary>
    ///Get Current User's Playlists
    ///Get a list of the playlists owned or followed by the current Spotify user.
    /// </summary>
    public static async Task<Paged<Playlist>?> GetCurrentUsersPlaylists(int limit = 20,
        int offset = 0, string? accessToken = null)
        => await WApiGlobals.CallWebApiEndpoint<Paged<Playlist>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/playlists",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
            }
        }, accessToken ?? WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
