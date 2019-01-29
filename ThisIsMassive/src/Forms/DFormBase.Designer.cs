namespace ThisIsMassive.src.Controls
{
  partial class DFormBase
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.TitleBar = new System.Windows.Forms.Label();
      this.CloseButton = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.95283F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.04717F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
      this.tableLayoutPanel1.Controls.Add(this.TitleBar, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.CloseButton, 2, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.210084F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(869, 31);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // TitleBar
      // 
      this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.tableLayoutPanel1.SetColumnSpan(this.TitleBar, 2);
      this.TitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TitleBar.ForeColor = System.Drawing.Color.White;
      this.TitleBar.Location = new System.Drawing.Point(0, 0);
      this.TitleBar.Margin = new System.Windows.Forms.Padding(0);
      this.TitleBar.Name = "TitleBar";
      this.TitleBar.Padding = new System.Windows.Forms.Padding(2);
      this.TitleBar.Size = new System.Drawing.Size(837, 31);
      this.TitleBar.TabIndex = 0;
      this.TitleBar.Text = "TITLE";
      this.TitleBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
      this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
      this.TitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
      // 
      // CloseButton
      // 
      this.CloseButton.BackColor = System.Drawing.Color.Silver;
      this.CloseButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CloseButton.FlatAppearance.BorderSize = 0;
      this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.CloseButton.Location = new System.Drawing.Point(837, 0);
      this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
      this.CloseButton.Name = "CloseButton";
      this.CloseButton.Size = new System.Drawing.Size(32, 31);
      this.CloseButton.TabIndex = 1;
      this.CloseButton.Text = "X";
      this.CloseButton.UseVisualStyleBackColor = false;
      this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
      // 
      // DFormBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(869, 612);
      this.Controls.Add(this.tableLayoutPanel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "DFormBase";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "DFormBase";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.DFormBase_Load);
      this.Shown += new System.EventHandler(this.DFormBase_Shown);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label TitleBar;
    private System.Windows.Forms.Button CloseButton;
  }
}