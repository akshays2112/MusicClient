using SpotifyApi.NetCore.Authorization;
using SpotifyApi.NetCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyApi.NetCore
{
    /// <summary>
    /// Endpoints for retrieving information about one or more albums from the Spotify catalog.
    /// </summary>
    public class AlbumsApi : SpotifyWebApi, IAlbumsApi
    {
        /// <summary>
        /// INCOMPLETE
        /// </summary>
        protected internal virtual ISearchApi SearchApi { get; set; }

        #region Constructors

        /// <summary>
        /// Instantiates a new <see cref="AlbumsApi"/>.
        /// </summary>
        /// <remarks>
        /// Use this constructor when an accessToken will be provided using the `accessToken` parameter 
        /// on each method
        /// </remarks>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/></param>
        public AlbumsApi(HttpClient httpClient) : base(httpClient)
        {
            SearchApi = new SearchApi(httpClient);
        }

        /// <summary>
        /// Instantiates a new <see cref="AlbumsApi"/>.
        /// </summary>
        /// <remarks>
        /// This constructor accepts a Spotify access token that will be used for all calls to the API 
        /// (except when an accessToken is provided using the optional `accessToken` parameter on each method).
        /// </remarks>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/></param>
        /// <param name="accessToken">A valid access token from the Spotify Accounts service</param>
        public AlbumsApi(HttpClient httpClient, string accessToken) : base(httpClient, accessToken)
        {
            SearchApi = new SearchApi(httpClient, accessToken);
        }

        /// <summary>
        /// Instantiates a new <see cref="AlbumsApi"/>.
        /// </summary>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/></param>
        /// <param name="accessTokenProvider">An instance of <see cref="IAccessTokenProvider"/>, e.g. <see cref="Authorization.AccountsService"/>.</param>
        public AlbumsApi(HttpClient httpClient, IAccessTokenProvider accessTokenProvider) : base(httpClient, accessTokenProvider)
        {
            SearchApi = new SearchApi(httpClient, accessTokenProvider);
        }

        #endregion

        #region GetAlbum

        /// <summary>
        /// Get Spotify catalog information for a single album.
        /// </summary>
        /// <param name="albumId">The Spotify ID for the album.</param>
        /// <param name="market">Optional. An ISO 3166-1 alpha-2 country code or the string `from_token` 
        /// (See <see cref="SpotifyCountryCodes"/>). Provide this parameter if you want to apply Track Relinking.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="Album"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/albums/get-album/</remarks>
        public Task<Album> GetAlbum(string albumId, string market = null, string accessToken = null)
            => GetAlbum<Album>(albumId, market: market, accessToken: accessToken);

        /// <summary>
        /// Get Spotify catalog information for a single album.
        /// </summary>
        /// <param name="albumId">The Spotify ID for the album.</param>
        /// <param name="market">Optional. An ISO 3166-1 alpha-2 country code or the string `from_token` 
        /// (See <see cref="SpotifyCountryCodes"/>). Provide this parameter if you want to apply Track Relinking.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <typeparam name="T">Optionally provide your own type to deserialise Spotify's response to.</typeparam>
        /// <returns>A Task that, once successfully completed, returns a Model of T.</returns>       
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/albums/get-album/</remarks>
        public async Task<T> GetAlbum<T>(string albumId, string market = null, string accessToken = null)
        {
            var builder = new UriBuilder($"{BaseUrl}/albums/{SpotifyUriHelper.AlbumId(albumId)}/");
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("market", market);
            return await GetModel<T>(builder.Uri, accessToken);
        }

        #endregion

        #region GetAlbumTracks

        /// <summary>
        /// Get Spotify catalog information about an album’s tracks. Optional parameters can be used to limit the number of tracks returned.
        /// </summary>
        /// <param name="albumId">The Spotify ID for the album.</param>
        /// <param name="limit">Optional. The maximum number of tracks to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first track to return. Default: 0 (the first 
        /// object). Use with limit to get the next set of tracks.</param>
        /// <param name="market">Optional. An ISO 3166-1 alpha-2 country code or the string `from_token` 
        /// (See <see cref="SpotifyCountryCodes"/>). Provide this parameter if you want to apply Track Relinking.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="Album"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/albums/get-albums-tracks/</remarks>
        public Task<Album> GetAlbumTracks(
            string albumId,
            int? limit = null,
            int offset = 0,
            string market = null,
            string accessToken = null)
            => GetAlbumTracks<Album>(albumId, limit: limit, offset: offset, market: market, accessToken: accessToken);

        /// <summary>
        /// Get Spotify catalog information about an album’s tracks. Optional parameters can be used to limit the number of tracks returned.
        /// </summary>
        /// <param name="albumId">The Spotify ID for the album.</param>
        /// <param name="limit">Optional. The maximum number of tracks to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first track to return. Default: 0 (the first 
        /// object). Use with limit to get the next set of tracks.</param>
        /// <param name="market">Optional. An ISO 3166-1 alpha-2 country code or the string `from_token` 
        /// (See <see cref="SpotifyCountryCodes"/>). Provide this parameter if you want to apply Track Relinking.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <typeparam name="T">Optionally provide your own type to deserialise Spotify's response to.</typeparam>
        /// <returns>A Task that, once successfully completed, returns a Model of T.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/albums/get-albums-tracks/</remarks>
        public async Task<T> GetAlbumTracks<T>(
            string albumId,
            int? limit = null,
            int offset = 0,
            string market = null,
            string accessToken = null)
        {
            var builder = new UriBuilder($"{BaseUrl}/albums/{SpotifyUriHelper.AlbumId(albumId)}/tracks");
            builder.AppendToQueryIfValueGreaterThan0("limit", limit);
            builder.AppendToQueryIfValueGreaterThan0("offset", offset);
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("market", market);
            return await GetModel<T>(builder.Uri, accessToken);
        }

        #endregion

        #region GetAlbums

        /// <summary>
        /// Get Spotify catalog information for multiple albums identified by their Spotify IDs.
        /// </summary>
        /// <param name="albumIds">An array of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <param name="market">Optional. An ISO 3166-1 alpha-2 country code or the string `from_token` 
        /// (See <see cref="SpotifyCountryCodes"/>). Provide this parameter if you want to apply Track Relinking.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns an array of full <see cref="Album"/> objects.</returns>
        public async Task<Album[]> GetAlbums(string[] albumIds, string market = null, string accessToken = null)
            => await GetAlbums<Album[]>(albumIds, market: market, accessToken: accessToken);

        /// <summary>
        /// Get Spotify catalog information for multiple albums identified by their Spotify IDs.
        /// </summary>
        /// <param name="albumIds">An array of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <param name="market">Optional. An ISO 3166-1 alpha-2 country code or the string `from_token` 
        /// (See <see cref="SpotifyCountryCodes"/>). Provide this parameter if you want to apply Track Relinking.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <typeparam name="T">Optionally provide your own type to deserialise Spotify's response to.</typeparam>
        /// <returns>A Task that, once successfully completed, returns a Model of T.</returns>
        public async Task<T> GetAlbums<T>(string[] albumIds, string market = null, string accessToken = null)
        {
            if (albumIds == null || albumIds.Length == 0 || string.IsNullOrEmpty(albumIds[0]))
            {
                throw new ArgumentNullException(nameof(albumIds));
            }

            var builder = new UriBuilder($"{BaseUrl}/albums");
            builder.AppendToQueryAsCsv("ids", albumIds);
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("market", market);
            return await GetModel<T>(builder.Uri, accessToken);
        }

        #endregion

        #region SearchAlbums

        /// <summary>
        /// Get Spotify Catalog information about albums that match a keyword string.
        /// </summary>
        /// <param name="query">Search query keywords and optional field filters and operators. See
        /// https://developer.spotify.com/documentation/web-api/reference/search/search/#writing-a-query---guidelines</param>
        /// <param name="market">Optional. Choose a <see cref="SpotifyCountryCodes"/>. If a country code
        /// is specified, only tracks with content that is playable in that market is returned. </param>
        /// <param name="limit">Optional. Maximum number of results to return. Default: 20, Minimum: 1,
        /// Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first result to return. Default: 0 (the
        /// first result). Maximum offset (including limit): 10,000. Use with limit to get the next
        /// page of search results.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>Task of <see cref="AlbumsSearchResult" /></returns>
        public async Task<SearchResult> SearchAlbums(
            string query,
            int? limit = null,
            int offset = 0,
            string market = null,
            string accessToken = null)
            => await SearchApi.Search<SearchResult>(
                query,
                new string[] { SpotifySearchTypes.Album },
                market: market,
                limit: limit,
                offset: offset,
                accessToken: accessToken);

        public async Task<SearchResult> SearchAlbumTracks(
            string query,
            int? limit = null,
            int offset = 0,
            string market = null,
            string accessToken = null)
            => await SearchApi.Search<SearchResult>(
                query,
                new string[] { SpotifySearchTypes.Track },
                market: market,
                limit: limit,
                offset: offset,
                accessToken: accessToken);

        #endregion

        #region GetSavedAlbums

        /// <summary>
        /// Get a list of the albums saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="limit">Optional. The maximum number of tracks to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="market">Optional. An ISO 3166-1 alpha-2 country code or the string `from_token` 
        /// (See <see cref="SpotifyCountryCodes"/>). Provide this parameter if you want to apply Track Relinking.</param>
        /// <param name="offset">Optional. The index of the first album to return. Default: 0 (the first 
        /// object). Use with limit to get the next set of tracks.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="Paged<Album>"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/#/operations/get-users-saved-albums</remarks>
        public Task<Paged<Album>> GetSavedAlbums(int? limit = null, string market = null, int offset = 0, string accessToken = null)
            => GetSavedAlbums<Album>(limit: limit, market: market, offset: offset, accessToken: accessToken);

        /// <summary>
        /// Get a list of the albums saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="market">Optional. An ISO 3166-1 alpha-2 country code or the string `from_token` 
        /// (See <see cref="SpotifyCountryCodes"/>). Provide this parameter if you want to apply Track Relinking.</param>
        /// <param name="limit">Optional. The maximum number of tracks to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first album to return. Default: 0 (the first 
        /// object). Use with limit to get the next set of tracks.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="Paged<T>"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/#/operations/get-users-saved-albums</remarks>
        public async Task<Paged<T>> GetSavedAlbums<T>(int? limit = null, string market = null, int offset = 0, string accessToken = null)
        {
            var builder = new UriBuilder($"{BaseUrl}/me/albums");
            builder.AppendToQueryIfValueGreaterThan0("limit", limit);
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("market", market);
            builder.AppendToQueryIfValueGreaterThan0("offset", offset);
            return await GetModel<Paged<T>>(builder.Uri, accessToken);
        }

        #endregion

        #region SaveAlbums

        /// <summary>
        /// Save one or more albums to the current user's 'Your Music' library.
        /// </summary>
        /// <param name="albumIds">An array of the Spotify IDs for the albums. Maximum: 20 IDs for Query Parameter or Maximum: 50 IDs for request body.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="SpotifyResponse"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/#/operations/save-albums-user</remarks>
        public Task<SpotifyResponse<Album[]>> SaveAlbums(string[] albumIds, string accessToken = null)
            => SaveAlbums<Album[]>(albumIds: albumIds, accessToken: accessToken);

        /// <summary>
        /// Save one or more albums to the current user's 'Your Music' library.
        /// </summary>
        /// <param name="albumIds">An array of the Spotify IDs for the albums. Maximum: 20 IDs for Query Parameter or Maximum: 50 IDs for request body.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="SpotifyResponse"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/#/operations/save-albums-user</remarks>
        public async Task<SpotifyResponse<T>> SaveAlbums<T>(string[] albumIds, string accessToken = null)
        {
            if (albumIds == null || albumIds.Length == 0 || string.IsNullOrEmpty(albumIds[0]) || albumIds.Length > 50)
            {
                throw new ArgumentNullException(nameof(albumIds));
            }

            var builder = new UriBuilder($"{BaseUrl}/me/albums");
            if(albumIds.Length <= 20)
            {
                builder.AppendToQueryAsCsv("ids", albumIds);
                return await Put<T>(builder.Uri, accessToken);
            }
            return await Put<T>(builder.Uri, albumIds, accessToken);
        }

        #endregion

        #region RemoveAlbums

        /// <summary>
        /// Remove one or more albums from the current user's 'Your Music' library.
        /// </summary>
        /// <param name="albumIds">An array of the Spotify IDs for the albums. Maximum: 20 IDs for Query Parameter or Maximum: 50 IDs for request body.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="SpotifyResponse"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/#/operations/save-albums-user</remarks>
        public Task<SpotifyResponse<Album[]>> RemoveAlbums(string[] albumIds, string accessToken = null)
            => RemoveAlbums(albumIds: albumIds, accessToken: accessToken);

        /// <summary>
        /// Remove one or more albums from the current user's 'Your Music' library.
        /// </summary>
        /// <param name="albumIds">An array of the Spotify IDs for the albums. Maximum: 20 IDs for Query Parameter or Maximum: 50 IDs for request body.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="SpotifyResponse"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/#/operations/save-albums-user</remarks>
        public async Task<SpotifyResponse> RemoveAlbums<T>(string[] albumIds, string accessToken = null)
        {
            if (albumIds == null || albumIds.Length == 0 || string.IsNullOrEmpty(albumIds[0]) || albumIds.Length > 50)
            {
                throw new ArgumentNullException(nameof(albumIds));
            }

            var builder = new UriBuilder($"{BaseUrl}/me/albums");
            if (albumIds.Length <= 20)
            {
                builder.AppendToQueryAsCsv("ids", albumIds);
                return await Delete<T>(builder.Uri, accessToken);
            }
            return await Delete<T>(builder.Uri, albumIds, accessToken);
        }

        #endregion

        #region CheckSavedAlbums

        /// <summary>
        /// Check if one or more albums is already saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="albumIds">An array of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="SpotifyResponse"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/#/operations/check-users-saved-albums</remarks>
        public Task<Album[]> CheckSavedAlbums(string[] albumIds, string accessToken = null) 
            => CheckSavedAlbums<Album[]>(albumIds: albumIds, accessToken: accessToken);

        /// <summary>
        /// Check if one or more albums is already saved in the current Spotify user's 'Your Music' library.
        /// </summary>
        /// <param name="albumIds">An array of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="SpotifyResponse"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/#/operations/check-users-saved-albums</remarks>
        public async Task<T> CheckSavedAlbums<T>(string[] albumIds, string accessToken = null)
        {
            if (albumIds == null || albumIds.Length == 0 || string.IsNullOrEmpty(albumIds[0]) || albumIds.Length <= 20)
            {
                throw new ArgumentNullException(nameof(albumIds));
            }

            var builder = new UriBuilder($"{BaseUrl}/me/albums/contains");
            builder.AppendToQueryAsCsv("ids", albumIds);
            return await GetModel<T>(builder.Uri, accessToken);
        }

        #endregion

        #region GetNewReleases

        /// <summary>
        /// Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">Optional. An ISO 3166-1 alpha-2 country code or the string `from_token` 
        /// (See <see cref="SpotifyCountryCodes"/>). A country: an ISO 3166-1 alpha-2 country code. Provide this parameter if 
        /// you want the list of returned items to be relevant to a particular country. If omitted, the returned albums will 
        /// be relevant to all countries.</param>
        /// <param name="limit">Optional. The maximum number of albums to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first album to return. Default: 0 (the first 
        /// object). Use with limit to get the next set of tracks.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="SpotifyResponse"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/#/operations/get-new-releases</remarks>
        public async Task<Paged<Album>> GetNewReleases(string country, int? limit = null, int offset = 0, string accessToken = null)
            => await GetNewReleases<Paged<Album>>(country: country, limit: limit, offset: offset, accessToken: accessToken);

        /// <summary>
        /// Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">Optional. An ISO 3166-1 alpha-2 country code or the string `from_token` 
        /// (See <see cref="SpotifyCountryCodes"/>). A country: an ISO 3166-1 alpha-2 country code. Provide this parameter if 
        /// you want the list of returned items to be relevant to a particular country. If omitted, the returned albums will 
        /// be relevant to all countries.</param>
        /// <param name="limit">Optional. The maximum number of albums to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first album to return. Default: 0 (the first 
        /// object). Use with limit to get the next set of tracks.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service.</param>
        /// <returns>A Task that, once successfully completed, returns a full <see cref="SpotifyResponse"/> object.</returns>
        /// <remarks>https://developer.spotify.com/documentation/web-api/reference/#/operations/get-new-releases</remarks>
        public async Task<T> GetNewReleases<T>(string country, int? limit = null, int offset = 0, string accessToken = null)
        {
            if(string.IsNullOrEmpty(country))
            {
                throw new ArgumentNullException(nameof(country));
            }

            var builder = new UriBuilder($"{BaseUrl}/browse/new-releases");
            builder.AppendToQuery("country", country);
            builder.AppendToQuery("limit", limit ?? 20);
            builder.AppendToQuery("offset", offset);
            return await GetModel<T>(builder.Uri, accessToken);
        }

        #endregion

    }
}
