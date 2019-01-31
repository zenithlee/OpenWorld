namespace OpenWorld
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.connectControl1 = new OpenWorld.src.Controls.ConnectControl();
      this.view3D1 = new OpenWorld.View3D();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.positionControl1 = new OpenWorld.src.Controls.PositionControl();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.68273F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.317269F));
      this.tableLayoutPanel1.Controls.Add(this.connectControl1, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.view3D1, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.positionControl1, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.53978F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.460218F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(996, 641);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // connectControl1
      // 
      this.connectControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.connectControl1.Location = new System.Drawing.Point(953, 0);
      this.connectControl1.Margin = new System.Windows.Forms.Padding(0);
      this.connectControl1.Name = "connectControl1";
      this.connectControl1.Size = new System.Drawing.Size(43, 32);
      this.connectControl1.TabIndex = 1;
      this.connectControl1.Load += new System.EventHandler(this.connectControl1_Load);
      // 
      // view3D1
      // 
      this.view3D1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.view3D1.Location = new System.Drawing.Point(3, 35);
      this.view3D1.Name = "view3D1";
      this.view3D1.Size = new System.Drawing.Size(947, 569);
      this.view3D1.TabIndex = 2;
      // 
      // positionControl1
      // 
      this.positionControl1.Location = new System.Drawing.Point(3, 3);
      this.positionControl1.Name = "positionControl1";
      this.positionControl1.Size = new System.Drawing.Size(304, 26);
      this.positionControl1.TabIndex = 3;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(996, 641);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "Open World";
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

   
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Timer timer1;
    private src.Controls.ConnectControl connectControl1;
    private View3D view3D1;
    private src.Controls.PositionControl positionControl1;
  }
}

