using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleTextEditor
{
    public partial class Form1 : Form
    {
        private string currentFilePath = string.Empty;
        private bool isModified = false;

        public Form1()
        {
            InitializeComponent();
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            string fileName = string.IsNullOrEmpty(currentFilePath) ? "Новый файл" : Path.GetFileName(currentFilePath);
            string modified = isModified ? " *" : "";
            this.Text = $"{fileName}{modified} - Текстовый редактор";
        }

        private void UpdateStatusBar()
        {
            int line = textBox.GetLineFromCharIndex(textBox.SelectionStart) + 1;
            int column = textBox.SelectionStart - textBox.GetFirstCharIndexOfCurrentLine() + 1;
            int totalLines = textBox.Lines.Length;

            toolStripStatusLabel.Text = $"Строка: {line}, Колонка: {column} | Всего строк: {totalLines}";
        }

        private void NewFile()
        {
            if (CheckUnsavedChanges())
            {
                textBox.Clear();
                currentFilePath = string.Empty;
                isModified = false;
                UpdateTitle();
                UpdateStatusBar();
            }
        }

        private void OpenFile()
        {
            if (CheckUnsavedChanges())
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string filePath = openFileDialog.FileName;
                            string fileContent = File.ReadAllText(filePath);

                            textBox.Text = fileContent;
                            currentFilePath = filePath;
                            isModified = false;
                            UpdateTitle();
                            UpdateStatusBar();

                            toolStripStatusLabel.Text = $"Файл загружен: {Path.GetFileName(filePath)}";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void SaveFile()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileAs();
            }
            else
            {
                SaveToFile(currentFilePath);
            }
        }

        private void SaveFileAs()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    SaveToFile(filePath);
                }
            }
        }

        private void SaveToFile(string filePath)
        {
            try
            {
                File.WriteAllText(filePath, textBox.Text);
                currentFilePath = filePath;
                isModified = false;
                UpdateTitle();

                toolStripStatusLabel.Text = $"Файл сохранен: {Path.GetFileName(filePath)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckUnsavedChanges()
        {
            if (isModified)
            {
                DialogResult result = MessageBox.Show(
                    "Сохранить изменения в файле?",
                    "Несохраненные изменения",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveFile();
                    return !isModified; // Возвращаем true если файл сохранен или изменения отменены
                }
                else if (result == DialogResult.No)
                {
                    return true; // Продолжить без сохранения
                }
                else
                {
                    return false; // Отмена операции
                }
            }
            return true;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (!isModified)
            {
                isModified = true;
                UpdateTitle();
            }
            UpdateStatusBar();
        }

        private void textBox_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckUnsavedChanges())
            {
                Application.Exit();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Простой текстовый редактор\n\n" +
                "Функции:\n" +
                "• Создание, открытие и сохранение текстовых файлов\n" +
                "• Поддержка горячих клавиш\n" +
                "• Статус бар с информацией о позиции курсора\n" +
                "• Проверка несохраненных изменений\n\n" +
                "Горячие клавиши:\n" +
                "Ctrl+N - Новый файл\n" +
                "Ctrl+O - Открыть\n" +
                "Ctrl+S - Сохранить\n" +
                "Ctrl+Shift+S - Сохранить как",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Обработка горячих клавиш
            switch (keyData)
            {
                case Keys.Control | Keys.N:
                    NewFile();
                    return true;
                case Keys.Control | Keys.O:
                    OpenFile();
                    return true;
                case Keys.Control | Keys.S:
                    SaveFile();
                    return true;
                case Keys.Control | Keys.Shift | Keys.S:
                    SaveFileAs();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}