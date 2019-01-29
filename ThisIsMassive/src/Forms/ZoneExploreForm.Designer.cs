namespace ThisIsMassive.src.Forms
{
  partial class ZoneExploreForm
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
      this.cExploreControl1 = new ThisIsMassive.src.Controls.CZoneExploreControl();
      this.SuspendLayout();
      // 
      // cExploreControl1
      // 
      this.cExploreControl1.BackColor = System.Drawing.Color.Transparent;
      this.cExploreControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cExploreControl1.ForeColor = System.Drawing.Color.White;
      this.cExploreControl1.Location = new System.Drawing.Point(2, 21);
      this.cExploreControl1.Margin = new System.Windows.Forms.Padding(0);
      this.cExploreControl1.Name = "cExploreControl1";
      this.cExploreControl1.Size = new System.Drawing.Size(241, 536);
      this.cExploreControl1.TabIndex = 2;
      // 
      // ZoneExploreForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(245, 559);
      this.Controls.Add(this.cExploreControl1);
      this.Name = "ZoneExploreForm";
      this.Opacity = 0.9D;
      this.Text = "ZoneExploreForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZoneExploreForm_FormClosing);
      this.Controls.SetChildIndex(this.cExploreControl1, 0);
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.CZoneExploreControl cExploreControl1;
  }
}