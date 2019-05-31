using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace TestBioLib
{
    public class ErrorLog
    {
        public static void WriteLogFile(string path, string error, bool addDate)
        {
            string pathDir = Path.GetDirectoryName(path);
            if (!Directory.Exists(pathDir))
                Directory.CreateDirectory(pathDir);

            StreamWriter stream = new StreamWriter(path + "Error_TestBioLib_" + DateTime.Now.ToString("ddMMyyyy") + ".txt", true);

            if (addDate)
                stream.WriteLine(DateTime.Now.ToString() + ": " + error);
            else
                stream.WriteLine(error);

            stream.Close();
        }

        public static void WriteLogFile(string path, string error)
        {
            string pathDir = Path.GetDirectoryName(path);
            if (!Directory.Exists(pathDir))
                Directory.CreateDirectory(pathDir);

            StreamWriter stream = new StreamWriter(path + "Error_" + DateTime.Now.ToString("ddMMyyyy") + ".txt", true);
            stream.WriteLine(DateTime.Now.ToString() + ": " + error);
            stream.Close();
        }
    }
}
