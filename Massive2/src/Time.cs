using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  public class Time : MObject
  {
    public Stopwatch stopwatch = new Stopwatch();
    public Stopwatch stopwatch_total = new Stopwatch();
    public static long FrameCount = 0;
    public static double DeltaTime; // in seconds
    public static double TotalTime;

    public Time() : base(EType.Other, "Time")
    {
      stopwatch_total.Start();
    }
    
    public override void Update()
    {
      FrameCount++;
      DeltaTime = (double)stopwatch.ElapsedMilliseconds * 0.001;      
      TotalTime = (double)stopwatch_total.ElapsedMilliseconds * 0.001;
      stopwatch.Restart();      
    }
  }
}
