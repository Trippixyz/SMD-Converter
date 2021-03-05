using System;
using System.IO;
using System.Windows.Forms;

namespace SMD_Converter_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 50;


            string credits = "SMD-Converter\nMade by Trippixyz! Ported to Windows Forms by Lord-Giganticus.";
            MessageBox.Show(credits);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            OpenFileDialog OFD1 = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Title = "Browse for a .smd file",
                DefaultExt = "smd",
                Filter = "smd files (*.smd)|*.smd|All files (*.*)|*.*",
                FilterIndex = 0,
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            };
            OFD1.ShowDialog();
            string filename = OFD1.FileName;
            if (String.IsNullOrEmpty(filename) == true) {
                MessageBox.Show("Error:\n(001) File does not exist or was deleted!!!\nPress ok to close the program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            string filelocation = Path.GetDirectoryName(filename);
            if (Directory.Exists(filelocation))
            {
                progressBar1.PerformStep();
                string name = Path.GetFileName(filename);
                MessageBox.Show("\nFilename:\n" + name);
                MessageBox.Show("Converting...");
                filelocation = Path.Combine(filelocation, "animation");
                string filecontent = File.ReadAllText(filename);
                string toolname = "Blender";
                if (filecontent.Contains(","))
                {
                    filecontent = filecontent.Replace(",", ".");   //Toolbox Animation Converts to Blender Animation
                    toolname = "Blender";
                }
                else
                {
                    filecontent = filecontent.Replace(".", ",");   //Blender Animation Converts to Toolbox Animation
                    toolname = "Toolbox";
                }
                if (!File.Exists(filelocation))
                {
                    Directory.CreateDirectory(filelocation);
                    File.WriteAllText(filelocation + "\\" + name, filecontent);
                }
                MessageBox.Show("Succesfully converted the SMD animation to work with " + toolname);
                MessageBox.Show("\nExport Path:\n"+ filelocation + "\\" + name);
                progressBar1.PerformStep();
                return;
            } else
            {
                MessageBox.Show("Error:\n(001) Invalid Path!!!\nPress ok to close the program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
    }
}
