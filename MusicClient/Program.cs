using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MusicClient;
using MusicClient.Data.SQLServer;
using SpotifyApi.NetCore;

var builder = WebApplication.CreateBuilder(args);

MusicClientDBContext.ConnectionString = builder.Configuration.GetConnectionString("MusicClientDBConnectionString");
Globals.RedirectUri = builder.Configuration.GetValue<string>("RedirectUri");
Globals.SpotifyClientId = builder.Configuration.GetValue<string>("SpotifyClientId");
Globals.SpotifyClientSecret = builder.Configuration.GetValue<string>("SpotifyClientSecret");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton(typeof(HttpClient), new HttpClient { BaseAddress = new Uri(Globals.RedirectUri) });
builder.Services.AddSingleton(typeof(IUsersProfileApi), typeof(UsersProfileApi));
builder.Services.AddSingleton(typeof(IPlaylistsApi), typeof(PlaylistsApi));
builder.Services.AddSingleton(typeof(IAlbumsApi), typeof(AlbumsApi));
builder.Services.AddSingleton(typeof(IArtistsApi), typeof(ArtistsApi));
builder.Services.AddSingleton(typeof(ITracksApi), typeof(TracksApi));

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
