using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchBoi
{
  public class AppStats
  {
    public string appName { get; set; }
    public string appPath { get; set; }
    public string appTime { get; set; }
    public string appInterval { get; set; }
    public Color appColor { get; set; }
    public string jsonData { get; set; }


    public int getSeconds()
    {
      // seconds, minutes, hours, days

      int value = 0;
      int app_Time = Convert.ToInt32(appTime);

      switch(appInterval)
      {
        case "seconds":
          value = app_Time * 1;
          break;
        case "minutes":
          value = app_Time * 1 * 60;
          break;
        case "hours":
          value = app_Time * 1 * 60 * 60;
          break;
        case "days":
          value = app_Time * 1 * 60 * 60 * 24;
          break;
      }

      return value;
    }
  }
}