using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BioLib;
using System.IO.Ports;
using QrsDetector;
using System.IO;
using Confluent.Kafka;
using System.Net;


namespace TestBioLib
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Path of application.
        /// </summary>
        private const string applicationPath = @"c:\VJ_SDK\";

        /// <summary>
        /// Ecg lead to record.
        /// </summary>
        private int leadToRecord = 1;

        /// <summary>
        /// 
        /// </summary>
        private delegate void UpDateBatteryValue(int level);
        private delegate void UpDateAccValue(Data.DataACC acc);
        private delegate void PushButtonEvent(DateTime date, int nTimes);
        private delegate void UpDateRtcValue(DateTime date);
        private delegate void UpDateTimestampValue(DateTime date);
        private delegate void SdCardStateEvent(bool state);
        private delegate void UpdateQrsValue(Data.Qrs qrs);
        private delegate void UpdateEcgStream(List<List<byte>> ecg);
        private delegate void RadioEventHandler(byte type, byte[] data);
        private delegate void DeviceIdEventHandler(string deviceId);
        private delegate void FirmwareEventHandler(string version);
        private delegate void AccConfEventHandler(byte type);

        private int numOfPushbuttons = 0;
        private int numOfTimestamps = 0;
        private int nQrs = 0;
        private int nLeads = 1;
        private int nBytesEcg = 0;
        private int nStreams = 0;
        private int numberOfSamples = 0;
        private frmQrs form = null;
        private bool isRecord = false;
        private StreamWriter fs1 = null, fs2 = null;
        private FileStream fs = null;
        private BinaryWriter fOpen = null;
        private int nSamplesRecord = 0;
        private Buffer buf = null;
        private bool statusRadioEvent = true;
        private int countTicks = 0;

        private string deviceId = null;

        /// <summary>
        /// BioLib
        /// </summary>
        private Data bioLib = null;

        /// <summary>
        /// QrsDetector
        /// </summary>
        private Detector detector = null;

        private ProducerConfig config = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            // Create application directory
            if (!Directory.Exists(applicationPath)) Directory.CreateDirectory(applicationPath);

            // Get serial port available
            comboBoxPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
                comboBoxPort.Items.Add(port);

            if (comboBoxPort.Items.Count > 0)
                comboBoxPort.SelectedIndex = 0;

            lblComm.Image = imageListCommStatus.Images[0];

            string textLog = "" + Environment.NewLine;
            textLog += "##################################################" + Environment.NewLine;
            textLog += "# ERROR LOG FILE - SDK Sample Code               #" + Environment.NewLine;
            textLog += "# VERSION: 1.0.07                                #" + Environment.NewLine;
            textLog += "# DATE: " + DateTime.Now.ToString("yyyy/MM/dd  HH:mm:ss") + "                     #" + Environment.NewLine;
            textLog += "##################################################" + Environment.NewLine;
            ErrorLog.WriteLogFile(applicationPath, textLog, false);

            // Kafka settings
            config = new ProducerConfig { BootstrapServers = "192.168.160.80:39092" };
            //ProducerRecord<K, V> a = new ProducerRecord<>(topic, key, value);



            Reset();
        }

        /// <summary>
        /// Reset variables and UI.
        /// </summary>
        private void Reset()
        {
            if (isRecord)
            {
                isRecord = false;
                if (fOpen != null) fOpen.Close();
                fOpen = null;
            }
            
            numberOfSamples = 0;
            numOfPushbuttons = 0;
            numOfTimestamps = 0;
            nQrs = 0;
            nLeads = 1;
            nBytesEcg = 0;
            nStreams = 0;
            numberOfSamples = 0;
            nSamplesRecord = 0;
            countTicks = 0;
            statusRadioEvent = false;

            sampleCount = 0;
            windowCounter = 0;
            pulseQueue = new Queue<int>();
            oldPeak = 0;
            pulseValue = 0;

            nQpeak1 = 0;
            nQpeak2 = 0;

            // Clean UI
            lblAccValue.Text = "Acc   X: --  Y: --  Z: --";
            lblBatteryValue.Text = "Battery: --%";
            lblPushButtonValue.Text = "Pushbutton: #--   -- / -- / --  --:--:--";
            lblRtcValue.Text = "RTC:  -- / -- / --  --:--:--";
            lblTimestampValue.Text = "Timestamp:   -- / -- / --  --:--:--";
            lblQRS.Text = "QRS   Position: --   R-R(ms): --   BPMi(bpm): --";
            lblSdCardStatus.Text = "Sd Card status: --";
            lblEcgStream.Text = "Ecg stream: --";
            lblNumberOfLeads.Text = "Nb. leads: -- ";
            lblSampleFrequency.Text = "Sample frequency (Hz): -- ";
            lblTimeConn.Text = "Time connection: - - :- -:- -";
            lblRecord.Text = "Record: - - :- -:- -";
            lblDeviceId.Text = "- - - - - - - - - -";

            numOfPushbuttons = 0;
            numOfTimestamps = 0;
            numberOfSamples = 0;
            nStreams = 0;

            nLeads = 1;
            nBytesEcg = 0;
            nSamplesRecord = 0;

            pictureBoxRadioEvent.Image = imageListCommStatus.Images[0];

            bioLib = null;
            detector = null;

            if (fs1 != null)
            {
                fs1.Close();
                fs1 = null;
            }

            if (fs2 != null)
            {
                fs2.Close();
                fs2 = null;
            }
        }

        private void EcgReceived(List<List<byte>> ecg)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new UpdateEcgStream(UpdateEcg), ecg);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[EcgReceived]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void AccReceived(Data.DataACC acc)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new UpDateAccValue(UpDateAcc), acc);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[AccReceived]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void BatteryReceived(byte batteryLevel)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new UpDateBatteryValue(UpDateBattery), batteryLevel);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[BatteryReceived]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void PushButtonReceived(DateTime date, int nPushButton)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new PushButtonEvent(UpDatePushButton), date, nPushButton);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[PushButtonReceived]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void RtcReceived(DateTime date)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new UpDateRtcValue(UpDateRTC), date);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[RtcReceived]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void TimestampReceived(DateTime date)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new UpDateTimestampValue(UpDateTimestamp), date);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[TimestampReceived]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void SdcardEventHandler(bool state)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new SdCardStateEvent(UpDateSdCardState), state);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[SdcardEventHandler]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void RadioEventReceived(byte typeRadioEvent, byte[] dataRadioEvent)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new RadioEventHandler(RadioEventState), typeRadioEvent, dataRadioEvent);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[RadioEventReceived]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void DeviceIdReceived(string deviceId)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new DeviceIdEventHandler(UpdateDeviceId), deviceId);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[DeviceIdReceived]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }

        }

        private void FirmwareVersionReceived(string version)
        {
            try
            {
                if (InvokeRequired)
                {

                    BeginInvoke(new FirmwareEventHandler(UpdateFirmwareVersion), version);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[FirmwareVersionReceived]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void AccConfReceived(byte type)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new AccConfEventHandler(UpdateAccConf), type);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[AccConfReceived]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void QrsDetected(Data.Qrs qrs)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new UpdateQrsValue(UpDateQRS), qrs);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[QrsDetected]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
        
        private void UpdateEcg(List<List<byte>> ecg)
        {
            try
            {
                byte[] ecg1 = ecg[0].ToArray();

                nStreams++;
                nLeads = ecg.Count;
                nBytesEcg = ecg1.Length;
                numberOfSamples += nBytesEcg;

                if (bioLib != null)
                {
                    int sampleFrequency = bioLib.GetSampleFrequency();
                    int nSeconds = numberOfSamples / sampleFrequency;
                    TimeSpan timeSpan = new TimeSpan(0, 0, nSeconds);
                    DateTime date = new DateTime(timeSpan.Ticks);
                    lblTimeConn.Text = "Time connection: " + date.ToString("HH:mm:ss");
                    lblEcgStream.Text = "Ecg stream [#" + nStreams + "]:  #" + nLeads + " lead(s)   nBytes = " + nBytesEcg + " bytes";
                }

                // Save Ecg raw data of Lead I
                if (isRecord)
                {
                    fOpen.Write(ecg1, 0, nBytesEcg);
                    nSamplesRecord += nBytesEcg;
                    int sampleFrequency = bioLib.GetSampleFrequency();
                    int nSeconds = nSamplesRecord / sampleFrequency;
                    TimeSpan timeSpan = new TimeSpan(0, 0, nSeconds);
                    DateTime date = new DateTime(timeSpan.Ticks);
                    lblRecord.Text = "Time record: " + date.ToString("HH:mm:ss");
                }

                // Use QrsDetector.dll
                WtrBuf(ecg[0].ToArray(), ecg[0].Count);
                
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[UpdateEcg]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        /// <summary>
        /// Write data in buffer.
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="nbytes">number of bytes</param>
        /// <returns>true, if no errors occurred</returns>
        private bool WtrBuf(byte[] data, int nbytes)
        {
            int i = 0;
            
            try
            {
                for (i = 0; i < nbytes; i++)
                {
                    buf.data[buf.wrPointer] = data[i];
                    buf.wrPointer++;

                    // Inc number of bytes received
                    buf.nBytes++;

                    if (buf.wrPointer > (Buffer.kBytes - 1))
                        buf.wrPointer = 0;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[WtrBuf]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Read value of buffer.
        /// </summary>
        /// <returns></returns>
        private short RdBuf()
        {
            short value = 0;

            try
            {
                if (buf.wrPointer != buf.rdPointer)
                {
                    value = buf.data[buf.rdPointer];

                    buf.rdPointer++;
                    buf.nBytes--;

                    if (buf.rdPointer > (Buffer.kBytes - 1))
                        buf.rdPointer = 0;

                    return value;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[RdBuf]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                return -2;
            }
        }

        #region Update values in UI

        /// <summary>
        /// Update accelerometer value.
        /// </summary>
        /// <param name="acc">coord (x,y,z)</param>
        private void UpDateAcc(Data.DataACC acc)
        {
            lblAccValue.Text = "Acc   X: " + acc.X + "  Y: " + acc.Y + "  Z: " + acc.Z;
        }

        /// <summary>
        /// Update battery level.
        /// </summary>
        /// <param name="battery"></param>
        private void UpDateBattery(int battery)
        {
            lblBatteryValue.Text = "Battery: " + battery.ToString() + "%";
        }

        /// <summary>
        /// Received push-button.
        /// </summary>
        /// <param name="date">date of push-button</param>
        /// <param name="nTimes">number of push-button</param>
        private void UpDatePushButton(DateTime date, int nTimes)
        {
            numOfPushbuttons = nTimes;
            lblPushButtonValue.Text = "Pushbutton:  #" + nTimes + "   " + date.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        /// <summary>
        /// Update RTC timecode.
        /// </summary>
        /// <param name="date">date of RTC</param>
        private void UpDateRTC(DateTime date)
        {
            lblRtcValue.Text = "RTC:  " + date.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        /// <summary>
        /// Update timestamp value.
        /// </summary>
        /// <param name="date">date of timestamp</param>
        private void UpDateTimestamp(DateTime date)
        {
            numOfTimestamps++;
            lblTimestampValue.Text = "Timestamp:  #" + numOfTimestamps + "  " + date.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        /// <summary>
        /// Update acc parameter configuration.
        /// </summary>
        /// <param name="type"></param>
        private void UpdateAccConf(byte type)
        {
            if (type == 0)
                lblAccConf.Text = "2G";
            else if (type == 1)
                lblAccConf.Text = "4G";
        }

        /// <summary>
        /// Update state of SD Card in device.
        /// </summary>
        /// <param name="state">state sd card</param>
        private void UpDateSdCardState(bool state)
        {
            if (state)
            {
                lblSdCardStatus.Text = "Sd Card status: ON";
                cmdSetLabel.Enabled = true;
                txtRadioEvent.Enabled = true;
                txtEventData.Enabled = true;
            }
            else
            {
                lblSdCardStatus.Text = "Sd Card status: OFF";
                cmdSetLabel.Enabled = false;
                txtRadioEvent.Enabled = false;
                txtEventData.Enabled = false;
            }
        }

        /// <summary>
        /// Receive Ack: radio-event write in SD Card.
        /// </summary>
        /// <param name="type"></param>
        private void RadioEventState(byte type, byte[] data)
        {
            pictureBoxRadioEvent.Image = imageListCommStatus.Images[2];

            string message = "";
            for (int i = 0; i < data.Length; i++)
                message += (Convert.ToChar(data[i])).ToString();
            txtEventData.Text = message;
            txtRadioEvent.Text = type.ToString();

            statusRadioEvent = true;
            countTicks = 0;
        }

        /// <summary>
        /// Device Id of device.
        /// </summary>
        /// <param name="deviceId">device Id</param>
        private void UpdateDeviceId(string deviceId)
        {
            this.deviceId = deviceId;

            lblDeviceId.Text = deviceId;

        }

        /// <summary>
        /// Firmware version.
        /// </summary>
        /// <param name="version">Version</param>
        private void UpdateFirmwareVersion(string version)
        {
            lblFirmwareVersion.Text = version;
        }

        /// <summary>
        /// New Qrs detected.
        /// </summary>
        /// <param name="qrs">QRS</param>
        private async void UpDateQRS(Data.Qrs qrs)
        {
            nQrs++;

            nQpeak1++;
            lblQRS.Text = "#" + nQpeak1.ToString() + "  Position: " + qrs.position + "   R-R(ms): " + qrs.rr + "   BPMi(bpm): " + qrs.bpmi;

            if (checkBoxRecordQRS.Checked)
                fs1.WriteLine(qrs.position + ";" + qrs.rr + ";" + qrs.bpmi);

            if (form != null)
                form.SetQrs1(lblQRS.Text);

            using (var p = new ProducerBuilder<string, string>(config).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync("bpmi-topic", new Message<string, string> { Key = deviceId, Value = "{\"value\": " + qrs.bpmi.ToString() + "}" });
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}' ' from ' {dr.Key}");
                }
                catch (ProduceException<string, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }

        #endregion

        /// <summary>
        /// Button 'click' event: open / close serial port.
        /// </summary>
        private void cmdOpenPort_Click(object sender, EventArgs e)
        {
            Open();
        }

        /// <summary>
        /// Open / Close serial port.
        /// </summary>
        private void Open()
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    cmdOpenPort.Text = "Open";
                    lblCommStatus.Text = "";
                    lblCommData.Text = "";
                    lblComm.Image = imageListCommStatus.Images[0];

                    timer.Enabled = false;
                    timerEcg.Enabled = false;

                    cmdSetRTC.Enabled = false;
                    cmdGetRTC.Enabled = false;
                    cmdGetLeads.Enabled = false;
                    cmdGetSampleFrequency.Enabled = false;
                    cmdSetLabel.Enabled = false;
                    cmdGetDeviceId.Enabled = false;
                    txtRadioEvent.Enabled = false;
                    txtEventData.Enabled = false;
                    txtRadioEvent.Text = "";
                    txtEventData.Text = "";
                    pictureBoxRadioEvent.Image = imageListCommStatus.Images[0];

                    checkBoxRecordQRS.Enabled = true;
                    checkBoxShowQRS.Enabled = true;
                    checkBoxRecordEcg.Enabled = true;

                    comboBoxAccConf.Enabled = false;
                    comboBoxAccConf.SelectedIndex = 0;
                    cmdSetAccConf.Enabled = false;
                    cmdGetAccConf.Enabled = false;
                    lblAccConf.Text = "- - - - - - - - - -";
                    lblFirmwareVersion.Text = "- - - - - -";

                    Application.DoEvents();

                    // Reset variables and clean UI
                    Reset();

                    comboBoxPort.Enabled = true;
                }
                else
                {
                    if (checkBoxShowQRS.Checked)
                    {
                        form = new frmQrs();
                        form.Show();
                    }

                    cmdOpenPort.Focus();

                    buf = new Buffer();

                    if (checkBoxRecordQRS.Checked)
                    {
                        fs1 = new StreamWriter(applicationPath + "RR_BioLib.txt", false);
                        fs1.WriteLine("POSITION;RR(ms);BPMi(bpm)");

                        fs2 = new StreamWriter(applicationPath + "RR_QrsDetector.txt", false);
                        fs2.WriteLine("POSITION;RR(ms);BPMi(bpm)");
                    }

                    if (checkBoxRecordEcg.Checked)
                    {
                        // Open file to record ecg data
                        string file = "ecg_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bin";
                        if (File.Exists(applicationPath + file)) File.Delete(applicationPath + file);
                        fs = new FileStream(applicationPath + file, FileMode.CreateNew, FileAccess.ReadWrite);
                        fOpen = new BinaryWriter(fs);

                        isRecord = true;
                        lblRecord.Visible = true;
                    }
                    else
                        lblRecord.Visible = false;

                    comboBoxPort.Enabled = false;
                    serialPort.PortName = comboBoxPort.SelectedItem.ToString();
                    serialPort.Open();
                    lblCommStatus.Text = serialPort.PortName + ", " + serialPort.BaudRate + ", " + serialPort.DataBits + ", " + serialPort.Parity.ToString() + ", " + serialPort.StopBits.ToString();
                    cmdOpenPort.Text = "Close";
                    lblComm.Image = imageListCommStatus.Images[2];

                    bioLib = new BioLib.Data(applicationPath, Data.LEADTOANALYSE.Lead2, Data.NUMBERPACKETPERSECOND.ten);
                    detector = new Detector(500, 7.0f, 0.3125f, 8);

                    bioLib.ecgEventHandler += new Data.EcgEventHandler(EcgReceived);
                    bioLib.accEventHandler += new Data.AccEventHandler(AccReceived);
                    bioLib.batteryEventHandler += new Data.BatterylevelEventHandler(BatteryReceived);
                    bioLib.pushbuttonEventHandler += new Data.PushbuttonEventHandler(PushButtonReceived);
                    bioLib.qrsEventHandler += new Data.QrsDetectedEventHandler(QrsDetected);
                    bioLib.rtcEventHandler += new Data.RTCEventHandler(RtcReceived);
                    bioLib.timestampEventHandler += new Data.TimestampEventHandler(TimestampReceived);
                    bioLib.sdcardEventHandler += new Data.SdCardStatusEventHandler(SdcardEventHandler);
                    bioLib.radioEventHandler += new Data.RadioEventHandler(RadioEventReceived);
                    bioLib.deviceIdEventHandler += new Data.DeviceIdEventHandler(DeviceIdReceived);
                    bioLib.accConfEventHandler += new Data.AccConfEventHandler(AccConfReceived);
                    bioLib.firmwareVersionEventHandler += new Data.FirmwareVersionEventHandler(FirmwareVersionReceived);
                    timer.Enabled = true;
                    timerEcg.Enabled = true;

                    cmdSetRTC.Enabled = true;
                    cmdGetRTC.Enabled = true;
                    cmdGetLeads.Enabled = true;
                    cmdGetSampleFrequency.Enabled = true;
                    cmdGetDeviceId.Enabled = true;

                    txtRadioEvent.Enabled = true;
                    txtRadioEvent.Text = "";

                    checkBoxRecordQRS.Enabled = false;
                    checkBoxShowQRS.Enabled = false;
                    checkBoxRecordEcg.Enabled = false;

                    comboBoxAccConf.Enabled = true;
                    comboBoxAccConf.SelectedIndex = 0;
                    cmdSetAccConf.Enabled = true;
                    cmdGetAccConf.Enabled = true;
                    lblAccConf.Text = "- - - - - - - - - -";
                    lblFirmwareVersion.Text = "- - - - - -";

                    GetFirmwareVersion();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[Open]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void GetFirmwareVersion()
        {
            try
            {
                byte[] data = new byte[4];

                data[0] = (byte)0xFC;
                data[1] = 0x02;
                data[2] = 0x15;
                data[3] = Utils.Get_CRC(data, 3);

                if (serialPort.IsOpen)
                    serialPort.Write(data, 0, 4);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[GetFirmwareVersion]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        /// <summary>
        /// Serial port data received event.
        /// </summary>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort.IsOpen && serialPort.BytesToRead > 0)
                {
                    int nBytes = serialPort.BytesToRead;
                    if (nBytes > 0)
                    {
                        byte[] buffer = new byte[nBytes];
                        serialPort.Read(buffer, 0, nBytes);

                        bioLib.SetData(buffer, nBytes);
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[SerialPort_DataReceived]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            string error = e.EventType.ToString();
            lblComm.Text = "ERROR: " + error;
        }

        /// <summary>
        /// Button 'click' event: open application directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOpenAppDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(applicationPath);
        }

        /// <summary>
        /// Button 'click' event: set RTC time code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSetRTC_Click(object sender, EventArgs e)
        {
            SetRTC(DateTime.Now);
        }

        /// <summary>
        /// Button 'click' event: get RTC time code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGetRTC_Click(object sender, EventArgs e)
        {
            GetRTC();
        }

        /// <summary>
        /// Button 'click' event: set label in ecg (write in SD CARD).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSetLabel_Click(object sender, EventArgs e)
        {
            if (txtRadioEvent.Text.Trim().Length > 0)
                SetLabel();
            else
                MessageBox.Show("Insert type of radio-event to send device!", "Test BioLib");
        }

        private void cmdGetDeviceId_Click(object sender, EventArgs e)
        {
            GetDeviceId();
        }

        /// <summary>
        /// Button 'click' event: get number of Ecg leads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGetLeads_Click(object sender, EventArgs e)
        {
            lblNumberOfLeads.Text = "Nb. leads: " + bioLib.GetNumberOfLeads();
        }

        /// <summary>
        /// Button 'click' event: get Ecg sample frequency.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGetSampleFrequency_Click(object sender, EventArgs e)
        {
            lblSampleFrequency.Text = "Sample frequency (Hz): " + bioLib.GetSampleFrequency();
            Console.WriteLine(bioLib.GetSampleFrequency());
        }

        /// <summary>
        /// Set RTC timecode.
        /// </summary>
        /// <param name="date"></param>
        private void SetRTC(DateTime date)
        {
            try
            {
                byte[] data = new byte[10];
    		
    		    data[0] = (byte)0xFC;
    		    data[1] = 0x08;
    		    data[2] = 0x06;
    		    data[3] = Utils.DECtoBCD(date.Second);
    		    data[4] = Utils.DECtoBCD(date.Minute);
    		    data[5] = Utils.DECtoBCD(date.Hour);
    		    data[6] = Utils.DECtoBCD(date.Day);
    		    data[7] = Utils.DECtoBCD(date.Month);
    		    data[8] = Utils.DECtoBCD(date.Year - 2000);
    		    data[9] = Utils.Get_CRC(data, 9);

                if (serialPort.IsOpen)
                    serialPort.Write(data, 0, 10);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[SetRTC]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        /// <summary>
        /// Get RTC timecode.
        /// </summary>
        private void GetRTC()
        {
            try
            {
                byte[] data = new byte[4];
    		
    		    data[0] = (byte)0xFC;
    		    data[1] = 0x02;
    		    data[2] = 0x04;
    		    data[3] = Utils.Get_CRC(data, 3);

                if (serialPort.IsOpen)
                    serialPort.Write(data, 0, 4);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[GetRTC]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }   
        }

        /// <summary>
        /// Set radio event in ecg (SD CARD).
        /// </summary>
        private void SetLabel()
        {
            try
            {
                byte[] dataEvent = null;
                byte nBytes = 0;

                if (txtEventData.Text.Trim().Length > 0)
                {
                    string message = txtEventData.Text;

                    nBytes = (byte)txtEventData.Text.Trim().Length;
                    dataEvent = new byte[nBytes];

                    for (int i = 0; i < nBytes; i++)
                        dataEvent[i] = (byte)Convert.ToChar(message.Substring(i, 1));
                }

                byte[] data = new byte[5 + dataEvent.Length];
                data[0] = (byte)0xFC;
                data[1] = (byte)(0x03 + dataEvent.Length);
                data[2] = 0x11;
                data[3] = Convert.ToByte(txtRadioEvent.Text);

                int index = 4;
                for (int i = 0; i < dataEvent.Length; i++)
                {
                    data[index] = dataEvent[i];
                    index++;
                }

                data[index] = Utils.Get_CRC(data, index);
                index++;

                pictureBoxRadioEvent.Image = imageListCommStatus.Images[0];

                txtRadioEvent.Text = "";
                txtEventData.Text = "";

                if (serialPort.IsOpen)
                    serialPort.Write(data, 0, index);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[SetLabel]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        /// <summary>
        /// Get device Id.
        /// </summary>
        private void GetDeviceId()
        {
            byte[] data = new byte[4];

            data[0] = (byte)0xFC;
            data[1] = 0x02;
            data[2] = 0x10;
            data[3] = Utils.Get_CRC(data, 3);

            if (serialPort.IsOpen)
                serialPort.Write(data, 0, 4);
        }


        #region QRS detection: user QrsDetector.dll (Sample Code)

        private int sampleCount = 0, windowCounter = 0;
        private int sampleFrequency = 500;
        private Queue<int> pulseQueue = new Queue<int>();
        private int oldPeak = 0;
        private float pulseValue = 0;
        private int nQpeak1 = 0;
        private int nQpeak2 = 0;


        /// <summary>
        /// Detect QRS.
        /// </summary>
        /// <param name="dataByte"></param>
        private void QrsDetector(short dataByte)
        {
            try
            {
                sampleCount++;

                if (windowCounter > sampleFrequency * 2)
                {
                    while (pulseQueue.Count > 5)
                        pulseQueue.Dequeue();

                    int[] cont = pulseQueue.ToArray();
                    float mean = (float)(Mean(cont, cont.Length) + 0.5);

                    pulseValue = mean;

                    windowCounter = 0;
                }
                else
                {
                    windowCounter++;
                }

                int delay = detector.QRSDet(dataByte * 10, 0, sampleCount);
                if (delay != 0)
                {
                    //Detector.Beat peak = qrsDetector.GetPeak();

                    int DetectionTime = sampleCount - delay;

                    // Cálculo do R-R
                    long rr = DetectionTime - oldPeak;

                    // Cálculo do valor do R-R (ms) & pulso (bpm)
                    Detector.QRS qrs = new Detector.QRS();
                    qrs.position = DetectionTime;
                    qrs.rr = (short)Detector.GetRR((int)rr, sampleFrequency);
                    qrs.bpmi = (short)Detector.GetPulse(qrs.rr);

                    nQpeak2++;
                    string text = "#" + nQpeak2.ToString() + "  Position: " + qrs.position + "   R-R(ms): " + qrs.rr + "   BPMi(bpm): " + qrs.bpmi;

                    if (checkBoxRecordQRS.Checked)
                        fs2.WriteLine(qrs.position + ";" + qrs.rr + ";" + qrs.bpmi);

                    if (form != null)
                        form.SetQrs2(text);

                    if (qrs.bpmi > 20 && qrs.bpmi < 255)
                    {
                        pulseQueue.Enqueue(qrs.bpmi);
                    }

                    oldPeak = DetectionTime;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[QrsDetector]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        /// <summary>
        /// Calculate mean of array values.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nvalues"></param>
        /// <returns></returns>
        private float Mean(int[] value, int nvalues)
        {
            float sum = 0;
            float nval = 0;

            for (int i = 0; i < nvalues; i++)
            {
                sum += value[i];

                if (value[i] > 0)
                    nval++;
            }

            if (nval > 0)
                sum /= nval;

            return sum;
        }

        #endregion


        /// <summary>
        /// Timer 'tick' event: keep alive device.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                byte[] buffer = new byte[1];
                buffer[0] = 0xFF;
                serialPort.Write(buffer, 0, 1);
            }
        }

        /// <summary>
        /// Timer 'tick' event: treat ecg data to detect QRS.
        /// </summary>
        private void timerEcg_Tick(object sender, EventArgs e)
        {
            timerEcg.Enabled = false;

            int n = buf.nBytes;
            while (n > 0)
            {
                short val = RdBuf();
                if (val >= 0)
                    QrsDetector((byte)val);

                n--;
            }

            if (statusRadioEvent)
            {
                countTicks++;
                if (countTicks >= 50)
                {
                    statusRadioEvent = false;
                    countTicks = 0;
                    pictureBoxRadioEvent.Image = imageListCommStatus.Images[0];
                }
            }
            else
                countTicks = 0;

            timerEcg.Enabled = true;
        }

        private void cmdSetAccConf_Click(object sender, EventArgs e)
        {
            SetAccConfiguration();
        }

        private void SetAccConfiguration()
        {
            try
            {
                byte[] data = new byte[5];

                data[0] = (byte)0xFC;
                data[1] = 0x03;
                data[2] = 0x12;
                data[3] = (byte)comboBoxAccConf.SelectedIndex;
                data[4] = Utils.Get_CRC(data, 4);

                if (serialPort.IsOpen)
                    serialPort.Write(data, 0, 5);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[SetAccConfiguration]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void cmdGetAccConf_Click(object sender, EventArgs e)
        {
            GetAccConfiguration();
        }

        private void GetAccConfiguration()
        {
            try
            {
                byte[] data = new byte[4];

                data[0] = (byte)0xFC;
                data[1] = 0x02;
                data[2] = 0x13;
                data[3] = Utils.Get_CRC(data, 3);

                if (serialPort.IsOpen)
                    serialPort.Write(data, 0, 4);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLogFile(applicationPath, "[GetAccConfiguration]: " + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        
        
    }
}
