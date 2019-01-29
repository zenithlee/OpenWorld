using Massive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisIsMassive.src.Forms;

namespace ThisIsMassive.Widgets
{
  public class MBookWidget
  {
    public static void CH_DoubleClick(MObject mo)
    {
      ProductInfoForm pif = new ProductInfoForm();
      pif.Setup((MSceneObject)mo);
      pif.Show(Main.GetInstance());
    }
  }
}
