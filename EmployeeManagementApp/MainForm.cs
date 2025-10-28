using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    public partial class MainForm : Form
    {
        private DatabaseHelper database;
        private List<Employee> employees;
        private Employee selectedEmployee;

        public MainForm()
        {
            InitializeComponent();
            database = new DatabaseHelper();
            LoadEmployees();
            UpdateStatistics();
        }

        private void LoadEmployees()
        {
            employees = database.GetAllEmployees();
            dataGridView.DataSource = employees;
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LastName",
                HeaderText = "Фамилия",
                Width = 120
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FirstName",
                HeaderText = "Имя",
                Width = 120
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Position",
                HeaderText = "Должность",
                Width = 150
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Department",
                HeaderText = "Отдел",
                Width = 100
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Salary",
                HeaderText = "Зарплата",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });
        }

        private void UpdateStatistics()
        {
            lblTotalEmployees.Text = $"Всего сотрудников: {employees.Count}";

            if (employees.Count > 0)
            {
                decimal avgSalary = employees.Average(e => e.Salary);
                decimal maxSalary = employees.Max(e => e.Salary);
                decimal minSalary = employees.Min(e => e.Salary);

                lblAvgSalary.Text = $"Средняя зарплата: {avgSalary:C2}";
                lblSalaryRange.Text = $"Диапазон зарплат: {minSalary:C2} - {maxSalary:C2}";

                // Статистика по отделам
                var deptStats = employees.GroupBy(e => e.Department)
                                       .Select(g => new { Department = g.Key, Count = g.Count() })
                                       .OrderByDescending(x => x.Count);

                lblDeptStats.Text = $"Отделы: {string.Join(", ", deptStats.Select(x => $"{x.Department}({x.Count})"))}";
            }
            else
            {
                lblAvgSalary.Text = "Средняя зарплата: -";
                lblSalaryRange.Text = "Диапазон зарплат: -";
                lblDeptStats.Text = "Отделы: -";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new EmployeeForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (database.AddEmployee(form.Employee))
                    {
                        LoadEmployees();
                        UpdateStatistics();
                        MessageBox.Show("Сотрудник успешно добавлен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении сотрудника!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new EmployeeForm(selectedEmployee))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (database.UpdateEmployee(form.Employee))
                    {
                        LoadEmployees();
                        UpdateStatistics();
                        MessageBox.Show("Данные сотрудника обновлены!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при обновлении данных!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить сотрудника {selectedEmployee.LastName} {selectedEmployee.FirstName}?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (database.DeleteEmployee(selectedEmployee.Id))
                {
                    LoadEmployees();
                    UpdateStatistics();
                    MessageBox.Show("Сотрудник удален!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении сотрудника!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                selectedEmployee = dataGridView.SelectedRows[0].DataBoundItem as Employee;
                ShowEmployeeDetails(selectedEmployee);
            }
            else
            {
                selectedEmployee = null;
                ClearEmployeeDetails();
            }
        }

        private void ShowEmployeeDetails(Employee employee)
        {
            lblDetailName.Text = $"{employee.LastName} {employee.FirstName}";
            lblDetailPosition.Text = employee.Position;
            lblDetailDepartment.Text = employee.Department;
            lblDetailSalary.Text = employee.Salary.ToString("C2");
            lblDetailHireDate.Text = employee.HireDate.ToString("dd.MM.yyyy");
            lblDetailEmail.Text = string.IsNullOrEmpty(employee.Email) ? "не указан" : employee.Email;
            lblDetailPhone.Text = string.IsNullOrEmpty(employee.Phone) ? "не указан" : employee.Phone;
            lblDetailAddress.Text = string.IsNullOrEmpty(employee.Address) ? "не указан" : employee.Address;
        }

        private void ClearEmployeeDetails()
        {
            lblDetailName.Text = "Выберите сотрудника";
            lblDetailPosition.Text = "";
            lblDetailDepartment.Text = "";
            lblDetailSalary.Text = "";
            lblDetailHireDate.Text = "";
            lblDetailEmail.Text = "";
            lblDetailPhone.Text = "";
            lblDetailAddress.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadEmployees();
            }
            else
            {
                var searchResults = database.SearchEmployees(txtSearch.Text);
                dataGridView.DataSource = searchResults;
            }
            UpdateStatistics();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
            UpdateStatistics();
            txtSearch.Clear();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Система учета сотрудников\n\n" +
                "Функции:\n" +
                "• Добавление, редактирование и удаление сотрудников\n" +
                "• Поиск по имени, фамилии, должности и отделу\n" +
                "• Статистика по отделам и зарплатам\n" +
                "• Детальная информация о сотрудниках\n" +
                "• База данных SQLite\n\n" +
                "Поля сотрудника:\n" +
                "• Фамилия и имя\n" +
                "• Должность и отдел\n" +
                "• Зарплата\n" +
                "• Дата приема\n" +
                "• Контактная информация",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}