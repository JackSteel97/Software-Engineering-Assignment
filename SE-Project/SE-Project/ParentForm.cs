using NewsAPI.Constants;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SE_Project
{
    public partial class HomeForm : Form
    {
        /// <summary>
        /// Selected category.
        /// </summary>
        private Categories SelectedCategory = Categories.Business;

        /// <summary>
        /// Flag indicating all is selected.
        /// </summary>
        private bool UseAllCategories = true;

        /// <summary>
        /// The recommender instance to reuse.
        /// </summary>
        private readonly Recommender Recommender;

        /// <summary>
        /// The index of the current article being viewed.
        /// </summary>
        private int CurrentArticleIndex = 0;

        /// <summary>
        /// An array of KeyValuePair that contains the current loaded results.
        /// </summary>
        private KeyValuePair<string, List<FullTrack>>[] Results;

        public HomeForm()
        {
            InitializeComponent();
            // Get a recommender instance.
            Recommender = new Recommender();
        }

        /// <summary>
        /// Handler for when the category selection drop-down value is changed.
        /// </summary>
        private void CategorySelector_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Get selected value.
            string val = CategorySelector.SelectedItem.ToString();

            // Is it all categories?
            if (val == "All")
            {
                UseAllCategories = true;
            }
            else
            {
                // No, parse which category it is.
                UseAllCategories = false;
                if (Enum.TryParse(val, out Categories cat))
                {
                    SelectedCategory = cat;
                }
                else
                {
                    // Fallback to All.
                    UseAllCategories = true;
                    CategorySelector.SelectedValue = "All";
                    CategorySelector.SelectedText = "All";
                }
            }
        }

        /// <summary>
        /// Handler for when the 'Get Tracks' button is clicked
        /// </summary>
        private async void GetTracksBtn_Click(object sender, EventArgs e)
        {
            // Indicate to the user that it is loading by setting the cursor.
            Cursor = Cursors.WaitCursor;
            // Clear any existing display.
            SongDisplayPanel.Controls.Clear();
            controlBarPanel.Hide();
            RecommendationsLabel.Hide();
            CurrentArticleIndex = 0;

            // Get results from the recommender.
            Dictionary<string, List<FullTrack>> result = await Recommender.GetRecommendedTracks(!UseAllCategories, SelectedCategory);
            // Dynamically size the display panel to take up most of the screen.
            SongDisplayPanel.Size = new Size(this.Width - 100, this.Height - 350);

            // Convert to an array for easy indexing.
            Results = result.ToArray();

            // Display the current article.
            ShowCurrentArticle();

            // Reset the cursor.
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Method to handle logic for displaying the current article.
        /// </summary>
        private void ShowCurrentArticle()
        {
            // Is the current article index a valid value?
            if (CurrentArticleIndex >= 0 && CurrentArticleIndex < Results.Length)
            {
                // Clear existing display
                SongDisplayPanel.Controls.Clear();
                // Display it.
                DisplayRecommendation(Results[CurrentArticleIndex]);

                // Show the container components
                controlBarPanel.Show();
                RecommendationsLabel.Show();
                showingLabel.Text = $"Showing Article {CurrentArticleIndex + 1} of {Results.Length}";
            }
            else if (CurrentArticleIndex < 0)
            {
                // The index is below 0, wrap back around to the end.
                CurrentArticleIndex = Results.Length - 1;
                ShowCurrentArticle();
            }
            else if (CurrentArticleIndex >= Results.Length)
            {
                // The index is above the end of the results, wrap back around to the start.
                CurrentArticleIndex = 0;
                ShowCurrentArticle();
            }
        }

        private void DisplayRecommendation(KeyValuePair<string, List<FullTrack>> recommendation)
        {
            // Create container.
            FlowLayoutPanel articleContainer = new FlowLayoutPanel();
            articleContainer.Size = new Size(SongDisplayPanel.Size.Width - 100, (128 * recommendation.Value.Count) + 250);

            // Disable horizontal scrolling.
            articleContainer.HorizontalScroll.Maximum = 0;
            articleContainer.AutoScroll = false;
            articleContainer.VerticalScroll.Visible = false;
            articleContainer.AutoScroll = true;
            articleContainer.WrapContents = false;
            articleContainer.BackColor = Color.FromArgb(76, 113, 131);

            articleContainer.FlowDirection = FlowDirection.TopDown;
            articleContainer.BorderStyle = BorderStyle.FixedSingle;

            // Create title label.
            Label articleTitleLabel = new Label();
            articleTitleLabel.Text = $"Article: {recommendation.Key}";
            articleTitleLabel.AutoSize = true;
            articleContainer.ForeColor = Color.White;
            articleTitleLabel.Font = new Font(FontFamily.GenericSansSerif, 32, FontStyle.Underline);
            articleTitleLabel.Top = 0;
            articleTitleLabel.Left = 0;
            articleTitleLabel.Margin = new Padding(3, 3, 3, 25);

            articleContainer.Controls.Add(articleTitleLabel);

            // Create list of songs.
            foreach (FullTrack song in recommendation.Value)
            {
                // Create song container.
                FlowLayoutPanel songContainer = new FlowLayoutPanel();
                songContainer.Size = new Size(SongDisplayPanel.Size.Width - 110, 128);
                songContainer.FlowDirection = FlowDirection.LeftToRight;

                // Create the song name label, this displays the song title and artist.
                LinkLabel songNameLabel = new LinkLabel();
                songNameLabel.Text = $"{song.Name} - {string.Join(", ", song.Artists.Select(a => a.Name))}";
                songNameLabel.AutoSize = true;
                songNameLabel.LinkColor = Color.White;
                songNameLabel.Font = new Font(FontFamily.GenericSansSerif, 18);

                // If there are external URLs available, use the first one as the link to open the song.
                if (song.ExternUrls.Count > 0)
                {
                    songNameLabel.Click += (sender, e) => Process.Start(song.ExternUrls.First().Value);
                }

                SpotifyAPI.Web.Models.Image art = song.Album.Images.FirstOrDefault();

                // If there is album art, use it.
                if (art != default)
                {
                    // Create a picture box and load the art from the provided URL.
                    PictureBox albumArtBox = new PictureBox();
                    albumArtBox.Size = new Size(128, 128);
                    albumArtBox.SizeMode = PictureBoxSizeMode.Zoom;
                    albumArtBox.Load(art.Url);
                    songContainer.Controls.Add(albumArtBox);
                }
                songContainer.Controls.Add(songNameLabel);
                articleContainer.Controls.Add(songContainer);
            }
            SongDisplayPanel.Controls.Add(articleContainer);
        }

        /// <summary>
        /// Handle the click on the next article button.
        /// </summary>
        private void nextArticleBtn_Click(object sender, EventArgs e)
        {
            CurrentArticleIndex++;
            ShowCurrentArticle();
        }

        /// <summary>
        /// Handle the click on the previous article button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prevArticleBtn_Click(object sender, EventArgs e)
        {
            CurrentArticleIndex--;
            ShowCurrentArticle();
        }
    }
}