using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazLab
{
    public static class Maze
    {
        public static Rectangle Bounds;
        public struct MazeNode
        {
            public int up;
            public int down;
            public int right;
            public int left;
        }

        public struct Node
        {
            public int x;
            public int y;
        }

        public static void initNeighbor(Graphics gr, Pen pen)
        {
            int matrisSize = Control.inputMatrisSize;
            double sayi = Convert.ToDouble(Control.inputMatrisSize);
            int mazeSize = Int32.Parse(Math.Sqrt(sayi).ToString());
            MazeNode[] neighbor = new MazeNode[matrisSize];

            Node index = new Node();
            index.x = 20;
            index.y = 0;
            for (int i = 0; i < matrisSize; i++)
            {
                List<int> komsu = new List<int>();
                Node current = new Node();
                current.x = i / mazeSize;
                current.y = i % mazeSize;
                for (int y = 0; y < matrisSize; y++)
                {
                    if (Control.rMatris[i, y] != -1)
                    {
                        komsu.Add(y);
                    }
                }
                Node[] neigh = new Node[komsu.Count];
                int z = 0;
                foreach (int key in komsu)
                {
                    neigh[z].x = key / mazeSize;
                    neigh[z].y = key % mazeSize;
                    z++;
                }
                for (int k = 0; k < z; k++)
                {
                    if (current.x - 1 == neigh[k].x && current.y == neigh[k].y && neighbor[i].up != 1)
                        neighbor[i].up = 1;
                    else if (current.x == neigh[k].x && current.y - 1 == neigh[k].y && neighbor[i].left != 1)
                        neighbor[i].left = 1;
                    else if (current.x + 1 == neigh[k].x && current.y == neigh[k].y && neighbor[i].down != 1)
                        neighbor[i].down = 1;
                    else if (current.x == neigh[k].x && current.y + 1 == neigh[k].y && neighbor[i].right != 1)
                        neighbor[i].right = 1;
                    else
                        continue;
                }
                if (i % mazeSize == 0)
                {
                    index.y += 40;
                    index.x = 40;
                }
                else
                {
                    index.x += 40;
                }
                DrawWall(gr, pen, neighbor[i], index, i);
            }
        }


        public static void DrawWall(Graphics gr, Pen pen, MazeNode side, Node index, int i)
        {
            if (side.up == 0)
            {
                gr.DrawLine(pen, index.x, index.y,
                    index.x + 40, index.y);
            }
            if (side.down == 0)
            {
                gr.DrawLine(pen, index.x, index.y + 40,
                    index.x + 40, index.y + 40);
            }
            if (side.left == 0)
            {
                gr.DrawLine(pen, index.x, index.y,
                    index.x, index.y + 40);
            }
            if (side.right == 0)
            {
                gr.DrawLine(pen, index.x + 40, index.y,
                    index.x + 40, index.y + 40);
            }
            int z = 0;
            foreach (int key in Control.pathFinder)
            {
                if (i == key && z == 0)
                {
                    gr.FillRectangle(Brushes.Red, index.x + 10, index.y + 10, 20, 20);
                }
                else if (i == key && z == Control.pathFinder.Count -1)
                {
                    gr.FillRectangle(Brushes.Green, index.x + 10, index.y + 10, 20, 20);
                }
                else if (i == key && z != 0 && z != Control.pathFinder.Count)
                {
                    gr.FillRectangle(Brushes.Blue, index.x + 10, index.y + 10, 20, 20);
                }
                else
                {

                }
                z++;
            }
        }
    }
}
