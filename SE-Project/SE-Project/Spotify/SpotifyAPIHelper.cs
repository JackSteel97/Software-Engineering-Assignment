using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System.Threading.Tasks;

namespace SE_Project.Spotify
{
    /// <summary>
    /// Helper class to make using the Spotify API a little easier
    /// </summary>
    public class SpotifyAPIHelper
    {
        // Constants simplify adjusting get request parameters
        private const string SPOTIFY_CLIENT_ID = "<YourSpotifyClientId>";

        private const string SPOTIFY_CLIENT_SECRET = "<YourSpotifyClientId";
        private const string MARKET = "gb";

        private SpotifyWebAPI spotifyAPI;

        /// <summary>
        /// Constructor that currently does nothing interesting
        /// </summary>
        public SpotifyAPIHelper() { }

        /// <summary>
        /// Initialise the Spotify API
        /// </summary>
        public async Task Init()
        {
            spotifyAPI = await createSpotifyAPI();
        }

        /// <summary>
        /// Gets tracks based on a query. Limited to 5 tracks from the GB market.
        /// </summary>
        /// <param name="query">The search term we want songs for.</param>
        /// <returns>An object containing a paged list of songs.</returns>
        public async Task<SearchItem> GetTracks(string query, int maxTracks = 3)
        {
            return await spotifyAPI.SearchItemsEscapedAsync(query, SearchType.Track, maxTracks, market: MARKET);
        }

        /// <summary>
        /// Method to create a new Spotify API client.
        /// </summary>
        /// <returns>A Spotify API client object that can be reused.</returns>
        private async Task<SpotifyWebAPI> createSpotifyAPI()
        {
            CredentialsAuth credentials = new CredentialsAuth(SPOTIFY_CLIENT_ID, SPOTIFY_CLIENT_SECRET);
            Token token = await credentials.GetToken();
            return new SpotifyWebAPI
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };
        }
    }
}