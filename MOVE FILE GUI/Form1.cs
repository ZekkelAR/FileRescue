using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MOVE_FILE_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string[] images = {".jpg", ".jpeg", ".jpe" ,".jif", ".jfif",".jfi",
                                  ".JPEG", ".png", ".gif", ".webp", ".tiff", ".tif",
                                  ".raw", ".arw", ".cr2", ".nrw", ".k25",
                                  ".bmp", ".dib", ".svg", "svgz"};

        public string[] office = { ".xlsx", ".pptx", ".docx", ".doc", ".dotx", ".dotm", ".xml",
                                   ".wps", ".xps", ".csv", ".dif", ".ods", ".xltm", ".odp", ".pot", ".potx",
                                   ".ppt", ".rtf"};

        public string[] pdf = { ".pdf" };
        public string[] photoshop = { ".psd" };
        public string[] illustrator = { ".ai" };
        public string[] html = { ".html" };
        public string[] text = { ".txt" };


        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            add_item_combobox();
        }



        private void custom_get_file()
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;

            string[] filePaths = Directory.GetFiles(@textBox1.Text+@"\", "*"+bunifuTextBox1.Text);
            foreach (string file_path in filePaths)
            {
                string[] f = file_path.Split('\\');
                string last = f[f.Length - 1];
                move_file(file_path, last);
            }
        }

        private void add_item_combobox()
        {
            comboBox1.Text = "Choose ur extension here dek";
            comboBox1.Items.Add("Images Files");
            comboBox1.Items.Add("Office Files");
            comboBox1.Items.Add("PDF Files");
            comboBox1.Items.Add("Photoshop Files");
            comboBox1.Items.Add("Illustrator Files");
            comboBox1.Items.Add("HTML Files");
            comboBox1.Items.Add("TEXT Files");

        }
        private void default_file()
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;

            if (comboBox1.Text.Contains("Images Files"))
            {
                foreach(string images_extension in images)
                {
                    string[] filePaths = Directory.GetFiles(@textBox1.Text, "*"+images_extension);
                    foreach (string file_path in filePaths)
                    {
                        string[] f = file_path.Split('\\');
                        string last = f[f.Length - 1];
                        move_file(file_path, last);
                    }
                }
            }

            if(comboBox1.Text.Contains("Office Files"))
            {
                foreach (string office_extension in office)
                {
                    string[] filePaths = Directory.GetFiles(@textBox1.Text, "*" + office_extension);
                    foreach (string file_path in filePaths)
                    {
                        string[] f = file_path.Split('\\');
                        string last = f[f.Length - 1];
                        move_file(file_path, last);
                    }
                }
            }


            if (comboBox1.Text.Contains("PDF File"))
            {
                foreach (string pdf_extension in pdf)
                {
                    string[] filePaths = Directory.GetFiles(@textBox1.Text, "*" + pdf_extension);
                    foreach (string file_path in filePaths)
                    {
                        string[] f = file_path.Split('\\');
                        string last = f[f.Length - 1];
                        move_file(file_path, last);
                    }
                }
            }

            if (comboBox1.Text.Contains("Photoshop Files"))
            {
                foreach (string photoshop_extension in photoshop)
                {
                    string[] filePaths = Directory.GetFiles(@textBox1.Text, "*" + photoshop_extension);
                    foreach (string file_path in filePaths)
                    {
                        string[] f = file_path.Split('\\');
                        string last = f[f.Length - 1];
                        move_file(file_path, last);
                    }
                }
            }

            if (comboBox1.Text.Contains("Illustrator Files"))
            {
                foreach (string illustrator_extension in illustrator)
                {
                    string[] filePaths = Directory.GetFiles(@textBox1.Text, "*" + illustrator_extension);
                    foreach (string file_path in filePaths)
                    {
                        string[] f = file_path.Split('\\');
                        string last = f[f.Length - 1];
                        move_file(file_path, last);
                    }
                }
            }

            if (comboBox1.Text.Contains("HTML Files"))
            {
                foreach (string html_extension in html)
                {
                    string[] filePaths = Directory.GetFiles(@textBox1.Text, "*" + html_extension);
                    foreach (string file_path in filePaths)
                    {
                        string[] f = file_path.Split('\\');
                        string last = f[f.Length - 1];
                        move_file(file_path, last);
                    }
                }
            }

            if (comboBox1.Text.Contains("TEXT Files"))
            {
                foreach (string text_extension in text)
                {
                    string[] filePaths = Directory.GetFiles(@textBox1.Text, "*" + text_extension);
                    foreach (string file_path in filePaths)
                    {
                        string[] f = file_path.Split('\\');
                        string last = f[f.Length - 1];
                        move_file(file_path, last);
                    }
                }
            }

            if (comboBox1.Text.Contains("Choose ur extension here dek"))
            {
                MessageBox.Show("Please choose extension !!!!!!!!!!!");
            }
        }
        private void move_file(string path, string name)
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;

            string path2 = @textBox2.Text + @"\" + name;
            try
            {
                if (!File.Exists(path))
                {
                    // This statement ensures that the file is created,  
                    // but the handle is not kept.  
                    using (FileStream fs = File.Create(path)) { }
                }
                // Ensure that the target does not exist.  
                if (File.Exists(path2))
                    File.Delete(path2);
                // Move the file.  
                File.Move(path, path2);
                listBox1.Items.Add(name+ " (✓)");


            }
            catch (Exception e)
            {
                listBox1.Items.Add(name + " (X)");
            }
        }
        private void bingung_guweh()
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;

            if (bunifuRadioButton1.Checked == true)
            {
                if (bunifuTextBox1.Text.Contains("example"))
                {
                    MessageBox.Show("Please input your custom extension !!!!!!!!!!");
                }
                else
                {
                    Thread fa = new Thread(custom_get_file);
                    fa.Start();
                }
            }
            if(bunifuRadioButton2.Checked == true)
            {
                Thread fa = new Thread(default_file);
                fa.Start();

            }
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bingung_guweh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;

            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                textBox1.Text = folderPath;
                // ...
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;

            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                textBox2.Text = folderPath;
                // ...
            }
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
   (
       int nLeftRect,     // x-coordinate of upper-left corner
       int nTopRect,      // y-coordinate of upper-left corner
       int nRightRect,    // x-coordinate of lower-right corner
       int nBottomRect,   // y-coordinate of lower-right corner
       int nWidthEllipse, // height of ellipse
       int nHeightEllipse // width of ellipse
   );


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;

            profile form2 = new profile();
            form2.Show();
        }
    }
}
