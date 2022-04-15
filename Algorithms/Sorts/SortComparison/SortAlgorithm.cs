using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Gif.Components;
using System.Threading;

namespace SortComparison
{
    public class SortAlgorithm
    {

        ArrayList arrayToSort;
        Graphics g;
        Bitmap bmpsave;
        PictureBox pnlSamples;
        bool savePicture;
        string outputFolder;
        string outputFile;
        int imgCount;
        int speed;

        public SortAlgorithm(ArrayList list, PictureBox pic, bool sp, string of, int s, string outFile)
        {
            imgCount = 0;
            arrayToSort = list;
            pnlSamples = pic;
            savePicture = sp;
            outputFolder = of;
            speed = s;
            outputFile = outFile;

            bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
            g = Graphics.FromImage(bmpsave);

            pnlSamples.Image = bmpsave;
            DrawSamples();

        }

        public IList BubbleSort(IList arrayToSort)
        {
            int n = arrayToSort.Count - 1;
            for (int i = 0; i < n; i++)
            {

                for (int j = n; j > i; j--)
                {
                    if (((IComparable)arrayToSort[j - 1]).CompareTo(arrayToSort[j]) > 0)
                    {
                        object temp = arrayToSort[j - 1];
                        arrayToSort[j - 1] = arrayToSort[j];
                        arrayToSort[j] = temp;
                        RedrawItem(j);
                        RedrawItem(j - 1);
                        RefreshPanel(pnlSamples);
                        if (savePicture)
                            SavePicture();
                        
                    }
                    Thread.Sleep(speed);
                }
            }
            return arrayToSort;
        }

        public IList BiDerectionalBubbleSort(IList arrayToSort)
        {

            int limit = arrayToSort.Count;
            int st = -1;
            bool swapped = false;
            do
            {
                swapped = false;
                st++;
                limit--;

                for (int j = st; j < limit; j++)
                {
                    if (((IComparable)arrayToSort[j]).CompareTo(arrayToSort[j + 1]) > 0)
                    {
                        object temp = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = temp;
                        swapped = true;
                        RedrawItem(j);
                        RedrawItem(j + 1);
                        RefreshPanel(pnlSamples);
                        if (savePicture)
                            SavePicture();
                        
                    }
                    Thread.Sleep(speed);
                    
                }
                for (int j = limit - 1; j >= st; j--)
                {
                    if (((IComparable)arrayToSort[j]).CompareTo(arrayToSort[j + 1]) > 0)
                    {
                        object temp = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = temp;
                        swapped = true;
                        RedrawItem(j);
                        RedrawItem(j + 1);

                        RefreshPanel(pnlSamples);
                        if (savePicture)
                            SavePicture();
                        
                    }
                    Thread.Sleep(speed);
                    
                }

            } while (st < limit && swapped);

            return arrayToSort;
        }

        public IList CombSort(IList arrayToSort)
        {
            int gap = arrayToSort.Count;
            int swaps = 0;

            do
            {
                gap = (int)(gap / 1.247330950103979);
                if (gap < 1)
                {
                    gap = 1;
                }
                int i = 0;
                swaps = 0;

                do
                {
                    if (((IComparable)arrayToSort[i]).CompareTo(arrayToSort[i + gap]) > 0)
                    {
                        object temp = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[i + gap];
                        arrayToSort[i + gap] = temp;
                        RedrawItem(i);
                        RedrawItem(i + gap);
                        RefreshPanel(pnlSamples);
                        if (savePicture)
                            SavePicture();
                        swaps = 1;
                    }
                    i++;
                    Thread.Sleep(speed);
                } while (!(i + gap >= arrayToSort.Count));

            } while (!(gap == 1 && swaps == 0));

            return arrayToSort;
        }

        public IList InsertionSort(IList arrayToSort)
        {
            for (int i = 1; i < arrayToSort.Count; i++)
            {
                object val = arrayToSort[i];
                int j = i - 1;
                bool done = false;
                do
                {
                    if (((IComparable)arrayToSort[j]).CompareTo(val) > 0)
                    {
                        arrayToSort[j + 1] = arrayToSort[j];
                        RedrawItem(j + 1);
                        RefreshPanel(pnlSamples);
                        if (savePicture)
                            SavePicture();
                        j--;
                        if (j < 0)
                        {
                            done = true;
                        }
                    }
                    else
                    {
                        done = true;
                    }
                    Thread.Sleep(speed);
                } while (!done);
                arrayToSort[j + 1] = val;

                RedrawItem(j + 1);
                RefreshPanel(pnlSamples);
                if (savePicture)
                    SavePicture();
                Thread.Sleep(speed);
            }
            return arrayToSort;
        }

        public IList SelectionSort(IList arrayToSort)
        {
            int min;
            for (int i = 0; i < arrayToSort.Count; i++)
            {

                min = i;
                for (int j = i + 1; j < arrayToSort.Count; j++)
                {
                    if (((IComparable)arrayToSort[j]).CompareTo(arrayToSort[min]) < 0)
                    {
                        min = j;
                    }
                    Thread.Sleep(speed);
                }
                object temp = arrayToSort[i];
                arrayToSort[i] = arrayToSort[min];
                arrayToSort[min] = temp;

                RedrawItem(i);
                RedrawItem(min);
                RefreshPanel(pnlSamples);
                if (savePicture)
                    SavePicture();

                Thread.Sleep(speed);
            }

            return arrayToSort;
        }

        public IList CountingSort(IList arrayToSort)
        {
            object min;
            object max;

            min = max = arrayToSort[0];

            for (int i = 0; i < arrayToSort.Count; i++)
            {
                if (((IComparable)arrayToSort[i]).CompareTo(min) < 0)
                {
                    min = arrayToSort[i];
                }
                else if (((IComparable)arrayToSort[i]).CompareTo(max) > 0)
                {
                    max = arrayToSort[i];
                }
            }

            int range = (int)max - (int)min + 1;

            int[] count = new int[range * sizeof(int)];

            for (int i = 0; i < range; i++)
            {
                count[i] = 0;
            }

            for (int i = 0; i < arrayToSort.Count; i++)
            {
                count[(int)arrayToSort[i] - (int)min]++;
            }
            int z = 0;
            for (int i = (int)min; i < arrayToSort.Count; i++)
            {
                for (int j = 0; j < count[i - (int)min]; j++)
                {
                    arrayToSort[z++] = i;
                    RedrawItem(z - 1);
                    RefreshPanel(pnlSamples);
                    if (savePicture)
                        SavePicture();
                }
            }

            return arrayToSort;
        }

        public IList ShellSort(IList arrayToSort)
        {
            int i, j, increment;
            object temp;

            increment = arrayToSort.Count / 2;

            while (increment > 0)
            {
                for (i = 0; i < arrayToSort.Count; i++)
                {
                    j = i;
                    temp = arrayToSort[i];
                    while ((j >= increment) && (((IComparable)arrayToSort[j - increment]).CompareTo(temp) > 0))
                    {
                        arrayToSort[j] = arrayToSort[j - increment];
                        RedrawItem(j);
                        RefreshPanel(pnlSamples);
                        if (savePicture)
                            SavePicture();
                        j = j - increment;
                        Thread.Sleep(speed);
                    }
                    arrayToSort[j] = temp;
                    RedrawItem(j);
                    RefreshPanel(pnlSamples);
                    if (savePicture)
                        SavePicture();
                    Thread.Sleep(speed);
                }
                if (increment == 2)
                    increment = 1;
                else
                    increment = increment * 5 / 11;
            }

            return arrayToSort;
        }

        public IList HeapSort(IList list)
        {
            for (int i = (list.Count - 1) / 2; i >= 0; i--)
            {
                Adjust(list, i, list.Count - 1);
                Thread.Sleep(speed);
            }

            for (int i = list.Count - 1; i >= 1; i--)
            {
                object Temp = list[0];
                list[0] = list[i];
                list[i] = Temp;
                RedrawItem(0);
                RedrawItem(i);
                RefreshPanel(pnlSamples);
                if (savePicture)
                    SavePicture();
                Adjust(list, 0, i - 1);
                Thread.Sleep(speed);
            }

            return list;
        }

        public void Adjust(IList list, int i, int m)
        {
            object Temp = list[i];
            int j = i * 2 + 1;
            while (j <= m)
            {
                if (j < m)
                    if (((IComparable)list[j]).CompareTo(list[j + 1]) < 0)
                        j = j + 1;

                if (((IComparable)Temp).CompareTo(list[j]) < 0)
                {
                    list[i] = list[j];
                    RedrawItem(i);
                    RefreshPanel(pnlSamples);
                    if (savePicture)
                        SavePicture();
                    i = j;
                    j = 2 * i + 1;
                }
                else
                {
                    j = m + 1;
                }
                Thread.Sleep(speed);
            }
            list[i] = Temp;
            RedrawItem(i);
            RefreshPanel(pnlSamples);
            if (savePicture)
                SavePicture();
            Thread.Sleep(speed);
        }

        public IList MergeSort(IList a, int low, int height)
        {
            int l = low;
            int h = height;

            if (l >= h)
            {
                return a;
            }

            int mid = (l + h) / 2;
            Thread.Sleep(speed);
            MergeSort(a, l, mid);
            MergeSort(a, mid + 1, h);

            int end_lo = mid;
            int start_hi = mid + 1;
            while ((l <= end_lo) && (start_hi <= h))
            {
                if (((IComparable)a[l]).CompareTo(a[start_hi]) < 0)
                {
                    l++;
                }
                else
                {
                    object temp = a[start_hi];
                    for (int k = start_hi - 1; k >= l; k--)
                    {
                        a[k + 1] = a[k];
                        RedrawItem(k + 1);
                        RefreshPanel(pnlSamples);
                        if (savePicture)
                            SavePicture();
                        Thread.Sleep(speed);
                    }
                    a[l] = temp;
                    RedrawItem(l);
                    RefreshPanel(pnlSamples);
                    if (savePicture)
                        SavePicture();
                    l++;
                    end_lo++;
                    start_hi++;
                }
            }
            return a;
        }

        public IList QuickSort(IList a, int left, int right)
        {
            int i = left;
            int j = right;
            double pivotValue = ((left + right) / 2);
            int x = (int)a[int.Parse(pivotValue.ToString())];
            Thread.Sleep(speed);

            while (i <= j)
            {
                while (((IComparable)a[i]).CompareTo(x) < 0)
                {
                    i++;
                }
                while (((IComparable)x).CompareTo(a[j]) < 0)
                {
                    j--;
                }
                if (i <= j)
                {
                    object temp = a[i];
                    a[i] = a[j];
                    RedrawItem(i);
                    i++;
                    a[j] = temp;
                    RedrawItem(j);
                    j--;
                    RefreshPanel(pnlSamples);
                    if (savePicture)
                        SavePicture();
                }
                Thread.Sleep(speed);
            }
            if (left < j)
            {
                QuickSort(a, left, j);
            }
            if (i < right)
            {
                QuickSort(a, i, right);
            }
            return a;
        }

public IList GnomeSort(IList arrayToSort)
{
    int pos = 1;
    while (pos < arrayToSort.Count)
    {
        if (((IComparable)arrayToSort[pos]).CompareTo(arrayToSort[pos - 1]) >= 0)
        {
            pos++;
        }
        else
        {
            object temp = arrayToSort[pos];
            arrayToSort[pos] = arrayToSort[pos - 1];
            RedrawItem(pos);

            arrayToSort[pos - 1] = temp;
            RedrawItem(pos - 1);
            RefreshPanel(pnlSamples);
            if (savePicture)
                SavePicture();
            if (pos > 1)
            {
                pos--;
            }
        }
        Thread.Sleep(speed);
    }
    return arrayToSort;
}

        public IList BubbleSort(IList arrayToSort, int left, int right)
        {

            for (int i = left; i < right; i++)
            {
                for (int j = right; j > i; j--)
                {
                    if (((IComparable)arrayToSort[j - 1]).CompareTo(arrayToSort[j]) > 0)
                    {
                        object temp = arrayToSort[j - 1];
                        arrayToSort[j - 1] = arrayToSort[j];
                        RedrawItem(j - 1);
                        arrayToSort[j] = temp;
                        RedrawItem(j);
                        RefreshPanel(pnlSamples);
                        if (savePicture)
                            SavePicture();
                        Thread.Sleep(speed);
                    }
                
                }
                
            }

            return arrayToSort;
        }

        public IList QuickSortWithBubbleSort(IList a, int left, int right)
        {
            int i = left;
            int j = right;

            Thread.Sleep(speed);
            if (right - left <= 6)
            {
                BubbleSort(a, left, right);
                return a;
            }

            double pivotValue = ((left + right) / 2);
            int x = (int)a[int.Parse(pivotValue.ToString())];

            a[(left + right) / 2] = a[right];
            a[right] = x;
            RedrawItem(right);
            RefreshPanel(pnlSamples);
            if (savePicture)
                SavePicture();

            while (i <= j)
            {
                while (((IComparable)a[i]).CompareTo(x) < 0)
                {
                    i++;
                }
                while (((IComparable)x).CompareTo(a[j]) < 0)
                {
                    j--;

                }

                if (i <= j)
                {
                    object temp = a[i];
                    a[i++] = a[j];
                    RedrawItem(i - 1);
                    a[j--] = temp;
                    RedrawItem(j + 1);
                    RefreshPanel(pnlSamples);
                    if (savePicture)
                        SavePicture();
                }
                Thread.Sleep(speed);
            }
            if (left < j)
            {
                QuickSortWithBubbleSort(a, left, j);
            }
            if (i < right)
            {
                QuickSortWithBubbleSort(a, i, right);
            }

            return a;
        }

        public IList BucketSort(IList arrayToSort)
        {
            if (arrayToSort == null || arrayToSort.Count == 0) return arrayToSort;

            object max = arrayToSort[0];
            object min = arrayToSort[0];


            for (int i = 0; i < arrayToSort.Count; i++)
            {

                if (((IComparable)arrayToSort[i]).CompareTo(max) > 0)
                {
                    max = arrayToSort[i];
                }

                if (((IComparable)arrayToSort[i]).CompareTo(min) < 0)
                {
                    min = arrayToSort[i];
                }
                Thread.Sleep(speed);
            }
            ArrayList[] holder = new ArrayList[(int)max - (int)min + 1];

            for (int i = 0; i < holder.Length; i++)
            {
                holder[i] = new ArrayList();
            }

            for (int i = 0; i < arrayToSort.Count; i++)
            {
                holder[(int)arrayToSort[i] - (int)min].Add(arrayToSort[i]);
            }

            int k = 0;

            for (int i = 0; i < holder.Length; i++)
            {
                if (holder[i].Count > 0)
                {
                    for (int j = 0; j < holder[i].Count; j++)
                    {
                        arrayToSort[k] = holder[i][j];
                        RedrawItem(k);
                        RefreshPanel(pnlSamples);
                        if (savePicture)
                            SavePicture();
                        k++;
                        Thread.Sleep(speed);
                    }
                }
            }

            return arrayToSort;
        }

        public IList CycleSort(IList arrayToSort)
        {
            try
            {
                int writes = 0;
                for (int cycleStart = 0; cycleStart < arrayToSort.Count; cycleStart++)
                {
                    object item = arrayToSort[cycleStart];
                    int pos = cycleStart;

                    do
                    {
                        int to = 0;
                        for (int i = 0; i < arrayToSort.Count; i++)
                        {
                            if (i != cycleStart && ((IComparable)arrayToSort[i]).CompareTo(item) < 0)
                            {
                                to++;
                            }
                            
                        }
                        if (pos != to)
                        {
                            while (pos != to && ((IComparable)item).CompareTo(arrayToSort[to]) == 0)
                            {
                                to++;
                                //Thread.Sleep(100);
                            }

                            object temp = arrayToSort[to];
                            lock (this)
                            {
                                arrayToSort[to] = item;
                            }
                            RedrawItem(to);
                            item = temp;
                            RedrawItem(cycleStart);
                            //Thread.Sleep(100);
                            RefreshPanel(pnlSamples);
                            if (savePicture)
                                SavePicture();
                            
                            writes++;
                            pos = to;
                        }
                        Thread.Sleep(speed);
                        
                    } while (cycleStart != pos);
                }
            }
            catch (Exception err)
            {
                string errr = err.Message;
            }
            return arrayToSort;
        }

        public IList OddEvenSort(IList arrayToSort)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (var i = 1; i < arrayToSort.Count - 1; i += 2)
                {
                    if (((IComparable)arrayToSort[i]).CompareTo(arrayToSort[i + 1]) > 0)
                    {
                        object temp = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[i + 1];
                        RedrawItem(i);
                        arrayToSort[i + 1] = temp;
                        RedrawItem(i + 1);
                        RefreshPanel(pnlSamples);
                        if (savePicture)
                            SavePicture();
                        sorted = false;
                    }
                    Thread.Sleep(speed);
                }

                for (var i = 0; i < arrayToSort.Count - 1; i += 2)
                {
                    if (((IComparable)arrayToSort[i]).CompareTo(arrayToSort[i + 1]) > 0)
                    {
                        object temp = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[i + 1];
                        arrayToSort[i + 1] = temp;
                        RedrawItem(i);
                        RedrawItem(i + 1);
                        RefreshPanel(pnlSamples);
                        if (savePicture)
                            SavePicture();
                        sorted = false;
                    }
                    Thread.Sleep(speed);
                }


            }
            return arrayToSort;
        }

public IList PigeonHoleSort(IList list)
{
    object min = list[0], max = list[0];
    foreach (object x in list)
    {
        if (((IComparable)min).CompareTo(x) > 0)
        {
            min = x;
        }
        if (((IComparable)max).CompareTo(x) < 0)
        {
            max = x;
        }
        Thread.Sleep(speed);
    }

    int size = (int)max - (int)min + 1;

    int[] holes = new int[size];

    foreach (int x in list)
        holes[x - (int)min]++;

    int i = 0;
    for (int count = 0; count < size; count++)
        while (holes[count]-- > 0)
        {

            list[i] = count + (int)min;
            RedrawItem(i);
            i++;
            RefreshPanel(pnlSamples);
            Thread.Sleep(speed);
        }
    return list;
}

        private void RedrawItem(int index1)
        {
            lock (this)
            {
                int x1 = (int)(((double)pnlSamples.Width / arrayToSort.Count) * index1);
                g.DrawLine(new Pen(Color.White), new Point(x1, 0), new Point(x1, pnlSamples.Height));
                g.DrawLine(new Pen(Color.Black), new Point(x1, pnlSamples.Height), new Point(x1, (int)(pnlSamples.Height - (int)arrayToSort[index1])));
            }
        }

        private void SavePicture()
        {
            ImageCodecInfo myImageCodecInfo = this.getEncoderInfo("image/gif");
            EncoderParameter myEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 0L);
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameters encoderParams = new EncoderParameters(2);
            encoderParams.Param[0] = qualityParam;
            encoderParams.Param[1] = myEncoderParameter;

            string destPath = System.IO.Path.Combine(outputFolder, outputFile + imgCount + ".gif");
            bmpsave.Save(destPath, myImageCodecInfo, encoderParams);
            imgCount++;
        }

        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        delegate void SetControlValueCallback(Control pnlSort);

        private void RefreshPanel(Control pnlSort)
        {
            if (pnlSort.InvokeRequired)
            {
                
                    SetControlValueCallback d = new SetControlValueCallback(RefreshPanel);
                    pnlSort.Invoke(d, new object[] { pnlSort });
                
            }
            else
            {
                
                    pnlSort.Refresh();
                
            }
        }

        private void DrawSamples()
        {
            g.Clear(Color.White);
            

            for (int i = 0; i < this.arrayToSort.Count; i++)
            {
                int x = (int)(((double)pnlSamples.Width / arrayToSort.Count) * i);

                Pen pen = new Pen(Color.Black);
                g.DrawLine(pen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - (int)arrayToSort[i])));
            }

        }

        public void CreateAnimation()
        {
            string outputFilePath = System.IO.Path.Combine(outputFolder, outputFile + ".gif");

            AnimatedGifEncoder enc = new AnimatedGifEncoder();
            enc.Start(outputFilePath);
            enc.SetDelay(1);
            enc.SetRepeat(0);

            for (int i = 0; i < imgCount; i++)
            {
                outputFilePath = System.IO.Path.Combine(outputFolder, outputFile+ i + ".gif");
                enc.AddFrame(Image.FromFile(outputFilePath));
            }
            enc.Finish();
            enc = null;
            MessageBox.Show("Animation has been created");
        }
    }
}
