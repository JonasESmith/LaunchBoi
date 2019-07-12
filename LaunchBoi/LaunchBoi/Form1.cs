using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchBoi
{
  public partial class mainForm : Form
  {
    public mainForm()
    {
      InitializeComponent();
      LoadStyles();
    }

    public void LoadStyles()
    {


      leftNavPanel.BackColor = Color.FromArgb(209, 209, 209);
      addNewAppButton.BackColor = Color.FromArgb(209, 209, 209);
      addNewAppButton.FlatStyle = FlatStyle.Flat;
      addNewAppButton.FlatAppearance.BorderColor = Color.FromArgb(150, 150, 150);
      browsePathButton.BackColor = Color.FromArgb(209, 209, 209);
      browsePathButton.FlatStyle = FlatStyle.Flat;
      browsePathButton.FlatAppearance.BorderColor = Color.FromArgb(150, 150, 150);
      addAppButton.BackColor = Color.FromArgb(209, 209, 209);
      addAppButton.FlatStyle = FlatStyle.Flat;
      addAppButton.FlatAppearance.BorderColor = Color.FromArgb(150, 150, 150);
    }

    private void BrowsePathButton_Click(object sender, EventArgs e)
    {
      // Show the dialog and get result.
      DialogResult result = openFileDialog1.ShowDialog();
      if (result == DialogResult.OK) // Test result.
      {
        pathTextBox.Text = openFileDialog1.FileName;
      }
      Console.WriteLine(result); // <-- For debugging use.
    }

    private void MainForm_ResizeEnd(object sender, EventArgs e)
    {
        ResiveTitleBars();
    }

    private void ResiveTitleBars()
    {
      leftPaddingPanel.Width    = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      rightPaddingPanel.Width   = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      AddNewPathNamePanel.Width = (int)Math.Ceiling(addAppPanel.Width * 0.6);
      //titlePanelRightPadding.Width = (int) Math.Ceiling( (addNewAppTopPanel.Width * 0.175) );
    }
  }
}
