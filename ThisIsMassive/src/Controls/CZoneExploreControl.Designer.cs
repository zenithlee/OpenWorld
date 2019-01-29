namespace ThisIsMassive.src.Controls
{
  partial class CZoneExploreControl
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
      System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Planets", System.Windows.Forms.HorizontalAlignment.Left);
      System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("UserZones", System.Windows.Forms.HorizontalAlignment.Left);
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Downloading...");
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.button1 = new System.Windows.Forms.Button();
      this.AddBookmarkButton = new System.Windows.Forms.Button();
      this.BookmarkListView = new System.Windows.Forms.ListView();
      this.ExploreContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.lookAtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.setAsHomeLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.replaceWithCurrentLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.BookmarkDelete = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      this.ExploreContextStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.AddBookmarkButton, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.BookmarkListView, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.BookmarkDelete, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Silver;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(245, 440);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.Black;
      this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.button1.FlatAppearance.BorderSize = 0;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.ForeColor = System.Drawing.Color.White;
      this.button1.Location = new System.Drawing.Point(1, 409);
      this.button1.Margin = new System.Windows.Forms.Padding(1);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(120, 30);
      this.button1.TabIndex = 8;
      this.button1.Text = "Surface";
      this.toolTip1.SetToolTip(this.button1, "Teleport to the nearest surface");
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.GoToSurfaceButton_Click);
      // 
      // AddBookmarkButton
      // 
      this.AddBookmarkButton.BackColor = System.Drawing.Color.Black;
      this.AddBookmarkButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.AddBookmarkButton.FlatAppearance.BorderSize = 0;
      this.AddBookmarkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.AddBookmarkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.AddBookmarkButton.ForeColor = System.Drawing.Color.White;
      this.AddBookmarkButton.Location = new System.Drawing.Point(1, 1);
      this.AddBookmarkButton.Margin = new System.Windows.Forms.Padding(1);
      this.AddBookmarkButton.Name = "AddBookmarkButton";
      this.AddBookmarkButton.Size = new System.Drawing.Size(120, 30);
      this.AddBookmarkButton.TabIndex = 2;
      this.AddBookmarkButton.Text = "Create";
      this.toolTip1.SetToolTip(this.AddBookmarkButton, "Create a new zone");
      this.AddBookmarkButton.UseVisualStyleBackColor = false;
      this.AddBookmarkButton.Click += new System.EventHandler(this.AddBookmarkButton_Click);
      // 
      // BookmarkListView
      // 
      this.BookmarkListView.BackColor = System.Drawing.Color.Black;
      this.tableLayoutPanel1.SetColumnSpan(this.BookmarkListView, 2);
      this.BookmarkListView.ContextMenuStrip = this.ExploreContextStrip;
      this.BookmarkListView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.BookmarkListView.ForeColor = System.Drawing.Color.Gray;
      this.BookmarkListView.GridLines = true;
      listViewGroup1.Header = "Planets";
      listViewGroup1.Name = "PlanetGroup";
      listViewGroup2.Header = "UserZones";
      listViewGroup2.Name = "UserZoneGroup";
      this.BookmarkListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
      listViewItem1.Group = listViewGroup1;
      this.BookmarkListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
      this.BookmarkListView.LabelEdit = true;
      this.BookmarkListView.Location = new System.Drawing.Point(0, 32);
      this.BookmarkListView.Margin = new System.Windows.Forms.Padding(0);
      this.BookmarkListView.Name = "BookmarkListView";
      this.BookmarkListView.ShowItemToolTips = true;
      this.BookmarkListView.Size = new System.Drawing.Size(245, 376);
      this.BookmarkListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.BookmarkListView.TabIndex = 3;
      this.toolTip1.SetToolTip(this.BookmarkListView, "Right click for more options");
      this.BookmarkListView.UseCompatibleStateImageBehavior = false;
      this.BookmarkListView.View = System.Windows.Forms.View.SmallIcon;
      this.BookmarkListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.BookmarkListView_AfterLabelEdit);
      this.BookmarkListView.SelectedIndexChanged += new System.EventHandler(this.BookmarkList_SelectedIndexChanged);
      this.BookmarkListView.DoubleClick += new System.EventHandler(this.BookmarkList_DoubleClick);
      // 
      // ExploreContextStrip
      // 
      this.ExploreContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lookAtToolStripMenuItem,
            this.setAsHomeLocationToolStripMenuItem,
            this.replaceWithCurrentLocationToolStripMenuItem});
      this.ExploreContextStrip.Name = "ExploreContextStrip";
      this.ExploreContextStrip.Size = new System.Drawing.Size(253, 70);
      // 
      // lookAtToolStripMenuItem
      // 
      this.lookAtToolStripMenuItem.Name = "lookAtToolStripMenuItem";
      this.lookAtToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
      this.lookAtToolStripMenuItem.Text = "LookAt";
      this.lookAtToolStripMenuItem.Click += new System.EventHandler(this.lookAtToolStripMenuItem_Click);
      // 
      // setAsHomeLocationToolStripMenuItem
      // 
      this.setAsHomeLocationToolStripMenuItem.Name = "setAsHomeLocationToolStripMenuItem";
      this.setAsHomeLocationToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
      this.setAsHomeLocationToolStripMenuItem.Text = "Set as Home Location";
      this.setAsHomeLocationToolStripMenuItem.Click += new System.EventHandler(this.setAsHomeLocationToolStripMenuItem_Click);
      // 
      // replaceWithCurrentLocationToolStripMenuItem
      // 
      this.replaceWithCurrentLocationToolStripMenuItem.Name = "replaceWithCurrentLocationToolStripMenuItem";
      this.replaceWithCurrentLocationToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
      this.replaceWithCurrentLocationToolStripMenuItem.Text = "Update Location To This Location";
      this.replaceWithCurrentLocationToolStripMenuItem.Click += new System.EventHandler(this.replaceWithCurrentLocationToolStripMenuItem_Click);
      // 
      // BookmarkDelete
      // 
      this.BookmarkDelete.BackColor = System.Drawing.Color.Black;
      this.BookmarkDelete.Dock = System.Windows.Forms.DockStyle.Fill;
      this.BookmarkDelete.FlatAppearance.BorderSize = 0;
      this.BookmarkDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.BookmarkDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BookmarkDelete.ForeColor = System.Drawing.Color.Firebrick;
      this.BookmarkDelete.Location = new System.Drawing.Point(123, 1);
      this.BookmarkDelete.Margin = new System.Windows.Forms.Padding(1);
      this.BookmarkDelete.Name = "BookmarkDelete";
      this.BookmarkDelete.Size = new System.Drawing.Size(121, 30);
      this.BookmarkDelete.TabIndex = 4;
      this.BookmarkDelete.Text = "Delete";
      this.toolTip1.SetToolTip(this.BookmarkDelete, "Delete the selected zone");
      this.BookmarkDelete.UseVisualStyleBackColor = false;
      this.BookmarkDelete.Click += new System.EventHandler(this.BookmarkDelete_Click);
      // 
      // UpdateTimer
      // 
      this.UpdateTimer.Interval = 1000;
      this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
      // 
      // CZoneExploreControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.Controls.Add(this.tableLayoutPanel1);
      this.ForeColor = System.Drawing.Color.White;
      this.Margin = new System.Windows.Forms.Padding(0);
      this.Name = "CZoneExploreControl";
      this.Size = new System.Drawing.Size(245, 440);
      this.Load += new System.EventHandler(this.CExploreControl_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ExploreContextStrip.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button AddBookmarkButton;
    private System.Windows.Forms.ListView BookmarkListView;
    private System.Windows.Forms.Button BookmarkDelete;
    private System.Windows.Forms.ContextMenuStrip ExploreContextStrip;
    private System.Windows.Forms.ToolStripMenuItem replaceWithCurrentLocationToolStripMenuItem;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ToolStripMenuItem setAsHomeLocationToolStripMenuItem;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.ToolStripMenuItem lookAtToolStripMenuItem;
    private System.Windows.Forms.Timer UpdateTimer;
  }
}
