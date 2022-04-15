using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RGZ
{
    public partial class Form : System.Windows.Forms.Form
    {
        Size windowSize = new Size(750, 600);                  // размер окна
        double[,] depthBuffer;                                  // буфер глубины
        int barSize = 150;                                      // ширина меню справа
        Graphics graphics;                                      // Graphics для рисования
        DirectBitmap directBitmap;                              // прямой доступ к Bitmap

        List<Vector3> objectVerts = new List<Vector3>();        // список точек объекта
        List<Triangle> objectTris = new List<Triangle>();       // список треугольников объекта
        int currentObjectID;                                    // текущий ID объекта

        double currentDegreesX = 1;                             // скорость вращения по X
        double currentDegreesY = 1;                             // скорость вращения по Y
        double currentDegreesZ = 1;                             // скорость вращения по Z
        double degreesX = 0;                                    // градусы вращения по X
        double degreesY = 0;                                    // градусы вращения по Y
        double degreesZ = 0;                                    // градусы вращения по Z

        Timer rotationTimer = new Timer();                      // таймер вращения
        Timer drawTimer = new Timer();                          // таймер отрисовки

        // Вектор в трёхмерном пространстве
        public struct Vector3
        {
            public double x, y, z;

            public Vector3(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        public struct Triangle
        {
            public int i, j, k;
            public Color color;
            public Triangle(int i, int j, int k, Color color)
            {
                this.i = i;
                this.j = j;
                this.k = k;
                this.color = color;
            }
        }

        public class Cube
        {
            public Vector3[] verts =
            {
                new Vector3(-200, -200, -200),
                new Vector3(-200, 200, -200),
                new Vector3(200, 200, -200),
                new Vector3(200, -200, -200),
                new Vector3(-200, -200, 200),
                new Vector3(-200, 200, 200),
                new Vector3(200, 200, 200),
                new Vector3(200, -200, 200),
            };

            public Triangle[] tris =
            {
                new Triangle(0,1,2, Color.Red),
                new Triangle(2,3,0, Color.Red),
                new Triangle(4,5,6, Color.Red),
                new Triangle(6,7,4, Color.Red),
                new Triangle(1,5,6, Color.Blue),
                new Triangle(6,2,1, Color.Blue),
                new Triangle(0,4,7, Color.Blue),
                new Triangle(7,3,0, Color.Blue),
                new Triangle(0,4,5, Color.Cyan),
                new Triangle(5,1,0, Color.Cyan),
                new Triangle(2,6,7, Color.Cyan),
                new Triangle(7,3,2, Color.Cyan)
            };
        }

        public class Pyramid
        {
            public Vector3[] verts =
            {
                new Vector3(-100, 100, 100),
                new Vector3(100, 100, 100),
                new Vector3(100, 100, 300),
                new Vector3(-100, 100, 300),
                new Vector3(0, -300, 200),
            };

            public Triangle[] tris =
            {
                new Triangle(0,1,2, Color.Blue),
                new Triangle(2,3,0, Color.Blue),
                new Triangle(0,1,4, Color.Red),
                new Triangle(1,2,4, Color.Cyan),
                new Triangle(2,3,4, Color.Yellow),
                new Triangle(3,0,4, Color.Magenta)
            };
        }
        
        public Form()
        {
            InitializeComponent();
            FormErrorCorrection();
            RotationTimer();
            listBox.SelectedIndex = 1;
            ObjectChanged(null, null);
        }

        // Коррекция формы
        private void FormErrorCorrection()
        {
            Size = windowSize;
            pictureBox.Size = windowSize;
            Size errorSize = windowSize - pictureBox.Size;
            Size = windowSize + errorSize;
            pictureBox.Size = windowSize + errorSize - new Size(barSize, 0);
            depthBuffer = new double[pictureBox.Size.Width, pictureBox.Height];
            FillDepthBuffer();
        }

        // Смена объекта на экране
        private void ObjectChanged(object sender, EventArgs e)
        {
            objectVerts.Clear();
            objectTris.Clear();
            drawTimer.Stop();
            degreesX = 0;
            degreesY = 0;
            degreesZ = 0;
            trackBarX.Value = 0;
            trackBarY.Value = 0;

            directBitmap = new DirectBitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(directBitmap.Bitmap);

            currentObjectID = listBox.SelectedIndex;
            switch (currentObjectID)
            {
                case 0:
                    Cube cube = new Cube();
                    foreach (Vector3 x in cube.verts)
                        objectVerts.Add(x);
                    foreach (Triangle x in cube.tris)
                        objectTris.Add(x);
                    break;
                case 1:
                    Pyramid pyramid = new Pyramid();
                    foreach (Vector3 x in pyramid.verts)
                        objectVerts.Add(x);
                    foreach (Triangle x in pyramid.tris)
                        objectTris.Add(x);
                    break;
            }
            DrawScene(null, null);
        }

        // Измение скорости вращения
        private void DegreeChanged(object sender, EventArgs e)
        {
            if (textBoxRotationX.Text.Contains("."))
            {
                int ind = textBoxRotationX.Text.IndexOf('.');
                textBoxRotationX.Text = textBoxRotationX.Text.Remove(ind);
                textBoxRotationX.Text = textBoxRotationX.Text.Insert(ind, ",");
                textBoxRotationX.SelectionStart = textBoxRotationX.Text.Length;
            }
            if (double.TryParse(textBoxRotationX.Text, out double d))
                currentDegreesX = double.Parse(textBoxRotationX.Text);

            if (textBoxRotationY.Text.Contains("."))
            {
                int ind = textBoxRotationY.Text.IndexOf('.');
                textBoxRotationY.Text = textBoxRotationY.Text.Remove(ind);
                textBoxRotationY.Text = textBoxRotationY.Text.Insert(ind, ",");
                textBoxRotationY.SelectionStart = textBoxRotationY.Text.Length;
            }
            if (double.TryParse(textBoxRotationY.Text, out d))
                currentDegreesY = double.Parse(textBoxRotationY.Text);

            if (textBoxRotationZ.Text.Contains("."))
            {
                int ind = textBoxRotationZ.Text.IndexOf('.');
                textBoxRotationZ.Text = textBoxRotationZ.Text.Remove(ind);
                textBoxRotationZ.Text = textBoxRotationZ.Text.Insert(ind, ",");
                textBoxRotationZ.SelectionStart = textBoxRotationZ.Text.Length;
            }
            if (double.TryParse(textBoxRotationZ.Text, out d))
                currentDegreesZ = double.Parse(textBoxRotationZ.Text);
        }

        // Отрисовка сцены
        private void DrawScene(object sender, EventArgs e)
        {
            drawTimer.Stop();
            graphics.Clear(Color.WhiteSmoke);
            FillDepthBuffer();

            DrawObject();
            pictureBox.Image = directBitmap.Bitmap;
            DrawTimer();
        }

        // Проекция точки
        private Vector3 Projection(Vector3 currentPoint)
        {
            double x, y;
            y = currentPoint.y;
            x = currentPoint.x;
            return new Vector3(x, y, currentPoint.z);
        }

        // Перенос начала координат в центр и перенос позиции
        private Vector3 ChangePosition(Vector3 currentPoint)
        {
            double x = currentPoint.x + pictureBox.Width / 2 + trackBarX.Value;
            double y = currentPoint.y + pictureBox.Height / 2 + trackBarY.Value;
            return new Vector3(x,y, currentPoint.z);
        }

        // Вращение точки объекта
        private Vector3 RotatePosition(Vector3 currentPoint)
        {
            Vector3 center = FindCenter();         
            double x = currentPoint.x;
            double y = currentPoint.y;
            double z = currentPoint.z;

            double radiansX = degreesX * Math.PI / 180;
            double radiansY = degreesY * Math.PI / 180;
            double radiansZ = degreesZ * Math.PI / 180;

            x = currentPoint.x * Math.Cos(radiansY) - currentPoint.z * Math.Sin(radiansY) - center.x * Math.Cos(radiansY) + center.z * Math.Sin(radiansY) + center.x;
            y = currentPoint.y;
            z = currentPoint.x * Math.Sin(radiansY) + currentPoint.z * Math.Cos(radiansY) - center.x * Math.Sin(radiansY) - center.z * Math.Cos(radiansY) + center.z;

            double backupY = y;
            double backupZ = z;
            y = backupY * Math.Cos(radiansX) - backupZ * Math.Sin(radiansX) - center.y * Math.Cos(radiansX) + center.z * Math.Sin(radiansX) + center.y;
            z = backupY * Math.Sin(radiansX) + backupZ * Math.Cos(radiansX) - center.y * Math.Sin(radiansX) - center.z * Math.Cos(radiansX) + center.z;

            double backupX = x;
            backupY = y;

            x = backupX * Math.Cos(radiansZ) - backupY * Math.Sin(radiansZ) - center.x * Math.Cos(radiansZ) + center.y * Math.Sin(radiansZ) + center.x;
            y = backupX * Math.Sin(radiansZ) + backupY * Math.Cos(radiansZ) - center.x * Math.Sin(radiansZ) - center.y * Math.Cos(radiansZ) + center.y;
            return new Vector3(x, y, z);
        }

        // Нахождение центра объекта
        private Vector3 FindCenter()
        {
            double x = 0, y = 0, z = 0;
            for (int i = 0; i < objectVerts.Count; i++)
            {
                x += objectVerts[i].x;
                y += objectVerts[i].y;
                z += objectVerts[i].z;
            }
            x /= objectVerts.Count;
            y /= objectVerts.Count;
            z /= objectVerts.Count;
            return new Vector3(x, y, z);
        }

        // Таймер отрисовки
        private void DrawTimer()
        {
            drawTimer.Tick -= new EventHandler(DrawScene);
            drawTimer.Interval = 10;
            drawTimer.Tick += new EventHandler(DrawScene);
            drawTimer.Start();
        }

        // Таймер вращения
        private void RotationTimer()
        {
            rotationTimer.Tick -= new EventHandler(AutoRotationActivation);
            rotationTimer.Interval = 10;
            rotationTimer.Tick += new EventHandler(AutoRotationActivation);
            rotationTimer.Start();
        }

        // Автовращение
        private void AutoRotationActivation(object sender, EventArgs e)
        {
            rotationTimer.Stop();
            if (checkBoxAutoRotationX.Checked)
            {
                degreesX += currentDegreesX / 50;
            }
            if (checkBoxAutoRotationY.Checked)
            {
                degreesY += currentDegreesY / 50;
            }
            if (checkBoxAutoRotationZ.Checked)
            {
                degreesZ += currentDegreesZ / 50;
            }
            RotationTimer();
        }

        int[] Interpolate(int x0, int y0, int x1, int y1)
        {

            int[] values = new int[x1 - x0 + 1];
            if (x0 == x1)
            {
                values[0] = y0;
                return values;
            }
            double a = (double)(y1 - y0) / (x1 - x0);
            double y = y0;
            for (int i = x0; i <= x1; i++)
            {
                values[i - x0] = (int)y;
                y += a;
            }
            return values;
        }

        void SwapPoints(ref Vector3 P1, ref Vector3 P2)
        {
            Vector3 swap = P1;
            P1 = P2;
            P2 = swap;
        }

        void DrawFilledRectangle(Vector3 P0, Vector3 P1, Vector3 P2, Color color)
        {
            if (P1.y < P0.y) SwapPoints(ref P0, ref P1);
            if (P2.y < P0.y) SwapPoints(ref P0, ref P2);
            if (P2.y < P1.y) SwapPoints(ref P1, ref P2);

            int[] x01 = Interpolate((int)P0.y, (int)P0.x, (int)P1.y, (int)P1.x);
            int[] x12 = Interpolate((int)P1.y, (int)P1.x, (int)P2.y, (int)P2.x);
            int[] x02 = Interpolate((int)P0.y, (int)P0.x, (int)P2.y, (int)P2.x);

            int[] x012 = new int[x01.Length + x12.Length - 1];
            x01.CopyTo(x012, 0);
            x12.CopyTo(x012, x01.Length-1);

            int m = x02.Length / 2;
            int[] xleft, xright;
            if (x02[m] < x012[m])
            {
                xleft = x02;
                xright = x012;
            }
            else
            {
                xleft = x012;
                xright = x02;
            }
            for (int y = (int)P0.y; y <= P2.y; y++)
            {
                for (int x = xleft[y - (int)P0.y]; x <= xright[y - (int)P0.y]; x++)
                {
                    double z = P0.z + ((P1.x - P0.x) * (P2.z - P0.z) - (P2.x - P0.x) * (P1.z - P0.z)) / ((P1.x - P0.x) * (P2.y - P0.y) - (P2.x - P0.x) * (P1.y - P0.y)) * (y - P0.y) - ((P1.y - P0.y) * (P2.z - P0.z) - (P2.y - P0.y) * (P1.z - P0.z)) / ((P1.x - P0.x) * (P2.y - P0.y) - (P2.x - P0.x) * (P1.y - P0.y)) * (x - P0.x);
                    if (x>= 0 && y >= 0 && x < directBitmap.Width && y < directBitmap.Height && z > depthBuffer[x, y])
                    {
                        directBitmap.SetPixel(x, y, color);
                        depthBuffer[x, y] = z;
                    }
                }
            }
        }

        void DrawObject()
        {
            foreach(Triangle x in objectTris)
            {
                Vector3 P0 = objectVerts[x.i];
                Vector3 P1 = objectVerts[x.j];
                Vector3 P2 = objectVerts[x.k];

                P0 = ChangePosition(RotatePosition(P0));
                P1 = ChangePosition(RotatePosition(P1));
                P2 = ChangePosition(RotatePosition(P2));

                DrawFilledRectangle(P0, P1, P2, x.color);
            }
            foreach (Triangle x in objectTris)
            {
                Vector3 P0 = objectVerts[x.i];
                Vector3 P1 = objectVerts[x.j];
                Vector3 P2 = objectVerts[x.k];

                P0 = ChangePosition(RotatePosition(P0));
                P1 = ChangePosition(RotatePosition(P1));
                P2 = ChangePosition(RotatePosition(P2));

                Bresenham(new Point((int)P0.x, (int)P0.y), new Point((int)P1.x, (int)P1.y), Color.Black);
                Bresenham(new Point((int)P1.x, (int)P1.y), new Point((int)P2.x, (int)P2.y), Color.Black);
                Bresenham(new Point((int)P2.x, (int)P2.y), new Point((int)P0.x, (int)P0.y), Color.Black);
            }
        }

        // Брезенхем
        private void Bresenham(Point startPoint, Point endPoint, Color color)
        {
            int pX = Math.Abs(endPoint.X - startPoint.X);
            int pY = Math.Abs(endPoint.Y - startPoint.Y);
            int sX = Math.Sign(endPoint.X - startPoint.X);
            int sY = Math.Sign(endPoint.Y - startPoint.Y);
            int x = startPoint.X;
            int y = startPoint.Y;

            bool isAbsPXGreaterPY = pX > pY ? true : false;
            if (!isAbsPXGreaterPY)
            {
                int backup = pX;
                pX = pY;
                pY = backup;
            }

            int E = 2 * pY - pX;
            for (int i = 0; i <= pX; i++)
            {
                if (x > -1 && x < pictureBox.Width && y > -1 && y < pictureBox.Height)
                    directBitmap.Bitmap.SetPixel(x, y, color);
                if (isAbsPXGreaterPY)
                {
                    if (E <= 0)
                    {
                        x += sX;
                        E = E + 2 * pY;
                    }
                    else
                    {
                        x += sX;
                        y += sY;
                        E = E + 2 * (pY - pX);
                    }
                }
                else
                {
                    if (E <= 0)
                    {
                        y += sY;
                        E = E + 2 * pY;
                    }
                    else
                    {
                        x += sX;
                        y += sY;
                        E = E + 2 * (pY - pX);
                    }
                }
            }
        }

        void FillDepthBuffer()
        {
            for (int i = 0; i < pictureBox.Size.Width; i++)
                for (int j = 0; j < pictureBox.Size.Height; j++)
                    depthBuffer[j, i] = int.MaxValue;
        }
    }

    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
