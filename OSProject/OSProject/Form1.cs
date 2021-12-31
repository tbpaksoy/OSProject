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
            /*hardware.AddSearchTerms("Name", "Win32_Processor");
            hardware.AddSearchTerms("MaxClockSpeed", "Win32_Processor");
            hardware.AddSearchTerms("NumberOfLogicalProcessors", "Win32_Processor");
            hardware.AddSearchTerms("Layout", "Win32_Keyboard");*/
            string[] asd = hardware.GetSearchTerms();
            //label3.Text = hardware.AddSearchTerms("NumberOfCores", "Win32_Processor");
            label3.Text = null;
            /*foreach(string s in asd) 
            {
                label3.Text += s + "\n";
            }*/
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HardwareInfo hardware = new HardwareInfo();

            hardware.AddSearchTerms("NumberOfCores", "Win32_Processor");
            label3.Text = null;
            string[] asd = hardware.GetSearchTerms();
            foreach (string s in asd)
            {
                label3.Text += s + "\n";
            }

            HardwareInfo hardware2 = new HardwareInfo();

            hardware2.AddSearchTerms("Name", "Win32_Processor");
            label4.Text = null;
            string[] asd2 = hardware2.GetSearchTerms();
            foreach (string s in asd2)
            {
                label4.Text += s + "\n";
            }

            HardwareInfo hardware3 = new HardwareInfo();

            hardware3.AddSearchTerms("MaxClockSpeed", "Win32_Processor");
            label8.Text = null;
            string[] asd3 = hardware3.GetSearchTerms();
            foreach (string s in asd3)
            {
                label8.Text += s + "\n";
            }

            HardwareInfo hardware4 = new HardwareInfo();

            hardware4.AddSearchTerms("NumberOfLogicalProcessors", "Win32_Processor");
            label6.Text = null;
            string[] asd4 = hardware4.GetSearchTerms();
            foreach (string s in asd4)
            {
                label6.Text += s + "\n";
            }

            HardwareInfo hardware5 = new HardwareInfo();

            hardware5.AddSearchTerms("Layout", "Win32_Keyboard");
            label12.Text = null;
            string[] asd5 = hardware5.GetSearchTerms();
            foreach (string s in asd5)
            {
                label12.Text += s + "\n";
            }


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
