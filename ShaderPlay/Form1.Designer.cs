namespace ShaderPlay
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      this.VertexShaderResult = new System.Windows.Forms.TextBox();
      this.VertexEditor = new FastColoredTextBoxNS.FastColoredTextBox();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.FragmentShaderEditor = new FastColoredTextBoxNS.FastColoredTextBox();
      this.FragmentResult = new System.Windows.Forms.TextBox();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.ShowNormalsCheck = new System.Windows.Forms.CheckBox();
      this.RotationCheck = new System.Windows.Forms.CheckBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.tableLayoutPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.VertexEditor)).BeginInit();
      this.tableLayoutPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.FragmentShaderEditor)).BeginInit();
      this.flowLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.60601F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.39399F));
      this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1160, 567);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // splitContainer1
      // 
      this.splitContainer1.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(404, 35);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel4);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
      this.splitContainer1.Size = new System.Drawing.Size(753, 529);
      this.splitContainer1.SplitterDistance = 387;
      this.splitContainer1.TabIndex = 1;
      // 
      // tableLayoutPanel4
      // 
      this.tableLayoutPanel4.ColumnCount = 1;
      this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel4.Controls.Add(this.VertexShaderResult, 0, 1);
      this.tableLayoutPanel4.Controls.Add(this.VertexEditor, 0, 0);
      this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel4.Name = "tableLayoutPanel4";
      this.tableLayoutPanel4.RowCount = 2;
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.tableLayoutPanel4.Size = new System.Drawing.Size(387, 529);
      this.tableLayoutPanel4.TabIndex = 0;
      // 
      // VertexShaderResult
      // 
      this.VertexShaderResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.VertexShaderResult.Dock = System.Windows.Forms.DockStyle.Fill;
      this.VertexShaderResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.VertexShaderResult.Location = new System.Drawing.Point(3, 432);
      this.VertexShaderResult.Multiline = true;
      this.VertexShaderResult.Name = "VertexShaderResult";
      this.VertexShaderResult.Size = new System.Drawing.Size(381, 94);
      this.VertexShaderResult.TabIndex = 2;
      // 
      // VertexEditor
      // 
      this.VertexEditor.AutoCompleteBracketsList = new char[] {
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
      this.VertexEditor.AutoScrollMinSize = new System.Drawing.Size(123, 14);
      this.VertexEditor.BackBrush = null;
      this.VertexEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.VertexEditor.CaretColor = System.Drawing.Color.LightSalmon;
      this.VertexEditor.CharHeight = 14;
      this.VertexEditor.CharWidth = 8;
      this.VertexEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.VertexEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
      this.VertexEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.VertexEditor.ForeColor = System.Drawing.Color.White;
      this.VertexEditor.IsReplaceMode = false;
      this.VertexEditor.Location = new System.Drawing.Point(3, 3);
      this.VertexEditor.Name = "VertexEditor";
      this.VertexEditor.Paddings = new System.Windows.Forms.Padding(0);
      this.VertexEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
      this.VertexEditor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("VertexEditor.ServiceColors")));
      this.VertexEditor.Size = new System.Drawing.Size(381, 423);
      this.VertexEditor.TabIndex = 1;
      this.VertexEditor.Text = "VertexEditor";
      this.VertexEditor.Zoom = 100;
      this.VertexEditor.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.VertexEditor_TextChanged);
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.ColumnCount = 1;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.Controls.Add(this.FragmentShaderEditor, 0, 0);
      this.tableLayoutPanel3.Controls.Add(this.FragmentResult, 0, 1);
      this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 2;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.tableLayoutPanel3.Size = new System.Drawing.Size(362, 529);
      this.tableLayoutPanel3.TabIndex = 0;
      // 
      // FragmentShaderEditor
      // 
      this.FragmentShaderEditor.AutoCompleteBracketsList = new char[] {
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
      this.FragmentShaderEditor.AutoScrollMinSize = new System.Drawing.Size(123, 14);
      this.FragmentShaderEditor.BackBrush = null;
      this.FragmentShaderEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.FragmentShaderEditor.CaretColor = System.Drawing.Color.LightSalmon;
      this.FragmentShaderEditor.CharHeight = 14;
      this.FragmentShaderEditor.CharWidth = 8;
      this.FragmentShaderEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.FragmentShaderEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
      this.FragmentShaderEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.FragmentShaderEditor.ForeColor = System.Drawing.Color.White;
      this.FragmentShaderEditor.IsReplaceMode = false;
      this.FragmentShaderEditor.Location = new System.Drawing.Point(3, 3);
      this.FragmentShaderEditor.Name = "FragmentShaderEditor";
      this.FragmentShaderEditor.Paddings = new System.Windows.Forms.Padding(0);
      this.FragmentShaderEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
      this.FragmentShaderEditor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("FragmentShaderEditor.ServiceColors")));
      this.FragmentShaderEditor.Size = new System.Drawing.Size(356, 423);
      this.FragmentShaderEditor.TabIndex = 0;
      this.FragmentShaderEditor.Text = "ShaderEditor";
      this.FragmentShaderEditor.Zoom = 100;
      this.FragmentShaderEditor.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.FragmentShaderEditor_TextChanged);
      // 
      // FragmentResult
      // 
      this.FragmentResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.FragmentResult.Dock = System.Windows.Forms.DockStyle.Fill;
      this.FragmentResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.FragmentResult.Location = new System.Drawing.Point(3, 432);
      this.FragmentResult.Multiline = true;
      this.FragmentResult.Name = "FragmentResult";
      this.FragmentResult.Size = new System.Drawing.Size(356, 94);
      this.FragmentResult.TabIndex = 3;
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Controls.Add(this.ShowNormalsCheck);
      this.flowLayoutPanel1.Controls.Add(this.RotationCheck);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(395, 26);
      this.flowLayoutPanel1.TabIndex = 2;
      // 
      // ShowNormalsCheck
      // 
      this.ShowNormalsCheck.AutoSize = true;
      this.ShowNormalsCheck.Location = new System.Drawing.Point(3, 3);
      this.ShowNormalsCheck.Name = "ShowNormalsCheck";
      this.ShowNormalsCheck.Size = new System.Drawing.Size(94, 17);
      this.ShowNormalsCheck.TabIndex = 0;
      this.ShowNormalsCheck.Text = "Show Normals";
      this.ShowNormalsCheck.UseVisualStyleBackColor = true;
      this.ShowNormalsCheck.CheckedChanged += new System.EventHandler(this.ShowNormalsCheck_CheckedChanged);
      // 
      // RotationCheck
      // 
      this.RotationCheck.AutoSize = true;
      this.RotationCheck.Checked = true;
      this.RotationCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.RotationCheck.Location = new System.Drawing.Point(103, 3);
      this.RotationCheck.Name = "RotationCheck";
      this.RotationCheck.Size = new System.Drawing.Size(107, 17);
      this.RotationCheck.TabIndex = 1;
      this.RotationCheck.Text = "Animate Rotation";
      this.RotationCheck.UseVisualStyleBackColor = true;
      this.RotationCheck.CheckedChanged += new System.EventHandler(this.RotationCheck_CheckedChanged);
      // 
      // timer1
      // 
      this.timer1.Interval = 40;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1160, 567);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "ShaderPlay";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.tableLayoutPanel4.ResumeLayout(false);
      this.tableLayoutPanel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.VertexEditor)).EndInit();
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.FragmentShaderEditor)).EndInit();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Timer timer1;
    private FastColoredTextBoxNS.FastColoredTextBox FragmentShaderEditor;
    private FastColoredTextBoxNS.FastColoredTextBox VertexEditor;
    private System.Windows.Forms.TextBox VertexShaderResult;
    private System.Windows.Forms.TextBox FragmentResult;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.CheckBox ShowNormalsCheck;
    private System.Windows.Forms.CheckBox RotationCheck;
  }
}

