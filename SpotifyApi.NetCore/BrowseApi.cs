using SpotifyApi.NetCore.Authorization;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyApi.NetCore
{
    ///<summary>
    /// Endpoints for getting playlists and new album releases featured on Spotify's Browse tab.
    ///</summary>
    public class BrowseApi : SpotifyWebApi, IBrowseApi
    {
        #region Constructors

        ///<summary>
        /// Instantiates a new <see cref="BrowseApi"/>.
        ///</summary>
        ///<remarks>
        /// Use this constructor when an accessToken will be provided using the `accessToken` parameter 
        /// on each method
        /// </remarks>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/></param>
        public BrowseApi(HttpClient httpClient) : base(httpClient)
        {
        }

        ///<summary>
        /// Instantiates a new <see cref="BrowseApi"/>.
        ///</summary>
        ///<remarks>
        /// This constructor accepts a Spotify access token that will be used for all calls to the API 
        /// (except when an accessToken is provided using the optional `accessToken` parameter on each method).
        /// </remarks>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/></param>
        /// <param name="accessToken">A valid access token from the Spotify Accounts service</param>
        public BrowseApi(HttpClient httpClient, string accessToken) : base(httpClient, accessToken)
        {
        }

        ///<summary>
        /// Instantiates a new <see cref="BrowseApi"/>.
        ///</summary>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/></param>
        /// <param name="accessTokenProvider">An instance of <see cref="IAccessTokenProvider"/>, e.g. <see cref="Authorization.AccountsService"/>.</param>
        public BrowseApi(HttpClient httpClient, IAccessTokenProvider accessTokenProvider) : base(httpClient, accessTokenProvider)
        {
        }

        #endregion

        public async Task<string[]> GetAvailableGenreSeeds()
        {
            var url = new Uri($"{BaseUrl}/recommendations/available-genre-seeds");
            return await GetModelFromProperty<string[]>(url, "genres");
        }

        ///<summary>
        /// Get a list of categories used to tag items in Spotify (on, for example, the Spotify player's "Browse" tab).
        ///</summary>
        /// <param name="country">Optional. A country: a <see cref="SpotifyCountryCodes"/>. Provide 
        /// this parameter to ensure that the category exists for a particular country.</param>
        /// <param name="locale">Optional. The desired language, consisting of an ISO 639-1 language 
        /// code and an ISO 3166-1 alpha-2 country code, joined by an underscore. For example: es_MX, 
        /// meaning "Spanish (Mexico)". Provide this parameter if you want the category strings returned 
        /// in a particular language. Note that, if locale is not supplied, or if the specified language 
        /// is not available, the category strings returned will be in the Spotify default language 
        /// (American English).</param>
        /// <param name="limit">Optional. Maximum number of results to return. Default: 20, Minimum: 1,
        /// Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first result to return. Default: 0 (the
        /// first result). Use with limit to get the next page of search results.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service,
        /// used for this call only. See constructors for other ways to provide an access token.</param>
        /// <returns>A <see cref="PagedCategories"/> object</returns>
        ///<remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-list-categories/ </remarks>
        public Task<PagedCategories> GetCategories(
            string country = null,
            string locale = null,
            int? limit = null,
            int offset = 0,
            string accessToken = null) => GetCategories<PagedCategories>(
                country: country,
                locale: locale,
                limit: limit,
                offset: offset,
                accessToken: accessToken);

        ///<summary>
        /// Get a list of categories used to tag items in Spotify (on, for example, the Spotify player's "Browse" tab).
        ///</summary>
        /// <typeparam name="T">Type to deserialise result to.</typeparam>
        /// <param name="country">Optional. A country: a <see cref="SpotifyCountryCodes"/>. Provide 
        /// this parameter to ensure that the category exists for a particular country.</param>
        /// <param name="locale">Optional. The desired language, consisting of an ISO 639-1 language 
        /// code and an ISO 3166-1 alpha-2 country code, joined by an underscore. For example: es_MX, 
        /// meaning "Spanish (Mexico)". Provide this parameter if you want the category strings returned 
        /// in a particular language. Note that, if locale is not supplied, or if the specified language 
        /// is not available, the category strings returned will be in the Spotify default language 
        /// (American English).</param>
        /// <param name="limit">Optional. Maximum number of results to return. Default: 20, Minimum: 1,
        /// Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first result to return. Default: 0 (the
        /// first result). Use with limit to get the next page of search results.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service,
        /// used for this call only. See constructors for other ways to provide an access token.</param>
        /// <returns>Result deserialised to `T`.</returns>
        ///<remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-list-categories/ </remarks>
        public async Task<T> GetCategories<T>(string country = null, string locale = null, int? limit = null, int offset = 0, string accessToken = null)
        {
            var builder = new UriBuilder($"{BaseUrl}/browse/categories");
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("country", country);
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("locale", locale);
            builder.AppendToQueryIfValueGreaterThan0("limit", limit);
            builder.AppendToQueryIfValueGreaterThan0("offset", offset);
            return await GetModelFromProperty<T>(builder.Uri, "categories", accessToken: accessToken);
        }

        ///<summary>
        /// Get a single category used to tag items in Spotify (on, for example, the Spotify player's "Browse" tab).
        ///</summary>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">Optional. A country: a <see cref="SpotifyCountryCodes"/>. Provide 
        /// this parameter to ensure that the category exists for a particular country.</param>
        /// <param name="locale">Optional. The desired language, consisting of an ISO 639-1 language 
        /// code and an ISO 3166-1 alpha-2 country code, joined by an underscore. For example: es_MX, 
        /// meaning "Spanish (Mexico)". Provide this parameter if you want the category strings returned 
        /// in a particular language. Note that, if locale is not supplied, or if the specified language 
        /// is not available, the category strings returned will be in the Spotify default language 
        /// (American English).</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service,
        /// used for this call only. See constructors for other ways to provide an access token.</param>
        /// <returns>A <see cref="Category"/> object</returns>
        ///<remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-category/ </remarks>
        public Task<Category> GetCategory(
            string categoryId,
            string country = null,
            string locale = null,
            string accessToken = null) => GetCategory<Category>(
                categoryId,
                country: country,
                locale: locale,
                accessToken: accessToken);

        ///<summary>
        /// Get a single category used to tag items in Spotify (on, for example, the Spotify player's "Browse" tab).
        ///</summary>
        /// <typeparam name="T">Type to deserialise result to.</typeparam>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">Optional. A country: a <see cref="SpotifyCountryCodes"/>. Provide 
        /// this parameter to ensure that the category exists for a particular country.</param>
        /// <param name="locale">Optional. The desired language, consisting of an ISO 639-1 language 
        /// code and an ISO 3166-1 alpha-2 country code, joined by an underscore. For example: es_MX, 
        /// meaning "Spanish (Mexico)". Provide this parameter if you want the category strings returned 
        /// in a particular language. Note that, if locale is not supplied, or if the specified language 
        /// is not available, the category strings returned will be in the Spotify default language 
        /// (American English).</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service,
        /// used for this call only. See constructors for other ways to provide an access token.</param>
        /// <returns>Result deserialised to `T`.</returns>
        ///<remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-category/ </remarks>
        public async Task<T> GetCategory<T>(string categoryId, string country = null, string locale = null, string accessToken = null)
        {
            var builder = new UriBuilder($"{BaseUrl}/browse/categories/{categoryId}");
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("country", country);
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("locale", locale);
            return await GetModel<T>(builder.Uri, accessToken: accessToken);
        }

        ///<summary>
        /// Get a list of Spotify playlists tagged with a particular category.
        ///</summary>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">Optional. A country: a <see cref="SpotifyCountryCodes"/>. Provide 
        /// this parameter to ensure that the category exists for a particular country.</param>
        /// <param name="limit">Optional. Maximum number of results to return. Default: 20, Minimum: 1,
        /// Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first result to return. Default: 0 (the
        /// first result). Use with limit to get the next page of search results.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service,
        /// used for this call only. See constructors for other ways to provide an access token.</param>
        /// <returns>A <see cref="PagedPlaylists"/> object</returns>
        ///<remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-categorys-playlists/ </remarks>
        public Task<PagedPlaylists> GetCategoryPlaylists(
            string categoryId,
            string country = null,
            int? limit = null,
            int offset = 0,
            string accessToken = null) => GetCategoryPlaylists<PagedPlaylists>(
                categoryId,
                country: country,
                limit: limit,
                offset: offset,
                accessToken: accessToken);

        ///<summary>
        /// Get a list of Spotify playlists tagged with a particular category.
        ///</summary>
        /// <typeparam name="T">Type to deserialise result to.</typeparam>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">Optional. A country: a <see cref="SpotifyCountryCodes"/>. Provide 
        /// this parameter to ensure that the category exists for a particular country.</param>
        /// <param name="limit">Optional. Maximum number of results to return. Default: 20, Minimum: 1,
        /// Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first result to return. Default: 0 (the
        /// first result). Use with limit to get the next page of search results.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service,
        /// used for this call only. See constructors for other ways to provide an access token.</param>
        /// <returns>Result deserialised to `T`.</returns>
        ///<remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-categorys-playlists/ </remarks>
        public async Task<T> GetCategoryPlaylists<T>(
            string categoryId,
            string country = null,
            int? limit = null,
            int offset = 0,
            string accessToken = null)
        {
            var builder = new UriBuilder($"{BaseUrl}/browse/categories/{categoryId}/playlists");
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("country", country);
            builder.AppendToQueryIfValueGreaterThan0("limit", limit);
            builder.AppendToQueryIfValueGreaterThan0("offset", offset);
            return await GetModelFromProperty<T>(builder.Uri, "playlists", accessToken: accessToken);
        }

        ///<summary>
        /// Get a list of Spotify featured playlists (shown, for example, on a Spotify player's "Browse" tab).
        ///</summary>
        /// <param name="country">Optional. A country: a <see cref="SpotifyCountryCodes"/>. Provide 
        /// this parameter to ensure that the category exists for a particular country.</param>
        /// <param name="locale">Optional. The desired language, consisting of an ISO 639-1 language 
        /// code and an ISO 3166-1 alpha-2 country code, joined by an underscore. For example: es_MX, 
        /// meaning "Spanish (Mexico)". Provide this parameter if you want the category strings returned 
        /// in a particular language. Note that, if locale is not supplied, or if the specified language 
        /// is not available, the category strings returned will be in the Spotify default language 
        /// (American English).</param>
        /// <param name="timestamp">Optional. Use this parameter to specify the user�s local time to 
        /// get results tailored for that specific date and time in the day. If not provided, the response 
        /// defaults to the current UTC time. If there were no featured playlists (or there is no data) 
        /// at the specified time, the response will revert to the current UTC time.</param>
        /// <param name="limit">Optional. Maximum number of results to return. Default: 20, Minimum: 1,
        /// Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first result to return. Default: 0 (the
        /// first result). Use with limit to get the next page of search results.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service,
        /// used for this call only. See constructors for other ways to provide an access token.</param>
        /// <returns>A <see cref="FeaturedPlaylists"/> object</returns>
        ///<remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-list-featured-playlists/ </remarks>
        public Task<FeaturedPlaylists> GetFeaturedPlaylists(
            string country = null,
            string locale = null,
            DateTime? timestamp = null,
            int? limit = null,
            int offset = 0,
            string accessToken = null) => GetFeaturedPlaylists<FeaturedPlaylists>(
                country: country,
                locale: locale,
                timestamp: timestamp,
                limit: limit,
                offset: offset,
                accessToken: accessToken);

        ///<summary>
        /// Get a list of Spotify featured playlists (shown, for example, on a Spotify player's "Browse" tab).
        ///</summary>
        /// <typeparam name="T">Type to deserialise result to.</typeparam>
        /// <param name="country">Optional. A country: a <see cref="SpotifyCountryCodes"/>. Provide 
        /// this parameter to ensure that the category exists for a particular country.</param>
        /// <param name="locale">Optional. The desired language, consisting of an ISO 639-1 language 
        /// code and an ISO 3166-1 alpha-2 country code, joined by an underscore. For example: es_MX, 
        /// meaning "Spanish (Mexico)". Provide this parameter if you want the category strings returned 
        /// in a particular language. Note that, if locale is not supplied, or if the specified language 
        /// is not available, the category strings returned will be in the Spotify default language 
        /// (American English).</param>
        /// <param name="timestamp">Optional. Use this parameter to specify the user�s local time to 
        /// get results tailored for that specific date and time in the day. If not provided, the response 
        /// defaults to the current UTC time. If there were no featured playlists (or there is no data) 
        /// at the specified time, the response will revert to the current UTC time.</param>
        /// <param name="limit">Optional. Maximum number of results to return. Default: 20, Minimum: 1,
        /// Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first result to return. Default: 0 (the
        /// first result). Use with limit to get the next page of search results.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service,
        /// used for this call only. See constructors for other ways to provide an access token.</param>
        /// <returns>Result deserialised to `T`.</returns>
        ///<remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-list-featured-playlists/ </remarks>
        public async Task<T> GetFeaturedPlaylists<T>(
            string country = null,
            string locale = null,
            DateTime? timestamp = null,
            int? limit = null,
            int offset = 0,
            string accessToken = null)
        {
            var builder = new UriBuilder($"{BaseUrl}/browse/featured-playlists");
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("country", country);
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("locale", locale);
            builder.AppendToQueryAsTimestampIso8601("timestamp", timestamp);
            builder.AppendToQueryIfValueGreaterThan0("limit", limit);
            builder.AppendToQueryIfValueGreaterThan0("offset", offset);
            return await GetModelFromProperty<T>(builder.Uri, "playlists", accessToken: accessToken);
        }

        ///<summary>
        /// Get a list of new album releases featured in Spotify (shown, for example, on a Spotify 
        /// player's "Browse" tab).
        ///</summary>
        /// <param name="country">Optional. Choose a <see cref="SpotifyCountryCodes"/>. If a country code
        /// is specified, only artists, albums, and tracks with content that is playable in that market 
        /// is returned. Note: Playlist results are not affected by the market parameter.</param>
        /// <param name="limit">Optional. Maximum number of results to return. Default: 20, Minimum: 1,
        /// Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first result to return. Default: 0 (the
        /// first result). Use with limit to get the next page of search results.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service,
        /// used for this call only. See constructors for more ways to provide access tokens.</param>
        /// <returns>Array of <see cref="Album"/></returns>
        ///<remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-list-new-releases/ </remarks>
        public Task<PagedAlbums> GetNewReleases(
            string country = null,
            int? limit = null,
            int offset = 0,
            string accessToken = null) => GetNewReleases<PagedAlbums>(country, limit, offset, accessToken);

        ///<summary>
        /// Get a list of new album releases featured in Spotify (shown, for example, on a Spotify 
        /// player's "Browse" tab).
        ///</summary>
        /// <typeparam name="T">Type to deserialise result to.</typeparam>
        /// <param name="country">Optional. Choose a <see cref="SpotifyCountryCodes"/>. If a country code
        /// is specified, only artists, albums, and tracks with content that is playable in that market 
        /// is returned. Note: Playlist results are not affected by the market parameter.</param>
        /// <param name="limit">Optional. Maximum number of results to return. Default: 20, Minimum: 1,
        /// Maximum: 50.</param>
        /// <param name="offset">Optional. The index of the first result to return. Default: 0 (the
        /// first result). Use with limit to get the next page of search results.</param>
        /// <param name="accessToken">Optional. A valid access token from the Spotify Accounts service,
        /// used for this call only. See constructors for more ways to provide access tokens.</param>
        /// <returns>Result deserialised to `T`.</returns>
        ///<remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-list-new-releases/ </remarks>
        public async Task<T> GetNewReleases<T>(
            string country = null,
            int? limit = null,
            int offset = 0,
            string accessToken = null)
        {
            var builder = new UriBuilder($"{BaseUrl}/browse/new-releases");
            builder.AppendToQueryIfValueNotNullOrWhiteSpace("country", country);
            builder.AppendToQueryIfValueGreaterThan0("limit", limit);
            builder.AppendToQueryIfValueGreaterThan0("offset", offset);
            return await GetModelFromProperty<T>(builder.Uri, "albums", accessToken: accessToken);
        }

        ///<summary>
        /// Create a playlist-style listening experience based on seed artists, tracks and genres.
        ///</summary>
        /// <param name="seedArtists">An array of Spotify IDs for seed Artists. Up to 5 seed values 
        /// may be provided in any combination of Artists, Tracks and Genres.</param>
        /// <param name="seedGenres">An array of available seed Genres. Up to 5 seed values 
        /// may be provided in any combination of Artists, Tracks and Genres. <seealso cref="GetAvailableGenreSeeds"/>.</param>
        /// <param name="seedTracks">An array of Spotify IDs for seed Tracks. Up to 5 seed values 
        /// may be provided in any combination of Artists, Tracks and Genres.</param>
        /// <param name="limit">Optional. The target size of the list of recommended tracks. Default:
        /// 20. Minimum: 1. Maximum: 100.</param>
        /// <returns><see cref="RecommendationsResult"/></returns>
        ///<remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-recommendations/ </remarks>
        public async Task<RecommendationsResult> GetRecommendations(
            string[] seedArtists = null,
            string[] seedGenres = null,
            string[] seedTracks = null,
            int? limit = null,
            string accessToken = null)
            => await GetRecommendations<RecommendationsResult>(
                seedArtists: seedArtists,
                seedGenres: seedGenres,
                seedTracks: seedTracks,
                limit: limit,
                accessToken: accessToken);

        ///<summary>
        /// Create a playlist-style listening experience based on seed artists, tracks and genres.
        ///</summary>
        /// <typeparam name="T">Type to deserialise result to.</typeparam>
        /// <param name="seedArtists">An array of Spotify IDs for seed Artists. Up to 5 seed values 
        /// may be provided in any combination of Artists, Tracks and Genres. <seealso cref="GetAvailableGenreSeeds"/>.</param>
        /// <param name="seedGenres">An array of available seed Genres. Up to 5 seed values 
        /// may be provided in any combination of Artists, Tracks and Genres.</param>
        /// <param name="seedTracks">An array of Spotify IDs for seed Tracks. Up to 5 seed values 
        /// may be provided in any combination of Artists, Tracks and Genres.</param>
        /// <param name="limit">Optional. The target size of the list of recommended tracks. Default:
        /// 20. Minimum: 1. Maximum: 100.</param>
        /// <param name="limit"></param>
        /// <returns>Result deserialised to `T`.</returns>
        public async Task<T> GetRecommendations<T>(
            string[] seedArtists = null,
            string[] seedGenres = null,
            string[] seedTracks = null,
            int? limit = null,
            string accessToken = null)
        {
            if (seedArtists == null && seedGenres == null && seedTracks == null)
                throw new ArgumentException("At least one of `seedArtists`, `seedGenres` or `seedTracks` must be provided.");

            var builder = new UriBuilder($"{BaseUrl}/recommendations");
            builder.AppendToQueryAsCsv("seed_artists", seedArtists);
            builder.AppendToQueryAsCsv("seed_genres", seedGenres);
            builder.AppendToQueryAsCsv("seed_tracks", seedTracks);
            builder.AppendToQueryIfValueGreaterThan0("limit", limit);
            return await GetModel<T>(builder.Uri, accessToken);
        }
    }
}
