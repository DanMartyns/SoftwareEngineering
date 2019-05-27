namespace TestBioLib
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblComm = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCommStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCommData = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblComAvailable = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.cmdOpenPort = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblBatteryValue = new System.Windows.Forms.Label();
            this.lblAccValue = new System.Windows.Forms.Label();
            this.lblSdCardStatus = new System.Windows.Forms.Label();
            this.lblRtcValue = new System.Windows.Forms.Label();
            this.lblPushButtonValue = new System.Windows.Forms.Label();
            this.lblQRS = new System.Windows.Forms.Label();
            this.lblTimestampValue = new System.Windows.Forms.Label();
            this.cmdSetRTC = new System.Windows.Forms.Button();
            this.cmdGetRTC = new System.Windows.Forms.Button();
            this.lblTimeConn = new System.Windows.Forms.Label();
            this.lblNumberOfLeads = new System.Windows.Forms.Label();
            this.lblSampleFrequency = new System.Windows.Forms.Label();
            this.lblEcgStream = new System.Windows.Forms.Label();
            this.cmdGetLeads = new System.Windows.Forms.Button();
            this.cmdGetSampleFrequency = new System.Windows.Forms.Button();
            this.timerEcg = new System.Windows.Forms.Timer(this.components);
            this.checkBoxShowQRS = new System.Windows.Forms.CheckBox();
            this.checkBoxRecordQRS = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxRecordEcg = new System.Windows.Forms.CheckBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.cmdOpenAppDir = new System.Windows.Forms.Button();
            this.cmdSetLabel = new System.Windows.Forms.Button();
            this.txtRadioEvent = new System.Windows.Forms.TextBox();
            this.lblRadioEvent = new System.Windows.Forms.Label();
            this.cmdGetDeviceId = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdGetAccConf = new System.Windows.Forms.Button();
            this.cmdSetAccConf = new System.Windows.Forms.Button();
            this.lblDeviceId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxRadioEvent = new System.Windows.Forms.PictureBox();
            this.txtEventData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageListCommStatus = new System.Windows.Forms.ImageList(this.components);
            this.lblAccConf = new System.Windows.Forms.Label();
            this.lblAcc = new System.Windows.Forms.Label();
            this.lblAccOptions = new System.Windows.Forms.Label();
            this.comboBoxAccConf = new System.Windows.Forms.ComboBox();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFirmwareVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRadioEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 56700;
            this.serialPort.DtrEnable = true;
            this.serialPort.RtsEnable = true;
            this.serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort_ErrorReceived);
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblComm,
            this.lblCommStatus,
            this.lblCommData,
            this.toolStripStatusLabel1,
            this.lblFirmwareVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 287);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(574, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblComm
            // 
            this.lblComm.AutoSize = false;
            this.lblComm.Name = "lblComm";
            this.lblComm.Size = new System.Drawing.Size(17, 19);
            // 
            // lblCommStatus
            // 
            this.lblCommStatus.Name = "lblCommStatus";
            this.lblCommStatus.Size = new System.Drawing.Size(0, 19);
            // 
            // lblCommData
            // 
            this.lblCommData.Name = "lblCommData";
            this.lblCommData.Size = new System.Drawing.Size(0, 19);
            // 
            // lblComAvailable
            // 
            this.lblComAvailable.AutoSize = true;
            this.lblComAvailable.Location = new System.Drawing.Point(10, 10);
            this.lblComAvailable.Name = "lblComAvailable";
            this.lblComAvailable.Size = new System.Drawing.Size(31, 13);
            this.lblComAvailable.TabIndex = 2;
            this.lblComAvailable.Text = "COM";
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(48, 6);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(61, 21);
            this.comboBoxPort.TabIndex = 3;
            // 
            // cmdOpenPort
            // 
            this.cmdOpenPort.Location = new System.Drawing.Point(116, 5);
            this.cmdOpenPort.Name = "cmdOpenPort";
            this.cmdOpenPort.Size = new System.Drawing.Size(75, 23);
            this.cmdOpenPort.TabIndex = 4;
            this.cmdOpenPort.Text = "Open";
            this.cmdOpenPort.UseVisualStyleBackColor = true;
            this.cmdOpenPort.Click += new System.EventHandler(this.cmdOpenPort_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblBatteryValue
            // 
            this.lblBatteryValue.AutoSize = true;
            this.lblBatteryValue.Location = new System.Drawing.Point(10, 85);
            this.lblBatteryValue.Name = "lblBatteryValue";
            this.lblBatteryValue.Size = new System.Drawing.Size(91, 13);
            this.lblBatteryValue.TabIndex = 5;
            this.lblBatteryValue.Text = "Battery level: - - %";
            // 
            // lblAccValue
            // 
            this.lblAccValue.AutoSize = true;
            this.lblAccValue.Location = new System.Drawing.Point(10, 110);
            this.lblAccValue.Name = "lblAccValue";
            this.lblAccValue.Size = new System.Drawing.Size(98, 13);
            this.lblAccValue.TabIndex = 6;
            this.lblAccValue.Text = "Acc:  x: --, y: --, z: --";
            // 
            // lblSdCardStatus
            // 
            this.lblSdCardStatus.AutoSize = true;
            this.lblSdCardStatus.Location = new System.Drawing.Point(30, 135);
            this.lblSdCardStatus.Name = "lblSdCardStatus";
            this.lblSdCardStatus.Size = new System.Drawing.Size(88, 13);
            this.lblSdCardStatus.TabIndex = 7;
            this.lblSdCardStatus.Text = "Sd Card status: --";
            // 
            // lblRtcValue
            // 
            this.lblRtcValue.AutoSize = true;
            this.lblRtcValue.Location = new System.Drawing.Point(10, 160);
            this.lblRtcValue.Name = "lblRtcValue";
            this.lblRtcValue.Size = new System.Drawing.Size(151, 13);
            this.lblRtcValue.TabIndex = 8;
            this.lblRtcValue.Text = "RTC timecode: -- / -- / --  --:--:--";
            // 
            // lblPushButtonValue
            // 
            this.lblPushButtonValue.AutoSize = true;
            this.lblPushButtonValue.Location = new System.Drawing.Point(10, 185);
            this.lblPushButtonValue.Name = "lblPushButtonValue";
            this.lblPushButtonValue.Size = new System.Drawing.Size(159, 13);
            this.lblPushButtonValue.TabIndex = 9;
            this.lblPushButtonValue.Text = "Pushbutton: #--   -- / -- / --  --:--:--";
            // 
            // lblQRS
            // 
            this.lblQRS.AutoSize = true;
            this.lblQRS.Location = new System.Drawing.Point(230, 85);
            this.lblQRS.Name = "lblQRS";
            this.lblQRS.Size = new System.Drawing.Size(219, 13);
            this.lblQRS.TabIndex = 10;
            this.lblQRS.Text = "QRS   Position: --   R-R(ms): --   BPMi(bpm): --";
            // 
            // lblTimestampValue
            // 
            this.lblTimestampValue.AutoSize = true;
            this.lblTimestampValue.Location = new System.Drawing.Point(10, 210);
            this.lblTimestampValue.Name = "lblTimestampValue";
            this.lblTimestampValue.Size = new System.Drawing.Size(137, 13);
            this.lblTimestampValue.TabIndex = 11;
            this.lblTimestampValue.Text = "Timestamp   -- / -- / --  --:--:--";
            // 
            // cmdSetRTC
            // 
            this.cmdSetRTC.Enabled = false;
            this.cmdSetRTC.Location = new System.Drawing.Point(332, 5);
            this.cmdSetRTC.Name = "cmdSetRTC";
            this.cmdSetRTC.Size = new System.Drawing.Size(110, 23);
            this.cmdSetRTC.TabIndex = 12;
            this.cmdSetRTC.Text = "Set RTC";
            this.toolTip1.SetToolTip(this.cmdSetRTC, "Set RTC time code");
            this.cmdSetRTC.UseVisualStyleBackColor = true;
            this.cmdSetRTC.Click += new System.EventHandler(this.cmdSetRTC_Click);
            // 
            // cmdGetRTC
            // 
            this.cmdGetRTC.Enabled = false;
            this.cmdGetRTC.Location = new System.Drawing.Point(454, 5);
            this.cmdGetRTC.Name = "cmdGetRTC";
            this.cmdGetRTC.Size = new System.Drawing.Size(110, 23);
            this.cmdGetRTC.TabIndex = 13;
            this.cmdGetRTC.Text = "Get RTC";
            this.toolTip1.SetToolTip(this.cmdGetRTC, "Get RTC time code");
            this.cmdGetRTC.UseVisualStyleBackColor = true;
            this.cmdGetRTC.Click += new System.EventHandler(this.cmdGetRTC_Click);
            // 
            // lblTimeConn
            // 
            this.lblTimeConn.AutoSize = true;
            this.lblTimeConn.Location = new System.Drawing.Point(10, 60);
            this.lblTimeConn.Name = "lblTimeConn";
            this.lblTimeConn.Size = new System.Drawing.Size(128, 13);
            this.lblTimeConn.TabIndex = 14;
            this.lblTimeConn.Text = "Time connection: - - :- -:- -";
            // 
            // lblNumberOfLeads
            // 
            this.lblNumberOfLeads.AutoSize = true;
            this.lblNumberOfLeads.Location = new System.Drawing.Point(230, 110);
            this.lblNumberOfLeads.Name = "lblNumberOfLeads";
            this.lblNumberOfLeads.Size = new System.Drawing.Size(67, 13);
            this.lblNumberOfLeads.TabIndex = 15;
            this.lblNumberOfLeads.Text = "Nb. leads: -- ";
            // 
            // lblSampleFrequency
            // 
            this.lblSampleFrequency.AutoSize = true;
            this.lblSampleFrequency.Location = new System.Drawing.Point(230, 135);
            this.lblSampleFrequency.Name = "lblSampleFrequency";
            this.lblSampleFrequency.Size = new System.Drawing.Size(132, 13);
            this.lblSampleFrequency.TabIndex = 16;
            this.lblSampleFrequency.Text = "Sample frequency (Hz): - - ";
            // 
            // lblEcgStream
            // 
            this.lblEcgStream.AutoSize = true;
            this.lblEcgStream.Location = new System.Drawing.Point(230, 160);
            this.lblEcgStream.Name = "lblEcgStream";
            this.lblEcgStream.Size = new System.Drawing.Size(100, 13);
            this.lblEcgStream.TabIndex = 17;
            this.lblEcgStream.Text = "Ecg stream [#--]: - - ";
            // 
            // cmdGetLeads
            // 
            this.cmdGetLeads.Enabled = false;
            this.cmdGetLeads.Location = new System.Drawing.Point(454, 105);
            this.cmdGetLeads.Name = "cmdGetLeads";
            this.cmdGetLeads.Size = new System.Drawing.Size(110, 23);
            this.cmdGetLeads.TabIndex = 18;
            this.cmdGetLeads.Text = "Get Leads";
            this.cmdGetLeads.UseVisualStyleBackColor = true;
            this.cmdGetLeads.Click += new System.EventHandler(this.cmdGetLeads_Click);
            // 
            // cmdGetSampleFrequency
            // 
            this.cmdGetSampleFrequency.Enabled = false;
            this.cmdGetSampleFrequency.Location = new System.Drawing.Point(454, 130);
            this.cmdGetSampleFrequency.Name = "cmdGetSampleFrequency";
            this.cmdGetSampleFrequency.Size = new System.Drawing.Size(110, 23);
            this.cmdGetSampleFrequency.TabIndex = 19;
            this.cmdGetSampleFrequency.Text = "Get fs(Hz)";
            this.cmdGetSampleFrequency.UseVisualStyleBackColor = true;
            this.cmdGetSampleFrequency.Click += new System.EventHandler(this.cmdGetSampleFrequency_Click);
            // 
            // timerEcg
            // 
            this.timerEcg.Tick += new System.EventHandler(this.timerEcg_Tick);
            // 
            // checkBoxShowQRS
            // 
            this.checkBoxShowQRS.AutoSize = true;
            this.checkBoxShowQRS.Location = new System.Drawing.Point(233, 210);
            this.checkBoxShowQRS.Name = "checkBoxShowQRS";
            this.checkBoxShowQRS.Size = new System.Drawing.Size(84, 17);
            this.checkBoxShowQRS.TabIndex = 21;
            this.checkBoxShowQRS.Text = "Show QRSs";
            this.checkBoxShowQRS.UseVisualStyleBackColor = true;
            // 
            // checkBoxRecordQRS
            // 
            this.checkBoxRecordQRS.AutoSize = true;
            this.checkBoxRecordQRS.Location = new System.Drawing.Point(360, 210);
            this.checkBoxRecordQRS.Name = "checkBoxRecordQRS";
            this.checkBoxRecordQRS.Size = new System.Drawing.Size(92, 17);
            this.checkBoxRecordQRS.TabIndex = 22;
            this.checkBoxRecordQRS.Text = "Record QRSs";
            this.checkBoxRecordQRS.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // checkBoxRecordEcg
            // 
            this.checkBoxRecordEcg.AutoSize = true;
            this.checkBoxRecordEcg.Location = new System.Drawing.Point(233, 185);
            this.checkBoxRecordEcg.Name = "checkBoxRecordEcg";
            this.checkBoxRecordEcg.Size = new System.Drawing.Size(110, 17);
            this.checkBoxRecordEcg.TabIndex = 24;
            this.checkBoxRecordEcg.Text = "Record ECG data";
            this.checkBoxRecordEcg.UseVisualStyleBackColor = true;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(360, 185);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(84, 13);
            this.lblRecord.TabIndex = 25;
            this.lblRecord.Text = "Record: - - :- -:- -";
            // 
            // cmdOpenAppDir
            // 
            this.cmdOpenAppDir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdOpenAppDir.BackgroundImage")));
            this.cmdOpenAppDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdOpenAppDir.Location = new System.Drawing.Point(10, 255);
            this.cmdOpenAppDir.Name = "cmdOpenAppDir";
            this.cmdOpenAppDir.Size = new System.Drawing.Size(28, 28);
            this.cmdOpenAppDir.TabIndex = 26;
            this.toolTip1.SetToolTip(this.cmdOpenAppDir, "Open application directory");
            this.cmdOpenAppDir.UseVisualStyleBackColor = true;
            this.cmdOpenAppDir.Click += new System.EventHandler(this.cmdOpenAppDir_Click);
            // 
            // cmdSetLabel
            // 
            this.cmdSetLabel.Enabled = false;
            this.cmdSetLabel.Location = new System.Drawing.Point(454, 29);
            this.cmdSetLabel.Name = "cmdSetLabel";
            this.cmdSetLabel.Size = new System.Drawing.Size(110, 23);
            this.cmdSetLabel.TabIndex = 27;
            this.cmdSetLabel.Text = "Send Radio Event";
            this.toolTip1.SetToolTip(this.cmdSetLabel, "Send radio event to device");
            this.cmdSetLabel.UseVisualStyleBackColor = true;
            this.cmdSetLabel.Click += new System.EventHandler(this.cmdSetLabel_Click);
            // 
            // txtRadioEvent
            // 
            this.txtRadioEvent.Enabled = false;
            this.txtRadioEvent.Location = new System.Drawing.Point(325, 31);
            this.txtRadioEvent.MaxLength = 3;
            this.txtRadioEvent.Name = "txtRadioEvent";
            this.txtRadioEvent.Size = new System.Drawing.Size(24, 20);
            this.txtRadioEvent.TabIndex = 28;
            // 
            // lblRadioEvent
            // 
            this.lblRadioEvent.AutoSize = true;
            this.lblRadioEvent.Location = new System.Drawing.Point(227, 34);
            this.lblRadioEvent.Name = "lblRadioEvent";
            this.lblRadioEvent.Size = new System.Drawing.Size(96, 13);
            this.lblRadioEvent.TabIndex = 29;
            this.lblRadioEvent.Text = "Type Radio-Event:";
            this.lblRadioEvent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdGetDeviceId
            // 
            this.cmdGetDeviceId.Enabled = false;
            this.cmdGetDeviceId.Location = new System.Drawing.Point(454, 53);
            this.cmdGetDeviceId.Name = "cmdGetDeviceId";
            this.cmdGetDeviceId.Size = new System.Drawing.Size(110, 23);
            this.cmdGetDeviceId.TabIndex = 30;
            this.cmdGetDeviceId.Text = "Get Device Id";
            this.toolTip1.SetToolTip(this.cmdGetDeviceId, "Get device Id");
            this.cmdGetDeviceId.UseVisualStyleBackColor = true;
            this.cmdGetDeviceId.Click += new System.EventHandler(this.cmdGetDeviceId_Click);
            // 
            // cmdGetAccConf
            // 
            this.cmdGetAccConf.Enabled = false;
            this.cmdGetAccConf.Location = new System.Drawing.Point(454, 260);
            this.cmdGetAccConf.Name = "cmdGetAccConf";
            this.cmdGetAccConf.Size = new System.Drawing.Size(110, 23);
            this.cmdGetAccConf.TabIndex = 43;
            this.cmdGetAccConf.Text = "Get ACC sensibility";
            this.toolTip1.SetToolTip(this.cmdGetAccConf, "Get ACC configuration");
            this.cmdGetAccConf.UseVisualStyleBackColor = true;
            this.cmdGetAccConf.Click += new System.EventHandler(this.cmdGetAccConf_Click);
            // 
            // cmdSetAccConf
            // 
            this.cmdSetAccConf.Enabled = false;
            this.cmdSetAccConf.Location = new System.Drawing.Point(454, 235);
            this.cmdSetAccConf.Name = "cmdSetAccConf";
            this.cmdSetAccConf.Size = new System.Drawing.Size(110, 23);
            this.cmdSetAccConf.TabIndex = 42;
            this.cmdSetAccConf.Text = "Set ACC sensibility";
            this.toolTip1.SetToolTip(this.cmdSetAccConf, "Set ACC configuration");
            this.cmdSetAccConf.UseVisualStyleBackColor = true;
            this.cmdSetAccConf.Click += new System.EventHandler(this.cmdSetAccConf_Click);
            // 
            // lblDeviceId
            // 
            this.lblDeviceId.Location = new System.Drawing.Point(325, 55);
            this.lblDeviceId.Name = "lblDeviceId";
            this.lblDeviceId.Size = new System.Drawing.Size(75, 18);
            this.lblDeviceId.TabIndex = 31;
            this.lblDeviceId.Text = "- - - - - - - - - -";
            this.lblDeviceId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Device Id:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxRadioEvent
            // 
            this.pictureBoxRadioEvent.Location = new System.Drawing.Point(423, 33);
            this.pictureBoxRadioEvent.Name = "pictureBoxRadioEvent";
            this.pictureBoxRadioEvent.Size = new System.Drawing.Size(17, 17);
            this.pictureBoxRadioEvent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxRadioEvent.TabIndex = 33;
            this.pictureBoxRadioEvent.TabStop = false;
            // 
            // txtEventData
            // 
            this.txtEventData.Enabled = false;
            this.txtEventData.Location = new System.Drawing.Point(351, 31);
            this.txtEventData.MaxLength = 10;
            this.txtEventData.Name = "txtEventData";
            this.txtEventData.Size = new System.Drawing.Size(66, 20);
            this.txtEventData.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "v1.0.07 @Mar15";
            // 
            // imageListCommStatus
            // 
            this.imageListCommStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCommStatus.ImageStream")));
            this.imageListCommStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCommStatus.Images.SetKeyName(0, "semaf_red_16.png");
            this.imageListCommStatus.Images.SetKeyName(1, "semaf_yellow_16.png");
            this.imageListCommStatus.Images.SetKeyName(2, "semaf_green_16.png");
            // 
            // lblAccConf
            // 
            this.lblAccConf.Location = new System.Drawing.Point(332, 265);
            this.lblAccConf.Name = "lblAccConf";
            this.lblAccConf.Size = new System.Drawing.Size(75, 18);
            this.lblAccConf.TabIndex = 47;
            this.lblAccConf.Text = "- - - - - - - - - -";
            this.lblAccConf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Location = new System.Drawing.Point(221, 265);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(99, 13);
            this.lblAcc.TabIndex = 46;
            this.lblAcc.Text = "Sensibility (Device):";
            // 
            // lblAccOptions
            // 
            this.lblAccOptions.AutoSize = true;
            this.lblAccOptions.Location = new System.Drawing.Point(244, 240);
            this.lblAccOptions.Name = "lblAccOptions";
            this.lblAccOptions.Size = new System.Drawing.Size(76, 13);
            this.lblAccOptions.TabIndex = 45;
            this.lblAccOptions.Text = "Acc sensibility:";
            // 
            // comboBoxAccConf
            // 
            this.comboBoxAccConf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAccConf.Enabled = false;
            this.comboBoxAccConf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxAccConf.FormattingEnabled = true;
            this.comboBoxAccConf.Items.AddRange(new object[] {
            "2G",
            "4G"});
            this.comboBoxAccConf.Location = new System.Drawing.Point(332, 236);
            this.comboBoxAccConf.Name = "comboBoxAccConf";
            this.comboBoxAccConf.Size = new System.Drawing.Size(110, 21);
            this.comboBoxAccConf.TabIndex = 44;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 19);
            this.toolStripStatusLabel1.Text = "Firmware version:";
            // 
            // lblFirmwareVersion
            // 
            this.lblFirmwareVersion.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblFirmwareVersion.Name = "lblFirmwareVersion";
            this.lblFirmwareVersion.Size = new System.Drawing.Size(56, 19);
            this.lblFirmwareVersion.Text = "- - - - - -";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 311);
            this.Controls.Add(this.lblAccConf);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.lblAccOptions);
            this.Controls.Add(this.comboBoxAccConf);
            this.Controls.Add(this.cmdGetAccConf);
            this.Controls.Add(this.cmdSetAccConf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEventData);
            this.Controls.Add(this.pictureBoxRadioEvent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDeviceId);
            this.Controls.Add(this.cmdGetDeviceId);
            this.Controls.Add(this.lblRadioEvent);
            this.Controls.Add(this.txtRadioEvent);
            this.Controls.Add(this.cmdSetLabel);
            this.Controls.Add(this.cmdOpenAppDir);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.checkBoxRecordEcg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBoxRecordQRS);
            this.Controls.Add(this.checkBoxShowQRS);
            this.Controls.Add(this.cmdGetSampleFrequency);
            this.Controls.Add(this.cmdGetLeads);
            this.Controls.Add(this.lblEcgStream);
            this.Controls.Add(this.lblSampleFrequency);
            this.Controls.Add(this.lblNumberOfLeads);
            this.Controls.Add(this.lblTimeConn);
            this.Controls.Add(this.cmdGetRTC);
            this.Controls.Add(this.cmdSetRTC);
            this.Controls.Add(this.lblTimestampValue);
            this.Controls.Add(this.lblQRS);
            this.Controls.Add(this.lblPushButtonValue);
            this.Controls.Add(this.lblRtcValue);
            this.Controls.Add(this.lblSdCardStatus);
            this.Controls.Add(this.lblAccValue);
            this.Controls.Add(this.lblBatteryValue);
            this.Controls.Add(this.cmdOpenPort);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.lblComAvailable);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(590, 350);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sample code SDK @Biodevices 2013";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRadioEvent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblComAvailable;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Button cmdOpenPort;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel lblComm;
        private System.Windows.Forms.ToolStripStatusLabel lblCommStatus;
        private System.Windows.Forms.Label lblBatteryValue;
        private System.Windows.Forms.Label lblAccValue;
        private System.Windows.Forms.Label lblSdCardStatus;
        private System.Windows.Forms.Label lblRtcValue;
        private System.Windows.Forms.Label lblPushButtonValue;
        private System.Windows.Forms.Label lblQRS;
        private System.Windows.Forms.Label lblTimestampValue;
        private System.Windows.Forms.ToolStripStatusLabel lblCommData;
        private System.Windows.Forms.Button cmdSetRTC;
        private System.Windows.Forms.Button cmdGetRTC;
        private System.Windows.Forms.Label lblTimeConn;
        private System.Windows.Forms.Label lblNumberOfLeads;
        private System.Windows.Forms.Label lblSampleFrequency;
        private System.Windows.Forms.Label lblEcgStream;
        private System.Windows.Forms.Button cmdGetLeads;
        private System.Windows.Forms.Button cmdGetSampleFrequency;
        private System.Windows.Forms.Timer timerEcg;
        private System.Windows.Forms.CheckBox checkBoxShowQRS;
        private System.Windows.Forms.CheckBox checkBoxRecordQRS;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxRecordEcg;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Button cmdOpenAppDir;
        private System.Windows.Forms.Button cmdSetLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtRadioEvent;
        private System.Windows.Forms.Label lblRadioEvent;
        private System.Windows.Forms.Button cmdGetDeviceId;
        private System.Windows.Forms.Label lblDeviceId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxRadioEvent;
        private System.Windows.Forms.TextBox txtEventData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageListCommStatus;
        private System.Windows.Forms.Label lblAccConf;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.Label lblAccOptions;
        private System.Windows.Forms.ComboBox comboBoxAccConf;
        private System.Windows.Forms.Button cmdGetAccConf;
        private System.Windows.Forms.Button cmdSetAccConf;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblFirmwareVersion;
    }
}

