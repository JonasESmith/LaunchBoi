using System;
using System.Windows.Forms;

namespace LaunchBoi
{
  public class UpdateItems
  {
    public UpdateItems(Label _label, Label _iterationLabel, TimeSpan _interval) {
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

    public void Iterate()
    {
      runCount++;
      iterationLabel.Text = string.Format("iterations : {0,-4}", runCount.ToString());
    }
  }
}
