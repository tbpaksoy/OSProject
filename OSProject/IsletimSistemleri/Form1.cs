using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsletimSistemleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OzellikGoster();
        }
        HardwareInfo hardware = new HardwareInfo();

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void OzellikGoster() {
          
           hardware.AddSearchTerms("NumberOfCores", "Win32_Processor");
           hardware.AddSearchTerms("Name", "Win32_Processor");
           hardware.AddSearchTerms("Layout", "Win32_Keyboard");
           hardware.AddSearchTerms("MaxClockSpeed", "Win32_Processor");
           hardware.AddSearchTerms("Name", "Win32_MemoryArray");
            String[]  asd = hardware.GetSearchTerms();
            for (int i = 0; i < asd.Length; i++)
            {
                txt_cekirdek.Text = asd[0];
                txt_islemci_adi.Text = asd[1];
                txt_klavye_arayuz.Text = asd[2];
                txt_islemci_hizi.Text = asd[3];
                txt_ram_hafiza.Text = asd[4];


            }


        }
      
    }

}
