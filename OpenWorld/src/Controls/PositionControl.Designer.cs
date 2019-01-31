namespace OpenWorld.src.Controls
{
  partial class PositionControl
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
      this.PositionBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // PositionBox
      // 
      this.PositionBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PositionBox.Location = new System.Drawing.Point(0, 0);
      this.PositionBox.Multiline = true;
      this.PositionBox.Name = "PositionBox";
      this.PositionBox.Size = new System.Drawing.Size(304, 33);
      this.PositionBox.TabIndex = 0;
      this.PositionBox.Text = "0,0,0\r\n-18.1, 33.00";
      // 
      // PositionControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PositionBox);
      this.Name = "PositionControl";
      this.Size = new System.Drawing.Size(304, 33);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox PositionBox;
  }
}
