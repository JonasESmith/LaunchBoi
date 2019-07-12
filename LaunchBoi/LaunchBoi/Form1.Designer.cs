namespace LaunchBoi
{
  partial class mainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.leftNavPanel = new System.Windows.Forms.Panel();
      this.appsRunningPanel = new System.Windows.Forms.Panel();
      this.AddNewAppPanel = new System.Windows.Forms.Panel();
      this.addNewAppButton = new System.Windows.Forms.Button();
      this.addAppPanel = new System.Windows.Forms.Panel();
      this.addNewAppBottomPanel = new System.Windows.Forms.Panel();
      this.addNewAppTopPanel = new System.Windows.Forms.Panel();
      this.AddNewPathNamePanel = new System.Windows.Forms.Panel();
      this.browsePathButton = new System.Windows.Forms.Button();
      this.pathTextBox = new System.Windows.Forms.TextBox();
      this.appPathLabel = new System.Windows.Forms.Label();
      this.panel4 = new System.Windows.Forms.Panel();
      this.appNameTextBox = new System.Windows.Forms.TextBox();
      this.newAppNameLabel = new System.Windows.Forms.Label();
      this.addAppButton = new System.Windows.Forms.Button();
      this.comboBox2 = new System.Windows.Forms.ComboBox();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.intervalLabel = new System.Windows.Forms.Label();
      this.topBufferPanel = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.panel2 = new System.Windows.Forms.Panel();
      this.leftPaddingPanel = new System.Windows.Forms.Panel();
      this.rightPaddingPanel = new System.Windows.Forms.Panel();
      this.leftNavPanel.SuspendLayout();
      this.AddNewAppPanel.SuspendLayout();
      this.addAppPanel.SuspendLayout();
      this.addNewAppTopPanel.SuspendLayout();
      this.AddNewPathNamePanel.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // leftNavPanel
      // 
      this.leftNavPanel.Controls.Add(this.appsRunningPanel);
      this.leftNavPanel.Controls.Add(this.AddNewAppPanel);
      this.leftNavPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.leftNavPanel.Location = new System.Drawing.Point(0, 0);
      this.leftNavPanel.Name = "leftNavPanel";
      this.leftNavPanel.Size = new System.Drawing.Size(302, 745);
      this.leftNavPanel.TabIndex = 0;
      // 
      // appsRunningPanel
      // 
      this.appsRunningPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.appsRunningPanel.Location = new System.Drawing.Point(0, 0);
      this.appsRunningPanel.Name = "appsRunningPanel";
      this.appsRunningPanel.Size = new System.Drawing.Size(302, 690);
      this.appsRunningPanel.TabIndex = 1;
      // 
      // AddNewAppPanel
      // 
      this.AddNewAppPanel.Controls.Add(this.addNewAppButton);
      this.AddNewAppPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.AddNewAppPanel.Location = new System.Drawing.Point(0, 690);
      this.AddNewAppPanel.Name = "AddNewAppPanel";
      this.AddNewAppPanel.Size = new System.Drawing.Size(302, 55);
      this.AddNewAppPanel.TabIndex = 0;
      // 
      // addNewAppButton
      // 
      this.addNewAppButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.addNewAppButton.Location = new System.Drawing.Point(0, 0);
      this.addNewAppButton.Name = "addNewAppButton";
      this.addNewAppButton.Size = new System.Drawing.Size(302, 55);
      this.addNewAppButton.TabIndex = 0;
      this.addNewAppButton.Text = "Add New App";
      this.addNewAppButton.UseVisualStyleBackColor = true;
      // 
      // addAppPanel
      // 
      this.addAppPanel.Controls.Add(this.addNewAppBottomPanel);
      this.addAppPanel.Controls.Add(this.addNewAppTopPanel);
      this.addAppPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.addAppPanel.Location = new System.Drawing.Point(302, 0);
      this.addAppPanel.Name = "addAppPanel";
      this.addAppPanel.Size = new System.Drawing.Size(985, 713);
      this.addAppPanel.TabIndex = 1;
      // 
      // addNewAppBottomPanel
      // 
      this.addNewAppBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.addNewAppBottomPanel.Location = new System.Drawing.Point(0, 215);
      this.addNewAppBottomPanel.Name = "addNewAppBottomPanel";
      this.addNewAppBottomPanel.Size = new System.Drawing.Size(985, 498);
      this.addNewAppBottomPanel.TabIndex = 12;
      // 
      // addNewAppTopPanel
      // 
      this.addNewAppTopPanel.Controls.Add(this.panel2);
      this.addNewAppTopPanel.Controls.Add(this.addAppButton);
      this.addNewAppTopPanel.Controls.Add(this.comboBox2);
      this.addNewAppTopPanel.Controls.Add(this.comboBox1);
      this.addNewAppTopPanel.Controls.Add(this.intervalLabel);
      this.addNewAppTopPanel.Controls.Add(this.topBufferPanel);
      this.addNewAppTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.addNewAppTopPanel.Location = new System.Drawing.Point(0, 0);
      this.addNewAppTopPanel.Name = "addNewAppTopPanel";
      this.addNewAppTopPanel.Size = new System.Drawing.Size(985, 215);
      this.addNewAppTopPanel.TabIndex = 11;
      // 
      // AddNewPathNamePanel
      // 
      this.AddNewPathNamePanel.Controls.Add(this.browsePathButton);
      this.AddNewPathNamePanel.Controls.Add(this.pathTextBox);
      this.AddNewPathNamePanel.Controls.Add(this.appPathLabel);
      this.AddNewPathNamePanel.Controls.Add(this.panel4);
      this.AddNewPathNamePanel.Controls.Add(this.appNameTextBox);
      this.AddNewPathNamePanel.Controls.Add(this.newAppNameLabel);
      this.AddNewPathNamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.AddNewPathNamePanel.Location = new System.Drawing.Point(119, 0);
      this.AddNewPathNamePanel.Name = "AddNewPathNamePanel";
      this.AddNewPathNamePanel.Size = new System.Drawing.Size(767, 29);
      this.AddNewPathNamePanel.TabIndex = 11;
      // 
      // browsePathButton
      // 
      this.browsePathButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.browsePathButton.Location = new System.Drawing.Point(659, 0);
      this.browsePathButton.Name = "browsePathButton";
      this.browsePathButton.Size = new System.Drawing.Size(108, 29);
      this.browsePathButton.TabIndex = 4;
      this.browsePathButton.Text = "Browse";
      this.browsePathButton.UseVisualStyleBackColor = true;
      this.browsePathButton.Click += new System.EventHandler(this.BrowsePathButton_Click);
      // 
      // pathTextBox
      // 
      this.pathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.pathTextBox.Location = new System.Drawing.Point(400, 0);
      this.pathTextBox.Multiline = true;
      this.pathTextBox.Name = "pathTextBox";
      this.pathTextBox.Size = new System.Drawing.Size(367, 29);
      this.pathTextBox.TabIndex = 3;
      // 
      // appPathLabel
      // 
      this.appPathLabel.Dock = System.Windows.Forms.DockStyle.Left;
      this.appPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.appPathLabel.Location = new System.Drawing.Point(324, 0);
      this.appPathLabel.Name = "appPathLabel";
      this.appPathLabel.Size = new System.Drawing.Size(76, 29);
      this.appPathLabel.TabIndex = 2;
      this.appPathLabel.Text = "App-Path";
      this.appPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // panel4
      // 
      this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel4.Location = new System.Drawing.Point(293, 0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(31, 29);
      this.panel4.TabIndex = 7;
      // 
      // appNameTextBox
      // 
      this.appNameTextBox.Dock = System.Windows.Forms.DockStyle.Left;
      this.appNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.appNameTextBox.Location = new System.Drawing.Point(85, 0);
      this.appNameTextBox.Multiline = true;
      this.appNameTextBox.Name = "appNameTextBox";
      this.appNameTextBox.Size = new System.Drawing.Size(208, 29);
      this.appNameTextBox.TabIndex = 1;
      // 
      // newAppNameLabel
      // 
      this.newAppNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
      this.newAppNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.newAppNameLabel.Location = new System.Drawing.Point(0, 0);
      this.newAppNameLabel.Name = "newAppNameLabel";
      this.newAppNameLabel.Size = new System.Drawing.Size(85, 29);
      this.newAppNameLabel.TabIndex = 0;
      this.newAppNameLabel.Text = "App-Name";
      this.newAppNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // addAppButton
      // 
      this.addAppButton.Location = new System.Drawing.Point(771, 81);
      this.addAppButton.Name = "addAppButton";
      this.addAppButton.Size = new System.Drawing.Size(165, 28);
      this.addAppButton.TabIndex = 10;
      this.addAppButton.Text = "Add App";
      this.addAppButton.UseVisualStyleBackColor = true;
      // 
      // comboBox2
      // 
      this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Items.AddRange(new object[] {
            "seconds",
            "minutes",
            "hours",
            "days"});
      this.comboBox2.Location = new System.Drawing.Point(248, 81);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new System.Drawing.Size(103, 28);
      this.comboBox2.TabIndex = 9;
      // 
      // comboBox1
      // 
      this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
      this.comboBox1.Location = new System.Drawing.Point(160, 81);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(82, 28);
      this.comboBox1.TabIndex = 8;
      // 
      // intervalLabel
      // 
      this.intervalLabel.AutoSize = true;
      this.intervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.intervalLabel.Location = new System.Drawing.Point(45, 84);
      this.intervalLabel.Name = "intervalLabel";
      this.intervalLabel.Size = new System.Drawing.Size(101, 20);
      this.intervalLabel.TabIndex = 6;
      this.intervalLabel.Text = "launch every ";
      // 
      // topBufferPanel
      // 
      this.topBufferPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topBufferPanel.Location = new System.Drawing.Point(0, 0);
      this.topBufferPanel.Name = "topBufferPanel";
      this.topBufferPanel.Size = new System.Drawing.Size(985, 31);
      this.topBufferPanel.TabIndex = 12;
      // 
      // panel1
      // 
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(302, 713);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(985, 319);
      this.panel1.TabIndex = 2;
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.AddNewPathNamePanel);
      this.panel2.Controls.Add(this.rightPaddingPanel);
      this.panel2.Controls.Add(this.leftPaddingPanel);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 31);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(985, 29);
      this.panel2.TabIndex = 13;
      // 
      // leftPaddingPanel
      // 
      this.leftPaddingPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.leftPaddingPanel.Location = new System.Drawing.Point(0, 0);
      this.leftPaddingPanel.Name = "leftPaddingPanel";
      this.leftPaddingPanel.Size = new System.Drawing.Size(119, 29);
      this.leftPaddingPanel.TabIndex = 0;
      // 
      // rightPaddingPanel
      // 
      this.rightPaddingPanel.Dock = System.Windows.Forms.DockStyle.Right;
      this.rightPaddingPanel.Location = new System.Drawing.Point(886, 0);
      this.rightPaddingPanel.Name = "rightPaddingPanel";
      this.rightPaddingPanel.Size = new System.Drawing.Size(99, 29);
      this.rightPaddingPanel.TabIndex = 1;
      // 
      // mainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1287, 745);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.addAppPanel);
      this.Controls.Add(this.leftNavPanel);
      this.Name = "mainForm";
      this.Text = "Launcher_Boi";
      this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
      this.leftNavPanel.ResumeLayout(false);
      this.AddNewAppPanel.ResumeLayout(false);
      this.addAppPanel.ResumeLayout(false);
      this.addNewAppTopPanel.ResumeLayout(false);
      this.addNewAppTopPanel.PerformLayout();
      this.AddNewPathNamePanel.ResumeLayout(false);
      this.AddNewPathNamePanel.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel leftNavPanel;
    private System.Windows.Forms.Panel appsRunningPanel;
    private System.Windows.Forms.Panel AddNewAppPanel;
    private System.Windows.Forms.Button addNewAppButton;
    private System.Windows.Forms.Panel addAppPanel;
    private System.Windows.Forms.TextBox appNameTextBox;
    private System.Windows.Forms.Label newAppNameLabel;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button browsePathButton;
    private System.Windows.Forms.TextBox pathTextBox;
    private System.Windows.Forms.Label appPathLabel;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label intervalLabel;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button addAppButton;
    private System.Windows.Forms.Panel addNewAppBottomPanel;
    private System.Windows.Forms.Panel addNewAppTopPanel;
    private System.Windows.Forms.Panel AddNewPathNamePanel;
    private System.Windows.Forms.Panel topBufferPanel;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel rightPaddingPanel;
    private System.Windows.Forms.Panel leftPaddingPanel;
  }
}

