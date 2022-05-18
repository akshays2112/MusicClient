using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MusicClient;
using MusicClient.Data.SQLServer;
using SpotifyApi.NetCore;
using MCGlobals = MusicClient.Globals;
using WApiGlobals = WebApis.Net6.Globals;
using WApiSpotifyGlobals = WebApis.Net6.Spotify.Globals;

var builder = WebApplication.CreateBuilder(args);

MusicClientDBContext.ConnectionString = builder.Configuration.GetConnectionString("MusicClientDBConnectionString");
MCGlobals.RedirectUri = builder.Configuration.GetValue<string>("RedirectUri");
MCGlobals.SpotifyClientId = builder.Configuration.GetValue<string>("SpotifyClientId");
MCGlobals.SpotifyClientSecret = builder.Configuration.GetValue<string>("SpotifyClientSecret");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

HttpClient httpClient = new() { BaseAddress = new Uri(MCGlobals.RedirectUri) };

builder.Services.AddSingleton(typeof(HttpClient), httpClient);
builder.Services.AddSingleton(typeof(IUsersProfileApi), typeof(UsersProfileApi));
builder.Services.AddSingleton(typeof(IPlaylistsApi), typeof(PlaylistsApi));
builder.Services.AddSingleton(typeof(IAlbumsApi), typeof(AlbumsApi));
builder.Services.AddSingleton(typeof(IArtistsApi), typeof(ArtistsApi));
builder.Services.AddSingleton(typeof(ITracksApi), typeof(TracksApi));

WApiSpotifyGlobals.SpotifyClientId = MCGlobals.SpotifyClientId;
WApiSpotifyGlobals.SpotifyClientSecret = MCGlobals.SpotifyClientSecret;
WApiGlobals.HttpClient = httpClient;

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
