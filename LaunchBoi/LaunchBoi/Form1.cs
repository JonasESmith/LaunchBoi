﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

    private void MainForm_Resize(object sender, EventArgs e)
    {
      middleLeftBufferPanel.Width  = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      middleRightBufferPanel.Width = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      middleAddNewAppPanel.Width   = (int)Math.Ceiling(addAppPanel.Width * 0.6);
      leftPaddingPanel.Width       = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      rightPaddingPanel.Width      = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      AddNewPathNamePanel.Width    = (int)Math.Ceiling(addAppPanel.Width * 0.6);
      rightColorPadding.Width      = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      leftColorPadding.Width       = (int)Math.Ceiling(addAppPanel.Width * 0.1);
    }

    private void AddAppButton_Click(object sender, EventArgs e)
    {

    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
      string red_string = redColorTExt.Text;
      string green_string = greenColorText.Text;
      string blue_string = blueColorText.Text;

      int red = 0;
      if(!string.IsNullOrEmpty(red_string) && Regex.IsMatch(red_string, "^[0-9]+$"))
      {
        red = Convert.ToInt32(red_string);
        if (red > 255)
        {
          redColorTExt.Text = "0";
          red = 0;
        }
      }

      int green = 0;
      if (!string.IsNullOrEmpty(green_string) && Regex.IsMatch(green_string, "^[0-9]+$"))
      {
        green = Convert.ToInt32(green_string);
        if (green > 255)
        {
          greenColorText.Text = "0";
          green = 0;
        }
      }

      int blue = 0;
      if (!string.IsNullOrEmpty(blue_string) && Regex.IsMatch(blue_string, "^[0-9]+$"))
      {
         blue = Convert.ToInt32(blue_string);
        if (blue > 255)
        {
          blueColorText.Text = "0";
          blue = 0;
        }
      }


      if (!string.IsNullOrEmpty(redColorTExt.Text) && !string.IsNullOrEmpty(blueColorText.Text) && !string.IsNullOrEmpty(greenColorText.Text))
        ColorPanel.BackColor = Color.FromArgb(red, green, blue);
    }
  }
}
