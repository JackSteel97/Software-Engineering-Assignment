using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SE_Project.News
{
    /// <summary>
    /// Helper class for easily using the news API library.
    /// </summary>
    public class NewsApiHelper
    {
        /// <summary>
        /// An instance of the API client to reuse.
        /// </summary>
        private readonly NewsApiClient Client;

        /// <summary>
        /// Constructor for the helper.
        /// </summary>
        /// <param name="apiKey">NewsApi.org API Key.</param>
        public NewsApiHelper(string apiKey)
        {
            Client = new NewsApiClient(apiKey);
        }

        /// <summary>
        /// Get the current top headlines.
        /// </summary>
        /// <param name="maxResults">Limit results to this number (Max 100).</param>
        /// <param name="query">Specify a specific search query. Use null to get all.</param>
        /// <returns>A list of articles</returns>
        public async Task<List<Article>> GetTopHeadlines(int maxResults = 100, string query = null)
        {
            if (maxResults > 100)
            {
                return new List<Article>();
            }
            ArticlesResult response = await Client.GetTopHeadlinesAsync(new TopHeadlinesRequest()
            {
                Country = Countries.GB,
                PageSize = maxResults,
                Language = Languages.EN,
                Q = query
            });

            if (response.Status == Statuses.Ok)
            {
                return response.Articles;
            }
            return new List<Article>();
        }

        /// <summary>
        /// Get the current top headlines in a category.
        /// </summary>
        /// <param name="category">Category to search.</param>
        /// <param name="maxResults">Limit results to this number (Max 100).</param>
        /// <param name="query">Specify a specific search query. Use null to get all.</param>
        /// <returns>A list of articles</returns>
        public async Task<List<Article>> GetTopHeadlines(Categories category, int maxResults = 100, string query = null)
        {
            ArticlesResult response = await Client.GetTopHeadlinesAsync(new TopHeadlinesRequest()
            {
                Country = Countries.GB,
                PageSize = maxResults,
                Language = Languages.EN,
                Category = category,
                Q = query
            });

            if (response.Status == Statuses.Ok)
            {
                return response.Articles;
            }
            return new List<Article>();
        }

        /// <summary>
        /// Extract a title from an article.
        /// </summary>
        /// <param name="article">Article to extract from.</param>
        /// <returns>A title.</returns>
        public static string ExtractTitle(Article article)
        {
            string title = article.Title;

            // Remove any instance of the source in the title.
            // It is common for the title to be in the format, "<title> - <source>" e.g. "A news headline - BBC News".
            return title.Replace(article.Source.Name, "").Trim().Trim('-').Trim();
        }

        /// <summary>
        /// Extract Titles from a list of articles.
        /// </summary>
        /// <param name="articles">Articles to extract from.</param>
        /// <returns>A list of titles.</returns>
        public static List<string> ExtractTitle(List<Article> articles)
        {
            List<string> titles = new List<string>();
            foreach (Article article in articles)
            {
                titles.Add(ExtractTitle(article));
            }
            return titles;
        }
    }
}