namespace OpenWorld.Forms
{
  partial class BuildForm
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
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.AddFoundation = new System.Windows.Forms.Button();
      this.PartsView = new System.Windows.Forms.ListView();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.75367F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.24634F));
      this.tableLayoutPanel2.Controls.Add(this.AddFoundation, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.PartsView, 0, 1);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 21);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.236842F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.76316F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(341, 456);
      this.tableLayoutPanel2.TabIndex = 2;
      // 
      // AddFoundation
      // 
      this.AddFoundation.Dock = System.Windows.Forms.DockStyle.Fill;
      this.AddFoundation.Location = new System.Drawing.Point(0, 0);
      this.AddFoundation.Margin = new System.Windows.Forms.Padding(0);
      this.AddFoundation.Name = "AddFoundation";
      this.AddFoundation.Size = new System.Drawing.Size(81, 33);
      this.AddFoundation.TabIndex = 0;
      this.AddFoundation.Text = "AddButton";
      this.AddFoundation.UseVisualStyleBackColor = true;
      this.AddFoundation.Click += new System.EventHandler(this.AddFoundation_Click);
      // 
      // PartsView
      // 
      this.tableLayoutPanel2.SetColumnSpan(this.PartsView, 2);
      this.PartsView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PartsView.LabelWrap = false;
      this.PartsView.LargeImageList = this.imageList1;
      this.PartsView.Location = new System.Drawing.Point(3, 36);
      this.PartsView.Name = "PartsView";
      this.PartsView.Size = new System.Drawing.Size(335, 417);
      this.PartsView.TabIndex = 1;
      this.PartsView.UseCompatibleStateImageBehavior = false;
      this.PartsView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PartsView_MouseDoubleClick);
      // 
      // imageList1
      // 
      this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
      this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // BuildForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(345, 479);
      this.Controls.Add(this.tableLayoutPanel2);
      this.Name = "BuildForm";
      this.Text = "BuildForm";
      this.Load += new System.EventHandler(this.BuildForm_Load);
      this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button AddFoundation;
    private System.Windows.Forms.ListView PartsView;
    private System.Windows.Forms.ImageList imageList1;
  }
}