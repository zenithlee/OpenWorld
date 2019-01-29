namespace ThisIsMassive.src.Controls
{
  partial class CTabSwitcher
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.cExploreControl1 = new ThisIsMassive.src.Controls.CZoneExploreControl();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Controls.Add(this.cExploreControl1, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(202, 572);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // cExploreControl1
      // 
      this.cExploreControl1.BackColor = System.Drawing.Color.Black;
      this.tableLayoutPanel1.SetColumnSpan(this.cExploreControl1, 2);
      this.cExploreControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cExploreControl1.ForeColor = System.Drawing.Color.White;
      this.cExploreControl1.Location = new System.Drawing.Point(0, 0);
      this.cExploreControl1.Margin = new System.Windows.Forms.Padding(0);
      this.cExploreControl1.Name = "cExploreControl1";
      this.cExploreControl1.Size = new System.Drawing.Size(202, 572);
      this.cExploreControl1.TabIndex = 3;
      // 
      // CTabSwitcher
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "CTabSwitcher";
      this.Size = new System.Drawing.Size(202, 572);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private CZoneExploreControl cExploreControl1;
  }
}
