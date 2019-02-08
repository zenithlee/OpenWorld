namespace OpenWorld.src.Controls
{
  partial class ObjectMoveControl
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
      this.MoveZMinus = new System.Windows.Forms.Button();
      this.MoveZPlus = new System.Windows.Forms.Button();
      this.MoveYMinus = new System.Windows.Forms.Button();
      this.MoveYPositive = new System.Windows.Forms.Button();
      this.MoveXPlus = new System.Windows.Forms.Button();
      this.MoveXMinus = new System.Windows.Forms.Button();
      this.RotateYP = new System.Windows.Forms.Button();
      this.RotateYM = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
      this.tableLayoutPanel1.Controls.Add(this.RotateYM, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.RotateYP, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.MoveZMinus, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.MoveZPlus, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.MoveYMinus, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.MoveYPositive, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.MoveXPlus, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.MoveXMinus, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(238, 141);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // MoveZMinus
      // 
      this.MoveZMinus.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MoveZMinus.Location = new System.Drawing.Point(0, 70);
      this.MoveZMinus.Margin = new System.Windows.Forms.Padding(0);
      this.MoveZMinus.Name = "MoveZMinus";
      this.MoveZMinus.Size = new System.Drawing.Size(79, 35);
      this.MoveZMinus.TabIndex = 5;
      this.MoveZMinus.Text = "Z-";
      this.MoveZMinus.UseVisualStyleBackColor = true;
      this.MoveZMinus.Click += new System.EventHandler(this.MoveZMinus_Click);
      // 
      // MoveZPlus
      // 
      this.MoveZPlus.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MoveZPlus.Location = new System.Drawing.Point(79, 70);
      this.MoveZPlus.Margin = new System.Windows.Forms.Padding(0);
      this.MoveZPlus.Name = "MoveZPlus";
      this.MoveZPlus.Size = new System.Drawing.Size(79, 35);
      this.MoveZPlus.TabIndex = 4;
      this.MoveZPlus.Text = "Z+";
      this.MoveZPlus.UseVisualStyleBackColor = true;
      this.MoveZPlus.Click += new System.EventHandler(this.MoveZPlus_Click);
      // 
      // MoveYMinus
      // 
      this.MoveYMinus.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MoveYMinus.Location = new System.Drawing.Point(0, 35);
      this.MoveYMinus.Margin = new System.Windows.Forms.Padding(0);
      this.MoveYMinus.Name = "MoveYMinus";
      this.MoveYMinus.Size = new System.Drawing.Size(79, 35);
      this.MoveYMinus.TabIndex = 3;
      this.MoveYMinus.Text = "Y-";
      this.MoveYMinus.UseVisualStyleBackColor = true;
      this.MoveYMinus.Click += new System.EventHandler(this.MoveYMinus_Click);
      // 
      // MoveYPositive
      // 
      this.MoveYPositive.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MoveYPositive.Location = new System.Drawing.Point(79, 35);
      this.MoveYPositive.Margin = new System.Windows.Forms.Padding(0);
      this.MoveYPositive.Name = "MoveYPositive";
      this.MoveYPositive.Size = new System.Drawing.Size(79, 35);
      this.MoveYPositive.TabIndex = 2;
      this.MoveYPositive.Text = "Y+";
      this.MoveYPositive.UseVisualStyleBackColor = true;
      this.MoveYPositive.Click += new System.EventHandler(this.MoveYPositive_Click);
      // 
      // MoveXPlus
      // 
      this.MoveXPlus.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MoveXPlus.Location = new System.Drawing.Point(79, 0);
      this.MoveXPlus.Margin = new System.Windows.Forms.Padding(0);
      this.MoveXPlus.Name = "MoveXPlus";
      this.MoveXPlus.Size = new System.Drawing.Size(79, 35);
      this.MoveXPlus.TabIndex = 1;
      this.MoveXPlus.Text = "X+";
      this.MoveXPlus.UseVisualStyleBackColor = true;
      this.MoveXPlus.Click += new System.EventHandler(this.MoveXPlus_Click);
      // 
      // MoveXMinus
      // 
      this.MoveXMinus.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MoveXMinus.Location = new System.Drawing.Point(0, 0);
      this.MoveXMinus.Margin = new System.Windows.Forms.Padding(0);
      this.MoveXMinus.Name = "MoveXMinus";
      this.MoveXMinus.Size = new System.Drawing.Size(79, 35);
      this.MoveXMinus.TabIndex = 0;
      this.MoveXMinus.Text = "X-";
      this.MoveXMinus.UseVisualStyleBackColor = true;
      this.MoveXMinus.Click += new System.EventHandler(this.MoveXMinus_Click);
      // 
      // RotateYP
      // 
      this.RotateYP.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RotateYP.Location = new System.Drawing.Point(79, 105);
      this.RotateYP.Margin = new System.Windows.Forms.Padding(0);
      this.RotateYP.Name = "RotateYP";
      this.RotateYP.Size = new System.Drawing.Size(79, 36);
      this.RotateYP.TabIndex = 6;
      this.RotateYP.Text = "RY+";
      this.RotateYP.UseVisualStyleBackColor = true;
      this.RotateYP.Click += new System.EventHandler(this.RotateYP_Click);
      // 
      // RotateYM
      // 
      this.RotateYM.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RotateYM.Location = new System.Drawing.Point(0, 105);
      this.RotateYM.Margin = new System.Windows.Forms.Padding(0);
      this.RotateYM.Name = "RotateYM";
      this.RotateYM.Size = new System.Drawing.Size(79, 36);
      this.RotateYM.TabIndex = 7;
      this.RotateYM.Text = "RY-";
      this.RotateYM.UseVisualStyleBackColor = true;
      this.RotateYM.Click += new System.EventHandler(this.RotateYM_Click);
      // 
      // ObjectMoveControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "ObjectMoveControl";
      this.Size = new System.Drawing.Size(238, 141);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button MoveXMinus;
    private System.Windows.Forms.Button MoveXPlus;
    private System.Windows.Forms.Button MoveYPositive;
    private System.Windows.Forms.Button MoveYMinus;
    private System.Windows.Forms.Button MoveZPlus;
    private System.Windows.Forms.Button MoveZMinus;
    private System.Windows.Forms.Button RotateYP;
    private System.Windows.Forms.Button RotateYM;
  }
}
