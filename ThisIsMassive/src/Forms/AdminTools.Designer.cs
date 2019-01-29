namespace ThisIsMassive.src.Forms
{
  partial class AdminTools
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
      this.GenAsteroids = new System.Windows.Forms.Button();
      this.GenAsteroids2 = new System.Windows.Forms.Button();
      this.OffsetX = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.OffsetY = new System.Windows.Forms.NumericUpDown();
      this.OffsetZ = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.OffsetX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.OffsetY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.OffsetZ)).BeginInit();
      this.SuspendLayout();
      // 
      // GenAsteroids
      // 
      this.GenAsteroids.Location = new System.Drawing.Point(12, 12);
      this.GenAsteroids.Name = "GenAsteroids";
      this.GenAsteroids.Size = new System.Drawing.Size(96, 57);
      this.GenAsteroids.TabIndex = 0;
      this.GenAsteroids.Text = "Generate Asteroid Field";
      this.GenAsteroids.UseVisualStyleBackColor = true;
      this.GenAsteroids.Click += new System.EventHandler(this.GenAsteroids_Click);
      // 
      // GenAsteroids2
      // 
      this.GenAsteroids2.Location = new System.Drawing.Point(12, 75);
      this.GenAsteroids2.Name = "GenAsteroids2";
      this.GenAsteroids2.Size = new System.Drawing.Size(96, 57);
      this.GenAsteroids2.TabIndex = 1;
      this.GenAsteroids2.Text = "Generate Asteroid Field Type 2";
      this.GenAsteroids2.UseVisualStyleBackColor = true;
      this.GenAsteroids2.Click += new System.EventHandler(this.GenAsteroids2_Click);
      // 
      // OffsetX
      // 
      this.OffsetX.Location = new System.Drawing.Point(161, 56);
      this.OffsetX.Name = "OffsetX";
      this.OffsetX.Size = new System.Drawing.Size(120, 20);
      this.OffsetX.TabIndex = 2;
      this.OffsetX.ValueChanged += new System.EventHandler(this.Tweak1Num_ValueChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(158, 40);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(92, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "OffsetThirdPerson";
      // 
      // OffsetY
      // 
      this.OffsetY.Location = new System.Drawing.Point(161, 75);
      this.OffsetY.Name = "OffsetY";
      this.OffsetY.Size = new System.Drawing.Size(120, 20);
      this.OffsetY.TabIndex = 4;
      this.OffsetY.ValueChanged += new System.EventHandler(this.OffsetY_ValueChanged);
      // 
      // OffsetZ
      // 
      this.OffsetZ.Location = new System.Drawing.Point(161, 95);
      this.OffsetZ.Name = "OffsetZ";
      this.OffsetZ.Size = new System.Drawing.Size(120, 20);
      this.OffsetZ.TabIndex = 5;
      this.OffsetZ.ValueChanged += new System.EventHandler(this.OffsetZ_ValueChanged);
      // 
      // AdminTools
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(390, 444);
      this.Controls.Add(this.OffsetZ);
      this.Controls.Add(this.OffsetY);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.OffsetX);
      this.Controls.Add(this.GenAsteroids2);
      this.Controls.Add(this.GenAsteroids);
      this.Name = "AdminTools";
      this.Text = "AdminTools";
      ((System.ComponentModel.ISupportInitialize)(this.OffsetX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.OffsetY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.OffsetZ)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button GenAsteroids;
    private System.Windows.Forms.Button GenAsteroids2;
    private System.Windows.Forms.NumericUpDown OffsetX;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown OffsetY;
    private System.Windows.Forms.NumericUpDown OffsetZ;
  }
}