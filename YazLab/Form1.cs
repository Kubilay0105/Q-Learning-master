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

namespace YazLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.RestoreDirectory = true;
            file.Filter = "Notepad Dosyası | *.txt";
            file.Title = "Lütfen İnput Dosyasını Seçiniz.";
            if (file.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = file.FileName;
                Control.filePath = file.FileName;
                Control.fileName = file.SafeFileName;

                FileStream fs = new FileStream(file.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                string line;
                while ((line = sw.ReadLine()) != null)
                {
                    Control.neighbor.Add(line);
                    Control.inputMatrisSize++;
                }
                sw.Close();
                fs.Close();

            }
            Control.exit = Int32.Parse(exitText.Text);
            Control.start = Int32.Parse(startText.Text);
            Control.iterasyon = Int32.Parse(iteText.Text);
            R_Matris rmatris = new R_Matris();
            rmatris.Show();
            Q_Matris qmatris = new Q_Matris();
            qmatris.Show();
            PathShow pathShow = new PathShow();
            pathShow.Show();
        }

    }
}
