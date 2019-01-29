namespace ThisIsMassive.src.Forms
{
  partial class ShaderEditor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShaderEditor));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.Output = new System.Windows.Forms.TextBox();
      this.Update = new System.Windows.Forms.Button();
      this.CodeBox = new FastColoredTextBoxNS.FastColoredTextBox();
      this.documentMap1 = new FastColoredTextBoxNS.DocumentMap();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CodeBox)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
      this.tableLayoutPanel1.Controls.Add(this.Output, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.Update, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.CodeBox, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.documentMap1, 3, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 21);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.428571F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.57143F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(817, 588);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // Output
      // 
      this.Output.BackColor = System.Drawing.Color.Gray;
      this.Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tableLayoutPanel1.SetColumnSpan(this.Output, 4);
      this.Output.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Output.Location = new System.Drawing.Point(0, 523);
      this.Output.Margin = new System.Windows.Forms.Padding(0);
      this.Output.Multiline = true;
      this.Output.Name = "Output";
      this.Output.Size = new System.Drawing.Size(817, 65);
      this.Output.TabIndex = 2;
      // 
      // Update
      // 
      this.Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.Update.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Update.FlatAppearance.BorderSize = 0;
      this.Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.Update.Location = new System.Drawing.Point(0, 0);
      this.Update.Margin = new System.Windows.Forms.Padding(0);
      this.Update.Name = "Update";
      this.Update.Size = new System.Drawing.Size(224, 33);
      this.Update.TabIndex = 1;
      this.Update.Text = "F5 Compile and Run";
      this.Update.UseVisualStyleBackColor = false;
      this.Update.Click += new System.EventHandler(this.Update_Click);
      // 
      // CodeBox
      // 
      this.CodeBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
      this.CodeBox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
      this.CodeBox.BackBrush = null;
      this.CodeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.CodeBox.CaretColor = System.Drawing.Color.White;
      this.CodeBox.CharHeight = 14;
      this.CodeBox.CharWidth = 8;
      this.tableLayoutPanel1.SetColumnSpan(this.CodeBox, 3);
      this.CodeBox.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.CodeBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
      this.CodeBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CodeBox.ForeColor = System.Drawing.Color.White;
      this.CodeBox.IsReplaceMode = false;
      this.CodeBox.Location = new System.Drawing.Point(3, 36);
      this.CodeBox.Name = "CodeBox";
      this.CodeBox.Paddings = new System.Windows.Forms.Padding(0);
      this.CodeBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
      this.CodeBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("CodeBox.ServiceColors")));
      this.CodeBox.Size = new System.Drawing.Size(619, 484);
      this.CodeBox.TabIndex = 3;
      this.CodeBox.Zoom = 100;
      this.CodeBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.CodeBox_TextChanged);
      this.CodeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShaderCode_KeyDown);
      // 
      // documentMap1
      // 
      this.documentMap1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.documentMap1.ForeColor = System.Drawing.Color.Maroon;
      this.documentMap1.Location = new System.Drawing.Point(628, 36);
      this.documentMap1.Name = "documentMap1";
      this.documentMap1.Size = new System.Drawing.Size(186, 484);
      this.documentMap1.TabIndex = 4;
      this.documentMap1.Target = this.CodeBox;
      this.documentMap1.Text = "documentMap1";
      // 
      // ShaderEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(817, 609);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "ShaderEditor";
      this.Text = "ShaderEditor";
      this.TopMost = false;
      this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CodeBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button Update;
    private System.Windows.Forms.TextBox Output;
    private FastColoredTextBoxNS.FastColoredTextBox CodeBox;
    private FastColoredTextBoxNS.DocumentMap documentMap1;
  }
}