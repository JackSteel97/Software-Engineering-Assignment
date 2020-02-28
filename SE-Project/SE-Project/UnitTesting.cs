using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web.Models;

namespace SE_Project
{
    public class NewsApiUnitTesting
    {

        private News.NewsApiHelper newsApiHelper;

        public NewsApiUnitTesting()
        {
            newsApiHelper = new News.NewsApiHelper("ca30cc426499449b805c020afd60bf2f");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(40)]
        public async Task TestMaxLimitForGetTopHeadlines(int val)
        {
            int numHeadlines = (await newsApiHelper.GetTopHeadlines(val)).Count;
            Assert.True(numHeadlines <= val, $"The number of headlines returned ({numHeadlines}) was greater than the limit passed in");
        }

        [Theory]
        [InlineData(101)]
        [InlineData(4000)]
        public async Task TestMaxLimitForGetTopHeadlinesFails(int val)
        {
            int count = (await newsApiHelper.GetTopHeadlines(val)).Count;
            Assert.Equal(0, count);
        }
    }

    public class KeywordHelperUnitTesting
    {
        private NewsApi.KeywordHelper keywordHelper;

        public KeywordHelperUnitTesting()
        {
            keywordHelper = new NewsApi.KeywordHelper();
        }

        [Theory]
        [InlineData("Extract my Keywords")]
        [InlineData("The Dish Ran Away with the Spoon")]
        [InlineData("The Death of Political Debate")]
        public void TestKeywordExtraction(string content)
        {
            List<string> inlineSmallWords = new List<string>() { "my", "the", "with", "of" };
            List<string> keywords = keywordHelper.GetKeyWords(content);
            
            foreach (string word in inlineSmallWords)
            {
                Assert.DoesNotContain(word, keywords);
            }
            
        }
    }

    public class SpotifyAPIHelperUnitTesting
    {
        private Spotify.SpotifyAPIHelper spotifyApi;
        public SpotifyAPIHelperUnitTesting()
        {
            spotifyApi = new Spotify.SpotifyAPIHelper();
            spotifyApi.Init().Wait();
        }

        [Theory]
        [InlineData("Rock music", 3)]
        [InlineData("Porter Robinson", 50)]
        public async Task TestSpotifyGetTracks(string query, int maxSongs)
        {
            SearchItem searchResults = await spotifyApi.GetTracks(query, maxSongs);
            Assert.Equal(maxSongs, searchResults.Tracks.Items.Count);
        }

        [Theory]
        [InlineData(5000)]
        [InlineData(51)]
        public async Task TestSpotifyGetTracksFails(int maxSongs)
        {
            SearchItem searchResults = await spotifyApi.GetTracks("example query", maxSongs);
            Assert.Empty(searchResults.Tracks.Items);
        }
    }
}
