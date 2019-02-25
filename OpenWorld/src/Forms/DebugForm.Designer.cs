namespace OpenWorld.Forms
{
  partial class DebugForm
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
      this.components = new System.ComponentModel.Container();
      this.DebugTable = new System.Windows.Forms.DataGridView();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.DebugTable)).BeginInit();
      this.SuspendLayout();
      // 
      // DebugTable
      // 
      this.DebugTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DebugTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DebugTable.Location = new System.Drawing.Point(2, 21);
      this.DebugTable.Name = "DebugTable";
      this.DebugTable.Size = new System.Drawing.Size(733, 563);
      this.DebugTable.TabIndex = 0;
      // 
      // timer1
      // 
      this.timer1.Interval = 300;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // DebugForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(737, 586);
      this.Controls.Add(this.DebugTable);
      this.Name = "DebugForm";
      this.Text = "DebugForm";
      this.Controls.SetChildIndex(this.DebugTable, 0);
      ((System.ComponentModel.ISupportInitialize)(this.DebugTable)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView DebugTable;
    private System.Windows.Forms.Timer timer1;
  }
}