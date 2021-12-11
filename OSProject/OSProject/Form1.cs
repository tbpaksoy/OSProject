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

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select MaxClockSpeed,Name,Manufacturer,Family from Win32_Processor");
            foreach (var item in searcher.Get())
            {
                label1.Text += (item["MaxClockSpeed"]).ToString() + "Hz \n";
                label1.Text += item["Name"].ToString() + "\n";
                label1.Text += item["Manufacturer"].ToString() + "\n" ;
                label1.Text += item["Family"].ToString() + "\n" ;
                label1.Text += (float) new ComputerInfo().TotalPhysicalMemory / (float)1073741824;
            }
            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(UpdateCurentClockLabel);
            timer.Start();
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
            label2.Text = GetCurrentCPUClock().ToString() + "Hz";
        }
    }
}
