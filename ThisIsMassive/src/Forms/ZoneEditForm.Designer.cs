namespace ThisIsMassive.src.Controls
{
  partial class ZoneForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZoneForm));
      this.ZoneNameBox = new System.Windows.Forms.TextBox();
      this.ZoneDescriptionBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.PositionBox = new System.Windows.Forms.TextBox();
      this.UpdatePropertiesButton = new System.Windows.Forms.Button();
      this.StatusLabel = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.ZoneGroup = new System.Windows.Forms.ComboBox();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // ZoneNameBox
      // 
      this.ZoneNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tableLayoutPanel1.SetColumnSpan(this.ZoneNameBox, 2);
      this.ZoneNameBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ZoneNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ZoneNameBox.Location = new System.Drawing.Point(91, 116);
      this.ZoneNameBox.Margin = new System.Windows.Forms.Padding(0);
      this.ZoneNameBox.MaxLength = 128;
      this.ZoneNameBox.Name = "ZoneNameBox";
      this.ZoneNameBox.Size = new System.Drawing.Size(287, 19);
      this.ZoneNameBox.TabIndex = 2;
      // 
      // ZoneDescriptionBox
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.ZoneDescriptionBox, 2);
      this.ZoneDescriptionBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ZoneDescriptionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ZoneDescriptionBox.Location = new System.Drawing.Point(94, 183);
      this.ZoneDescriptionBox.MaxLength = 1024;
      this.ZoneDescriptionBox.Multiline = true;
      this.ZoneDescriptionBox.Name = "ZoneDescriptionBox";
      this.tableLayoutPanel1.SetRowSpan(this.ZoneDescriptionBox, 2);
      this.ZoneDescriptionBox.Size = new System.Drawing.Size(281, 233);
      this.ZoneDescriptionBox.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Location = new System.Drawing.Point(3, 116);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(85, 32);
      this.label2.TabIndex = 10;
      this.label2.Text = "Zone Name";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label3.Location = new System.Drawing.Point(3, 180);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(85, 32);
      this.label3.TabIndex = 11;
      this.label3.Text = "Zone Description";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label4.Location = new System.Drawing.Point(3, 84);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(85, 32);
      this.label4.TabIndex = 14;
      this.label4.Text = "Zone X,Y,Z Location";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // PositionBox
      // 
      this.PositionBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tableLayoutPanel1.SetColumnSpan(this.PositionBox, 2);
      this.PositionBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PositionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.PositionBox.Location = new System.Drawing.Point(91, 84);
      this.PositionBox.Margin = new System.Windows.Forms.Padding(0);
      this.PositionBox.Name = "PositionBox";
      this.PositionBox.ReadOnly = true;
      this.PositionBox.Size = new System.Drawing.Size(287, 19);
      this.PositionBox.TabIndex = 1;
      this.PositionBox.Text = "0,0,0";
      // 
      // UpdatePropertiesButton
      // 
      this.UpdatePropertiesButton.BackColor = System.Drawing.Color.Gray;
      this.UpdatePropertiesButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.UpdatePropertiesButton.FlatAppearance.BorderSize = 0;
      this.UpdatePropertiesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.UpdatePropertiesButton.Location = new System.Drawing.Point(311, 419);
      this.UpdatePropertiesButton.Margin = new System.Windows.Forms.Padding(0);
      this.UpdatePropertiesButton.Name = "UpdatePropertiesButton";
      this.UpdatePropertiesButton.Size = new System.Drawing.Size(67, 32);
      this.UpdatePropertiesButton.TabIndex = 5;
      this.UpdatePropertiesButton.Text = "Update";
      this.UpdatePropertiesButton.UseVisualStyleBackColor = false;
      this.UpdatePropertiesButton.Click += new System.EventHandler(this.UpdatePropertiesButton_Click);
      // 
      // StatusLabel
      // 
      this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.StatusLabel.Location = new System.Drawing.Point(26, 363);
      this.StatusLabel.Name = "StatusLabel";
      this.StatusLabel.Size = new System.Drawing.Size(143, 34);
      this.StatusLabel.TabIndex = 16;
      this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // timer1
      // 
      this.timer1.Interval = 800;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // ZoneGroup
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.ZoneGroup, 2);
      this.ZoneGroup.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ZoneGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ZoneGroup.FormattingEnabled = true;
      this.ZoneGroup.Items.AddRange(new object[] {
            "Home",
            "Art",
            "Clothing",
            "Commercial",
            "Entertainment",
            "Experimental",
            "Historical",
            "Industrial",
            "Infrastructure",
            "Personal",
            "Playground",
            "Restaurant",
            "Public",
            "Testing"});
      this.ZoneGroup.Location = new System.Drawing.Point(91, 148);
      this.ZoneGroup.Margin = new System.Windows.Forms.Padding(0);
      this.ZoneGroup.MaxLength = 127;
      this.ZoneGroup.Name = "ZoneGroup";
      this.ZoneGroup.Size = new System.Drawing.Size(287, 26);
      this.ZoneGroup.TabIndex = 3;
      this.ZoneGroup.Text = "Public";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.02611F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.97389F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
      this.tableLayoutPanel1.Controls.Add(this.ZoneGroup, 1, 4);
      this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
      this.tableLayoutPanel1.Controls.Add(this.PositionBox, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.ZoneDescriptionBox, 1, 5);
      this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.ZoneNameBox, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.UpdatePropertiesButton, 2, 7);
      this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 21);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 8;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 451);
      this.tableLayoutPanel1.TabIndex = 18;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label5.Location = new System.Drawing.Point(3, 148);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(85, 32);
      this.label5.TabIndex = 18;
      this.label5.Text = "Zone Group";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan(this.label6, 2);
      this.label6.Location = new System.Drawing.Point(3, 34);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(184, 13);
      this.label6.TabIndex = 19;
      this.label6.Text = "Zones are listed in the Zone Directory";
      // 
      // ZoneForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Silver;
      this.ClientSize = new System.Drawing.Size(421, 474);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.StatusLabel);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ZoneForm";
      this.ShowIcon = false;
      this.Text = "ZoneForm";
      this.Shown += new System.EventHandler(this.ZoneForm_Shown);
      this.Controls.SetChildIndex(this.StatusLabel, 0);
      this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox ZoneNameBox;
    private System.Windows.Forms.TextBox ZoneDescriptionBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox PositionBox;
    private System.Windows.Forms.Button UpdatePropertiesButton;
    private System.Windows.Forms.Label StatusLabel;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.ComboBox ZoneGroup;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
  }
}