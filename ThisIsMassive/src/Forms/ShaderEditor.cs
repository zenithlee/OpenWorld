using FastColoredTextBoxNS;
using Massive;
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

namespace ThisIsMassive.src.Forms
{
  public partial class ShaderEditor : DToolForm
  {
    MShader CurrentShader;

    TextStyle brownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
    TextStyle blueStyle = new TextStyle(Brushes.CornflowerBlue, null, FontStyle.Regular);
    TextStyle greenStyle = new TextStyle(Brushes.LightGreen, null, FontStyle.Regular);


    public ShaderEditor()
    {
      InitializeComponent();
      SetTitle("Shader Editor");          
    }

    public void SetObject(MShader mo)
    { 
      CurrentShader = mo;
      string sShader = File.ReadAllText(Path.Combine(Globals.ResourcePath, mo.FragmentShaderPath));
      //sShader = sShader.Replace("\r", "\r\n");
      CodeBox.Text = sShader;
    }

    private void Update_Click(object sender, EventArgs e)
    {
      CompileAndRun();
    }

    void CompileAndRun()
    {
      string sVertShader = File.ReadAllText(Path.Combine(Globals.ResourcePath, CurrentShader.VertexShaderPath));
      string Error = CurrentShader.LoadFromString(sVertShader, CodeBox.Text);
      CurrentShader.SetInt("material.diffuse", MShader.LOCATION_DIFFUSE);
      CurrentShader.SetInt("material.specular", MShader.LOCATION_SPECULAR);
      CurrentShader.SetInt("material.multitex", MShader.LOCATION_MULTITEX);
      CurrentShader.SetInt("material.normalmap", MShader.LOCATION_NORMALMAP);
      CurrentShader.SetInt("material.shadowMap", MShader.LOCATION_SHADOWMAP);
      MMaterial mat = (MMaterial)CurrentShader.Parent;
      mat.shader = CurrentShader;
      mat.Bind();

      if (string.IsNullOrEmpty(Error))
      {
        Output.Text = "Compiled Successfully";
      }
      else
      {
        Output.Text = Error;
      }
      
    }

    private void ShaderCode_KeyDown(object sender, KeyEventArgs e)
    {
      if ( e.KeyCode == Keys.F5)
      {
        CompileAndRun();
      }
    }

    private void CodeBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      //clear previous highlighting
      e.ChangedRange.ClearStyle(brownStyle);
      //highlight tags
      e.ChangedRange.SetStyle(brownStyle, "<[^>]+>");      

      //highlight keywords of GLSL
      CodeBox.Range.SetStyle(blueStyle, @"\b(out|in|void|and|eval|else|if|lambda|or|set|lerp|mix|mult|dot|pow|struct|uniform|sampler2D)\b", 
        System.Text.RegularExpressions.RegexOptions.IgnoreCase);

      CodeBox.Range.SetStyle(greenStyle, @"\b(vec2|vec3|mat3|mat4|float|int|bool|double)\b",
  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
      //find function declarations, highlight all of their entry into the code
      //foreach (Range found in CodeBox.GetRanges(@"\b(defun|DEFUN)\s+(?<range>\w+)\b"))
      //fctb.Range.SetStyle(FunctionNameStyle, @"\b" + found.Text + @"\b");

    }
  }
}
