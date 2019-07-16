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
    public string   days        { get; set; }
    public string   appName     { get; set; }
    public string   appPath     { get; set; }
    public string   appTime     { get; set; }
    public string   appInterval { get; set; }
    public string   jsonData    { get; set; }
    public Color    appColor    { get; set; }
    public DateTime date        { get; set; }
    public int      hour        { get; set; }


    public int getSeconds()
    {
      if (!string.IsNullOrEmpty(appTime)) {

        int value    = 0;
        int app_Time = Convert.ToInt32(appTime);

        switch (appInterval) {
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
      else
      {
        DateTime now = DateTime.Now;

        switch(days)
        {
          case "Monday":
            date = DateTime.Now.StartOfWeek(DayOfWeek.Monday).AddHours(hour);
            break;
          case "Tuesday":
            date = DateTime.Now.StartOfWeek(DayOfWeek.Tuesday).AddHours(hour);
            break;
          case "Wednesday":
            date = DateTime.Now.StartOfWeek(DayOfWeek.Wednesday).AddHours(hour);
            break;
          case "Thursday":
            date = DateTime.Now.StartOfWeek(DayOfWeek.Thursday).AddHours(hour);
            break;
          case "Friday":
            date = DateTime.Now.StartOfWeek(DayOfWeek.Friday).AddHours(hour);
            break;
          case "Saturday":
            date = DateTime.Now.StartOfWeek(DayOfWeek.Saturday).AddHours(hour);
            break;
          case "Sunday":
            date = DateTime.Now.StartOfWeek(DayOfWeek.Sunday).AddHours(hour);
            break;
          default:
            DayOfWeek day = (DayOfWeek) DateTime.Today.Day;
            date = DateTime.Now.StartOfWeek(day);
            break;
        }

        TimeSpan nextDay = date.Subtract(DateTime.Now);

        if (nextDay.ToString().Contains("-") && days != "Everyday")
          date = date.AddDays(7);
        else if (nextDay.ToString().Contains("-") && days == "Everyday")
          date = date.AddDays(1);

        return (int)Math.Ceiling(date.Subtract(DateTime.Now).TotalSeconds);
      }
    }
  }

  // extension method 
  // https://stackoverflow.com/questions/38039/how-can-i-get-the-datetime-for-the-start-of-the-week
  public static class DateTimeExtensions
  {
    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
      int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
      return dt.AddDays(-1 * diff).Date;
    }
  }
}