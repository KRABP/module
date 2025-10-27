using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleDrawingApp
{
    public partial class Form1 : Form
    {
        private Point startPoint;
        private Point endPoint;
        private bool isDrawing = false;
        private ShapeType currentShape = ShapeType.Line;
        private Pen drawingPen = new Pen(Color.Black, 2);
        private Bitmap canvasBitmap;
        private Graphics canvasGraphics;

        public Form1()
        {
            InitializeComponent();
            InitializeCanvas();
        }

        private void InitializeCanvas()
        {
            canvasBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);
            pictureBox.Image = canvasBitmap;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                startPoint = e.Location;
                endPoint = e.Location;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                endPoint = e.Location;
                pictureBox.Invalidate(); // Перерисовываем pictureBox для отображения временной фигуры
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                isDrawing = false;
                endPoint = e.Location;
                DrawFinalShape();
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Отображаем основное изображение
            if (canvasBitmap != null)
            {
                e.Graphics.DrawImage(canvasBitmap, 0, 0);
            }

            // Рисуем временную фигуру при перетаскивании
            if (isDrawing)
            {
                DrawTemporaryShape(e.Graphics);
            }
        }

        private void DrawTemporaryShape(Graphics g)
        {
            using (Pen tempPen = new Pen(Color.Gray, 1))
            {
                tempPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                DrawShape(g, tempPen, startPoint, endPoint);
            }
        }

        private void DrawFinalShape()
        {
            DrawShape(canvasGraphics, drawingPen, startPoint, endPoint);
        }

        private void DrawShape(Graphics g, Pen pen, Point start, Point end)
        {
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(end.X - start.X);
            int height = Math.Abs(end.Y - start.Y);

            switch (currentShape)
            {
                case ShapeType.Line:
                    g.DrawLine(pen, start, end);
                    break;
                case ShapeType.Circle:
                    g.DrawEllipse(pen, x, y, width, height);
                    break;
                case ShapeType.Rectangle:
                    g.DrawRectangle(pen, x, y, width, height);
                    break;
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.Line;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.Circle;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.Rectangle;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            canvasGraphics.Clear(Color.White);
            pictureBox.Invalidate();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    drawingPen.Color = colorDialog.Color;
                    colorButton.BackColor = colorDialog.Color;
                }
            }
        }

        private void trackBarWidth_Scroll(object sender, EventArgs e)
        {
            drawingPen.Width = trackBarWidth.Value;
            lblWidth.Text = $"Толщина: {trackBarWidth.Value}px";
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            canvasGraphics?.Dispose();
            drawingPen?.Dispose();
            canvasBitmap?.Dispose();
        }
    }

    public enum ShapeType
    {
        Line,
        Circle,
        Rectangle
    }
}