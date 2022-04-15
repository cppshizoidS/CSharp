using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace SortComparison
{
    public partial class frmMain : Form
    {
        Graphics g1;
        Graphics g2;
        ArrayList array1;
        ArrayList array2;
        Bitmap bmpsave1;
        Bitmap bmpsave2;

        static Random rng = new Random();

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Randomize(IList list)
        {

            for (int i = list.Count - 1; i > 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                if (swapIndex != i)
                {
                    object tmp = list[swapIndex];
                    list[swapIndex] = list[i];
                    list[i] = tmp;
                }
            }
        }

        private void DrawSamples()
        {
            g1.Clear(Color.White);
            g2.Clear(Color.White);

            for (int i = 0; i < array1.Count; i++)
            {
                int x = (int)(((double)pnlSort1.Width / array1.Count) * i);

                Pen pen = new Pen(Color.Black);
                g1.DrawLine(pen, new Point(x, pnlSort1.Height), new Point(x, (int)(pnlSort1.Height - (int)array1[i])));
                g2.DrawLine(pen, new Point(x, pnlSort1.Height), new Point(x, (int)(pnlSort2.Height - (int)array1[i])));
            }

        }

        private void cmdShuffle_Click(object sender, EventArgs e)
        {
            bmpsave1 = new Bitmap(pnlSort1.Width, pnlSort1.Height);
            g1 = Graphics.FromImage(bmpsave1);

            bmpsave2 = new Bitmap(pnlSort2.Width, pnlSort2.Height);
            g2 = Graphics.FromImage(bmpsave2);

            pnlSort1.Image = bmpsave1;
            pnlSort2.Image = bmpsave2;
            

            array1 = new ArrayList(tbSamples.Value);
            array2 = new ArrayList(tbSamples.Value);
            for (int i = 0; i < array1.Capacity; i++)
            {
                int y = (int)((double)i / array1.Capacity * pnlSort1.Height);
                array1.Add(y);
            }
            Randomize(array1);
            array2 = (ArrayList)array1.Clone();
            DrawSamples();
        }

        private void RedrawItem(int index1, Graphics g, IList a)
        {
            int x1 = (int)(((double)pnlSort1.Width / array1.Count) * index1);
            g.DrawLine(new Pen(Color.White), new Point(x1, 0), new Point(x1, pnlSort1.Height));
            g.DrawLine(new Pen(Color.Black), new Point(x1, pnlSort1.Height), new Point(x1, (int)(pnlSort1.Height - (int)a[index1])));
        }

        private void cmdSort_Click(object sender, EventArgs e)
        {
            int speed = 100 - tbSpeed.Value;

            string alg1="";
            string alg2="";

            if(cboAlg1.SelectedItem!=null)
                alg1 = cboAlg1.SelectedItem.ToString();

            if(cboAlg2.SelectedItem!=null)
                alg2 = cboAlg2.SelectedItem.ToString();

            SortAlgorithm sa = new SortAlgorithm(array1, pnlSort1, true, txtOutputFolder.Text, speed, alg1);
            SortAlgorithm sa2 = new SortAlgorithm(array2, pnlSort2, true, txtOutputFolder.Text, speed, alg2);
            
            ThreadStart ts = delegate()
            {
                try
                {
                    switch (alg1)
                    {
                        case "BiDirectional Bubble Sort":
                            sa.BiDerectionalBubbleSort(array1);
                            break;
                        case "Bubble Sort":
                            sa.BubbleSort(array1);
                            break;
                        case "Bucket Sort":
                            sa.BucketSort(array1);
                            break;
                        case "Comb Sort":
                            sa.CombSort(array1);
                            break;
                        case "Cycle Sort":
                            sa.CycleSort(array1);
                            break;
                        case "Gnome Sort":
                            sa.GnomeSort(array1);
                            break;
                        case "Heap Sort":
                            sa.HeapSort(array1);
                            break;
                        case "Insertion Sort":
                            sa.InsertionSort(array1);
                            break;
                        case "Merge Sort":
                            sa.MergeSort(array1, 0, array1.Count - 1);
                            break;
                        case "Odd-Even Sort":
                            sa.OddEvenSort(array1);
                            break;
                        case "Quick Sort":
                            sa.QuickSort(array1, 0, array1.Count - 1);
                            break;
                        case "Quick Sort with Bubble Sort":
                            sa.QuickSortWithBubbleSort(array1, 0, array1.Count - 1);
                            break;
                        case "Selection Sort":
                            sa.SelectionSort(array1);
                            break;
                        case "Shell Sort":
                            sa.ShellSort(array1);
                            break;
                        case "Pigeon Hole Sort":
                            sa.PigeonHoleSort(array1);
                            break;
                    }
                    if(chkAnimation.Checked)
                        sa.CreateAnimation();
                    MessageBox.Show("Finish");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            };

            ThreadStart ts2 = delegate()
            {
                try
                {
                    switch (alg2)
                    {
                        case "BiDirectional Bubble Sort":
                            sa2.BiDerectionalBubbleSort(array2);
                            break;
                        case "Bubble Sort":
                            sa2.BubbleSort(array2);
                            break;
                        case "Bucket Sort":
                            sa2.BucketSort(array2);
                            break;
                        case "Comb Sort":
                            sa2.CombSort(array2);
                            break;
                        case "Cycle Sort":
                            sa2.CycleSort(array2);
                            break;
                        case "Gnome Sort":
                            sa2.GnomeSort(array2);
                            break;
                        case "Heap Sort":
                            sa2.HeapSort(array2);
                            break;
                        case "Insertion Sort":
                            sa2.InsertionSort(array2);
                            break;
                        case "Merge Sort":
                            sa2.MergeSort(array2, 0, array2.Count - 1);
                            break;
                        case "Odd-Even Sort":
                            sa2.OddEvenSort(array2);
                            break;
                        case "Quick Sort":
                            sa2.QuickSort(array2, 0, array2.Count - 1);
                            break;
                        case "Quick Sort with Bubble Sort":
                            sa2.QuickSortWithBubbleSort(array2, 0, array2.Count - 1);
                            break;
                        case "Selection Sort":
                            sa2.SelectionSort(array2);
                            break;
                        case "Shell Sort":
                            sa2.ShellSort(array2);
                            break;
                        case "Pigeon Hole Sort":
                            sa2.PigeonHoleSort(array2);
                            break;
                    }
                    if (chkAnimation.Checked)
                        sa2.CreateAnimation();
                    MessageBox.Show("Finish");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            };

            if (alg1 != "")
            {
                Thread t = new Thread(ts);
                t.Start();
            }
            if (alg2 != "")
            {
                Thread t2 = new Thread(ts2);
                t2.Start();
            }
        }        
        
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtOutputFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }
      
    }
}
