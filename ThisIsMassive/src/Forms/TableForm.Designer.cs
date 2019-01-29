namespace ThisIsMassive.src.Forms
{
  partial class TableForm
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
      this.cTableControl1 = new ThisIsMassive.src.Controls.CTableControl();
      this.SuspendLayout();
      // 
      // cTableControl1
      // 
      this.cTableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cTableControl1.Location = new System.Drawing.Point(2, 21);
      this.cTableControl1.Name = "cTableControl1";
      this.cTableControl1.Size = new System.Drawing.Size(510, 407);
      this.cTableControl1.TabIndex = 2;
      // 
      // TableForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(514, 430);
      this.Controls.Add(this.cTableControl1);
      this.Name = "TableForm";
      this.Text = "TableForm";
      this.Controls.SetChildIndex(this.cTableControl1, 0);
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.CTableControl cTableControl1;
  }
}