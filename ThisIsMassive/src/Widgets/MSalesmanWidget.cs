using Massive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThisIsMassive.src.Forms;

namespace ThisIsMassive.Widgets
{
  public class MSalesmanWidget
  {
    public static void Clicked(MObject mo)
    {
      Console.Write("CLIEDKEKDKADFAS");

      SalesForm Sales = new SalesForm();
      Sales.Setup(mo);
      Sales.Show(Main.GetInstance());
    }
  }
}
