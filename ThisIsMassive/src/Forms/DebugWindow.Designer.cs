namespace ThisIsMassive.src.Forms
{
  partial class DebugWindow
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
      this.Tweak2Bar = new System.Windows.Forms.TrackBar();
      this.TriggerButton = new System.Windows.Forms.Button();
      this.GotoButton = new System.Windows.Forms.Button();
      this.GetVisible = new System.Windows.Forms.Button();
      this.DebugPhysics = new System.Windows.Forms.Button();
      this.DepthDebug = new System.Windows.Forms.Button();
      this.DisableRender = new System.Windows.Forms.Button();
      this.TestButton = new System.Windows.Forms.Button();
      this.EditShader = new System.Windows.Forms.Button();
      this.GetMyData = new System.Windows.Forms.Button();
      this.GraphView = new System.Windows.Forms.TreeView();
      this.cacheControl1 = new ThisIsMassive.src.Controls.CacheControl();
      this.GetGraph = new System.Windows.Forms.Button();
      this.Status = new System.Windows.Forms.TextBox();
      this.MergeButton = new System.Windows.Forms.Button();
      this.Tweaker1 = new System.Windows.Forms.TrackBar();
      this.TweakValue = new System.Windows.Forms.Label();
      this.ItemInfo = new System.Windows.Forms.TextBox();
      this.DeleteNode = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Tweak2Bar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Tweaker1)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 8;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
      this.tableLayoutPanel1.Controls.Add(this.Tweak2Bar, 7, 1);
      this.tableLayoutPanel1.Controls.Add(this.TriggerButton, 7, 2);
      this.tableLayoutPanel1.Controls.Add(this.GotoButton, 6, 2);
      this.tableLayoutPanel1.Controls.Add(this.GetVisible, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.DebugPhysics, 3, 1);
      this.tableLayoutPanel1.Controls.Add(this.DepthDebug, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.DisableRender, 4, 1);
      this.tableLayoutPanel1.Controls.Add(this.TestButton, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.EditShader, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.GetMyData, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.GraphView, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.cacheControl1, 5, 0);
      this.tableLayoutPanel1.Controls.Add(this.GetGraph, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.Status, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.MergeButton, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.Tweaker1, 5, 1);
      this.tableLayoutPanel1.Controls.Add(this.TweakValue, 6, 1);
      this.tableLayoutPanel1.Controls.Add(this.ItemInfo, 5, 3);
      this.tableLayoutPanel1.Controls.Add(this.DeleteNode, 5, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 5;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(932, 662);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // Tweak2Bar
      // 
      this.Tweak2Bar.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Tweak2Bar.Location = new System.Drawing.Point(761, 35);
      this.Tweak2Bar.Maximum = 100;
      this.Tweak2Bar.Minimum = -100;
      this.Tweak2Bar.Name = "Tweak2Bar";
      this.Tweak2Bar.Size = new System.Drawing.Size(168, 27);
      this.Tweak2Bar.TabIndex = 33;
      this.Tweak2Bar.TickFrequency = 10;
      this.Tweak2Bar.ValueChanged += new System.EventHandler(this.Tweak2Bar_ValueChanged);
      // 
      // TriggerButton
      // 
      this.TriggerButton.BackColor = System.Drawing.Color.Silver;
      this.TriggerButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TriggerButton.FlatAppearance.BorderSize = 0;
      this.TriggerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.TriggerButton.Location = new System.Drawing.Point(758, 65);
      this.TriggerButton.Margin = new System.Windows.Forms.Padding(0);
      this.TriggerButton.Name = "TriggerButton";
      this.TriggerButton.Size = new System.Drawing.Size(174, 32);
      this.TriggerButton.TabIndex = 32;
      this.TriggerButton.Text = "Trigger";
      this.TriggerButton.UseVisualStyleBackColor = false;
      this.TriggerButton.Click += new System.EventHandler(this.TriggerButton_Click);
      // 
      // GotoButton
      // 
      this.GotoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.GotoButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GotoButton.FlatAppearance.BorderSize = 0;
      this.GotoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.GotoButton.Location = new System.Drawing.Point(698, 65);
      this.GotoButton.Margin = new System.Windows.Forms.Padding(0);
      this.GotoButton.Name = "GotoButton";
      this.GotoButton.Size = new System.Drawing.Size(60, 32);
      this.GotoButton.TabIndex = 31;
      this.GotoButton.Text = "Goto";
      this.GotoButton.UseVisualStyleBackColor = false;
      this.GotoButton.Click += new System.EventHandler(this.GotoButton_Click);
      // 
      // GetVisible
      // 
      this.GetVisible.BackColor = System.Drawing.Color.DarkGray;
      this.GetVisible.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GetVisible.FlatAppearance.BorderSize = 0;
      this.GetVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.GetVisible.Location = new System.Drawing.Point(360, 0);
      this.GetVisible.Margin = new System.Windows.Forms.Padding(0);
      this.GetVisible.Name = "GetVisible";
      this.GetVisible.Size = new System.Drawing.Size(120, 32);
      this.GetVisible.TabIndex = 29;
      this.GetVisible.Text = "Get My Visible Items";
      this.GetVisible.UseVisualStyleBackColor = false;
      this.GetVisible.Click += new System.EventHandler(this.GetVisible_Click);
      // 
      // DebugPhysics
      // 
      this.DebugPhysics.BackColor = System.Drawing.Color.DimGray;
      this.DebugPhysics.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DebugPhysics.FlatAppearance.BorderSize = 0;
      this.DebugPhysics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.DebugPhysics.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.DebugPhysics.ForeColor = System.Drawing.Color.White;
      this.DebugPhysics.Location = new System.Drawing.Point(361, 33);
      this.DebugPhysics.Margin = new System.Windows.Forms.Padding(1);
      this.DebugPhysics.Name = "DebugPhysics";
      this.DebugPhysics.Size = new System.Drawing.Size(118, 31);
      this.DebugPhysics.TabIndex = 26;
      this.DebugPhysics.Text = "DEBUGPHYSICS";
      this.DebugPhysics.UseVisualStyleBackColor = false;
      this.DebugPhysics.Click += new System.EventHandler(this.DebugPhysics_Click);
      // 
      // DepthDebug
      // 
      this.DepthDebug.BackColor = System.Drawing.Color.DimGray;
      this.DepthDebug.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DepthDebug.FlatAppearance.BorderSize = 0;
      this.DepthDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.DepthDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.DepthDebug.ForeColor = System.Drawing.Color.White;
      this.DepthDebug.Location = new System.Drawing.Point(241, 33);
      this.DepthDebug.Margin = new System.Windows.Forms.Padding(1);
      this.DepthDebug.Name = "DepthDebug";
      this.DepthDebug.Size = new System.Drawing.Size(118, 31);
      this.DepthDebug.TabIndex = 25;
      this.DepthDebug.Text = "DEBUGDEPTH";
      this.DepthDebug.UseVisualStyleBackColor = false;
      this.DepthDebug.Click += new System.EventHandler(this.DepthDebug_Click);
      // 
      // DisableRender
      // 
      this.DisableRender.BackColor = System.Drawing.Color.DimGray;
      this.DisableRender.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DisableRender.FlatAppearance.BorderSize = 0;
      this.DisableRender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.DisableRender.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.DisableRender.ForeColor = System.Drawing.Color.White;
      this.DisableRender.Location = new System.Drawing.Point(481, 33);
      this.DisableRender.Margin = new System.Windows.Forms.Padding(1);
      this.DisableRender.Name = "DisableRender";
      this.DisableRender.Size = new System.Drawing.Size(87, 31);
      this.DisableRender.TabIndex = 24;
      this.DisableRender.Text = "RENDEROFF";
      this.DisableRender.UseVisualStyleBackColor = false;
      this.DisableRender.Click += new System.EventHandler(this.DisableRender_Click);
      // 
      // TestButton
      // 
      this.TestButton.BackColor = System.Drawing.Color.DimGray;
      this.TestButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TestButton.FlatAppearance.BorderSize = 0;
      this.TestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.TestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TestButton.ForeColor = System.Drawing.Color.White;
      this.TestButton.Location = new System.Drawing.Point(121, 33);
      this.TestButton.Margin = new System.Windows.Forms.Padding(1);
      this.TestButton.Name = "TestButton";
      this.TestButton.Size = new System.Drawing.Size(118, 31);
      this.TestButton.TabIndex = 23;
      this.TestButton.Text = "Test";
      this.TestButton.UseVisualStyleBackColor = false;
      this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
      // 
      // EditShader
      // 
      this.EditShader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.EditShader.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EditShader.FlatAppearance.BorderSize = 0;
      this.EditShader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.EditShader.Location = new System.Drawing.Point(120, 0);
      this.EditShader.Margin = new System.Windows.Forms.Padding(0);
      this.EditShader.Name = "EditShader";
      this.EditShader.Size = new System.Drawing.Size(120, 32);
      this.EditShader.TabIndex = 19;
      this.EditShader.Text = "Edit Shader";
      this.EditShader.UseVisualStyleBackColor = false;
      this.EditShader.Click += new System.EventHandler(this.EditShader_Click);
      // 
      // GetMyData
      // 
      this.GetMyData.BackColor = System.Drawing.Color.DarkGray;
      this.GetMyData.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GetMyData.FlatAppearance.BorderSize = 0;
      this.GetMyData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.GetMyData.Location = new System.Drawing.Point(240, 0);
      this.GetMyData.Margin = new System.Windows.Forms.Padding(0);
      this.GetMyData.Name = "GetMyData";
      this.GetMyData.Size = new System.Drawing.Size(120, 32);
      this.GetMyData.TabIndex = 18;
      this.GetMyData.Text = "Get All My Data";
      this.GetMyData.UseVisualStyleBackColor = false;
      this.GetMyData.Click += new System.EventHandler(this.GetMyData_Click);
      // 
      // GraphView
      // 
      this.GraphView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tableLayoutPanel1.SetColumnSpan(this.GraphView, 5);
      this.GraphView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GraphView.Location = new System.Drawing.Point(3, 100);
      this.GraphView.Name = "GraphView";
      this.GraphView.Size = new System.Drawing.Size(563, 539);
      this.GraphView.TabIndex = 0;
      this.GraphView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.GraphView_AfterSelect);
      // 
      // cacheControl1
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.cacheControl1, 3);
      this.cacheControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cacheControl1.Location = new System.Drawing.Point(569, 0);
      this.cacheControl1.Margin = new System.Windows.Forms.Padding(0);
      this.cacheControl1.Name = "cacheControl1";
      this.cacheControl1.Size = new System.Drawing.Size(363, 32);
      this.cacheControl1.TabIndex = 15;
      // 
      // GetGraph
      // 
      this.GetGraph.BackColor = System.Drawing.Color.Silver;
      this.GetGraph.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GetGraph.FlatAppearance.BorderSize = 0;
      this.GetGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.GetGraph.Location = new System.Drawing.Point(0, 0);
      this.GetGraph.Margin = new System.Windows.Forms.Padding(0);
      this.GetGraph.Name = "GetGraph";
      this.GetGraph.Size = new System.Drawing.Size(120, 32);
      this.GetGraph.TabIndex = 1;
      this.GetGraph.Text = "GetGraph";
      this.GetGraph.UseVisualStyleBackColor = false;
      this.GetGraph.Click += new System.EventHandler(this.GetGraph_Click);
      // 
      // Status
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.Status, 7);
      this.Status.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Status.Location = new System.Drawing.Point(3, 645);
      this.Status.Name = "Status";
      this.Status.Size = new System.Drawing.Size(752, 20);
      this.Status.TabIndex = 20;
      // 
      // MergeButton
      // 
      this.MergeButton.BackColor = System.Drawing.Color.DarkGray;
      this.MergeButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MergeButton.FlatAppearance.BorderSize = 0;
      this.MergeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.MergeButton.Location = new System.Drawing.Point(0, 32);
      this.MergeButton.Margin = new System.Windows.Forms.Padding(0);
      this.MergeButton.Name = "MergeButton";
      this.MergeButton.Size = new System.Drawing.Size(120, 33);
      this.MergeButton.TabIndex = 22;
      this.MergeButton.Text = "Merge My Data";
      this.MergeButton.UseVisualStyleBackColor = false;
      this.MergeButton.Click += new System.EventHandler(this.MergeMyData_Click);
      // 
      // Tweaker1
      // 
      this.Tweaker1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Tweaker1.Location = new System.Drawing.Point(572, 35);
      this.Tweaker1.Maximum = 100;
      this.Tweaker1.Minimum = -100;
      this.Tweaker1.Name = "Tweaker1";
      this.Tweaker1.Size = new System.Drawing.Size(123, 27);
      this.Tweaker1.TabIndex = 27;
      this.Tweaker1.TickFrequency = 10;
      this.Tweaker1.ValueChanged += new System.EventHandler(this.Tweaker1_ValueChanged);
      // 
      // TweakValue
      // 
      this.TweakValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TweakValue.Location = new System.Drawing.Point(701, 32);
      this.TweakValue.Name = "TweakValue";
      this.TweakValue.Size = new System.Drawing.Size(54, 33);
      this.TweakValue.TabIndex = 28;
      this.TweakValue.Text = "0";
      // 
      // ItemInfo
      // 
      this.ItemInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tableLayoutPanel1.SetColumnSpan(this.ItemInfo, 3);
      this.ItemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ItemInfo.Location = new System.Drawing.Point(572, 100);
      this.ItemInfo.MaxLength = 1132767;
      this.ItemInfo.Multiline = true;
      this.ItemInfo.Name = "ItemInfo";
      this.ItemInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.ItemInfo.Size = new System.Drawing.Size(357, 539);
      this.ItemInfo.TabIndex = 2;
      // 
      // DeleteNode
      // 
      this.DeleteNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.DeleteNode.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DeleteNode.FlatAppearance.BorderSize = 0;
      this.DeleteNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.DeleteNode.Location = new System.Drawing.Point(569, 65);
      this.DeleteNode.Margin = new System.Windows.Forms.Padding(0);
      this.DeleteNode.Name = "DeleteNode";
      this.DeleteNode.Size = new System.Drawing.Size(129, 32);
      this.DeleteNode.TabIndex = 30;
      this.DeleteNode.Text = "Delete";
      this.DeleteNode.UseVisualStyleBackColor = false;
      this.DeleteNode.Click += new System.EventHandler(this.DeleteNode_Click);
      // 
      // DebugWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(932, 662);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "DebugWindow";
      this.Text = "DebugWindow";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugWindow_FormClosing);
      this.Shown += new System.EventHandler(this.DebugWindow_Shown);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Tweak2Bar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Tweaker1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button EditShader;
    private System.Windows.Forms.Button GetMyData;
    private System.Windows.Forms.TreeView GraphView;
    private Controls.CacheControl cacheControl1;
    private System.Windows.Forms.Button GetGraph;
    private System.Windows.Forms.TextBox ItemInfo;
    private System.Windows.Forms.TextBox Status;
    private System.Windows.Forms.Button MergeButton;
    private System.Windows.Forms.Button TestButton;
    private System.Windows.Forms.Button DisableRender;
    private System.Windows.Forms.Button DepthDebug;
    private System.Windows.Forms.Button DebugPhysics;
    private System.Windows.Forms.TrackBar Tweaker1;
    private System.Windows.Forms.Label TweakValue;
    private System.Windows.Forms.Button GetVisible;
    private System.Windows.Forms.Button DeleteNode;
    private System.Windows.Forms.Button GotoButton;
    private System.Windows.Forms.Button TriggerButton;
    private System.Windows.Forms.TrackBar Tweak2Bar;
  }
}