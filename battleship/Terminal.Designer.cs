namespace battleship
{
    partial class Terminal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminal));
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonPlayAgain = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonShowStats = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelTimesUntilWin = new System.Windows.Forms.Label();
            this.labelTimeNeed = new System.Windows.Forms.Label();
            this.labelWinsUser = new System.Windows.Forms.Label();
            this.labelWinsBot = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.BackColor = System.Drawing.Color.Transparent;
            this.labelResult.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelResult.Location = new System.Drawing.Point(102, 52);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(47, 14);
            this.labelResult.TabIndex = 0;
            this.labelResult.Text = "Result";
            // 
            // buttonPlayAgain
            // 
            this.buttonPlayAgain.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayAgain.Location = new System.Drawing.Point(499, 333);
            this.buttonPlayAgain.Name = "buttonPlayAgain";
            this.buttonPlayAgain.Size = new System.Drawing.Size(75, 23);
            this.buttonPlayAgain.TabIndex = 1;
            this.buttonPlayAgain.Text = "Play Again";
            this.buttonPlayAgain.UseVisualStyleBackColor = true;
            this.buttonPlayAgain.Click += new System.EventHandler(this.buttonPlayAgain_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(856, 415);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonShowStats
            // 
            this.buttonShowStats.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowStats.Location = new System.Drawing.Point(358, 333);
            this.buttonShowStats.Name = "buttonShowStats";
            this.buttonShowStats.Size = new System.Drawing.Size(75, 23);
            this.buttonShowStats.TabIndex = 3;
            this.buttonShowStats.Text = "Show Stats";
            this.buttonShowStats.UseVisualStyleBackColor = true;
            this.buttonShowStats.Click += new System.EventHandler(this.buttonShowStats_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(358, 158);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(216, 124);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // labelTimesUntilWin
            // 
            this.labelTimesUntilWin.AutoSize = true;
            this.labelTimesUntilWin.BackColor = System.Drawing.Color.Transparent;
            this.labelTimesUntilWin.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimesUntilWin.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelTimesUntilWin.Location = new System.Drawing.Point(102, 91);
            this.labelTimesUntilWin.Name = "labelTimesUntilWin";
            this.labelTimesUntilWin.Size = new System.Drawing.Size(44, 14);
            this.labelTimesUntilWin.TabIndex = 5;
            this.labelTimesUntilWin.Text = "label1";
            // 
            // labelTimeNeed
            // 
            this.labelTimeNeed.AutoSize = true;
            this.labelTimeNeed.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeNeed.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeNeed.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelTimeNeed.Location = new System.Drawing.Point(102, 125);
            this.labelTimeNeed.Name = "labelTimeNeed";
            this.labelTimeNeed.Size = new System.Drawing.Size(32, 14);
            this.labelTimeNeed.TabIndex = 6;
            this.labelTimeNeed.Text = "Time";
            // 
            // labelWinsUser
            // 
            this.labelWinsUser.AutoSize = true;
            this.labelWinsUser.BackColor = System.Drawing.Color.Transparent;
            this.labelWinsUser.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinsUser.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelWinsUser.Location = new System.Drawing.Point(254, 52);
            this.labelWinsUser.Name = "labelWinsUser";
            this.labelWinsUser.Size = new System.Drawing.Size(44, 14);
            this.labelWinsUser.TabIndex = 7;
            this.labelWinsUser.Text = "label1";
            // 
            // labelWinsBot
            // 
            this.labelWinsBot.AutoSize = true;
            this.labelWinsBot.BackColor = System.Drawing.Color.Transparent;
            this.labelWinsBot.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinsBot.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelWinsBot.Location = new System.Drawing.Point(254, 91);
            this.labelWinsBot.Name = "labelWinsBot";
            this.labelWinsBot.Size = new System.Drawing.Size(44, 14);
            this.labelWinsBot.TabIndex = 8;
            this.labelWinsBot.Text = "label2";
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(943, 450);
            this.Controls.Add(this.labelWinsBot);
            this.Controls.Add(this.labelWinsUser);
            this.Controls.Add(this.labelTimeNeed);
            this.Controls.Add(this.labelTimesUntilWin);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonShowStats);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonPlayAgain);
            this.Controls.Add(this.labelResult);
            this.Name = "Terminal";
            this.Load += new System.EventHandler(this.Terminal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonPlayAgain;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonShowStats;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelTimesUntilWin;
        private System.Windows.Forms.Label labelTimeNeed;
        private System.Windows.Forms.Label labelWinsUser;
        private System.Windows.Forms.Label labelWinsBot;
    }
}