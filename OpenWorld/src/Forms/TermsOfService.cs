﻿using Massive.Platform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenWorld.Forms
{
  public partial class TermsOfService : Form
  {
    public TermsOfService()
    {
      InitializeComponent();
    }

    public void Setup()
    {
      string sPath = Path.Combine(MFileSystem.AppDataPath, "Terms.txt");
      if ( !File.Exists(sPath))
      {
        Console.WriteLine("ERROR, could not find TOS");
        return;
      }
      string sData = MFileSystem.GetFile(sPath);
      TermsTextBox.Text = sData;
    }

    private void AcceptButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }
  }
}
