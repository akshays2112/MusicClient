using WApiGlobals = WebApis.Net6.Globals;
using static WebApis.Net6.Spotify.Globals;
using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public class WApiPlaylist
    {
        ///<summary>
        ///Get Current User's Playlists
        ///Get a list of the playlists owned or followed by the current Spotify user.
        /// </summary>
        public static async Task<Paged<Playlist>?> GetCurrentUsersPlaylists(int limit = 20, int offset = 0)
            => await WApiGlobals.CallWebApiEndpoint<Paged<Playlist>>(new()
            {
                HttpMethod = HttpMethod.Get,
                EndPointUrl = "/me/playlists",
                QueryParameters = new QueryParameter[]
                {
                    new() {
                        Name = "limit", SimpleValue = limit,
                        Constraints = new Constraint[] { new() { MinValue = 0, MaxValue = 50 } }
                    },
                    new() {
                        Name = "offset", SimpleValue = offset,
                        Constraints = new Constraint[] { new() { MinValue = 0, MaxValue = 5 } }
                    }
                }
            }, AccessToken);
    }
}
