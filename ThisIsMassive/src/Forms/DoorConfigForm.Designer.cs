namespace ThisIsMassive.src.Forms
{
  partial class DoorConfigForm
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
      this.Public = new System.Windows.Forms.RadioButton();
      this.Friends = new System.Windows.Forms.RadioButton();
      this.OnlyMe = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.Updatebutton = new System.Windows.Forms.Button();
      this.StatusText = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.LockedRadio = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // Public
      // 
      this.Public.AutoSize = true;
      this.Public.Checked = true;
      this.Public.ForeColor = System.Drawing.Color.White;
      this.Public.Location = new System.Drawing.Point(50, 57);
      this.Public.Name = "Public";
      this.Public.Size = new System.Drawing.Size(61, 17);
      this.Public.TabIndex = 0;
      this.Public.TabStop = true;
      this.Public.Text = "Anyone";
      this.Public.UseVisualStyleBackColor = true;
      // 
      // Friends
      // 
      this.Friends.AutoSize = true;
      this.Friends.ForeColor = System.Drawing.Color.White;
      this.Friends.Location = new System.Drawing.Point(50, 80);
      this.Friends.Name = "Friends";
      this.Friends.Size = new System.Drawing.Size(76, 17);
      this.Friends.TabIndex = 1;
      this.Friends.Text = "My Friends";
      this.Friends.UseVisualStyleBackColor = true;
      // 
      // OnlyMe
      // 
      this.OnlyMe.AutoSize = true;
      this.OnlyMe.ForeColor = System.Drawing.Color.White;
      this.OnlyMe.Location = new System.Drawing.Point(50, 103);
      this.OnlyMe.Name = "OnlyMe";
      this.OnlyMe.Size = new System.Drawing.Size(64, 17);
      this.OnlyMe.TabIndex = 2;
      this.OnlyMe.Text = "Only Me";
      this.OnlyMe.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(47, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(127, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Who can open this door?";
      // 
      // Updatebutton
      // 
      this.Updatebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(172)))), ((int)(((byte)(128)))));
      this.Updatebutton.FlatAppearance.BorderSize = 0;
      this.Updatebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.Updatebutton.Location = new System.Drawing.Point(194, 166);
      this.Updatebutton.Name = "Updatebutton";
      this.Updatebutton.Size = new System.Drawing.Size(75, 34);
      this.Updatebutton.TabIndex = 4;
      this.Updatebutton.Text = "Update";
      this.Updatebutton.UseVisualStyleBackColor = false;
      this.Updatebutton.Click += new System.EventHandler(this.Updatebutton_Click);
      // 
      // StatusText
      // 
      this.StatusText.Location = new System.Drawing.Point(50, 123);
      this.StatusText.Name = "StatusText";
      this.StatusText.Size = new System.Drawing.Size(138, 34);
      this.StatusText.TabIndex = 5;
      this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // timer1
      // 
      this.timer1.Interval = 500;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // LockedRadio
      // 
      this.LockedRadio.AutoSize = true;
      this.LockedRadio.ForeColor = System.Drawing.Color.White;
      this.LockedRadio.Location = new System.Drawing.Point(50, 126);
      this.LockedRadio.Name = "LockedRadio";
      this.LockedRadio.Size = new System.Drawing.Size(105, 17);
      this.LockedRadio.TabIndex = 6;
      this.LockedRadio.Text = "Locked (No one)";
      this.LockedRadio.UseVisualStyleBackColor = true;
      // 
      // DoorConfigForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(281, 212);
      this.Controls.Add(this.LockedRadio);
      this.Controls.Add(this.StatusText);
      this.Controls.Add(this.Updatebutton);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.OnlyMe);
      this.Controls.Add(this.Friends);
      this.Controls.Add(this.Public);
      this.Name = "DoorConfigForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Door Configuration";
      this.TopMost = false;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoorConfigForm_FormClosing);
      this.Controls.SetChildIndex(this.Public, 0);
      this.Controls.SetChildIndex(this.Friends, 0);
      this.Controls.SetChildIndex(this.OnlyMe, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.Updatebutton, 0);
      this.Controls.SetChildIndex(this.StatusText, 0);
      this.Controls.SetChildIndex(this.LockedRadio, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton Public;
    private System.Windows.Forms.RadioButton Friends;
    private System.Windows.Forms.RadioButton OnlyMe;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button Updatebutton;
    private System.Windows.Forms.Label StatusText;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.RadioButton LockedRadio;
  }
}