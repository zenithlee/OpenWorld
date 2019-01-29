namespace ThisIsMassive.src.Forms
{
  partial class BuildForm
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
      this.cBuildPartSelecter1 = new ThisIsMassive.src.Controls.CBuildPartSelecter();
      this.cObjectInspector1 = new ThisIsMassive.src.Controls.CObjectInspector();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // cBuildPartSelecter1
      // 
      this.cBuildPartSelecter1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cBuildPartSelecter1.Location = new System.Drawing.Point(0, 0);
      this.cBuildPartSelecter1.Margin = new System.Windows.Forms.Padding(0);
      this.cBuildPartSelecter1.Name = "cBuildPartSelecter1";
      this.cBuildPartSelecter1.Size = new System.Drawing.Size(226, 354);
      this.cBuildPartSelecter1.TabIndex = 2;
      // 
      // cObjectInspector1
      // 
      this.cObjectInspector1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cObjectInspector1.Location = new System.Drawing.Point(0, 354);
      this.cObjectInspector1.Margin = new System.Windows.Forms.Padding(0);
      this.cObjectInspector1.Name = "cObjectInspector1";
      this.cObjectInspector1.Size = new System.Drawing.Size(226, 280);
      this.cObjectInspector1.TabIndex = 3;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.Controls.Add(this.cObjectInspector1, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.cBuildPartSelecter1, 0, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 21);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 280F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(226, 634);
      this.tableLayoutPanel2.TabIndex = 4;
      // 
      // BuildForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(226, 655);
      this.Controls.Add(this.tableLayoutPanel2);
      this.Name = "BuildForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.TopMost = false;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BuildForm_FormClosing);
      this.Shown += new System.EventHandler(this.BuildForm_Shown);
      this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.CBuildPartSelecter cBuildPartSelecter1;
    private Controls.CObjectInspector cObjectInspector1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
  }
}
