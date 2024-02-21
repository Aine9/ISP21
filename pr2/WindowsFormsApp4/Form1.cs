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

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >-1)

            {
                ManagementObjectSearcher searcher = null;
                if (comboBox1.SelectedIndex ==0)
                {
                      searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                }
                else if(comboBox1.SelectedIndex ==1) 
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_IDEController");
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery");
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                }
                else if (comboBox1.SelectedIndex == 5)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
                }
                else if (comboBox1.SelectedIndex == 6)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_CacheMemory");
                }
                else if (comboBox1.SelectedIndex == 7)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBController");
                }
                else if (comboBox1.SelectedIndex == 8)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                }
                else if (comboBox1.SelectedIndex == 9)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk");
                }
                else if (comboBox1.SelectedIndex == 10)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Keyboard");
                }
                else if (comboBox1.SelectedIndex == 11)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter");

                }
                else if (comboBox1.SelectedIndex == 12)
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Account");

                }

                int n = 0;
                foreach (ManagementObject obj in searcher.Get())

                {
                    foreach(PropertyData data in obj.Properties)
                    {
                        n = n + 1;
                        dataGridView1.RowCount = n;
                        dataGridView1[0, n - 1].Value = data.Name;
                        dataGridView1[1,n-1].Value = data.Value;
                    }
                  
                }
            }
        }
    }
}
