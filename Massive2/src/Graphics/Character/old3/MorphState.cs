using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public class MorphState
  {
    public float[] oldMorphWeights;
    public float[] targetMorphWeights;
    public float[] morphWeights;
    public double[] morphInterpTimes;
    public double[] morphAnimTimes;

    public MorphState(int numMorphs)
    {
      oldMorphWeights = new float[numMorphs];
      targetMorphWeights = new float[numMorphs];
      morphInterpTimes = new double[numMorphs];
      morphAnimTimes = new double[numMorphs];
      morphWeights = new float[numMorphs];
    }
  }
}
