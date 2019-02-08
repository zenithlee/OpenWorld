namespace OpenWorld.Forms
{
  partial class ImageUploader
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageUploader));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.CloseButton = new System.Windows.Forms.Button();
      this.SelectFileButton = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.UploadButton = new System.Windows.Forms.Button();
      this.UploadProgressBar = new System.Windows.Forms.TrackBar();
      this.label1 = new System.Windows.Forms.Label();
      this.StatusText = new System.Windows.Forms.Label();
      this.HDBox = new System.Windows.Forms.CheckBox();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.UploadProgressBar)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 5;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.Controls.Add(this.CloseButton, 4, 0);
      this.tableLayoutPanel1.Controls.Add(this.SelectFileButton, 2, 2);
      this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.UploadButton, 3, 2);
      this.tableLayoutPanel1.Controls.Add(this.UploadProgressBar, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.StatusText, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.HDBox, 1, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 5;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(639, 501);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // CloseButton
      // 
      this.CloseButton.BackColor = System.Drawing.Color.Silver;
      this.CloseButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CloseButton.FlatAppearance.BorderSize = 0;
      this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.CloseButton.Location = new System.Drawing.Point(607, 0);
      this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
      this.CloseButton.Name = "CloseButton";
      this.CloseButton.Size = new System.Drawing.Size(32, 32);
      this.CloseButton.TabIndex = 7;
      this.CloseButton.Text = "x";
      this.CloseButton.UseVisualStyleBackColor = false;
      this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
      // 
      // SelectFileButton
      // 
      this.SelectFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
      this.SelectFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SelectFileButton.FlatAppearance.BorderSize = 0;
      this.SelectFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SelectFileButton.Location = new System.Drawing.Point(408, 430);
      this.SelectFileButton.Margin = new System.Windows.Forms.Padding(1);
      this.SelectFileButton.Name = "SelectFileButton";
      this.SelectFileButton.Size = new System.Drawing.Size(98, 30);
      this.SelectFileButton.TabIndex = 1;
      this.SelectFileButton.Text = "Select File...";
      this.SelectFileButton.UseVisualStyleBackColor = false;
      this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
      // 
      // pictureBox1
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 5);
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.Location = new System.Drawing.Point(3, 35);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(633, 391);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      // 
      // UploadButton
      // 
      this.UploadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
      this.UploadButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.UploadButton.FlatAppearance.BorderSize = 0;
      this.UploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.UploadButton.Location = new System.Drawing.Point(508, 430);
      this.UploadButton.Margin = new System.Windows.Forms.Padding(1);
      this.UploadButton.Name = "UploadButton";
      this.UploadButton.Size = new System.Drawing.Size(98, 30);
      this.UploadButton.TabIndex = 4;
      this.UploadButton.Text = "Upload";
      this.UploadButton.UseVisualStyleBackColor = false;
      this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
      // 
      // UploadProgressBar
      // 
      this.UploadProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.UploadProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
      this.UploadProgressBar.Enabled = false;
      this.UploadProgressBar.Location = new System.Drawing.Point(3, 432);
      this.UploadProgressBar.Maximum = 100;
      this.UploadProgressBar.Name = "UploadProgressBar";
      this.UploadProgressBar.Size = new System.Drawing.Size(351, 26);
      this.UploadProgressBar.TabIndex = 6;
      this.UploadProgressBar.TickFrequency = 10;
      this.UploadProgressBar.TickStyle = System.Windows.Forms.TickStyle.None;
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
      this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Margin = new System.Windows.Forms.Padding(0);
      this.label1.Name = "label1";
      this.label1.Padding = new System.Windows.Forms.Padding(5);
      this.label1.Size = new System.Drawing.Size(607, 32);
      this.label1.TabIndex = 8;
      this.label1.Text = "File Upload";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // StatusText
      // 
      this.StatusText.AutoSize = true;
      this.StatusText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.StatusText.ForeColor = System.Drawing.Color.Silver;
      this.StatusText.Location = new System.Drawing.Point(3, 461);
      this.StatusText.Name = "StatusText";
      this.StatusText.Size = new System.Drawing.Size(351, 27);
      this.StatusText.TabIndex = 9;
      this.StatusText.Text = "Select a file to upload";
      this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // HDBox
      // 
      this.HDBox.AutoSize = true;
      this.HDBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.HDBox.ForeColor = System.Drawing.Color.White;
      this.HDBox.Location = new System.Drawing.Point(360, 432);
      this.HDBox.Name = "HDBox";
      this.HDBox.Size = new System.Drawing.Size(44, 26);
      this.HDBox.TabIndex = 10;
      this.HDBox.Text = "HD";
      this.HDBox.UseVisualStyleBackColor = true;
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // ImageUploader
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(639, 501);
      this.Controls.Add(this.tableLayoutPanel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ImageUploader";
      this.ShowInTaskbar = false;
      this.Text = "ImageUploader";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.UploadProgressBar)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button UploadButton;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.TrackBar UploadProgressBar;
    private System.Windows.Forms.Button CloseButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button SelectFileButton;
    private System.Windows.Forms.Label StatusText;
    private System.Windows.Forms.CheckBox HDBox;
  }
}