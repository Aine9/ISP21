using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace пр3
{
    public partial class Form1 : Form
    {
        private object fileContentTextBox;

        public Form1()
        {
            InitializeComponent();
        }



        private void openFileDialog1_FileOk(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Encoding encoding = GetSelectedEncoding();

                try
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    using (BinaryReader reader = new BinaryReader(fileStream, encoding))
                    {
                        byte[] bytes = reader.ReadBytes((int)fileStream.Length);
                        string fileContent = encoding.GetString(bytes);
                        textBox1.Text = fileContent;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сохранение не удалаось: " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveFileDialog1_FileOk(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                Encoding encoding = GetSelectedEncoding();

                try
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    using (BinaryWriter writer = new BinaryWriter(fileStream, encoding))
                    {
                        byte[] bytes = encoding.GetBytes(textBox1.Text);
                        writer.Write(bytes);
                    }
                    MessageBox.Show("Сохранение прошло успешно!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сохранение не удалаось: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Encoding GetSelectedEncoding()
        {
            if (radioButton1.Checked)
            {
                return Encoding.UTF8;
            }
            else if (radioButton2.Checked)
            {
                return Encoding.Unicode;
            }
            else if (radioButton3.Checked)
            {
                return Encoding.ASCII;
            }
            else
            {
                 
                return Encoding.UTF8;
            }
        }

       
    }
}


