﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive.Events
{
  public class TextureRequestEvent
  {
    public string TextureID = "";

    public TextureRequestEvent(string inTexID)
    {
      TextureID = inTexID;
    }
  }
}
