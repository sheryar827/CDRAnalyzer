using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReadExcelApp.Classes
{
    class HWID
    {
        public static string GetMachineid()
        {
            const string _Salt = "Cisco@@@54321";
            const string _Paper = "54321@@@Cisco";

            StringBuilder sb = new StringBuilder();

            using (ManagementObjectSearcher searcherMB = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard"))
            {
                foreach (ManagementObject info in searcherMB.Get())
                {
                    sb.Append(info.GetPropertyValue("SerialNumber").ToString());
                }

                sb.Append(_Salt);
                searcherMB.Dispose();
            }

            using (ManagementObjectSearcher searchCPU = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
            {
                foreach (ManagementObject info in searchCPU.Get())
                {
                    sb.Append(info.GetPropertyValue("ProcessorId").ToString());
                }

                sb.Append(_Paper);
                searchCPU.Dispose();
            }

            using (MD5 md5 = MD5.Create())
            {
                byte[] Input = Encoding.ASCII.GetBytes(sb.ToString());
                byte[] Output = md5.ComputeHash(Input);

                sb.Clear();

                for (int i = 0; i < Output.Length; i++)
                {
                    sb.Append(Output[i].ToString("X2"));

                }
                md5.Dispose();

            }

            return sb.ToString();
        }

        public static string EncryptPassword(string password)
        {
            const string _Salt = "Cisco@@@54321";
            const string _Paper = "54321@@@Cisco";
            password = _Salt + password + _Paper;
            StringBuilder sb = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] Input = Encoding.ASCII.GetBytes(password.ToString());

                byte[] Output = md5.ComputeHash(Input);

                password = null;

                for (int i = 0; i < Output.Length; i++)
                {
                    sb.Append(Output[i].ToString("X2"));

                }
                md5.Dispose();

            }

            return sb.ToString();
        }
    }
}
