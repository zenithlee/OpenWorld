namespace OpenWorld.Forms
{
  partial class UserStatusForm
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
      this.UpdateButton = new System.Windows.Forms.Button();
      this.UserStatusText = new System.Windows.Forms.TextBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.UploadStatusLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // UpdateButton
      // 
      this.UpdateButton.Location = new System.Drawing.Point(501, 286);
      this.UpdateButton.Name = "UpdateButton";
      this.UpdateButton.Size = new System.Drawing.Size(75, 32);
      this.UpdateButton.TabIndex = 2;
      this.UpdateButton.Text = "Post";
      this.UpdateButton.UseVisualStyleBackColor = true;
      this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
      // 
      // UserStatusText
      // 
      this.UserStatusText.Location = new System.Drawing.Point(256, 43);
      this.UserStatusText.Multiline = true;
      this.UserStatusText.Name = "UserStatusText";
      this.UserStatusText.Size = new System.Drawing.Size(320, 234);
      this.UserStatusText.TabIndex = 3;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(22, 43);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(228, 234);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 4;
      this.pictureBox1.TabStop = false;
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(22, 286);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(228, 32);
      this.progressBar1.TabIndex = 5;
      // 
      // UploadStatusLabel
      // 
      this.UploadStatusLabel.ForeColor = System.Drawing.Color.White;
      this.UploadStatusLabel.Location = new System.Drawing.Point(257, 286);
      this.UploadStatusLabel.Name = "UploadStatusLabel";
      this.UploadStatusLabel.Size = new System.Drawing.Size(238, 32);
      this.UploadStatusLabel.TabIndex = 6;
      this.UploadStatusLabel.Text = "...";
      this.UploadStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // UserStatusForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(637, 345);
      this.Controls.Add(this.UploadStatusLabel);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.UserStatusText);
      this.Controls.Add(this.UpdateButton);
      this.Name = "UserStatusForm";
      this.Text = "UserStatusForm";
      this.Controls.SetChildIndex(this.UpdateButton, 0);
      this.Controls.SetChildIndex(this.UserStatusText, 0);
      this.Controls.SetChildIndex(this.pictureBox1, 0);
      this.Controls.SetChildIndex(this.progressBar1, 0);
      this.Controls.SetChildIndex(this.UploadStatusLabel, 0);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button UpdateButton;
    private System.Windows.Forms.TextBox UserStatusText;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label UploadStatusLabel;
  }
}