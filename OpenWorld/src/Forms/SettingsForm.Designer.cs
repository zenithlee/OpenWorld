﻿namespace OpenWorld.Forms
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
      this.TerrainPhysicsCheck = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.GravityCheck = new System.Windows.Forms.CheckBox();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.Controls.Add(this.TerrainPhysicsCheck, 1, 1);
      this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.GravityCheck, 1, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 21);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 5;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(296, 435);
      this.tableLayoutPanel2.TabIndex = 2;
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
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox GravityCheck;
    private System.Windows.Forms.CheckBox TerrainPhysicsCheck;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}