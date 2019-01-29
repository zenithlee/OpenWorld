namespace ThisIsMassive.src.Controls
{
  partial class CCloseButton
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.CloseButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // CloseButton
      // 
      this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.CloseButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CloseButton.FlatAppearance.BorderSize = 0;
      this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CloseButton.ForeColor = System.Drawing.Color.White;
      this.CloseButton.Location = new System.Drawing.Point(0, 0);
      this.CloseButton.Name = "CloseButton";
      this.CloseButton.Size = new System.Drawing.Size(26, 24);
      this.CloseButton.TabIndex = 0;
      this.CloseButton.Text = "X";
      this.CloseButton.UseVisualStyleBackColor = false;
      this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
      // 
      // CCloseButton
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.CloseButton);
      this.Name = "CCloseButton";
      this.Size = new System.Drawing.Size(26, 24);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button CloseButton;
  }
}
