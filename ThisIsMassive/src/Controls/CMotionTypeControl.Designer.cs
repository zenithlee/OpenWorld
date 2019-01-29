namespace ThisIsMassive.src.Controls
{
  partial class CMotionTypeControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMotionTypeControl));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.MotionTypeFlying = new System.Windows.Forms.Button();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.GravityButton = new System.Windows.Forms.Button();
      this.WalkButton = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel1.Controls.Add(this.MotionTypeFlying, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.GravityButton, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.WalkButton, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(159, 47);
      this.tableLayoutPanel1.TabIndex = 9;
      // 
      // MotionTypeFlying
      // 
      this.MotionTypeFlying.BackColor = System.Drawing.Color.Gray;
      this.MotionTypeFlying.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.MotionTypeFlying.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MotionTypeFlying.FlatAppearance.BorderSize = 0;
      this.MotionTypeFlying.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.MotionTypeFlying.ForeColor = System.Drawing.Color.White;
      this.MotionTypeFlying.ImageIndex = 3;
      this.MotionTypeFlying.ImageList = this.imageList1;
      this.MotionTypeFlying.Location = new System.Drawing.Point(53, 0);
      this.MotionTypeFlying.Margin = new System.Windows.Forms.Padding(0);
      this.MotionTypeFlying.Name = "MotionTypeFlying";
      this.MotionTypeFlying.Size = new System.Drawing.Size(53, 47);
      this.MotionTypeFlying.TabIndex = 10;
      this.toolTip1.SetToolTip(this.MotionTypeFlying, "Free Fly Mode.\r\nYour rotation is unlocked\r\nAD - Yaw\r\nWS - Pitch\r\nQE - Roll\r\nMouse" +
        " Left/Right - Roll\r\nMouse Up/Down - Pitch\r\nSpace - Afterburner\r\nShift:  + Boost\r" +
        "\nCtrl: + Massive Boost");
      this.MotionTypeFlying.UseVisualStyleBackColor = false;
      this.MotionTypeFlying.Click += new System.EventHandler(this.FlyButton_Click);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "icons8-walking-40.png");
      this.imageList1.Images.SetKeyName(1, "icons8-skydiving-40.png");
      this.imageList1.Images.SetKeyName(2, "icons8-handball-40.png");
      this.imageList1.Images.SetKeyName(3, "icons8-space-shuttle-80 (1).png");
      // 
      // GravityButton
      // 
      this.GravityButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(175)))));
      this.GravityButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.GravityButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GravityButton.FlatAppearance.BorderSize = 0;
      this.GravityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.GravityButton.ForeColor = System.Drawing.Color.White;
      this.GravityButton.ImageKey = "icons8-skydiving-40.png";
      this.GravityButton.ImageList = this.imageList1;
      this.GravityButton.Location = new System.Drawing.Point(106, 0);
      this.GravityButton.Margin = new System.Windows.Forms.Padding(0);
      this.GravityButton.Name = "GravityButton";
      this.GravityButton.Size = new System.Drawing.Size(53, 47);
      this.GravityButton.TabIndex = 9;
      this.toolTip1.SetToolTip(this.GravityButton, "Gravity On/Off\r\nWhen building in space it is often easier to disable gravity");
      this.GravityButton.UseVisualStyleBackColor = false;
      this.GravityButton.Click += new System.EventHandler(this.GravityButton_Click);
      // 
      // WalkButton
      // 
      this.WalkButton.BackColor = System.Drawing.Color.Teal;
      this.WalkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.WalkButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.WalkButton.FlatAppearance.BorderSize = 0;
      this.WalkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.WalkButton.ForeColor = System.Drawing.Color.White;
      this.WalkButton.ImageIndex = 0;
      this.WalkButton.ImageList = this.imageList1;
      this.WalkButton.Location = new System.Drawing.Point(0, 0);
      this.WalkButton.Margin = new System.Windows.Forms.Padding(0);
      this.WalkButton.Name = "WalkButton";
      this.WalkButton.Size = new System.Drawing.Size(53, 47);
      this.WalkButton.TabIndex = 8;
      this.toolTip1.SetToolTip(this.WalkButton, "Walk Mode.\r\nYour body is perpendicular to the nearest planet.\r\nWASD to move \r\nSpa" +
        "ce to Jetpack\r\nMouse to look around. \r\nShift:  + Boost\r\nCtrl: + Massive Boost");
      this.WalkButton.UseVisualStyleBackColor = false;
      this.WalkButton.Click += new System.EventHandler(this.WalkButton_Click);
      // 
      // CMotionTypeControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "CMotionTypeControl";
      this.Size = new System.Drawing.Size(159, 47);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button WalkButton;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button GravityButton;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.Button MotionTypeFlying;
  }
}
