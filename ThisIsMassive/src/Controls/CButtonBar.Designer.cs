namespace ThisIsMassive.src.Controls
{
  partial class CButtonBar
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
      this.Zones = new System.Windows.Forms.Button();
      this.SocialButton = new System.Windows.Forms.Button();
      this.BuildButton = new System.Windows.Forms.Button();
      this.Market = new System.Windows.Forms.Button();
      this.AssetsButton = new System.Windows.Forms.Button();
      this.AdminTools = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.AdminTools, 0, 5);
      this.tableLayoutPanel1.Controls.Add(this.Zones, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.SocialButton, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.BuildButton, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.Market, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.AssetsButton, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 8;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(84, 553);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // Zones
      // 
      this.Zones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(192)))));
      this.Zones.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Zones.FlatAppearance.BorderSize = 0;
      this.Zones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.Zones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Zones.Location = new System.Drawing.Point(0, 128);
      this.Zones.Margin = new System.Windows.Forms.Padding(0);
      this.Zones.Name = "Zones";
      this.Zones.Size = new System.Drawing.Size(84, 32);
      this.Zones.TabIndex = 22;
      this.Zones.Text = "Zones";
      this.Zones.UseVisualStyleBackColor = false;
      this.Zones.Click += new System.EventHandler(this.Zones_Click);
      // 
      // SocialButton
      // 
      this.SocialButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      this.SocialButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SocialButton.FlatAppearance.BorderSize = 0;
      this.SocialButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SocialButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SocialButton.Location = new System.Drawing.Point(0, 96);
      this.SocialButton.Margin = new System.Windows.Forms.Padding(0);
      this.SocialButton.Name = "SocialButton";
      this.SocialButton.Size = new System.Drawing.Size(84, 32);
      this.SocialButton.TabIndex = 21;
      this.SocialButton.Text = "_SOCIAL";
      this.SocialButton.UseVisualStyleBackColor = false;
      this.SocialButton.Click += new System.EventHandler(this.SocialButton_Click);
      // 
      // BuildButton
      // 
      this.BuildButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.BuildButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.BuildButton.FlatAppearance.BorderSize = 0;
      this.BuildButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.BuildButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BuildButton.Location = new System.Drawing.Point(0, 64);
      this.BuildButton.Margin = new System.Windows.Forms.Padding(0);
      this.BuildButton.Name = "BuildButton";
      this.BuildButton.Size = new System.Drawing.Size(84, 32);
      this.BuildButton.TabIndex = 20;
      this.BuildButton.Text = "_BUILD";
      this.BuildButton.UseVisualStyleBackColor = false;
      this.BuildButton.Click += new System.EventHandler(this.BuildModeButton_Click);
      // 
      // Market
      // 
      this.Market.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.Market.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Market.FlatAppearance.BorderSize = 0;
      this.Market.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.Market.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Market.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.Market.Location = new System.Drawing.Point(0, 32);
      this.Market.Margin = new System.Windows.Forms.Padding(0);
      this.Market.Name = "Market";
      this.Market.Size = new System.Drawing.Size(84, 32);
      this.Market.TabIndex = 18;
      this.Market.Text = "Market";
      this.Market.UseVisualStyleBackColor = false;
      this.Market.Click += new System.EventHandler(this.Market_Click);
      // 
      // AssetsButton
      // 
      this.AssetsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(168)))), ((int)(((byte)(155)))));
      this.AssetsButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.AssetsButton.FlatAppearance.BorderSize = 0;
      this.AssetsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.AssetsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.AssetsButton.Location = new System.Drawing.Point(0, 0);
      this.AssetsButton.Margin = new System.Windows.Forms.Padding(0);
      this.AssetsButton.Name = "AssetsButton";
      this.AssetsButton.Size = new System.Drawing.Size(84, 32);
      this.AssetsButton.TabIndex = 17;
      this.AssetsButton.Text = "Assets";
      this.AssetsButton.UseVisualStyleBackColor = false;
      this.AssetsButton.Click += new System.EventHandler(this.AssetsButton_Click);
      // 
      // AdminTools
      // 
      this.AdminTools.BackColor = System.Drawing.Color.Black;
      this.AdminTools.Dock = System.Windows.Forms.DockStyle.Fill;
      this.AdminTools.FlatAppearance.BorderSize = 0;
      this.AdminTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.AdminTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.AdminTools.ForeColor = System.Drawing.Color.White;
      this.AdminTools.Location = new System.Drawing.Point(0, 160);
      this.AdminTools.Margin = new System.Windows.Forms.Padding(0);
      this.AdminTools.Name = "AdminTools";
      this.AdminTools.Size = new System.Drawing.Size(84, 32);
      this.AdminTools.TabIndex = 23;
      this.AdminTools.Text = "Admin";
      this.AdminTools.UseVisualStyleBackColor = false;
      this.AdminTools.Click += new System.EventHandler(this.AdminTools_Click);
      // 
      // CButtonBar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Margin = new System.Windows.Forms.Padding(0);
      this.Name = "CButtonBar";
      this.Size = new System.Drawing.Size(84, 553);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button SocialButton;
    private System.Windows.Forms.Button BuildButton;
    private System.Windows.Forms.Button Market;
    private System.Windows.Forms.Button AssetsButton;
    private System.Windows.Forms.Button Zones;
    private System.Windows.Forms.Button AdminTools;
  }
}
