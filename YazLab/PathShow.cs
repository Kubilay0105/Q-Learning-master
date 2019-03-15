using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazLab
{
    public partial class PathShow : Form
    {
        public PathShow()
        {
            InitializeComponent();
            String filePath = "C:\\Users\\Kubilay\\Desktop\\Output\\outPath.txt";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            int i = 1;
            foreach (int key in Control.pathFinder)
            {
                String Row = i + ". Yol = ";
                Row += key.ToString();
                sw.WriteLine(Row);
                i++;
            }
            sw.Flush();
            sw.Close();
            fs.Close();
            Bitmap bm = new Bitmap(
                            picMaze.ClientSize.Width,
                            picMaze.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                double sayi = Convert.ToDouble(Control.inputMatrisSize);
                int mazeSize = Int32.Parse(Math.Sqrt(sayi).ToString());
                Maze.initNeighbor(gr, Pens.Black);
            }
            picMaze.Image = bm;
        }

        private void picMaze_Click(object sender, EventArgs e)
        {

        }

        private void PathShow_Load(object sender, EventArgs e)
        {

        }
    }
}
