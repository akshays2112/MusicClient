using WebApis.Net6.Spotify.Models;
using WebApis.Net6.Spotify.Models.Responses;

namespace WebApis.Net6.Spotify.WebApiEndpoints;

public class WApiTrack : IWApiTrack
{
    private readonly IWApiGlobals _wApiGlobals;
    private readonly IWApiSpotifyGlobals _wApiSpotifyGlobals;

    public WApiTrack(IWApiGlobals wApiGlobals, IWApiSpotifyGlobals wApiSpotifyGlobals)
    {
        _wApiGlobals = wApiGlobals;
        _wApiSpotifyGlobals = wApiSpotifyGlobals;
    }

    ///<summary>
    ///Get Track
    ///Get Spotify catalog information for a single track identified by its unique Spotify ID.
    ///</summary>
    public async Task<Track?> GetTrack(string id, string? market = null,
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Track>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/tracks/{id}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
               new() { Placeholder = "{id}", SimpleValue = id }
            },
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Several Tracks
    ///Get Spotify catalog information for multiple tracks based on their Spotify IDs.
    ///</summary>
    public async Task<RTracks?> GetSeveralTracks(string[] ids, string? market = null,
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RTracks>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/tracks",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get User's Saved Tracks
    ///Get a list of the songs saved in the current Spotify user's 'Your Music' library.
    ///</summary>
    public async Task<Paged<RTrack>?> GetUsersSavedTracks(int? limit = 20,
        int? offset = 0, string? market = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<RTrack>>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/tracks",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 50, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "offset", SimpleValue = offset, Constraints = new Constraint[]
                    { new() { Value = 0, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 5, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "market", SimpleValue = market }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    public async Task<Paged<RTrack>?> GetNextPageUsersSavedTracks(string nextPage, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Paged<RTrack>>(new()
        {
            HttpMethod = HttpMethod.Get,
            PrecalculatedQueryString = nextPage
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Save Tracks for Current User
    ///Save one or more tracks to current Spotify user's library.
    ///</summary>
    public async Task<EmptyResponse?> PutSaveTracksForCurrentUser(string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Put,
            EndPointUrl = "/me/tracks",
            BodyObject = new { ids },
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Remove User's Saved Tracks
    ///Delete one or more tracks from current Spotify user's library.
    ///</summary>
    public async Task<EmptyResponse?> DeleteRemoveUsersSavedTracks(string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<EmptyResponse>(new()
        {
            HttpMethod = HttpMethod.Delete,
            EndPointUrl = "/me/tracks",
            BodyObject = new { ids }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Check User's Saved Tracks
    ///Check if one or more tracks is already saved in the current Spotify user's library.
    ///</summary>
    public async Task<bool[]?> GetCheckUsersSavedTracks(string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<bool[]>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/me/tracks/contains",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Tracks' Audio Features
    ///Get audio features for multiple tracks based on their Spotify IDs.
    ///</summary>
    public async Task<RAudioFeatures?> GetTracksAudioFeatures(string[] ids, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<RAudioFeatures>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/audio-features",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "ids", SimpleValue = ids }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Track's Audio Features
    ///Get audio feature information for a single track identified by its unique Spotify ID.
    ///</summary>
    public async Task<AudioFeature?> GetTracksAudioFeatures(string id,
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<AudioFeature>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/audio-features/{id}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
               new() { Placeholder = "{id}", SimpleValue = id }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Track's Audio Analysis
    ///Get a low-level audio analysis for a track in the Spotify catalog. The audio 
    ///analysis describes the track’s structure and musical content, including 
    ///rhythm, pitch, and timbre.
    ///</summary>
    public async Task<AudioAnalysis?> GetTracksAudioAnalysis(string id,
        string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<AudioAnalysis>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/audio-analysis/{id}",
            EndPointUrlPlaceholders = new EndPointUrlPlaceholder[]
            {
               new() { Placeholder = "{id}", SimpleValue = id }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);

    ///<summary>
    ///Get Recommendations
    ///Recommendations are generated based on the available information for a given seed 
    ///entity and matched against similar artists and tracks. If there is sufficient 
    ///information about the provided seeds, a list of tracks will be returned together 
    ///with pool size details.
    ///
    /// For artists and tracks that are very new or obscure there might not be enough 
    /// data to generate a list of tracks.
    ///</summary>
    public async Task<Recommendation?> GetRecommendations(object? obj,
        int? limit = 20, string? market = null, string? accessToken = null)
        => await _wApiGlobals.CallWebApiEndpoint<Recommendation>(new()
        {
            HttpMethod = HttpMethod.Get,
            EndPointUrl = "/recommendations",
            QuerySimpleParameters = new SimpleParameter[]
            {
                new() { Name = "limit", SimpleValue = limit, Constraints = new Constraint[]
                    { new() { Value = 1, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.GreaterThanOrEqual) },
                      new() { Value = 100, ConstraintComparison = ((int)WApiGlobals.ConstraintComparison.LessThanOrEqual) } } },
                new() { Name = "market", SimpleValue = market }
            },
            QueryObjInstance = obj,
            QueryObjParameterProperties = new ObjectParameterProperty[]
            {
                new() { PropertyName = "seed_artists" },
                new() { PropertyName = "seed_genres" },
                new() { PropertyName = "seed_tracks" },
                new() { PropertyName = "max_acousticness" },
                new() { PropertyName = "max_danceability" },
                new() { PropertyName = "max_duration_ms" },
                new() { PropertyName = "max_energy" },
                new() { PropertyName = "max_instrumentalness" },
                new() { PropertyName = "max_key" },
                new() { PropertyName = "max_liveness" },
                new() { PropertyName = "max_loudness" },
                new() { PropertyName = "max_mode" },
                new() { PropertyName = "max_popularity" },
                new() { PropertyName = "max_speechiness" },
                new() { PropertyName = "max_tempo" },
                new() { PropertyName = "max_time_signature" },
                new() { PropertyName = "max_valence" },
                new() { PropertyName = "min_acousticness" },
                new() { PropertyName = "min_danceability" },
                new() { PropertyName = "min_duration_ms" },
                new() { PropertyName = "min_energy" },
                new() { PropertyName = "min_instrumentalness" },
                new() { PropertyName = "min_key" },
                new() { PropertyName = "min_liveness" },
                new() { PropertyName = "min_loudness" },
                new() { PropertyName = "min_mode" },
                new() { PropertyName = "min_popularity" },
                new() { PropertyName = "min_speechiness" },
                new() { PropertyName = "min_tempo" },
                new() { PropertyName = "min_time_signature" },
                new() { PropertyName = "min_valence" },
                new() { PropertyName = "target_acousticness" },
                new() { PropertyName = "target_danceability" },
                new() { PropertyName = "target_duration_ms" },
                new() { PropertyName = "target_energy" },
                new() { PropertyName = "target_instrumentalness" },
                new() { PropertyName = "target_key" },
                new() { PropertyName = "target_liveness" },
                new() { PropertyName = "target_loudness" },
                new() { PropertyName = "target_mode" },
                new() { PropertyName = "target_popularity" },
                new() { PropertyName = "target_speechiness" },
                new() { PropertyName = "target_tempo" },
                new() { PropertyName = "target_time_signature" },
                new() { PropertyName = "target_valence" }
            }
        }, accessToken ?? _wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken);
}
