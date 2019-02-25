namespace OpenWorld.Forms
{
  partial class SettingsForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.DebugDepthCheck = new System.Windows.Forms.CheckBox();
      this.label4 = new System.Windows.Forms.Label();
      this.DebugPhysicsCheck = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.TerrainPhysicsCheck = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.GravityCheck = new System.Windows.Forms.CheckBox();
      this.TweakBar1 = new System.Windows.Forms.TrackBar();
      this.TweakBar2 = new System.Windows.Forms.TrackBar();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.TweakBar4 = new System.Windows.Forms.TrackBar();
      this.TweakBar3 = new System.Windows.Forms.TrackBar();
      this.tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TweakBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TweakBar2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TweakBar4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TweakBar3)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.Controls.Add(this.TweakBar3, 0, 5);
      this.tableLayoutPanel2.Controls.Add(this.TweakBar4, 0, 5);
      this.tableLayoutPanel2.Controls.Add(this.DebugDepthCheck, 1, 3);
      this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
      this.tableLayoutPanel2.Controls.Add(this.DebugPhysicsCheck, 1, 2);
      this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
      this.tableLayoutPanel2.Controls.Add(this.TerrainPhysicsCheck, 1, 1);
      this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.GravityCheck, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.TweakBar1, 0, 4);
      this.tableLayoutPanel2.Controls.Add(this.TweakBar2, 1, 4);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 21);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 7;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(296, 435);
      this.tableLayoutPanel2.TabIndex = 2;
      // 
      // DebugDepthCheck
      // 
      this.DebugDepthCheck.AutoSize = true;
      this.DebugDepthCheck.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DebugDepthCheck.ForeColor = System.Drawing.Color.White;
      this.DebugDepthCheck.Location = new System.Drawing.Point(151, 99);
      this.DebugDepthCheck.Name = "DebugDepthCheck";
      this.DebugDepthCheck.Size = new System.Drawing.Size(142, 26);
      this.DebugDepthCheck.TabIndex = 7;
      this.DebugDepthCheck.Text = "Enabled";
      this.DebugDepthCheck.UseVisualStyleBackColor = true;
      this.DebugDepthCheck.CheckedChanged += new System.EventHandler(this.DebugDepthCheck_CheckedChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new System.Drawing.Point(3, 96);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(142, 32);
      this.label4.TabIndex = 6;
      this.label4.Text = "Debug Depth";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.toolTip1.SetToolTip(this.label4, "Only applies to new terrain tiles");
      // 
      // DebugPhysicsCheck
      // 
      this.DebugPhysicsCheck.AutoSize = true;
      this.DebugPhysicsCheck.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DebugPhysicsCheck.ForeColor = System.Drawing.Color.White;
      this.DebugPhysicsCheck.Location = new System.Drawing.Point(151, 67);
      this.DebugPhysicsCheck.Name = "DebugPhysicsCheck";
      this.DebugPhysicsCheck.Size = new System.Drawing.Size(142, 26);
      this.DebugPhysicsCheck.TabIndex = 5;
      this.DebugPhysicsCheck.Text = "Enabled";
      this.DebugPhysicsCheck.UseVisualStyleBackColor = true;
      this.DebugPhysicsCheck.CheckedChanged += new System.EventHandler(this.DebugPhysicsCheck_CheckedChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(3, 64);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(142, 32);
      this.label3.TabIndex = 4;
      this.label3.Text = "Debug Physics";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.toolTip1.SetToolTip(this.label3, "Only applies to new terrain tiles");
      // 
      // TerrainPhysicsCheck
      // 
      this.TerrainPhysicsCheck.AutoSize = true;
      this.TerrainPhysicsCheck.Checked = true;
      this.TerrainPhysicsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.TerrainPhysicsCheck.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TerrainPhysicsCheck.ForeColor = System.Drawing.Color.White;
      this.TerrainPhysicsCheck.Location = new System.Drawing.Point(151, 35);
      this.TerrainPhysicsCheck.Name = "TerrainPhysicsCheck";
      this.TerrainPhysicsCheck.Size = new System.Drawing.Size(142, 26);
      this.TerrainPhysicsCheck.TabIndex = 3;
      this.TerrainPhysicsCheck.Text = "Enabled";
      this.TerrainPhysicsCheck.UseVisualStyleBackColor = true;
      this.TerrainPhysicsCheck.CheckedChanged += new System.EventHandler(this.TerrainPhysicsCheck_CheckedChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(3, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(142, 32);
      this.label2.TabIndex = 2;
      this.label2.Text = "Terrain Physics";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.toolTip1.SetToolTip(this.label2, "Only applies to new terrain tiles");
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(142, 32);
      this.label1.TabIndex = 0;
      this.label1.Text = "Gravity";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.toolTip1.SetToolTip(this.label1, "Global gravity");
      // 
      // GravityCheck
      // 
      this.GravityCheck.AutoSize = true;
      this.GravityCheck.Checked = true;
      this.GravityCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.GravityCheck.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GravityCheck.ForeColor = System.Drawing.Color.White;
      this.GravityCheck.Location = new System.Drawing.Point(151, 3);
      this.GravityCheck.Name = "GravityCheck";
      this.GravityCheck.Size = new System.Drawing.Size(142, 26);
      this.GravityCheck.TabIndex = 1;
      this.GravityCheck.Text = "Enabled";
      this.GravityCheck.UseVisualStyleBackColor = true;
      this.GravityCheck.CheckedChanged += new System.EventHandler(this.GravityCheck_CheckedChanged);
      // 
      // TweakBar1
      // 
      this.TweakBar1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TweakBar1.LargeChange = 10;
      this.TweakBar1.Location = new System.Drawing.Point(3, 131);
      this.TweakBar1.Maximum = 100;
      this.TweakBar1.Name = "TweakBar1";
      this.TweakBar1.Size = new System.Drawing.Size(142, 27);
      this.TweakBar1.TabIndex = 8;
      this.TweakBar1.TickFrequency = 10;
      this.TweakBar1.Scroll += new System.EventHandler(this.TweakBar1_Scroll);
      // 
      // TweakBar2
      // 
      this.TweakBar2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TweakBar2.LargeChange = 10;
      this.TweakBar2.Location = new System.Drawing.Point(151, 131);
      this.TweakBar2.Maximum = 100;
      this.TweakBar2.Name = "TweakBar2";
      this.TweakBar2.Size = new System.Drawing.Size(142, 27);
      this.TweakBar2.TabIndex = 9;
      this.TweakBar2.TickFrequency = 10;
      this.TweakBar2.Scroll += new System.EventHandler(this.TweakBar2_Scroll);
      // 
      // TweakBar4
      // 
      this.TweakBar4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TweakBar4.LargeChange = 10;
      this.TweakBar4.Location = new System.Drawing.Point(151, 164);
      this.TweakBar4.Maximum = 100;
      this.TweakBar4.Name = "TweakBar4";
      this.TweakBar4.Size = new System.Drawing.Size(142, 27);
      this.TweakBar4.TabIndex = 10;
      this.TweakBar4.TickFrequency = 10;
      this.TweakBar4.Scroll += new System.EventHandler(this.TweakBar4_Scroll);
      // 
      // TweakBar3
      // 
      this.TweakBar3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TweakBar3.LargeChange = 10;
      this.TweakBar3.Location = new System.Drawing.Point(3, 164);
      this.TweakBar3.Maximum = 100;
      this.TweakBar3.Name = "TweakBar3";
      this.TweakBar3.Size = new System.Drawing.Size(142, 27);
      this.TweakBar3.TabIndex = 11;
      this.TweakBar3.TickFrequency = 10;
      this.TweakBar3.Scroll += new System.EventHandler(this.TweakBar3_Scroll);
      // 
      // SettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(300, 458);
      this.Controls.Add(this.tableLayoutPanel2);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "SettingsForm";
      this.Text = "Settings";
      this.Load += new System.EventHandler(this.SettingsForm_Load);
      this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TweakBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TweakBar2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TweakBar4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TweakBar3)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox GravityCheck;
    private System.Windows.Forms.CheckBox TerrainPhysicsCheck;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.CheckBox DebugPhysicsCheck;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox DebugDepthCheck;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TrackBar TweakBar1;
    private System.Windows.Forms.TrackBar TweakBar2;
    private System.Windows.Forms.TrackBar TweakBar3;
    private System.Windows.Forms.TrackBar TweakBar4;
  }
}