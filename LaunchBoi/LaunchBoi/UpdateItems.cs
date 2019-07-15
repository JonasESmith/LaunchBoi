using System;
using System.Windows.Forms;

namespace LaunchBoi
{
  public class UpdateItems
  {
    public UpdateItems(Label _label, TimeSpan _interval) {
      interval = _interval;
      label    = _label;
    }
    public Label    label    { get; set; }
    public TimeSpan interval { get; set; }
  }
}
