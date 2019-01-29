namespace ThisIsMassive.src.Controls
{
  partial class CacheControl
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
      this.components = new System.ComponentModel.Container();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.label3 = new System.Windows.Forms.Label();
      this.TotalObjectsCount = new System.Windows.Forms.Label();
      this.UniqueObjectsCount = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.EmptyCacheButton = new System.Windows.Forms.Button();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.Draws = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
      this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.TotalObjectsCount, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.UniqueObjectsCount, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.EmptyCacheButton, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.Draws, 2, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.ForeColor = System.Drawing.Color.White;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(306, 47);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label3.Location = new System.Drawing.Point(3, 23);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(75, 24);
      this.label3.TabIndex = 4;
      this.label3.Text = "Total";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // TotalObjectsCount
      // 
      this.TotalObjectsCount.AutoSize = true;
      this.TotalObjectsCount.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TotalObjectsCount.Location = new System.Drawing.Point(84, 23);
      this.TotalObjectsCount.Name = "TotalObjectsCount";
      this.TotalObjectsCount.Size = new System.Drawing.Size(75, 24);
      this.TotalObjectsCount.TabIndex = 3;
      this.TotalObjectsCount.Text = "0";
      this.TotalObjectsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // UniqueObjectsCount
      // 
      this.UniqueObjectsCount.AutoSize = true;
      this.UniqueObjectsCount.Dock = System.Windows.Forms.DockStyle.Fill;
      this.UniqueObjectsCount.Location = new System.Drawing.Point(84, 0);
      this.UniqueObjectsCount.Name = "UniqueObjectsCount";
      this.UniqueObjectsCount.Size = new System.Drawing.Size(75, 23);
      this.UniqueObjectsCount.TabIndex = 1;
      this.UniqueObjectsCount.Text = "0";
      this.UniqueObjectsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(75, 23);
      this.label1.TabIndex = 0;
      this.label1.Text = "Unique Objects";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // EmptyCacheButton
      // 
      this.EmptyCacheButton.BackColor = System.Drawing.Color.Gray;
      this.EmptyCacheButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EmptyCacheButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
      this.EmptyCacheButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.EmptyCacheButton.ForeColor = System.Drawing.Color.White;
      this.EmptyCacheButton.Location = new System.Drawing.Point(223, 0);
      this.EmptyCacheButton.Margin = new System.Windows.Forms.Padding(0);
      this.EmptyCacheButton.Name = "EmptyCacheButton";
      this.tableLayoutPanel1.SetRowSpan(this.EmptyCacheButton, 2);
      this.EmptyCacheButton.Size = new System.Drawing.Size(83, 47);
      this.EmptyCacheButton.TabIndex = 2;
      this.EmptyCacheButton.Text = "Empty Cache";
      this.EmptyCacheButton.UseVisualStyleBackColor = false;
      this.EmptyCacheButton.Click += new System.EventHandler(this.EmptyCacheButton_Click);
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // Draws
      // 
      this.Draws.AutoSize = true;
      this.Draws.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Draws.Location = new System.Drawing.Point(165, 0);
      this.Draws.Name = "Draws";
      this.Draws.Size = new System.Drawing.Size(55, 23);
      this.Draws.TabIndex = 5;
      this.Draws.Text = "0";
      this.Draws.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.Draws.Click += new System.EventHandler(this.Draws_Click);
      // 
      // CacheControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "CacheControl";
      this.Size = new System.Drawing.Size(306, 47);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label UniqueObjectsCount;
    private System.Windows.Forms.Button EmptyCacheButton;
    private System.Windows.Forms.Label TotalObjectsCount;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label Draws;
    private System.Windows.Forms.Timer timer1;
  }
}
