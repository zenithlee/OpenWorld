namespace ThisIsMassive.src.Controls
{
  partial class CPosition
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.SpeedKMH = new System.Windows.Forms.TextBox();
      this.SelectedPositionText = new System.Windows.Forms.Label();
      this.WorldPositionText = new System.Windows.Forms.TextBox();
      this.UpVector = new System.Windows.Forms.TextBox();
      this.SpeedTimer = new System.Windows.Forms.Timer(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
      this.tableLayoutPanel1.Controls.Add(this.SpeedKMH, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.SelectedPositionText, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.WorldPositionText, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.UpVector, 1, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(490, 37);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // SpeedKMH
      // 
      this.SpeedKMH.BackColor = System.Drawing.Color.Teal;
      this.SpeedKMH.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.SpeedKMH.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SpeedKMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SpeedKMH.ForeColor = System.Drawing.Color.White;
      this.SpeedKMH.Location = new System.Drawing.Point(400, 0);
      this.SpeedKMH.Margin = new System.Windows.Forms.Padding(0);
      this.SpeedKMH.Multiline = true;
      this.SpeedKMH.Name = "SpeedKMH";
      this.SpeedKMH.Size = new System.Drawing.Size(90, 18);
      this.SpeedKMH.TabIndex = 5;
      this.SpeedKMH.Text = "0km/h";
      this.SpeedKMH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.toolTip1.SetToolTip(this.SpeedKMH, "Your speed");
      // 
      // SelectedPositionText
      // 
      this.SelectedPositionText.AutoSize = true;
      this.SelectedPositionText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SelectedPositionText.ForeColor = System.Drawing.Color.White;
      this.SelectedPositionText.Location = new System.Drawing.Point(3, 18);
      this.SelectedPositionText.Name = "SelectedPositionText";
      this.SelectedPositionText.Size = new System.Drawing.Size(394, 19);
      this.SelectedPositionText.TabIndex = 1;
      this.SelectedPositionText.Text = "0,0,0";
      this.SelectedPositionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip(this.SelectedPositionText, "The position of the selected object");
      // 
      // WorldPositionText
      // 
      this.WorldPositionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.WorldPositionText.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.WorldPositionText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.WorldPositionText.ForeColor = System.Drawing.Color.White;
      this.WorldPositionText.Location = new System.Drawing.Point(3, 3);
      this.WorldPositionText.Name = "WorldPositionText";
      this.WorldPositionText.Size = new System.Drawing.Size(394, 13);
      this.WorldPositionText.TabIndex = 2;
      this.WorldPositionText.Text = "0,0,0";
      this.WorldPositionText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.toolTip1.SetToolTip(this.WorldPositionText, "Your Universe position");
      // 
      // UpVector
      // 
      this.UpVector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(205)))));
      this.UpVector.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.UpVector.Dock = System.Windows.Forms.DockStyle.Fill;
      this.UpVector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.UpVector.ForeColor = System.Drawing.Color.White;
      this.UpVector.Location = new System.Drawing.Point(400, 18);
      this.UpVector.Margin = new System.Windows.Forms.Padding(0);
      this.UpVector.Multiline = true;
      this.UpVector.Name = "UpVector";
      this.UpVector.Size = new System.Drawing.Size(90, 19);
      this.UpVector.TabIndex = 4;
      this.UpVector.Text = "0,0,0";
      this.UpVector.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.toolTip1.SetToolTip(this.UpVector, "Current Gravity");
      // 
      // SpeedTimer
      // 
      this.SpeedTimer.Interval = 1000;
      this.SpeedTimer.Tick += new System.EventHandler(this.SpeedTimer_Tick);
      // 
      // CPosition
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "CPosition";
      this.Size = new System.Drawing.Size(490, 37);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TextBox WorldPositionText;
    private System.Windows.Forms.TextBox SpeedKMH;
    private System.Windows.Forms.Timer SpeedTimer;
    private System.Windows.Forms.Label SelectedPositionText;
    private System.Windows.Forms.TextBox UpVector;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}
