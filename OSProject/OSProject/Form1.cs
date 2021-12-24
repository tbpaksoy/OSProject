using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Microsoft.VisualBasic.Devices;

namespace OSProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            HardwareInfo hardware = new HardwareInfo();
            hardware.AddSearchTerms("NumberOfCores" , "Win32_Processor");
            hardware.AddSearchTerms("Name", "Win32_Processor");
            hardware.AddSearchTerms("MaxClockSpeed", "Win32_Processor");
            hardware.AddSearchTerms("NumberOfLogicalProcessors", "Win32_Processor");
            //hardware.AddSearchTerms("Layout", "Win32_Keyboard");
            string[] asd = hardware.GetSearchTerms();
            label1.Text = null;
            foreach(string s in asd) 
            {
                label1.Text += s + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private uint GetCurrentCPUClock() 
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select CurrentClockSpeed from Win32_Processor");
            foreach(var item in searcher.Get()) 
            {
                return (uint)item["CurrentClockSpeed"];
            }
            return 0;
        }
        private void UpdateCurentClockLabel(object sender, EventArgs e) 
        {

        }
    }
}
