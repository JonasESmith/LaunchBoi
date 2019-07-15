using Newtonsoft.Json;
using System;
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
using System.Configuration;

namespace LaunchBoi
{
  public partial class mainForm : Form
  {
    public static List<AppStats> appList = new List<AppStats>();

    public mainForm()
    {
      InitializeComponent();
      LoadStyles();
      appList = Load_App_Stats_From_JSON();
      Load_App_Buttons();
    }

    public void Load_App_Buttons()
    {

      for(int i = 0; i < appList.Count; i++) {
        Panel appPanel     = new Panel();
        appPanel.Dock      = DockStyle.Top;
        appPanel.Width     = appsRunningPanel.Width;
        appPanel.Height    = 100;
        appPanel.BackColor = Color.White;

        Panel topPad     = new Panel();
        topPad.Dock      = DockStyle.Top;
        topPad.BackColor = Color.Gray;
        topPad.Height    = 1;
        appPanel.Controls.Add(topPad);

        Panel botPad     = new Panel();
        botPad.Dock      = DockStyle.Bottom;
        botPad.BackColor = Color.Gray;
        botPad.Height    = 1;
        appPanel.Controls.Add(botPad);

        Panel mainPanel     = new Panel();
        mainPanel.Dock      = DockStyle.Fill;
        mainPanel.BackColor = Color.Orange;
        appPanel.Controls.Add(mainPanel);

        Panel topAppBar     = new Panel();
        topAppBar.Dock      = DockStyle.Top;
        topAppBar.Height    = (mainPanel.Height / 2);
        topAppBar.BackColor = SystemColors.Control;
        mainPanel.Controls.Add(topAppBar);

        Panel colorPanel     = new Panel();
        colorPanel.BackColor = appList[i].appColor;
        colorPanel.Dock      = DockStyle.Left;
        colorPanel.Width     = 10;

        Panel padingPanel = new Panel();
        padingPanel.Width = 15;
        padingPanel.Dock  = DockStyle.Left;

        Label nameLabel     = new Label();
        nameLabel.Font      = new Font(new FontFamily("Verdana"), 12);
        nameLabel.Text      = appList[i].appName;
        nameLabel.AutoSize  = false;
        nameLabel.TextAlign = ContentAlignment.MiddleLeft;
        nameLabel.Dock      = DockStyle.Fill;

        Label timeLabel     = new Label();
        timeLabel.Text      = "00:00:00";
        timeLabel.Dock      = DockStyle.Right;
        timeLabel.AutoSize  = false;
        timeLabel.Width     = 60;
        timeLabel.TextAlign = ContentAlignment.MiddleCenter;

        topAppBar.Controls.Add(nameLabel);
        topAppBar.Controls.Add(padingPanel);
        topAppBar.Controls.Add(timeLabel);
        topAppBar.Controls.Add(colorPanel);

        Panel botAppBar     = new Panel();
        botAppBar.Dock      = DockStyle.Bottom;
        botAppBar.Height    = (mainPanel.Height / 2);
        botAppBar.BackColor = SystemColors.Control;
        botAppBar.Width     = mainPanel.Width;

        botAppBar.BackColor = SystemColors.Control;

        Panel topPadding   = new Panel();
        topPad.Dock        = DockStyle.Top;
        topPad.Height      = 1;
        topPad.BackColor   = Color.DarkGray;

        Panel leftTopPanel = new Panel();
        leftTopPanel.Width = 15;
        leftTopPanel.Dock  = DockStyle.Left;
        leftTopPanel.BackColor = SystemColors.Control;

        Panel rightTopPanel = new Panel();
        rightTopPanel.Width = 15;
        rightTopPanel.Dock  = DockStyle.Right;
        rightTopPanel.BackColor = SystemColors.Control;

        topPad.Controls.Add(leftTopPanel);
        topPad.Controls.Add(rightTopPanel);

        botAppBar.Controls.Add(topPad);

        Label iterationLabel = new Label();
        iterationLabel.Text = "iterations : 1043";
        iterationLabel.Dock = DockStyle.Right;
        iterationLabel.AutoSize = false;
        iterationLabel.Width = (int) (botAppBar.Width * 0.5);
        iterationLabel.TextAlign = ContentAlignment.MiddleCenter;

        Label updateLabel = new Label();
        updateLabel.Text = "updates : 23";
        updateLabel.Dock = DockStyle.Left;
        updateLabel.AutoSize = false;
        updateLabel.Width = (int)(botAppBar.Width * 0.5);
        updateLabel.TextAlign = ContentAlignment.MiddleCenter;

        Panel bottomStatPanel = new Panel();
        bottomStatPanel.Dock = DockStyle.Fill;

        bottomStatPanel.Controls.Add(iterationLabel);
        bottomStatPanel.Controls.Add(updateLabel);


        botAppBar.Controls.Add(bottomStatPanel);

        mainPanel.Controls.Add(botAppBar);

        Panel bottomHeightPanel = new Panel();
        bottomHeightPanel.Height = 8;
        bottomHeightPanel.Dock = DockStyle.Top;
        

        appsRunningPanel.Controls.Add(bottomHeightPanel);
        appsRunningPanel.Controls.Add(appPanel);
      }
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
      middleRightBufferPanel.Width = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      middleLeftBufferPanel.Width  = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      middleAddNewAppPanel.Width   = (int)Math.Ceiling(addAppPanel.Width * 0.6);
      AddNewPathNamePanel.Width    = (int)Math.Ceiling(addAppPanel.Width * 0.6);
      rightPaddingPanel.Width      = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      rightColorPadding.Width      = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      leftPaddingPanel.Width       = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      leftColorPadding.Width       = (int)Math.Ceiling(addAppPanel.Width * 0.1);
    }

    private void AddAppButton_Click(object sender, EventArgs e)
    {
      AppStats newApp    = new AppStats();
      newApp.appInterval = intervalComboBox.Text;
      newApp.appName     = appNameTextBox.Text;
      newApp.appPath     = pathTextBox.Text;
      newApp.appTime     = timeComboBox.Text;
      newApp.appColor    = Color.FromArgb(Convert.ToInt32(redColorText.Text),
                                          Convert.ToInt32(greenColorText.Text), 
                                          Convert.ToInt32(blueColorText.Text));

      appList.Add(newApp);
      Save_Apps_to_JSON();
    }

    static List<AppStats> Load_App_Stats_From_JSON()
    {
      List<AppStats> list = JsonConvert.DeserializeObject<List<AppStats>>(Properties.Settings.Default.appJson);

      if (list == null)
        list = new List<AppStats>();

      return list;
    }

    static void Save_Apps_to_JSON()
    {
      Properties.Settings.Default.appJson = JsonConvert.SerializeObject(appList);
      Properties.Settings.Default.Save();
    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
      string red_string   = redColorText.Text;
      string green_string = greenColorText.Text;
      string blue_string  = blueColorText.Text;

      int red = 0;
      if(!string.IsNullOrEmpty(red_string) && Regex.IsMatch(red_string, "^[0-9]+$"))
      {
        red = Convert.ToInt32(red_string);
        if (red > 255)
        {
          redColorText.Text = "0";
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

      ColorPanel.BackColor = Color.FromArgb(red, green, blue);
    }
  }
}
