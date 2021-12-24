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
            if(!this.source.Contains(source.Trim()))
            this.source.Add(source.Trim());
            toSearch.Add(term.Trim());
        }
        public string[] GetSearchTerms() 
        {
            string[] result = new string[toSearch.Count];
            string query = "SELECT ";
            for(int i = 0; i < toSearch.Count; i++) 
            {
                query += toSearch[i];
                if (i == toSearch.Count - 1) continue;
                query += ",";
            }
            query += " FROM ";
            for(int i = 0; i < source.Count; i++) 
            {
                query += source[i];
                if (i == source.Count - 1) continue;
                query += ",";
            }
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            for (int i = 0; i < toSearch.Count; i++)
            {
                foreach (var baseObject in searcher.Get())
                {
                    result[i] = baseObject[toSearch[i]].ToString();
                }
            }

            return result;
        }
    }
}
