using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

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
        public static string[] Test() 
        {
            string[] result = new string[2];
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach(var baseObject in searcher.Get()) 
            {
                result[0] = baseObject["Win32_Processor.Availability"].ToString();
                result[1] = baseObject["Win32_MotherboardDevice.Availability"].ToString();
            }
            return result;
        }
    }
}
