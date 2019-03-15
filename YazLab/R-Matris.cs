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
    public partial class R_Matris : Form
    {
        public R_Matris()
        {
            InitializeComponent();
        }

        private void R_Matris_Load(object sender, EventArgs e)
        {
            Control.CreateRMatris();
            Control.initRDataTable();
            dataGridView1.DataSource = Control.rtable;

            String filePath = "C:\\Users\\Ali Erdem\\Desktop\\Output\\rMatris.txt";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for(int i = 0; i<Control.inputMatrisSize; i++)
            {
                String Row = "";
                for(int y = 0; y<Control.inputMatrisSize; y++)
                {
                    Row += "[";
                    Row += Control.rMatris[i, y];
                    Row += "]";
                }
                sw.WriteLine(Row);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
