namespace SE_Project
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.CategorySelector = new System.Windows.Forms.ComboBox();
            this.CategorySelectorLabel = new System.Windows.Forms.Label();
            this.GetTracksBtn = new System.Windows.Forms.Button();
            this.SongDisplayPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.RecommendationsLabel = new System.Windows.Forms.Label();
            this.prevArticleBtn = new System.Windows.Forms.Button();
            this.nextArticleBtn = new System.Windows.Forms.Button();
            this.controlBarPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.showingLabel = new System.Windows.Forms.Label();
            this.controlBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(1418, 27);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(435, 108);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "UP-2-US";
            // 
            // CategorySelector
            // 
            this.CategorySelector.BackColor = System.Drawing.Color.White;
            this.CategorySelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CategorySelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategorySelector.ForeColor = System.Drawing.Color.Black;
            this.CategorySelector.FormattingEnabled = true;
            this.CategorySelector.Items.AddRange(new object[] {
            "All",
            "Business",
            "Entertainment",
            "Health",
            "Science",
            "Sports",
            "Technology"});
            this.CategorySelector.Location = new System.Drawing.Point(135, 102);
            this.CategorySelector.Name = "CategorySelector";
            this.CategorySelector.Size = new System.Drawing.Size(254, 33);
            this.CategorySelector.TabIndex = 1;
            this.CategorySelector.Text = "All";
            this.CategorySelector.SelectedIndexChanged += new System.EventHandler(this.CategorySelector_SelectedIndexChanged);
            // 
            // CategorySelectorLabel
            // 
            this.CategorySelectorLabel.AutoSize = true;
            this.CategorySelectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategorySelectorLabel.ForeColor = System.Drawing.Color.White;
            this.CategorySelectorLabel.Location = new System.Drawing.Point(60, 57);
            this.CategorySelectorLabel.Name = "CategorySelectorLabel";
            this.CategorySelectorLabel.Size = new System.Drawing.Size(441, 42);
            this.CategorySelectorLabel.TabIndex = 2;
            this.CategorySelectorLabel.Text = "Select a News Category";
            // 
            // GetTracksBtn
            // 
            this.GetTracksBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(121)))), ((int)(((byte)(108)))));
            this.GetTracksBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GetTracksBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetTracksBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetTracksBtn.ForeColor = System.Drawing.Color.White;
            this.GetTracksBtn.Location = new System.Drawing.Point(135, 141);
            this.GetTracksBtn.Name = "GetTracksBtn";
            this.GetTracksBtn.Size = new System.Drawing.Size(254, 58);
            this.GetTracksBtn.TabIndex = 3;
            this.GetTracksBtn.Text = "Get Tracks";
            this.GetTracksBtn.UseVisualStyleBackColor = false;
            this.GetTracksBtn.Click += new System.EventHandler(this.GetTracksBtn_Click);
            // 
            // SongDisplayPanel
            // 
            this.SongDisplayPanel.AutoScroll = true;
            this.SongDisplayPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.SongDisplayPanel.Location = new System.Drawing.Point(30, 258);
            this.SongDisplayPanel.Name = "SongDisplayPanel";
            this.SongDisplayPanel.Size = new System.Drawing.Size(1823, 759);
            this.SongDisplayPanel.TabIndex = 4;
            this.SongDisplayPanel.WrapContents = false;
            // 
            // RecommendationsLabel
            // 
            this.RecommendationsLabel.AutoSize = true;
            this.RecommendationsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecommendationsLabel.ForeColor = System.Drawing.Color.White;
            this.RecommendationsLabel.Location = new System.Drawing.Point(24, 224);
            this.RecommendationsLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 50);
            this.RecommendationsLabel.Name = "RecommendationsLabel";
            this.RecommendationsLabel.Size = new System.Drawing.Size(255, 31);
            this.RecommendationsLabel.TabIndex = 5;
            this.RecommendationsLabel.Text = "Recommendations";
            this.RecommendationsLabel.Visible = false;
            // 
            // prevArticleBtn
            // 
            this.prevArticleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(121)))), ((int)(((byte)(108)))));
            this.prevArticleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevArticleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevArticleBtn.ForeColor = System.Drawing.Color.White;
            this.prevArticleBtn.Location = new System.Drawing.Point(3, 3);
            this.prevArticleBtn.Name = "prevArticleBtn";
            this.prevArticleBtn.Size = new System.Drawing.Size(137, 67);
            this.prevArticleBtn.TabIndex = 6;
            this.prevArticleBtn.Text = "Previous";
            this.prevArticleBtn.UseVisualStyleBackColor = false;
            this.prevArticleBtn.Click += new System.EventHandler(this.prevArticleBtn_Click);
            // 
            // nextArticleBtn
            // 
            this.nextArticleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(121)))), ((int)(((byte)(108)))));
            this.nextArticleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextArticleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextArticleBtn.ForeColor = System.Drawing.Color.White;
            this.nextArticleBtn.Location = new System.Drawing.Point(549, 3);
            this.nextArticleBtn.Name = "nextArticleBtn";
            this.nextArticleBtn.Size = new System.Drawing.Size(148, 67);
            this.nextArticleBtn.TabIndex = 7;
            this.nextArticleBtn.Text = "Next";
            this.nextArticleBtn.UseVisualStyleBackColor = false;
            this.nextArticleBtn.Click += new System.EventHandler(this.nextArticleBtn_Click);
            // 
            // controlBarPanel
            // 
            this.controlBarPanel.Controls.Add(this.prevArticleBtn);
            this.controlBarPanel.Controls.Add(this.showingLabel);
            this.controlBarPanel.Controls.Add(this.nextArticleBtn);
            this.controlBarPanel.Location = new System.Drawing.Point(459, 182);
            this.controlBarPanel.Name = "controlBarPanel";
            this.controlBarPanel.Size = new System.Drawing.Size(1394, 70);
            this.controlBarPanel.TabIndex = 8;
            this.controlBarPanel.Visible = false;
            // 
            // showingLabel
            // 
            this.showingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showingLabel.ForeColor = System.Drawing.Color.White;
            this.showingLabel.Location = new System.Drawing.Point(146, 0);
            this.showingLabel.Name = "showingLabel";
            this.showingLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.showingLabel.Size = new System.Drawing.Size(397, 50);
            this.showingLabel.TabIndex = 7;
            this.showingLabel.Text = "Showing Article 1 of 32";
            this.showingLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.controlBarPanel);
            this.Controls.Add(this.RecommendationsLabel);
            this.Controls.Add(this.SongDisplayPanel);
            this.Controls.Add(this.GetTracksBtn);
            this.Controls.Add(this.CategorySelectorLabel);
            this.Controls.Add(this.CategorySelector);
            this.Controls.Add(this.TitleLabel);
            this.Name = "HomeForm";
            this.Text = "Spotify Project";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.controlBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.ComboBox CategorySelector;
        private System.Windows.Forms.Label CategorySelectorLabel;
        private System.Windows.Forms.Button GetTracksBtn;
        private System.Windows.Forms.FlowLayoutPanel SongDisplayPanel;
        private System.Windows.Forms.Label RecommendationsLabel;
        private System.Windows.Forms.Button prevArticleBtn;
        private System.Windows.Forms.Button nextArticleBtn;
        private System.Windows.Forms.FlowLayoutPanel controlBarPanel;
        private System.Windows.Forms.Label showingLabel;
    }
}

