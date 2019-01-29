namespace ThisIsMassive.src.Controls
{
  partial class CUserNameControl
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.Username = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.StatusText = new System.Windows.Forms.Label();
      this.CreditLabel = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.47518F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.52483F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
      this.tableLayoutPanel1.Controls.Add(this.Username, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.StatusText, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.CreditLabel, 2, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(167, 39);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // Username
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.Username, 2);
      this.Username.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Username.Location = new System.Drawing.Point(15, 0);
      this.Username.Name = "Username";
      this.Username.Size = new System.Drawing.Size(149, 19);
      this.Username.TabIndex = 0;
      this.Username.Text = "Anonymouse";
      this.Username.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.Username.Click += new System.EventHandler(this.Username_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.Image = global::ThisIsMassive.Properties.Resources.icons8_user_16;
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(12, 19);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new System.EventHandler(this.Username_Click);
      // 
      // StatusText
      // 
      this.StatusText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.StatusText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.StatusText.Location = new System.Drawing.Point(15, 19);
      this.StatusText.Name = "StatusText";
      this.StatusText.Size = new System.Drawing.Size(74, 20);
      this.StatusText.TabIndex = 2;
      this.StatusText.Text = "0/0";
      this.StatusText.Click += new System.EventHandler(this.Username_Click);
      // 
      // CreditLabel
      // 
      this.CreditLabel.AutoSize = true;
      this.CreditLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CreditLabel.Location = new System.Drawing.Point(95, 19);
      this.CreditLabel.Name = "CreditLabel";
      this.CreditLabel.Size = new System.Drawing.Size(69, 20);
      this.CreditLabel.TabIndex = 3;
      this.CreditLabel.Text = "$1000";
      this.CreditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // CUserNameControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Gray;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "CUserNameControl";
      this.Size = new System.Drawing.Size(167, 39);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label Username;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label StatusText;
    private System.Windows.Forms.Label CreditLabel;
  }
}
