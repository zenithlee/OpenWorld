namespace ThisIsMassive.src.Controls
{
  partial class HelpForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
      this.HelpText = new System.Windows.Forms.TextBox();
      this.CloseButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.AboutButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // HelpText
      // 
      this.HelpText.BackColor = System.Drawing.Color.Silver;
      this.HelpText.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.HelpText.Location = new System.Drawing.Point(12, 35);
      this.HelpText.Multiline = true;
      this.HelpText.Name = "HelpText";
      this.HelpText.ReadOnly = true;
      this.HelpText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.HelpText.Size = new System.Drawing.Size(476, 448);
      this.HelpText.TabIndex = 0;
      this.HelpText.TabStop = false;
      this.HelpText.Text = resources.GetString("HelpText.Text");
      // 
      // CloseButton
      // 
      this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.CloseButton.FlatAppearance.BorderSize = 0;
      this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.CloseButton.Location = new System.Drawing.Point(466, 0);
      this.CloseButton.Name = "CloseButton";
      this.CloseButton.Size = new System.Drawing.Size(34, 24);
      this.CloseButton.TabIndex = 1;
      this.CloseButton.Text = "x";
      this.CloseButton.UseVisualStyleBackColor = false;
      this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.IndianRed;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(-1, 0);
      this.label1.Margin = new System.Windows.Forms.Padding(0);
      this.label1.Name = "label1";
      this.label1.Padding = new System.Windows.Forms.Padding(5);
      this.label1.Size = new System.Drawing.Size(501, 24);
      this.label1.TabIndex = 2;
      this.label1.Text = "Help";
      // 
      // AboutButton
      // 
      this.AboutButton.BackColor = System.Drawing.Color.DarkGray;
      this.AboutButton.FlatAppearance.BorderSize = 0;
      this.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.AboutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.AboutButton.Location = new System.Drawing.Point(12, 489);
      this.AboutButton.Name = "AboutButton";
      this.AboutButton.Size = new System.Drawing.Size(75, 37);
      this.AboutButton.TabIndex = 3;
      this.AboutButton.Text = "About";
      this.AboutButton.UseVisualStyleBackColor = false;
      this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
      // 
      // HelpForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.DimGray;
      this.ClientSize = new System.Drawing.Size(500, 549);
      this.Controls.Add(this.AboutButton);
      this.Controls.Add(this.CloseButton);
      this.Controls.Add(this.HelpText);
      this.Controls.Add(this.label1);
      this.ForeColor = System.Drawing.Color.White;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "HelpForm";
      this.Text = "HelpForm";
      this.TopMost = true;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox HelpText;
    private System.Windows.Forms.Button CloseButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button AboutButton;
  }
}