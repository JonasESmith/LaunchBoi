/// Programmer : Jonas Smith
/// Purpose    : Application to keep track of all the scripts I have created for pinnacle Hemp

using System;
using System.Linq;
using System.Drawing;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LaunchBoi
{
  public partial class mainForm : Form
  {
    public static List<AppStats>    appList     = new List<AppStats>();
    public static List<UpdateItems> updateList  = new List<UpdateItems>();
    public bool                     _isNew      = true;
    public int                      globalIndex = 0;
    public int                      timeToSave  = 60;

    public mainForm()
    {
      InitializeComponent();
      Load_Styles();
      appList = Load_App_Stats_From_JSON();
      Load_App_Buttons();
      Start_Timers();
    }

    public void Start_Timers()
    {
      Timer timer    = new Timer();
      timer.Interval = 1000;
      timer.Enabled  = true;
      timer.Tick    += Timer_Tick;
      timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      TimeSpan second = TimeSpan.FromSeconds(1);
      TimeSpan zero   = TimeSpan.Zero;
      timeToSave--;


      for (int i = 0; i < updateList.Count; i++) {
        updateList[i].interval            = updateList[i].interval.Subtract(second);
        updateList[i].countDownLabel.Text = updateList[i].interval.ToString();

        if (updateList[i].interval  == zero) {
          //RunApplication(appList[i], i);
          //updateList[i].interval = TimeSpan.FromSeconds(appList[i].getSeconds());
          //updateList[i].Iterate();

          BackgroundWorker worker = new BackgroundWorker();
          worker.DoWork += Worker_DoWork;
          worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
          worker.RunWorkerAsync(argument: i);
        }
      }

      if(timeToSave == 0) {
        timeToSave = 60;
        Save_Apps_to_JSON();
      }
    }

    private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      int i = (int) e.Result;

      updateList[i].interval = TimeSpan.FromSeconds(appList[i].getSeconds());
      updateList[i].Iterate();
    }

    private void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
      int i = (int)e.Argument;

      RunApplication(appList[i], i);
      e.Result = i;
    }

    public bool RunApplication(AppStats app, int index)
    {
      ProcessStartInfo startInfo       = new ProcessStartInfo();
      startInfo.CreateNoWindow         = true;
      startInfo.UseShellExecute        = false;
      startInfo.RedirectStandardOutput = true;
      startInfo.FileName               = app.appPath;

      try
      {
        using (Process exeProcess = Process.Start(startInfo))
        {
          while (!exeProcess.StandardOutput.EndOfStream)
          {
            string line = exeProcess.StandardOutput.ReadLine();
            appList[index].jsonData += line;
          }
        }
      }
      catch (Exception)
      {
        throw;
      }

      return true;
    }

    public void Load_App_Buttons()
    {
      appsRunningPanel.Controls.Clear();

      for(int i = 0; i < appList.Count; i++) {
        Panel appPanel     = new Panel();
        appPanel.Dock      = DockStyle.Top;
        appPanel.Width     = appsRunningPanel.Width;
        appPanel.Height    = 100;
        appPanel.BackColor = Color.White;
        appPanel.Click    += AppPanel_Click;

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
        topAppBar.Click    += AppPanel_Click;
        mainPanel.Controls.Add(topAppBar);

        Panel colorPanel     = new Panel();
        colorPanel.BackColor = appList[i].appColor;
        colorPanel.Dock      = DockStyle.Left;
        colorPanel.Width     = 10;

        Panel padingPanel    = new Panel();
        padingPanel.Width    = 15;
        padingPanel.Dock     = DockStyle.Left;

        Label nameLabel      = new Label();
        nameLabel.Font       = new Font(new FontFamily("Verdana"), 12);
        nameLabel.Text       = appList[i].appName;
        nameLabel.Name       = i.ToString() + ",nameLabel";
        nameLabel.AutoSize   = false;
        nameLabel.TextAlign  = ContentAlignment.MiddleLeft;
        nameLabel.Click     += AppPanel_Click;
        nameLabel.Dock       = DockStyle.Fill;

        Label timeLabel      = new Label();
        timeLabel.Name       = i.ToString() + ",timeLabel";
        timeLabel.Text       = "00:00:00";
        timeLabel.Dock       = DockStyle.Right;
        timeLabel.AutoSize   = false;
        timeLabel.Width      = 60;
        timeLabel.Click     += AppPanel_Click;
        timeLabel.TextAlign  = ContentAlignment.MiddleCenter;


        topAppBar.Controls.Add(nameLabel);
        topAppBar.Controls.Add(padingPanel);
        topAppBar.Controls.Add(timeLabel);
        topAppBar.Controls.Add(colorPanel);

        Panel botAppBar      = new Panel();
        botAppBar.Dock       = DockStyle.Bottom;
        botAppBar.Height     = (mainPanel.Height / 2);
        botAppBar.BackColor  = SystemColors.Control;
        botAppBar.Width      = mainPanel.Width;
        botAppBar.Click     += AppPanel_Click;

        botAppBar.BackColor  = SystemColors.Control;

        Panel topPadding     = new Panel();
        topPad.Dock          = DockStyle.Top;
        topPad.Height        = 1;
        topPad.BackColor     = Color.DarkGray;
        

        Panel leftTopPanel      = new Panel();
        leftTopPanel.Width      = 15;
        leftTopPanel.Dock       = DockStyle.Left;
        leftTopPanel.BackColor  = SystemColors.Control;

        Panel rightTopPanel     = new Panel();
        rightTopPanel.Width     = 15;
        rightTopPanel.Dock      = DockStyle.Right;
        rightTopPanel.BackColor = SystemColors.Control;

        topPad.Controls.Add(leftTopPanel);
        topPad.Controls.Add(rightTopPanel);

        botAppBar.Controls.Add(topPad);

        Label iterationLabel     = new Label();
        iterationLabel.Name      = i.ToString() + ",iterationLabel";
        iterationLabel.Text      = "iterations : ";
        iterationLabel.Dock      = DockStyle.Right;
        iterationLabel.AutoSize  = false;
        iterationLabel.Width     = (int) (botAppBar.Width * 0.5);
        iterationLabel.TextAlign = ContentAlignment.MiddleRight;
        iterationLabel.Click    += AppPanel_Click;

        Label updateLabel     = new Label();
        updateLabel.Name      = i.ToString() + ",updateLabel";
        updateLabel.Text      = " ";
        updateLabel.Dock      = DockStyle.Left;
        updateLabel.AutoSize  = false;
        updateLabel.Width     = (int)(botAppBar.Width * 0.5);
        updateLabel.TextAlign = ContentAlignment.MiddleCenter;
        updateLabel.Click    += AppPanel_Click;

        Panel bottomStatPanel = new Panel();
        bottomStatPanel.Dock  = DockStyle.Fill;

        bottomStatPanel.Controls.Add(iterationLabel);
        bottomStatPanel.Controls.Add(updateLabel);


        botAppBar.Controls.Add(bottomStatPanel);

        mainPanel.Controls.Add(botAppBar);

        bool exist = updateList.Any(item => item.index == i);
        if(!exist)
          updateList.Add( new UpdateItems(timeLabel, iterationLabel, TimeSpan.FromSeconds(appList[i].getSeconds()), i));
        else
          updateList[i].UpdateLabel(timeLabel, iterationLabel);

        Panel bottomHeightPanel  = new Panel();
        bottomHeightPanel.Height = 8;
        bottomHeightPanel.Dock   = DockStyle.Top;

        appsRunningPanel.Controls.Add(bottomHeightPanel);
        appsRunningPanel.Controls.Add(appPanel);
      }
    }

    private void AppPanel_Click(object sender, EventArgs e)
    {
      deleteAppButton.Visible = true;

      _isNew          = false;
      Label label     = sender as Label;
      string[] words  = label.Name.Split(',');

      globalIndex = Convert.ToInt32(words[0]);

      appNameTextBox.Text   = appList[globalIndex].appName;
      pathTextBox.Text      = appList[globalIndex].appPath;
      timeComboBox.Text     = appList[globalIndex].appTime;
      intervalComboBox.Text = appList[globalIndex].appInterval;
      ColorPanel.BackColor  = appList[globalIndex].appColor;
      redColorText.Text     = appList[globalIndex].appColor.R.ToString();
      greenColorText.Text   = appList[globalIndex].appColor.G.ToString();
      blueColorText.Text    = appList[globalIndex].appColor.B.ToString();
      addAppButton.Text     = "Update App";

      dataTextOutput.Text = "";
      words = appList[globalIndex].jsonData.Split(',');
      for(int i = 0; i < words.Length; i++) {
        dataTextOutput.Text += words[i];
        if(i < words.Length - 1)
          dataTextOutput.Text += Environment.NewLine;
      }

      hourComboBox.Text     = appList[globalIndex].hour.ToString();
      dayComboBox.Text      = appList[globalIndex].days;
    }

    public void Load_Styles()
    {
      leftNavPanel.BackColor                     = Color.FromArgb(209, 209, 209);

      addNewAppButton.BackColor                  = Color.FromArgb(209, 209, 209);
      addNewAppButton.FlatStyle                  = FlatStyle.Flat;
      addNewAppButton.FlatAppearance.BorderColor = Color.FromArgb(150, 150, 150);

      browsePathButton.BackColor                  = Color.FromArgb(209, 209, 209);
      browsePathButton.FlatStyle                  = FlatStyle.Flat;
      browsePathButton.FlatAppearance.BorderColor = Color.FromArgb(150, 150, 150);

      addAppButton.BackColor                      = Color.FromArgb(209, 209, 209);
      addAppButton.FlatStyle                      = FlatStyle.Flat;
      addAppButton.FlatAppearance.BorderColor     = Color.FromArgb(150, 150, 150);
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
      leftTextBoxPadding.Width     = (int)Math.Ceiling(addAppPanel.Width * 0.1);
      rightTextBoxPadding.Width    = (int)Math.Ceiling(addAppPanel.Width * 0.1);
    }

    private void AddAppButton_Click(object sender, EventArgs e)
    {
      if(_isNew) {
        if( !string.IsNullOrEmpty( appNameTextBox.Text  )  && 
            !string.IsNullOrEmpty( pathTextBox.Text     )  && 
            !string.IsNullOrEmpty( redColorText.Text    )  &&
            !string.IsNullOrEmpty( greenColorText.Text  )  &&
            !string.IsNullOrEmpty( blueColorText.Text   )) {
          AppStats newApp      = new AppStats();
          newApp.appName       = appNameTextBox.Text;
          newApp.appPath       = pathTextBox.Text;
          newApp.appColor      = Color.FromArgb(Convert.ToInt32(redColorText.Text),
                                              Convert.ToInt32(greenColorText.Text), 
                                              Convert.ToInt32(blueColorText.Text));

          if(!string.IsNullOrEmpty(dayComboBox.Text) && !string.IsNullOrEmpty(hourComboBox.Text)) {
            newApp.days        = dayComboBox.Text;
            newApp.hour        = Convert.ToInt32( hourComboBox.Text);
            newApp.appTime     = null;
            newApp.appInterval = null;
          }
          else {
            newApp.appTime     = timeComboBox.Text;
            newApp.appInterval = intervalComboBox.Text;
            newApp.days        = null;
          }

          appList.Add(newApp);
          Save_Apps_to_JSON();
          Load_App_Buttons();
        }
      }
      else {
        if (!string.IsNullOrEmpty(appNameTextBox.Text) &&
            !string.IsNullOrEmpty(pathTextBox.Text)    &&
            !string.IsNullOrEmpty(redColorText.Text)   &&
            !string.IsNullOrEmpty(greenColorText.Text) &&
            !string.IsNullOrEmpty(blueColorText.Text)) {
          appList[globalIndex].appName     = appNameTextBox.Text;
          appList[globalIndex].appPath     = pathTextBox.Text;

          appList[globalIndex].appTime     = timeComboBox.Text;
          appList[globalIndex].appInterval = intervalComboBox.Text;
          appList[globalIndex].hour        = Convert.ToInt32(hourComboBox.Text);
          appList[globalIndex].days        = dayComboBox.Text;
          appList[globalIndex].jsonData    = dataTextOutput.Text;

          string red_string    =  redColorText.Text;
          string blue_string   =  blueColorText.Text;
          string green_string  =  greenColorText.Text;
          int    red           =  0;
          int    blue          =  0;
          int    green         =  0;

          if ( !string.IsNullOrEmpty( red_string)   && Regex.IsMatch(red_string,   "^[0-9]+$" )) red   = Convert.ToInt32(red_string); 
          if ( !string.IsNullOrEmpty( green_string) && Regex.IsMatch(green_string, "^[0-9]+$" )) green = Convert.ToInt32(green_string); 
          if ( !string.IsNullOrEmpty( blue_string ) && Regex.IsMatch(blue_string,  "^[0-9]+$" )) blue  = Convert.ToInt32(blue_string); 
          if ( red   > 255 ) red   = 0; 
          if ( green > 255 ) green = 0; 
          if ( blue  > 255 ) blue  = 0; 

          ColorPanel.BackColor = Color.FromArgb(red, green, blue);

          Save_Apps_to_JSON();
          Load_App_Buttons();
        }
      }
    }

    static List<AppStats> Load_App_Stats_From_JSON()
    {
      List<AppStats>    list = JsonConvert.DeserializeObject<List<AppStats>>(Properties.Settings.Default.appJson);
      if (list == null) list = new List<AppStats>();

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
      string blue_string  = blueColorText.Text;
      string green_string = greenColorText.Text;
      int    red          = 0;
      int    blue         = 0;
      int    green        = 0;

      if(!string.IsNullOrEmpty(red_string) && Regex.IsMatch(red_string, "^[0-9]+$"))
        red = Convert.ToInt32(red_string);
        if (red > 255) {
          redColorText.Text = "0";
          red = 0;
        }

      if (!string.IsNullOrEmpty(green_string) && Regex.IsMatch(green_string, "^[0-9]+$"))
        green = Convert.ToInt32(green_string);
        if (green > 255) {
          greenColorText.Text = "0";
          green = 0;
        }

      if (!string.IsNullOrEmpty(blue_string) && Regex.IsMatch(blue_string, "^[0-9]+$"))
         blue = Convert.ToInt32(blue_string);
        if (blue > 255) {
          blueColorText.Text = "0";
          blue = 0;
        }

      ColorPanel.BackColor = Color.FromArgb(red, green, blue);
    }

    private void AddNewAppButton_Click(object sender, EventArgs e)
    {
      deleteAppButton.Visible = false;
      ColorPanel.BackColor    = SystemColors.Control;
      _isNew                  = true;
      appNameTextBox.Text     = "";
      pathTextBox.Text        = "";
      timeComboBox.Text       = "";
      intervalComboBox.Text   = "";
      redColorText.Text       = "";
      greenColorText.Text     = "";
      blueColorText.Text      = "";
      addAppButton.Text       = "Add App";
      dataTextOutput.Text     = "";
      hourComboBox.Text       = "";
      dayComboBox.Text        = "";
    }

    private void DeleteAppButton_Click(object sender, EventArgs e)
    {
      appList.RemoveAt(globalIndex);
      Load_App_Buttons();
      Save_Apps_to_JSON();
    }

    private void BrowsePathButton_MouseDown(object sender, MouseEventArgs e)
    {
      MouseEventArgs mouse = (MouseEventArgs)e;

      switch (mouse.Button)
      {
        case MouseButtons.Right:
          if(!_isNew)
          RunApplication(appList[globalIndex], globalIndex);
          break;

        default:
          {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
              pathTextBox.Text = openFileDialog1.FileName;
          }
          break;
      }
    }
  }
}
