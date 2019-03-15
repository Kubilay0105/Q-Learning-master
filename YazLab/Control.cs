using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace YazLab
{
    public static class Control
    {
        public static string filePath { get; set; }
        public static string fileName { get; set; }
        public static List<string> neighbor = new List<string>();
        public static int inputMatrisSize;
        public static int iterasyon;
        public static int start;
        public static int exit;
        public static double gamma = 0.8;
        public static int control = 0;
        public static int[,] rMatris;
        public static int[,] qMatris;
        public static List<int> pathFinder;
        public static DataTable rtable;
        public static DataTable qtable;


        public static void CreateRMatris()
        {
            rMatris = new int[inputMatrisSize, inputMatrisSize];
            for (int k = 0; k < inputMatrisSize; k++)
                for (int l = 0; l < inputMatrisSize; l++)
                    rMatris[k, l] = -1;
            int i = 0;
            foreach (string value in neighbor)
            {
                if (value.Length > 1)
                {
                    string[] keys = value.Split(',');
                    foreach (string key in keys)
                    {
                        for (int y = 0; y < inputMatrisSize; y++)
                        {
                            if (y.ToString() == key)
                            {
                                rMatris[i, y] = 0;
                            }
                            else
                            {
                                if (rMatris[i, y] != 0)
                                {
                                    rMatris[i, y] = -1;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int y = 0; y < inputMatrisSize; y++)
                    {
                        if (y.ToString() == value)
                        {
                            rMatris[i, y] = 0;
                        }
                        else
                        {
                            if (rMatris[i, y] != 0)
                            {
                                rMatris[i, y] = -1;
                            }
                        }
                    }
                }
                i++;
            }

            for (int y = 0; y < inputMatrisSize; y++)
            {
                if (rMatris[y, exit] == 0)
                {
                    rMatris[y, exit] = 100;
                }
            }
            rMatris[exit, exit] = 100;
        }

        public static void InitQMatris()
        {
            qMatris = new int[inputMatrisSize, inputMatrisSize];
            for (int i = 0; i < inputMatrisSize; i++)
                for (int y = 0; y < inputMatrisSize; y++)
                    qMatris[i, y] = 0;
        }

        public static void CreateQMatris()
        {
            for (int z = 0; z < iterasyon; z++)
            {
                for (int i = 0; i < inputMatrisSize; i++)
                {
                    for (int y = 0; y < inputMatrisSize; y++)
                    {
                        int max = 0;
                        for (int k = 0; k < inputMatrisSize; k++)
                        {
                            if (rMatris[y, k] != -1 && qMatris[y, k] >= max)
                            {
                                max = qMatris[y, k];
                            }
                        }
                        if (rMatris[i, y] == -1)
                        {
                            qMatris[i, y] = 0;
                        }
                        else
                        {
                            qMatris[i, y] = (int)(rMatris[i, y] + (gamma * max));
                        }
                    }
                }
            }
        }

        public static void initQDataTable()
        {
            qtable = new DataTable();

            for (int i = 0; i < inputMatrisSize; i++)
            {
                qtable.Columns.Add();
            }
            for (int i = 0; i < inputMatrisSize; i++)
            {
                DataRow row = qtable.NewRow();
                for (int y = 0; y < inputMatrisSize; y++)
                {
                    row[y] = qMatris[i, y];
                }
                qtable.Rows.Add(row);
            }
        }

        public static void initRDataTable()
        {
            rtable = new DataTable();

            for (int i = 0; i < inputMatrisSize; i++)
            {
                rtable.Columns.Add();
            }
            for (int i = 0; i < inputMatrisSize; i++)
            {
                DataRow row = rtable.NewRow();
                for (int y = 0; y < inputMatrisSize; y++)
                {
                    row[y] = rMatris[i, y];
                }
                rtable.Rows.Add(row);
            }
        }

        public static void FindPath()
        {
            pathFinder = new List<int>();
            pathFinder.Add(start);
            for (int i = start; i < inputMatrisSize;)
            {
                int max = 0;
                int index = 0;
                for (int y = 0; y < inputMatrisSize; y++)
                {
                    if(qMatris[i,y] > max)
                    {
                        max = qMatris[i, y];
                        index = y;
                    }
                }
                pathFinder.Add(index);
                if(index == exit)
                {
                    break;
                }
                i = index;
            }

        }
    }
}
