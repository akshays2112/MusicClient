using WApiGlobals = WebApis.Net6.Globals;
using static WebApis.Net6.Spotify.Globals;
using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify.WebApiEndpoints
{
    public class WApiAlbum
    {
        ///<summary>
        ///Get Album
        ///Get Spotify catalog information for a single album.
        ///</summary>
        //public static async Task<Album?> GetAlbum(string id, string? market = null)
        //    => await WApiGlobals.CallWebApiEndpoint<Album>(new()
        //    {
        //        HttpMethod = HttpMethod.Get,
        //        EndPointUrl = "/playlists/{playlist_id}/followers/contains",
        //        EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
        //        {
        //            new() { Placeholder = "{playlist_id}", SimpleValue = playlist_id }
        //        },
        //        QueryParameters = new QueryParameter[]
        //        {
        //            new() { Name = "ids", SimpleValue = ids, Constraints = new Constraint[] { new() { MaxCount = 5 } } }
        //        }
        //    }, Globals.SpotifyAccessToken?.AccessToken?.AccessToken);
    }
}
