namespace OpenWorld.Controls
{
  partial class CChatControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CChatControl));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.ChatBox = new System.Windows.Forms.RichTextBox();
      this.SendButton = new System.Windows.Forms.Button();
      this.ChatBoxMessage = new System.Windows.Forms.RichTextBox();
      this.GiveCake = new System.Windows.Forms.Button();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.ChatBox, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.SendButton, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.ChatBoxMessage, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.GiveCake, 0, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 493);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // ChatBox
      // 
      this.ChatBox.BackColor = System.Drawing.Color.Black;
      this.ChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tableLayoutPanel1.SetColumnSpan(this.ChatBox, 2);
      this.ChatBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ChatBox.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ChatBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.ChatBox.Location = new System.Drawing.Point(0, 0);
      this.ChatBox.Margin = new System.Windows.Forms.Padding(0);
      this.ChatBox.Name = "ChatBox";
      this.ChatBox.ReadOnly = true;
      this.ChatBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
      this.ChatBox.Size = new System.Drawing.Size(280, 397);
      this.ChatBox.TabIndex = 0;
      this.ChatBox.Text = "";
      this.ChatBox.VisibleChanged += new System.EventHandler(this.ChatBox_VisibleChanged);
      // 
      // SendButton
      // 
      this.SendButton.BackColor = System.Drawing.Color.Gray;
      this.SendButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SendButton.FlatAppearance.BorderSize = 0;
      this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SendButton.ForeColor = System.Drawing.Color.White;
      this.SendButton.Location = new System.Drawing.Point(140, 461);
      this.SendButton.Margin = new System.Windows.Forms.Padding(0);
      this.SendButton.Name = "SendButton";
      this.SendButton.Size = new System.Drawing.Size(140, 32);
      this.SendButton.TabIndex = 1;
      this.SendButton.Text = "Send";
      this.SendButton.UseVisualStyleBackColor = false;
      this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
      // 
      // ChatBoxMessage
      // 
      this.ChatBoxMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.ChatBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tableLayoutPanel1.SetColumnSpan(this.ChatBoxMessage, 2);
      this.ChatBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ChatBoxMessage.ForeColor = System.Drawing.Color.White;
      this.ChatBoxMessage.Location = new System.Drawing.Point(0, 397);
      this.ChatBoxMessage.Margin = new System.Windows.Forms.Padding(0);
      this.ChatBoxMessage.MaxLength = 2048;
      this.ChatBoxMessage.Name = "ChatBoxMessage";
      this.ChatBoxMessage.Size = new System.Drawing.Size(280, 64);
      this.ChatBoxMessage.TabIndex = 2;
      this.ChatBoxMessage.Text = "";
      this.ChatBoxMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChatBoxMessage_KeyUp);
      // 
      // GiveCake
      // 
      this.GiveCake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      this.GiveCake.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GiveCake.FlatAppearance.BorderSize = 0;
      this.GiveCake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.GiveCake.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.GiveCake.ImageIndex = 0;
      this.GiveCake.ImageList = this.imageList1;
      this.GiveCake.Location = new System.Drawing.Point(0, 461);
      this.GiveCake.Margin = new System.Windows.Forms.Padding(0);
      this.GiveCake.Name = "GiveCake";
      this.GiveCake.Size = new System.Drawing.Size(140, 32);
      this.GiveCake.TabIndex = 3;
      this.GiveCake.Text = "Cake";
      this.GiveCake.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.GiveCake, "Give Cake");
      this.GiveCake.UseVisualStyleBackColor = false;
      this.GiveCake.Click += new System.EventHandler(this.GiveCake_Click);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "icons8-cake-64.png");
      // 
      // CChatControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "CChatControl";
      this.Padding = new System.Windows.Forms.Padding(1);
      this.Size = new System.Drawing.Size(282, 495);
      this.Load += new System.EventHandler(this.CChatControl_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.RichTextBox ChatBox;
    private System.Windows.Forms.Button SendButton;
    private System.Windows.Forms.RichTextBox ChatBoxMessage;
    private System.Windows.Forms.Button GiveCake;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}
