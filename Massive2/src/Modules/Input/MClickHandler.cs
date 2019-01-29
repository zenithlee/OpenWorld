using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Add this to a sceneobject
 * and subscribe to Callback to get click notification
 * 
 * */

namespace Massive
{
  public delegate void ClickFunction(MObject mo);

  public class MClickHandler : MObject
  {    
    public ClickFunction Clicked;
    public ClickFunction DoubleClicked;

    public MClickHandler() : base(EType.ClickHandler, "ClickHandler")
    {      
    }

    public override void OnClick(bool DoubleClick)
    {
      base.OnClick();
      
      if ( DoubleClick)
      {
        if (DoubleClicked!= null) DoubleClicked(this.Parent);
      }
      else
      {
        if (Clicked != null) Clicked(this.Parent);
      }
      
    }
  }
}
