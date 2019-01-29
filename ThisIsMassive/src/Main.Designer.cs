using OpenTK.Graphics;

namespace ThisIsMassive
{
  partial class Main
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.StatusBox = new System.Windows.Forms.RichTextBox();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.MapButton = new System.Windows.Forms.Button();
      this.DebugButton = new System.Windows.Forms.Button();
      this._HelpButton = new System.Windows.Forms.Button();
      this.GoButton = new System.Windows.Forms.Button();
      this.HomeButton = new System.Windows.Forms.Button();
      this.ConnectionButton = new System.Windows.Forms.Button();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.LocusBox = new System.Windows.Forms.TextBox();
      this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      this.ShadowButton = new System.Windows.Forms.Button();
      this.FogEnableButton = new System.Windows.Forms.Button();
      this.RenderTimer = new System.Windows.Forms.Timer(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.cButtonBar1 = new ThisIsMassive.src.Controls.CButtonBar();
      this.cMotionTypeControl1 = new ThisIsMassive.src.Controls.CMotionTypeControl();
      this.cPosition1 = new ThisIsMassive.src.Controls.CPosition();
      this.userNameControl1 = new ThisIsMassive.src.Controls.CUserNameControl();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.tableLayoutPanel4.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1132F));
      this.tableLayoutPanel1.Controls.Add(this.cButtonBar1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.StatusBox, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1220, 594);
      this.tableLayoutPanel1.TabIndex = 0;
      this.tableLayoutPanel1.Resize += new System.EventHandler(this.glControl1_Resize);
      // 
      // StatusBox
      // 
      this.StatusBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.StatusBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.StatusBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.StatusBox.ForeColor = System.Drawing.Color.White;
      this.StatusBox.Location = new System.Drawing.Point(89, 553);
      this.StatusBox.Margin = new System.Windows.Forms.Padding(1);
      this.StatusBox.Name = "StatusBox";
      this.StatusBox.Size = new System.Drawing.Size(1130, 40);
      this.StatusBox.TabIndex = 4;
      this.StatusBox.TabStop = false;
      this.StatusBox.Text = "Ready>";
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 8;
      this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel2.Controls.Add(this.MapButton, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.DebugButton, 5, 0);
      this.tableLayoutPanel2.Controls.Add(this._HelpButton, 6, 0);
      this.tableLayoutPanel2.Controls.Add(this.GoButton, 7, 1);
      this.tableLayoutPanel2.Controls.Add(this.HomeButton, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.ConnectionButton, 7, 0);
      this.tableLayoutPanel2.Controls.Add(this.cMotionTypeControl1, 2, 0);
      this.tableLayoutPanel2.Controls.Add(this.cPosition1, 3, 0);
      this.tableLayoutPanel2.Controls.Add(this.userNameControl1, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.LocusBox, 1, 1);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 3;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(1220, 64);
      this.tableLayoutPanel2.TabIndex = 5;
      // 
      // MapButton
      // 
      this.MapButton.BackColor = System.Drawing.Color.CadetBlue;
      this.MapButton.BackgroundImage = global::ThisIsMassive.Properties.Resources.icons8_world_map_64;
      this.MapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.MapButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MapButton.FlatAppearance.BorderSize = 0;
      this.MapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.MapButton.ForeColor = System.Drawing.Color.White;
      this.MapButton.Location = new System.Drawing.Point(120, 0);
      this.MapButton.Margin = new System.Windows.Forms.Padding(0);
      this.MapButton.Name = "MapButton";
      this.MapButton.Size = new System.Drawing.Size(32, 30);
      this.MapButton.TabIndex = 11;
      this.MapButton.TabStop = false;
      this.toolTip1.SetToolTip(this.MapButton, "Worlds Map");
      this.MapButton.UseVisualStyleBackColor = false;
      this.MapButton.Click += new System.EventHandler(this.MapButton_Click);
      // 
      // DebugButton
      // 
      this.DebugButton.BackColor = System.Drawing.Color.RoyalBlue;
      this.DebugButton.BackgroundImage = global::ThisIsMassive.Properties.Resources.icons8_code_40;
      this.DebugButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.DebugButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DebugButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
      this.DebugButton.FlatAppearance.BorderSize = 0;
      this.DebugButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.DebugButton.ForeColor = System.Drawing.Color.White;
      this.DebugButton.Location = new System.Drawing.Point(1122, 0);
      this.DebugButton.Margin = new System.Windows.Forms.Padding(0);
      this.DebugButton.Name = "DebugButton";
      this.DebugButton.Size = new System.Drawing.Size(33, 30);
      this.DebugButton.TabIndex = 9;
      this.DebugButton.TabStop = false;
      this.DebugButton.Text = "?";
      this.toolTip1.SetToolTip(this.DebugButton, "Debug View");
      this.DebugButton.UseVisualStyleBackColor = false;
      this.DebugButton.Click += new System.EventHandler(this.DebugButton_Click);
      // 
      // _HelpButton
      // 
      this._HelpButton.BackColor = System.Drawing.Color.RoyalBlue;
      this._HelpButton.BackgroundImage = global::ThisIsMassive.Properties.Resources.icons8_ask_question_40;
      this._HelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this._HelpButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this._HelpButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
      this._HelpButton.FlatAppearance.BorderSize = 0;
      this._HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this._HelpButton.ForeColor = System.Drawing.Color.White;
      this._HelpButton.Location = new System.Drawing.Point(1155, 0);
      this._HelpButton.Margin = new System.Windows.Forms.Padding(0);
      this._HelpButton.Name = "_HelpButton";
      this._HelpButton.Size = new System.Drawing.Size(33, 30);
      this._HelpButton.TabIndex = 8;
      this._HelpButton.TabStop = false;
      this._HelpButton.Text = "?";
      this.toolTip1.SetToolTip(this._HelpButton, "Help F1");
      this._HelpButton.UseVisualStyleBackColor = false;
      this._HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
      // 
      // GoButton
      // 
      this.GoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.GoButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GoButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.GoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.GoButton.ForeColor = System.Drawing.Color.White;
      this.GoButton.Location = new System.Drawing.Point(1188, 30);
      this.GoButton.Margin = new System.Windows.Forms.Padding(0);
      this.GoButton.Name = "GoButton";
      this.GoButton.Size = new System.Drawing.Size(32, 32);
      this.GoButton.TabIndex = 6;
      this.GoButton.TabStop = false;
      this.GoButton.Text = ">";
      this.GoButton.UseVisualStyleBackColor = false;
      this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
      // 
      // HomeButton
      // 
      this.HomeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.HomeButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.HomeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.HomeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
      this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.HomeButton.ForeColor = System.Drawing.Color.White;
      this.HomeButton.Location = new System.Drawing.Point(0, 30);
      this.HomeButton.Margin = new System.Windows.Forms.Padding(0);
      this.HomeButton.Name = "HomeButton";
      this.HomeButton.Size = new System.Drawing.Size(120, 32);
      this.HomeButton.TabIndex = 4;
      this.HomeButton.TabStop = false;
      this.HomeButton.Text = "Home";
      this.toolTip1.SetToolTip(this.HomeButton, "Teleport to your Home");
      this.HomeButton.UseVisualStyleBackColor = false;
      this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click_1);
      // 
      // ConnectionButton
      // 
      this.ConnectionButton.BackColor = System.Drawing.Color.DarkRed;
      this.ConnectionButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ConnectionButton.Enabled = false;
      this.ConnectionButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
      this.ConnectionButton.FlatAppearance.BorderSize = 0;
      this.ConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ConnectionButton.ImageIndex = 0;
      this.ConnectionButton.ImageList = this.imageList1;
      this.ConnectionButton.Location = new System.Drawing.Point(1188, 0);
      this.ConnectionButton.Margin = new System.Windows.Forms.Padding(0);
      this.ConnectionButton.Name = "ConnectionButton";
      this.ConnectionButton.Size = new System.Drawing.Size(32, 30);
      this.ConnectionButton.TabIndex = 2;
      this.ConnectionButton.TabStop = false;
      this.toolTip1.SetToolTip(this.ConnectionButton, "Connection Indicator");
      this.ConnectionButton.UseVisualStyleBackColor = false;
      this.ConnectionButton.Click += new System.EventHandler(this.ConnectionButton_Click);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "icons8-disconnected-40.png");
      this.imageList1.Images.SetKeyName(1, "icons8-connected-40.png");
      // 
      // LocusBox
      // 
      this.LocusBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tableLayoutPanel2.SetColumnSpan(this.LocusBox, 6);
      this.LocusBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LocusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LocusBox.Location = new System.Drawing.Point(120, 30);
      this.LocusBox.Margin = new System.Windows.Forms.Padding(0);
      this.LocusBox.Multiline = true;
      this.LocusBox.Name = "LocusBox";
      this.LocusBox.Size = new System.Drawing.Size(1068, 32);
      this.LocusBox.TabIndex = 17;
      // 
      // tableLayoutPanel4
      // 
      this.tableLayoutPanel4.ColumnCount = 2;
      this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel4.Controls.Add(this.ShadowButton, 0, 0);
      this.tableLayoutPanel4.Controls.Add(this.FogEnableButton, 0, 0);
      this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 555);
      this.tableLayoutPanel4.Name = "tableLayoutPanel4";
      this.tableLayoutPanel4.RowCount = 1;
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel4.Size = new System.Drawing.Size(82, 36);
      this.tableLayoutPanel4.TabIndex = 7;
      // 
      // ShadowButton
      // 
      this.ShadowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.ShadowButton.BackgroundImage = global::ThisIsMassive.Properties.Resources.icons8_shadow_photography_48;
      this.ShadowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.ShadowButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ShadowButton.FlatAppearance.BorderSize = 0;
      this.ShadowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ShadowButton.ForeColor = System.Drawing.Color.White;
      this.ShadowButton.Location = new System.Drawing.Point(41, 0);
      this.ShadowButton.Margin = new System.Windows.Forms.Padding(0);
      this.ShadowButton.Name = "ShadowButton";
      this.ShadowButton.Size = new System.Drawing.Size(41, 36);
      this.ShadowButton.TabIndex = 4;
      this.ShadowButton.UseVisualStyleBackColor = false;
      this.ShadowButton.Click += new System.EventHandler(this.ShadowButton_Click);
      // 
      // FogEnableButton
      // 
      this.FogEnableButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.FogEnableButton.BackgroundImage = global::ThisIsMassive.Properties.Resources.icons8_fog_40;
      this.FogEnableButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.FogEnableButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.FogEnableButton.FlatAppearance.BorderSize = 0;
      this.FogEnableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.FogEnableButton.ForeColor = System.Drawing.Color.White;
      this.FogEnableButton.Location = new System.Drawing.Point(0, 0);
      this.FogEnableButton.Margin = new System.Windows.Forms.Padding(0);
      this.FogEnableButton.Name = "FogEnableButton";
      this.FogEnableButton.Size = new System.Drawing.Size(41, 36);
      this.FogEnableButton.TabIndex = 3;
      this.FogEnableButton.UseVisualStyleBackColor = false;
      this.FogEnableButton.Click += new System.EventHandler(this.FogEnableButton_Click);
      // 
      // RenderTimer
      // 
      this.RenderTimer.Interval = 40;
      this.RenderTimer.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // cButtonBar1
      // 
      this.cButtonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cButtonBar1.Location = new System.Drawing.Point(0, 64);
      this.cButtonBar1.Margin = new System.Windows.Forms.Padding(0);
      this.cButtonBar1.Name = "cButtonBar1";
      this.cButtonBar1.Size = new System.Drawing.Size(88, 488);
      this.cButtonBar1.TabIndex = 19;
      // 
      // cMotionTypeControl1
      // 
      this.cMotionTypeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cMotionTypeControl1.Location = new System.Drawing.Point(152, 0);
      this.cMotionTypeControl1.Margin = new System.Windows.Forms.Padding(0);
      this.cMotionTypeControl1.Name = "cMotionTypeControl1";
      this.cMotionTypeControl1.Size = new System.Drawing.Size(113, 30);
      this.cMotionTypeControl1.TabIndex = 12;
      this.cMotionTypeControl1.TabStop = false;
      // 
      // cPosition1
      // 
      this.cPosition1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.tableLayoutPanel2.SetColumnSpan(this.cPosition1, 2);
      this.cPosition1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cPosition1.Location = new System.Drawing.Point(265, 0);
      this.cPosition1.Margin = new System.Windows.Forms.Padding(0);
      this.cPosition1.Name = "cPosition1";
      this.cPosition1.Size = new System.Drawing.Size(857, 30);
      this.cPosition1.TabIndex = 13;
      // 
      // userNameControl1
      // 
      this.userNameControl1.BackColor = System.Drawing.Color.Gray;
      this.userNameControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.userNameControl1.Location = new System.Drawing.Point(0, 0);
      this.userNameControl1.Margin = new System.Windows.Forms.Padding(0);
      this.userNameControl1.Name = "userNameControl1";
      this.userNameControl1.Size = new System.Drawing.Size(120, 30);
      this.userNameControl1.TabIndex = 16;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(1220, 594);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Name = "Main";
      this.Text = "_WONDERLAND Alpha 0.1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Shown += new System.EventHandler(this.Main_Shown);
      this.LocationChanged += new System.EventHandler(this.Main_LocationChanged);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
      this.Leave += new System.EventHandler(this.Main_Leave);
      this.MouseLeave += new System.EventHandler(this.Main_MouseLeave);
      this.Move += new System.EventHandler(this.Main_Move);
      this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Main_PreviewKeyDown);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.tableLayoutPanel4.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Timer RenderTimer;
    private System.Windows.Forms.RichTextBox StatusBox;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private src.Controls.CObjectInspector objectInspector1;
    private src.Controls.CPosition cPosition1;
    private System.Windows.Forms.Button ConnectionButton;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    private System.Windows.Forms.Button GoButton;
    private System.Windows.Forms.Button HomeButton;
    private System.Windows.Forms.Button _HelpButton;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.Button DebugButton;
    private System.Windows.Forms.Button FogEnableButton;
    private System.Windows.Forms.Button ShadowButton;
    private src.Controls.CMotionTypeControl cMotionTypeControl1;
    private System.Windows.Forms.Button MapButton;
    private System.Windows.Forms.ToolTip toolTip1;
    private src.Controls.CMotionTypeControl cMotionTypeControl2;
    private src.Controls.CPosition cPosition2;
    private src.Controls.CacheControl cacheControl2;    
    private src.Controls.CObjectInspector cObjectInspector2;
    private src.Controls.CBuildPartSelecter cBuildPartSelecter2;
    private src.Controls.CUserNameControl userNameControl1;
    private src.Controls.CButtonBar cButtonBar1;
    private System.Windows.Forms.TextBox LocusBox;
  }
}

