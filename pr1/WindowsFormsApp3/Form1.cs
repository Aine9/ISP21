using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 6;
            dataGridView1[0, 0].Value = "Версия Windows";
            dataGridView1[1, 0].Value = Environment.OSVersion.ToString();

            dataGridView1[0, 1].Value = "64 Bit операционная система";
            dataGridView1[1, 1].Value = Environment.Is64BitOperatingSystem;

            dataGridView1[0, 2].Value = "Имя компьютера";
            dataGridView1[1, 2].Value = Environment.MachineName;

            dataGridView1[0, 3].Value = "Число процессоров";
            dataGridView1[1, 3].Value = Environment.ProcessorCount;
 
            dataGridView1[0, 4].Value = "Системная папка";
            dataGridView1[1, 4].Value = Environment.SystemDirectory;

            dataGridView1[0, 5].Value = "Логические диски";
            string[] drives = Environment.GetLogicalDrives();
            dataGridView1[1, 5].Value = String.Join(", ", drives);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
