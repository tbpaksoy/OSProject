using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Iot.Device.HardwareMonitor;
using OpenHardwareMonitor;
using OpenHardwareMonitor.Hardware;


namespace OSProject
{
    public class HardwareInfo
    {
        private List<string> source = new List<string>();
        private List<string> toSearch = new List<string>();

        public void AddSearchTerms(string term, string source)
        {
            this.source.Add(source);
            toSearch.Add(term);
        }
        public string[] GetSearchTerms()
        {
            string[] result = new string[toSearch.Count];

            for (int i = 0; i < toSearch.Count; i++)
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {source[i]}");
                foreach (var baseObject in searcher.Get())
                {
                    result[i] = baseObject[toSearch[i]].ToString();
                }
            }
            return result;
        }
        public static string GetCPUTemperature() 
        {
            Computer computer = new Computer() { CPUEnabled = true };
            computer.Open();
            string result = null;
            foreach(var hardaware in computer.Hardware) 
            {
                foreach(var sensor in hardaware.Sensors) 
                {
                    if(sensor.SensorType == OpenHardwareMonitor.Hardware.SensorType.Temperature && sensor.Value.HasValue) 
                    {
                        result = sensor.Value.GetValueOrDefault().ToString();
                    }
                }
            }
            computer.Close();
            return result;
        }
    }
}
