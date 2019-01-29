namespace ThisIsMassive.src.Controls
{
  partial class TermsOfService
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TermsOfService));
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.AcceptButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(12, 12);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBox1.Size = new System.Drawing.Size(685, 394);
      this.textBox1.TabIndex = 0;
      this.textBox1.TabStop = false;
      this.textBox1.Text = resources.GetString("textBox1.Text");
      // 
      // AcceptButton
      // 
      this.AcceptButton.Location = new System.Drawing.Point(309, 422);
      this.AcceptButton.Name = "AcceptButton";
      this.AcceptButton.Size = new System.Drawing.Size(75, 44);
      this.AcceptButton.TabIndex = 1;
      this.AcceptButton.Text = "I Accept";
      this.AcceptButton.UseVisualStyleBackColor = true;
      this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
      // 
      // TermsOfService
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(709, 492);
      this.Controls.Add(this.AcceptButton);
      this.Controls.Add(this.textBox1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "TermsOfService";
      this.Text = "Terms and Conditions";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button AcceptButton;
  }
}