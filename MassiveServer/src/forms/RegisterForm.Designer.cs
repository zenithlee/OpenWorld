namespace MassiveServer.src.forms
{
  partial class RegisterForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
      this.RegisterButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.UniName = new System.Windows.Forms.TextBox();
      this.StyleCombo = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.ResponseText = new System.Windows.Forms.TextBox();
      this.IPLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // RegisterButton
      // 
      this.RegisterButton.Location = new System.Drawing.Point(362, 312);
      this.RegisterButton.Name = "RegisterButton";
      this.RegisterButton.Size = new System.Drawing.Size(86, 37);
      this.RegisterButton.TabIndex = 0;
      this.RegisterButton.Text = "Register";
      this.RegisterButton.UseVisualStyleBackColor = true;
      this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(69, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Server Name";
      // 
      // UniName
      // 
      this.UniName.Location = new System.Drawing.Point(13, 30);
      this.UniName.Name = "UniName";
      this.UniName.Size = new System.Drawing.Size(259, 20);
      this.UniName.TabIndex = 2;
      this.UniName.Text = "My Universe";
      // 
      // StyleCombo
      // 
      this.StyleCombo.FormattingEnabled = true;
      this.StyleCombo.Items.AddRange(new object[] {
            "Real World",
            "Fantasy",
            "Sci Fi",
            "History",
            "Experimental",
            "Game",
            "Shopping",
            "Astronomy",
            "Politics",
            "Banter",
            "Adult",
            "Anonymous"});
      this.StyleCombo.Location = new System.Drawing.Point(13, 76);
      this.StyleCombo.Name = "StyleCombo";
      this.StyleCombo.Size = new System.Drawing.Size(259, 21);
      this.StyleCombo.TabIndex = 3;
      this.StyleCombo.Text = "Real World";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 60);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(64, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Server Style";
      // 
      // ResponseText
      // 
      this.ResponseText.Location = new System.Drawing.Point(13, 137);
      this.ResponseText.Multiline = true;
      this.ResponseText.Name = "ResponseText";
      this.ResponseText.Size = new System.Drawing.Size(435, 169);
      this.ResponseText.TabIndex = 5;
      this.ResponseText.Text = "Register Server in Lobby\r\nUnused Servers expire after 30 days";
      // 
      // IPLabel
      // 
      this.IPLabel.AutoSize = true;
      this.IPLabel.Location = new System.Drawing.Point(13, 100);
      this.IPLabel.Name = "IPLabel";
      this.IPLabel.Size = new System.Drawing.Size(17, 13);
      this.IPLabel.TabIndex = 6;
      this.IPLabel.Text = "IP";
      // 
      // RegisterForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(458, 360);
      this.Controls.Add(this.IPLabel);
      this.Controls.Add(this.ResponseText);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.StyleCombo);
      this.Controls.Add(this.UniName);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.RegisterButton);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "RegisterForm";
      this.Text = "RegisterForm";
      this.Load += new System.EventHandler(this.RegisterForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button RegisterButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox UniName;
    private System.Windows.Forms.ComboBox StyleCombo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox ResponseText;
    private System.Windows.Forms.Label IPLabel;
  }
}