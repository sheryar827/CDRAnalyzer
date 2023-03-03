using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace UpdateAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WebClient webClient = new WebClient();
            var client = new WebClient();

            try
            {
                System.Threading.Thread.Sleep(5000);
                File.Delete(@".\ReadExcelApp.exe");
                //client.DownloadFile("https://buddig827.000webhostapp.com/update/ReadExcelApp.zip", @"ReadExcelApp.zip");
                client.Credentials = new NetworkCredential("test", "test");
                client.DownloadFile("ftp://58.65.176.128/ReadExcelApp.zip", @"ReadExcelApp.zip");
                string zipPath = @".\ReadExcelApp.zip";
                string extractPath = @".\";
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                File.Delete(@".\ReadExcelApp.zip");
                Process.Start(@".\ReadExcelApp.exe");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Process.Start("ReadExcelApp.exe");
                this.Close();
            }
        }
    }
}
