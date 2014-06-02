namespace TheTVDB_API
{
    partial class frmMain
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtMovieTitle = new System.Windows.Forms.TextBox();
            this.radDynamic = new System.Windows.Forms.RadioButton();
            this.radNormal = new System.Windows.Forms.RadioButton();
            this.btnData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(137, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(295, 160);
            this.listBox1.TabIndex = 1;
                // 
            // txtMovieTitle
            // 
            this.txtMovieTitle.Location = new System.Drawing.Point(12, 12);
            this.txtMovieTitle.Name = "txtMovieTitle";
            this.txtMovieTitle.Size = new System.Drawing.Size(119, 20);
            this.txtMovieTitle.TabIndex = 0;
            this.txtMovieTitle.TextChanged += new System.EventHandler(this.txtMovieTitle_TextChanged);
            // 
            // radDynamic
            // 
            this.radDynamic.AutoSize = true;
            this.radDynamic.Location = new System.Drawing.Point(12, 90);
            this.radDynamic.Name = "radDynamic";
            this.radDynamic.Size = new System.Drawing.Size(107, 17);
            this.radDynamic.TabIndex = 3;
            this.radDynamic.Text = "Dynamic (Slower)";
            this.radDynamic.UseVisualStyleBackColor = true;
            // 
            // radNormal
            // 
            this.radNormal.AutoSize = true;
            this.radNormal.Checked = true;
            this.radNormal.Location = new System.Drawing.Point(12, 67);
            this.radNormal.Name = "radNormal";
            this.radNormal.Size = new System.Drawing.Size(109, 17);
            this.radNormal.TabIndex = 2;
            this.radNormal.TabStop = true;
            this.radNormal.Text = "Normal (preferred)";
            this.radNormal.UseVisualStyleBackColor = true;
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(12, 149);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(119, 23);
            this.btnData.TabIndex = 4;
            this.btnData.Text = "Select";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 186);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.radNormal);
            this.Controls.Add(this.radDynamic);
            this.Controls.Add(this.txtMovieTitle);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSearch);
            this.Name = "frmMain";
            this.Text = "TMDB lib ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtMovieTitle;
        private System.Windows.Forms.RadioButton radDynamic;
        private System.Windows.Forms.RadioButton radNormal;
        private System.Windows.Forms.Button btnData;
    }
}

