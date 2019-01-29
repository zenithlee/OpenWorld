namespace ThisIsMassive.src.Forms
{
  partial class SalesForm
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
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.OrderInfo = new System.Windows.Forms.TextBox();
      this.PlaceOrderButton = new System.Windows.Forms.Button();
      this.StatusText = new System.Windows.Forms.Label();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 4;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.26031F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.7397F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel2.Controls.Add(this.OrderInfo, 1, 1);
      this.tableLayoutPanel2.Controls.Add(this.PlaceOrderButton, 2, 2);
      this.tableLayoutPanel2.Controls.Add(this.StatusText, 1, 2);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 21);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 4;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.352798F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.6472F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(482, 481);
      this.tableLayoutPanel2.TabIndex = 2;
      // 
      // OrderInfo
      // 
      this.OrderInfo.BackColor = System.Drawing.Color.Gray;
      this.OrderInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tableLayoutPanel2.SetColumnSpan(this.OrderInfo, 2);
      this.OrderInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OrderInfo.Location = new System.Drawing.Point(30, 22);
      this.OrderInfo.Margin = new System.Windows.Forms.Padding(0);
      this.OrderInfo.Multiline = true;
      this.OrderInfo.Name = "OrderInfo";
      this.OrderInfo.Size = new System.Drawing.Size(425, 399);
      this.OrderInfo.TabIndex = 0;
      // 
      // PlaceOrderButton
      // 
      this.PlaceOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.PlaceOrderButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PlaceOrderButton.FlatAppearance.BorderSize = 0;
      this.PlaceOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.PlaceOrderButton.Location = new System.Drawing.Point(371, 421);
      this.PlaceOrderButton.Margin = new System.Windows.Forms.Padding(0);
      this.PlaceOrderButton.Name = "PlaceOrderButton";
      this.PlaceOrderButton.Size = new System.Drawing.Size(84, 40);
      this.PlaceOrderButton.TabIndex = 1;
      this.PlaceOrderButton.Text = "Place Order";
      this.PlaceOrderButton.UseVisualStyleBackColor = false;
      this.PlaceOrderButton.Click += new System.EventHandler(this.PlaceOrderButton_Click);
      // 
      // StatusText
      // 
      this.StatusText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.StatusText.Location = new System.Drawing.Point(33, 421);
      this.StatusText.Name = "StatusText";
      this.StatusText.Size = new System.Drawing.Size(335, 40);
      this.StatusText.TabIndex = 2;
      this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // SalesForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(482, 502);
      this.Controls.Add(this.tableLayoutPanel2);
      this.Name = "SalesForm";
      this.Text = "SalesForm";
      this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.TextBox OrderInfo;
    private System.Windows.Forms.Button PlaceOrderButton;
    private System.Windows.Forms.Label StatusText;
  }
}