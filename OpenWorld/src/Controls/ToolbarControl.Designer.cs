namespace OpenWorld.Controls
{
  partial class ToolbarControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolbarControl));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.ChatButton = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.BuildButton = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.BuildButton, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.ChatButton, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 5;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(45, 388);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // ChatButton
      // 
      this.ChatButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChatButton.BackgroundImage")));
      this.ChatButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.ChatButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ChatButton.Location = new System.Drawing.Point(0, 0);
      this.ChatButton.Margin = new System.Windows.Forms.Padding(0);
      this.ChatButton.Name = "ChatButton";
      this.ChatButton.Size = new System.Drawing.Size(45, 32);
      this.ChatButton.TabIndex = 0;
      this.toolTip1.SetToolTip(this.ChatButton, "Chat with others");
      this.ChatButton.UseVisualStyleBackColor = true;
      this.ChatButton.Click += new System.EventHandler(this.ChatButton_Click);
      // 
      // BuildButton
      // 
      this.BuildButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuildButton.BackgroundImage")));
      this.BuildButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.BuildButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.BuildButton.Location = new System.Drawing.Point(0, 32);
      this.BuildButton.Margin = new System.Windows.Forms.Padding(0);
      this.BuildButton.Name = "BuildButton";
      this.BuildButton.Size = new System.Drawing.Size(45, 32);
      this.BuildButton.TabIndex = 1;
      this.toolTip1.SetToolTip(this.BuildButton, "Chat with others");
      this.BuildButton.UseVisualStyleBackColor = true;
      this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
      // 
      // ToolbarControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "ToolbarControl";
      this.Size = new System.Drawing.Size(45, 388);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button ChatButton;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button BuildButton;
  }
}
