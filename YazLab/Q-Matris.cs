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
    public partial class Q_Matris : Form
    {
        public Q_Matris()
        {
            InitializeComponent();
        }

        private void Q_Matris_Load(object sender, EventArgs e)
        {
            Control.InitQMatris();
            Control.CreateQMatris();
            Control.initQDataTable();
            Control.FindPath();
            dataGridView2.DataSource = Control.qtable;

            String filePath = "C:\\Users\\Kubilay\\Desktop\\Output\\qMatris.txt";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < Control.inputMatrisSize; i++)
            {
                String Row = "";
                for (int y = 0; y < Control.inputMatrisSize; y++)
                {
                    Row += "[";
                    Row += Control.qMatris[i, y];
                    Row += "]";
                }
                sw.WriteLine(Row);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
