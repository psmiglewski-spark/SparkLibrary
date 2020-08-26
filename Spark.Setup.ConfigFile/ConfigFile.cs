using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Setup
{
    public class ConfigFile : ISetup
    {
        private string connectionString;
        public string filePath { get; set; }

        public ConfigFile(string _filePath)
        {
            this.filePath = _filePath;
        }

        public void SetProperties()
        {
            string FailLogPath = Directory.GetCurrentDirectory() + "\\faillog" + DateTime.Now.ToString("yyyyMMddhhmm") + ".txt";


            try
            {
                List<string> list = new List<string>();

                string[] Name = { " " };

                try
                {
                    Name = File.ReadAllLines(filePath, Encoding.Default);
                }
                catch (Exception exc)
                {


                    using (StreamWriter sw = File.CreateText(FailLogPath))
                    {
                        sw.WriteLine(exc);

                    }

                    System.Environment.Exit(0);
                }
                foreach (var t in Name)
                {
                    list.Add(t);

                }
                this.connectionString = list[0];
                //this.timeInterval = list[1];
                //this.timeInterval = timeInterval.Substring(timeInterval.IndexOf("=") + 1);

            }
            catch (Exception ex)
            {

                using (StreamWriter sw = File.CreateText(FailLogPath))
                {
                    sw.WriteLine(ex);

                }

                System.Environment.Exit(0);

            }
        }

        public string GetConnectionString()
        {
            return connectionString;
        }


       

        public string GetInstallationPath()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }
    }
}
