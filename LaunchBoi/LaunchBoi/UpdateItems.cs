﻿/// Programmer : Jonas Smith
/// Purpose    : Gives controls and minor details that need to be seperated from the base
///               Appstats controls/classes when they are updated.


using System;
using System.Windows.Forms;

namespace LaunchBoi
{
  public class UpdateItems
  {
    public UpdateItems(Label _label, Label _iterationLabel, TimeSpan _interval, int _index) {
      index          = _index;
      interval       = _interval;
      countDownLabel = _label;
      iterationLabel = _iterationLabel;
      runCount       = -1;
      Iterate();
    }
    public Label    countDownLabel { get; set; }
    public Label    iterationLabel { get; set; }
    public TimeSpan interval       { get; set; }
    public int      runCount       { get; set; }
    public int      index          { get; set; }

    public void Iterate()
    {
      runCount++;
      iterationLabel.Text = string.Format("iterations : {0,-4}", runCount.ToString());
    }

    public void UpdateLabel(Label _label, Label _iterationLabel)
    {
      countDownLabel = _label;
      iterationLabel = _iterationLabel;
    }
  }
}
