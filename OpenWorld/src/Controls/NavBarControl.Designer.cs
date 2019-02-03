namespace OpenWorld.src.Controls
{
  partial class NavBarControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavBarControl));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.HomeButton = new System.Windows.Forms.Button();
      this.cUserNameControl1 = new ThisIsMassive.src.Controls.CUserNameControl();
      this.SiteBox = new System.Windows.Forms.TextBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
      this.tableLayoutPanel1.Controls.Add(this.HomeButton, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.cUserNameControl1, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.SiteBox, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(727, 32);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // HomeButton
      // 
      this.HomeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HomeButton.BackgroundImage")));
      this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.HomeButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.HomeButton.Location = new System.Drawing.Point(0, 0);
      this.HomeButton.Margin = new System.Windows.Forms.Padding(0);
      this.HomeButton.Name = "HomeButton";
      this.HomeButton.Size = new System.Drawing.Size(32, 32);
      this.HomeButton.TabIndex = 1;
      this.HomeButton.UseVisualStyleBackColor = true;
      this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
      // 
      // cUserNameControl1
      // 
      this.cUserNameControl1.BackColor = System.Drawing.Color.Transparent;
      this.cUserNameControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cUserNameControl1.Location = new System.Drawing.Point(607, 0);
      this.cUserNameControl1.Margin = new System.Windows.Forms.Padding(0);
      this.cUserNameControl1.Name = "cUserNameControl1";
      this.cUserNameControl1.Size = new System.Drawing.Size(120, 32);
      this.cUserNameControl1.TabIndex = 3;
      // 
      // SiteBox
      // 
      this.SiteBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SiteBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SiteBox.Location = new System.Drawing.Point(35, 3);
      this.SiteBox.Multiline = true;
      this.SiteBox.Name = "SiteBox";
      this.SiteBox.Size = new System.Drawing.Size(569, 26);
      this.SiteBox.TabIndex = 4;
      this.SiteBox.Text = "Home";
      // 
      // NavBarControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Margin = new System.Windows.Forms.Padding(0);
      this.Name = "NavBarControl";
      this.Size = new System.Drawing.Size(727, 32);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button HomeButton;
    private ThisIsMassive.src.Controls.CUserNameControl cUserNameControl1;
    private System.Windows.Forms.TextBox SiteBox;
  }
}
