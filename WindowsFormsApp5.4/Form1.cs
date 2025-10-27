using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ImageViewerApp
{
    public partial class Form1 : Form
    {
        private Image currentImage;
        private float zoomFactor = 1.0f;
        private const float ZOOM_STEP = 0.25f;
        private const float MIN_ZOOM = 0.1f;
        private const float MAX_ZOOM = 5.0f;
        private Point lastMousePosition;
        private bool isPanning = false;
        private Point imagePosition = Point.Empty;

        public Form1()
        {
            InitializeComponent();
            UpdateStatusBar();
            UpdateZoomInfo();
        }

        private void OpenImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tiff;*.ico|All Files|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Освобождаем предыдущее изображение
                        currentImage?.Dispose();

                        // Загружаем новое изображение
                        currentImage = Image.FromFile(openFileDialog.FileName);

                        // Сбрасываем масштаб и позицию
                        zoomFactor = 1.0f;
                        imagePosition = Point.Empty;

                        // Обновляем интерфейс
                        pictureBox.Invalidate();
                        UpdateStatusBar();
                        UpdateZoomInfo();

                        // Обновляем заголовок окна
                        this.Text = $"Просмотр изображений - {Path.GetFileName(openFileDialog.FileName)}";

                        toolStripStatusLabel.Text = $"Загружено: {Path.GetFileName(openFileDialog.FileName)}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ZoomIn()
        {
            if (currentImage == null) return;

            float newZoom = zoomFactor + ZOOM_STEP;
            if (newZoom <= MAX_ZOOM)
            {
                zoomFactor = newZoom;
                pictureBox.Invalidate();
                UpdateZoomInfo();
            }
        }

        private void ZoomOut()
        {
            if (currentImage == null) return;

            float newZoom = zoomFactor - ZOOM_STEP;
            if (newZoom >= MIN_ZOOM)
            {
                zoomFactor = newZoom;
                pictureBox.Invalidate();
                UpdateZoomInfo();
            }
        }

        private void ZoomToFit()
        {
            if (currentImage == null) return;

            // Вычисляем масштаб для полного отображения изображения
            float zoomX = (float)pictureBox.Width / currentImage.Width;
            float zoomY = (float)pictureBox.Height / currentImage.Height;
            zoomFactor = Math.Min(zoomX, zoomY) * 0.95f; // Небольшой отступ

            imagePosition = Point.Empty;
            pictureBox.Invalidate();
            UpdateZoomInfo();
        }

        private void ZoomToActualSize()
        {
            if (currentImage == null) return;

            zoomFactor = 1.0f;
            imagePosition = Point.Empty;
            pictureBox.Invalidate();
            UpdateZoomInfo();
        }

        private void UpdateZoomInfo()
        {
            lblZoom.Text = $"Масштаб: {zoomFactor * 100:F0}%";
            btnZoomActual.Enabled = Math.Abs(zoomFactor - 1.0f) > 0.01f;
            btnZoomFit.Enabled = currentImage != null;
        }

        private void UpdateStatusBar()
        {
            if (currentImage != null)
            {
                toolStripStatusLabel.Text = $"Размер: {currentImage.Width} × {currentImage.Height} | " +
                                          $"Формат: {currentImage.PixelFormat}";
            }
            else
            {
                toolStripStatusLabel.Text = "Готов к загрузке изображения";
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (currentImage == null) return;

            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Вычисляем размер изображения с учетом масштаба
            int scaledWidth = (int)(currentImage.Width * zoomFactor);
            int scaledHeight = (int)(currentImage.Height * zoomFactor);

            // Вычисляем позицию для центрирования
            int x = imagePosition.X + (pictureBox.Width - scaledWidth) / 2;
            int y = imagePosition.Y + (pictureBox.Height - scaledHeight) / 2;

            // Рисуем изображение
            e.Graphics.DrawImage(currentImage, x, y, scaledWidth, scaledHeight);

            // Рисуем рамку вокруг изображения
            using (Pen pen = new Pen(Color.Gray, 1) { DashStyle = DashStyle.Dash })
            {
                e.Graphics.DrawRectangle(pen, x, y, scaledWidth, scaledHeight);
            }
        }

        private void pictureBox_Resize(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (currentImage == null) return;

            if (e.Delta > 0)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && currentImage != null)
            {
                isPanning = true;
                lastMousePosition = e.Location;
                pictureBox.Cursor = Cursors.SizeAll;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPanning && currentImage != null)
            {
                int deltaX = e.X - lastMousePosition.X;
                int deltaY = e.Y - lastMousePosition.Y;

                imagePosition.X += deltaX;
                imagePosition.Y += deltaY;

                lastMousePosition = e.Location;
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPanning = false;
                pictureBox.Cursor = Cursors.Default;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void btnZoomFit_Click(object sender, EventArgs e)
        {
            ZoomToFit();
        }

        private void btnZoomActual_Click(object sender, EventArgs e)
        {
            ZoomToActualSize();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Просмотрщик изображений\n\n" +
                "Функции:\n" +
                "• Открытие изображений (BMP, JPG, PNG, GIF, TIFF, ICO)\n" +
                "• Масштабирование колесом мыши и кнопками\n" +
                "• Перетаскивание изображения мышью\n" +
                "• Автоматическое подгонка под размер окна\n" +
                "• Просмотр в реальном размере\n\n" +
                "Управление:\n" +
                "• Колесо мыши - масштабирование\n" +
                "• ЛКМ + перетаскивание - перемещение\n" +
                "• Ctrl + '+' - увеличение\n" +
                "• Ctrl + '-' - уменьшение\n" +
                "• Ctrl + 0 - подогнать по размеру",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Обработка горячих клавиш
            switch (keyData)
            {
                case Keys.Control | Keys.O:
                    OpenImage();
                    return true;
                case Keys.Control | Keys.Add:
                case Keys.Control | Keys.Oemplus:
                    ZoomIn();
                    return true;
                case Keys.Control | Keys.Subtract:
                case Keys.Control | Keys.OemMinus:
                    ZoomOut();
                    return true;
                case Keys.Control | Keys.D0:
                    ZoomToFit();
                    return true;
                case Keys.Control | Keys.D1:
                    ZoomToActualSize();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            currentImage?.Dispose();
        }
    }
}