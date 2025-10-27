using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private double currentValue = 0;
        private string currentOperation = "";
        private bool isNewOperation = true;
        private bool isOperationPending = false;
        private double storedValue = 0;

        public Form1()
        {
            InitializeComponent();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            txtDisplay.Text = currentValue.ToString();
        }

        private void ClearAll()
        {
            currentValue = 0;
            currentOperation = "";
            isNewOperation = true;
            isOperationPending = false;
            storedValue = 0;
            lblOperation.Text = "";
            UpdateDisplay();
        }

        private void ClearEntry()
        {
            currentValue = 0;
            isNewOperation = true;
            UpdateDisplay();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string number = button.Text;

                if (isNewOperation)
                {
                    currentValue = 0;
                    isNewOperation = false;
                }

                if (currentValue == 0 && !txtDisplay.Text.Contains("."))
                {
                    currentValue = double.Parse(number);
                }
                else
                {
                    string currentText = currentValue.ToString();
                    currentText += number;
                    currentValue = double.Parse(currentText);
                }

                UpdateDisplay();
            }
        }

        private void DecimalButton_Click(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                currentValue = 0;
                isNewOperation = false;
            }

            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
                currentValue = double.Parse(txtDisplay.Text);
            }
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (isOperationPending)
                {
                    CalculateResult();
                }

                storedValue = currentValue;
                currentOperation = button.Text;
                isOperationPending = true;
                isNewOperation = true;

                lblOperation.Text = $"{storedValue} {currentOperation}";
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            CalculateResult();
            currentOperation = "";
            isOperationPending = false;
            lblOperation.Text = "";
        }

        private void CalculateResult()
        {
            if (!isOperationPending) return;

            try
            {
                switch (currentOperation)
                {
                    case "+":
                        currentValue = storedValue + currentValue;
                        break;
                    case "-":
                        currentValue = storedValue - currentValue;
                        break;
                    case "×":
                        currentValue = storedValue * currentValue;
                        break;
                    case "÷":
                        if (currentValue == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        currentValue = storedValue / currentValue;
                        break;
                    case "%":
                        currentValue = storedValue * (currentValue / 100);
                        break;
                }

                UpdateDisplay();
                isNewOperation = true;
            }
            catch (DivideByZeroException)
            {
                txtDisplay.Text = "Деление на ноль!";
                currentValue = 0;
                isNewOperation = true;
            }
        }

        private void PlusMinusButton_Click(object sender, EventArgs e)
        {
            currentValue = -currentValue;
            UpdateDisplay();
        }

        private void SquareRootButton_Click(object sender, EventArgs e)
        {
            if (currentValue < 0)
            {
                txtDisplay.Text = "Ошибка!";
                currentValue = 0;
                isNewOperation = true;
                return;
            }

            currentValue = Math.Sqrt(currentValue);
            UpdateDisplay();
            isNewOperation = true;
        }

        private void SquareButton_Click(object sender, EventArgs e)
        {
            currentValue = Math.Pow(currentValue, 2);
            UpdateDisplay();
            isNewOperation = true;
        }

        private void ReciprocalButton_Click(object sender, EventArgs e)
        {
            if (currentValue == 0)
            {
                txtDisplay.Text = "Деление на ноль!";
                currentValue = 0;
                isNewOperation = true;
                return;
            }

            currentValue = 1 / currentValue;
            UpdateDisplay();
            isNewOperation = true;
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (isNewOperation) return;

            string currentText = currentValue.ToString();
            if (currentText.Length > 1)
            {
                currentText = currentText.Substring(0, currentText.Length - 1);
                currentValue = double.Parse(currentText);
            }
            else
            {
                currentValue = 0;
                isNewOperation = true;
            }

            UpdateDisplay();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearEntry();
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void MemoryClearButton_Click(object sender, EventArgs e)
        {
            // В простой версии память не реализована
            MessageBox.Show("Функция памяти в этой версии не реализована", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Обработка ввода с клавиатуры
            switch (e.KeyChar)
            {
                case '0': btn0.PerformClick(); break;
                case '1': btn1.PerformClick(); break;
                case '2': btn2.PerformClick(); break;
                case '3': btn3.PerformClick(); break;
                case '4': btn4.PerformClick(); break;
                case '5': btn5.PerformClick(); break;
                case '6': btn6.PerformClick(); break;
                case '7': btn7.PerformClick(); break;
                case '8': btn8.PerformClick(); break;
                case '9': btn9.PerformClick(); break;
                case '+': btnPlus.PerformClick(); break;
                case '-': btnMinus.PerformClick(); break;
                case '*': btnMultiply.PerformClick(); break;
                case '/': btnDivide.PerformClick(); break;
                case '.': btnDecimal.PerformClick(); break;
                case '=':
                case '\r': btnEquals.PerformClick(); break;
                case '\b': btnBackspace.PerformClick(); break;
                case 'c':
                case 'C': btnClear.PerformClick(); break;
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Калькулятор\n\n" +
                "Функции:\n" +
                "• Основные арифметические операции\n" +
                "• Проценты, квадрат, квадратный корень\n" +
                "• Обратное число, смена знака\n" +
                "• Поддержка ввода с клавиатуры\n\n" +
                "Горячие клавиши:\n" +
                "0-9 - цифры\n" +
                "+ - сложение\n" +
                "- - вычитание\n" +
                "* - умножение\n" +
                "/ - деление\n" +
                ". - десятичная точка\n" +
                "Enter или = - вычисление\n" +
                "Backspace - удаление\n" +
                "C - очистка",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}