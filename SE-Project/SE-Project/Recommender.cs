using NewsAPI.Constants;
using NewsAPI.Models;
using SE_Project.News;
using SE_Project.NewsApi;
using SE_Project.Spotify;
using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Project
{
    /// <summary>
    /// This class joins together the news and spotify APIs into a single song recommender that utilises both data sources.
    /// </summary>
    public class Recommender
    {
        /// <summary>
        /// The new API interface helper.
        /// </summary>
        private readonly NewsApiHelper NewsApiHelper;

        /// <summary>
        /// The Spotify API helper.
        /// </summary>
        private readonly SpotifyAPIHelper SpotifyAPIHelper;

        /// <summary>
        /// The keyword helper instance.
        /// </summary>
        private readonly KeywordHelper KeywordHelper;

        /// <summary>
        /// A basic cache, the outer key is the cache key, the value is a dictionary of article titles and their tracks.
        /// </summary>
        private readonly static Dictionary<string, Dictionary<string, List<FullTrack>>> RecommendationCache = new Dictionary<string, Dictionary<string, List<FullTrack>>>();

        /// <summary>
        /// Constructor for the recommender class.
        /// </summary>
        public Recommender()
        {
            // Initialise the helpers.
            NewsApiHelper = new NewsApiHelper("<YourNewsApiKey>");
            SpotifyAPIHelper = new SpotifyAPIHelper();
            KeywordHelper = new KeywordHelper();
        }

        /// <summary>
        /// Get recommended tracks for today in a given category.
        /// </summary>
        /// <param name="useCategory">If true the category provided will be used, otherwise it is ignored.</param>
        /// <param name="category">Category to filter by.</param>
        /// <returns></returns>
        public async Task<Dictionary<string, List<FullTrack>>> GetRecommendedTracks(bool useCategory, Categories category)
        {
            // Construct a unique cache key.
            string cacheKey;
            if (useCategory)
            {
                cacheKey = category.ToString();
            }
            else
            {
                cacheKey = "All";
            }

            // Check if the result has been cached.
            if (RecommendationCache.ContainsKey(cacheKey))
            {
                return RecommendationCache[cacheKey];
            }

            // It has not been cached, gather the data required to generate a new result.
            await SpotifyAPIHelper.Init();

            // Get headlines and their keywords.
            Dictionary<string, List<string>> headlineKeywords = await GetTodaysKeywords(useCategory, category);

            // Get headlines and their tracks.
            Dictionary<string, List<FullTrack>> result = await GetTracksFromKeywords(headlineKeywords);

            // Add to the cache.
            RecommendationCache.Add(cacheKey, result);
            return result;
        }

        /// <summary>
        /// Get Spotify tracks from keywords.
        /// </summary>
        /// <param name="headlineKeywords">A dictionary of Key: full headline, and Value: collection of keywords.</param>
        /// <returns>A dictionary of Key: full headline, and Value: collection of Spotify tracks.</returns>
        private async Task<Dictionary<string, List<FullTrack>>> GetTracksFromKeywords(Dictionary<string, List<string>> headlineKeywords)
        {
            // Initialise a dictionary for the result, the same size as the input.
            Dictionary<string, List<FullTrack>> tracksWithHeadline = new Dictionary<string, List<FullTrack>>(headlineKeywords.Count);

            // Iterate the headlines.
            foreach (KeyValuePair<string, List<string>> headline in headlineKeywords)
            {
                // Initialise a list of tracks the same size as the number of keywords in this headline.
                List<FullTrack> topTracks = new List<FullTrack>(headline.Value.Count);

                // Iterate the keywords in this headline.
                foreach (string keyword in headline.Value)
                {
                    // Get the top track for this word.
                    SearchItem result = await SpotifyAPIHelper.GetTracks(keyword, 1);
                    // Add to topTracks.
                    FullTrack trackResult = result?.Tracks?.Items.FirstOrDefault();
                    if (trackResult != default)
                    {
                        topTracks.Add(trackResult);
                    }
                }
                // Add to output.
                tracksWithHeadline.Add(headline.Key, topTracks);
            }

            // Remove headlines with no results.
            return tracksWithHeadline.Where(h => h.Value.Count > 0).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Get today's keywords from the news API.
        /// </summary>
        /// <param name="useCategory">If true, the provided category will be used.</param>
        /// <param name="category">The category to filter by if required.</param>
        /// <returns></returns>
        private async Task<Dictionary<string, List<string>>> GetTodaysKeywords(bool useCategory, Categories category)
        {
            // Get today's headlines.
            List<Article> articles;
            if (useCategory)
            {
                articles = await NewsApiHelper.GetTopHeadlines(category);
            }
            else
            {
                articles = await NewsApiHelper.GetTopHeadlines();
            }

            // Get the titles from those headlines.
            List<string> headlines = NewsApiHelper.ExtractTitle(articles);

            // Get Keywords into a list.
            Dictionary<string, List<string>> keywordCollection = new Dictionary<string, List<string>>(headlines.Count);
            foreach (string headline in headlines)
            {
                keywordCollection.Add(headline, KeywordHelper.GetKeyWords(headline));
            }

            return keywordCollection;
        }
    }
}