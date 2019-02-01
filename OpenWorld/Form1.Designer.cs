namespace OpenWorld
{
  partial class Form1
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.connectControl1 = new OpenWorld.src.Controls.ConnectControl();
      this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
      this.HomeButton = new System.Windows.Forms.Button();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      this.ButtonLayout.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.83013F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.169867F));
      this.tableLayoutPanel1.Controls.Add(this.connectControl1, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.ButtonLayout, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.736138F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.26386F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(677, 523);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // connectControl1
      // 
      this.connectControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.connectControl1.Location = new System.Drawing.Point(641, 0);
      this.connectControl1.Margin = new System.Windows.Forms.Padding(0);
      this.connectControl1.Name = "connectControl1";
      this.connectControl1.Size = new System.Drawing.Size(36, 30);
      this.connectControl1.TabIndex = 0;
      // 
      // ButtonLayout
      // 
      this.ButtonLayout.ColumnCount = 2;
      this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.ButtonLayout.Controls.Add(this.HomeButton, 0, 0);
      this.ButtonLayout.Location = new System.Drawing.Point(0, 0);
      this.ButtonLayout.Margin = new System.Windows.Forms.Padding(0);
      this.ButtonLayout.Name = "ButtonLayout";
      this.ButtonLayout.RowCount = 1;
      this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.ButtonLayout.Size = new System.Drawing.Size(200, 30);
      this.ButtonLayout.TabIndex = 1;
      // 
      // HomeButton
      // 
      this.HomeButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.HomeButton.Location = new System.Drawing.Point(0, 0);
      this.HomeButton.Margin = new System.Windows.Forms.Padding(0);
      this.HomeButton.Name = "HomeButton";
      this.HomeButton.Size = new System.Drawing.Size(100, 30);
      this.HomeButton.TabIndex = 0;
      this.HomeButton.Text = "Home";
      this.HomeButton.UseVisualStyleBackColor = true;
      this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
      // 
      // timer1
      // 
      this.timer1.Interval = 30;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(677, 523);
      this.Controls.Add(this.tableLayoutPanel1);
      this.KeyPreview = true;
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ButtonLayout.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private src.Controls.ConnectControl connectControl1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.TableLayoutPanel ButtonLayout;
    private System.Windows.Forms.Button HomeButton;
  }
}

