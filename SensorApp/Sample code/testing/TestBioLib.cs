using System;
using BioLib;
using QrsDetector;

public class TestBioLib
{

    private const String applicationPath = @"c:\VJ_SDK\";

    private delegate void UpdateEcgStream(List<List<byte>> ecg);

    private Data bioLib = null;

    private Detector detector = null;

	public TestBioLib()
	{
        if (!Directory.Exists(applicationPath)) Directory.CreateDirectory(applicationPath);

        bioLib = new BioLib.Data(applicationPath, Data.LEADTOANALYSE.Lead2, Data.NUMBERPACKETPERSECOND.ten);
        detector = new Detector(500, 7.0f, 0.3125f, 8);
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
}
