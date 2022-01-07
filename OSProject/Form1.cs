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
            //label3.Text = null;
            /*foreach(string s in asd) 
            {
                label3.Text += s + "\n";
            }*/
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HardwareInfo ram = new HardwareInfo();

            ram.AddSearchTerms("NumberOfCores", "Win32_Processor");//İşlemcinin çekirdek sayısı
            ram.AddSearchTerms("Name", "Win32_Processor");//İşlemci Adı
            ram.AddSearchTerms("MaxClockSpeed", "Win32_Processor");//En fazla işlemci saati hızı
            ram.AddSearchTerms("NumberOfLogicalProcessors", "Win32_Processor");//Matıksal İşlemci Sayısı
            label1.Text = null;
            label2.Text = null;
            label3.Text = null;
            label4.Text = null;
            string[] asd = ram.GetSearchTerms();
            label1.Text += asd[0] + "\n";
            label2.Text += asd[1] + "\n";
            label3.Text += asd[2] + "\n";
            label4.Text += asd[3] + "\n";



            HardwareInfo hardware2 = new HardwareInfo();

            hardware2.AddSearchTerms("Layout", "Win32_Keyboard");//Klavye arayüzü
            label8.Text = null;
            string[] asd2 = hardware2.GetSearchTerms();
            label8.Text += asd2[0] + "\n";
            label5.Text = PC_NeZamandirAcik();
            PC_NeZamandirAcik();

            HardwareInfo storage = new HardwareInfo();
            storage.AddSearchTerms("Name", "Win32_DiskDrive");//Disk Adı
            storage.AddSearchTerms("Model", "Win32_DiskDrive");//Disk Modeli
            storage.AddSearchTerms("Manufacturer", "Win32_DiskDrive");//Disk üretici
            storage.AddSearchTerms("Partitions", "Win32_DiskDrive");//Disk bölümlenmesi
            storage.AddSearchTerms("Size", "Win32_DiskDrive");//Disk boyutı(byte)
            storage.AddSearchTerms("InstallDate", "Win32_DiskDrive");//Yüklenme Tarihi
            string[] storageData = storage.GetSearchTerms();


        }
        //Ne kada süredir çalıştığı
        int gun = Environment.TickCount / 86400000;
        int saat = Environment.TickCount / 3600000 % 24;
        int dakika = Environment.TickCount / 120000 % 60;
        int saniye = Environment.TickCount / 1000 % 60;
        int salise = 0;
        public string PC_NeZamandirAcik()
        {
            


            String cevap = String.Empty;

            cevap += Convert.ToString(gun) + " gün, ";
            cevap += Convert.ToString(saat) + " saat, ";
            cevap += Convert.ToString(dakika) + " dakika, ";
            cevap += Convert.ToString(saniye) + " saniye.";

            timer1.Start();

            return cevap;

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
        //Zaman hesaplayıcı
        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            //progressBar1.Value = salise;
            if (saniye == 60)
            {
                saniye = 0;
                dakika++;
            }

            if (dakika == 60)
            {
                dakika = 0;
                saat++;
            }


            if (saat == 24)
            {
                saat = 0;
                gun++;
            }

            label16.Text = saniye.ToString();
            label15.Text = dakika.ToString();
            label14.Text = saat.ToString();
            label13.Text = gun.ToString();
        }
    }
}
