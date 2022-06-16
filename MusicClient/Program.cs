using MusicClient;
using MusicClient.Data.SQLServer;
using WebApis.Net6;
using WebApis.Net6.Spotify;
using WebApis.Net6.Spotify.WebApiEndpoints;

var builder = WebApplication.CreateBuilder(args);

MusicClientDBContext.ConnectionString = builder.Configuration.GetConnectionString("MusicClientDBConnectionString");
Globals.RedirectUri = builder.Configuration.GetValue<string>("RedirectUri");
Globals.SpotifyClientId = builder.Configuration.GetValue<string>("SpotifyClientId");
Globals.SpotifyClientSecret = builder.Configuration.GetValue<string>("SpotifyClientSecret");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<HttpClient>(context => new() { BaseAddress = new Uri(Globals.RedirectUri) });
builder.Services.AddScoped<IWApiGlobals, WApiGlobals>();
builder.Services.AddScoped<IWApiSpotifyGlobals, WApiSpotifyGlobals>(context =>
{
    WApiSpotifyGlobals wApiSpotifyGlobals = new();
    wApiSpotifyGlobals.SpotifyClientId = Globals.SpotifyClientId;
    wApiSpotifyGlobals.SpotifyClientSecret = Globals.SpotifyClientSecret;
    return wApiSpotifyGlobals;
});
builder.Services.AddScoped<ISpotifyAuthentication, SpotifyAuthentication>();
builder.Services.AddScoped<IWApiAlbum, WApiAlbum>();
builder.Services.AddScoped<IWApiArtist, WApiArtist>();
builder.Services.AddScoped<IWApiShow, WApiShow>();

//builder.Services.AddSingleton(typeof(IUsersProfileApi), typeof(UsersProfileApi));
//builder.Services.AddSingleton(typeof(IPlaylistsApi), typeof(PlaylistsApi));
//builder.Services.AddSingleton(typeof(IAlbumsApi), typeof(AlbumsApi));
//builder.Services.AddSingleton(typeof(IArtistsApi), typeof(ArtistsApi));
//builder.Services.AddSingleton(typeof(ITracksApi), typeof(TracksApi));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
