using System;
using System.Windows.Forms;

namespace EmployeeManagementApp
{
    public partial class EmployeeForm : Form
    {
        public Employee Employee { get; private set; }

        public EmployeeForm()
        {
            InitializeComponent();
            Employee = new Employee();
            InitializeForm();
        }

        public EmployeeForm(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            InitializeForm();
            FillFormData();
        }

        private void InitializeForm()
        {
            // Заполняем комбобокс отделов
            cmbDepartment.Items.Clear();
            foreach (var dept in Enum.GetValues(typeof(Department)))
            {
                cmbDepartment.Items.Add(dept.ToString());
            }

            dtpHireDate.Value = DateTime.Now;
        }

        private void FillFormData()
        {
            txtFirstName.Text = Employee.FirstName;
            txtLastName.Text = Employee.LastName;
            txtPosition.Text = Employee.Position;
            numSalary.Value = Employee.Salary;
            dtpHireDate.Value = Employee.HireDate;
            cmbDepartment.Text = Employee.Department;
            txtEmail.Text = Employee.Email;
            txtPhone.Text = Employee.Phone;
            txtAddress.Text = Employee.Address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            Employee.FirstName = txtFirstName.Text.Trim();
            Employee.LastName = txtLastName.Text.Trim();
            Employee.Position = txtPosition.Text.Trim();
            Employee.Salary = numSalary.Value;
            Employee.HireDate = dtpHireDate.Value;
            Employee.Department = cmbDepartment.Text;
            Employee.Email = txtEmail.Text.Trim();
            Employee.Phone = txtPhone.Text.Trim();
            Employee.Address = txtAddress.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Введите имя сотрудника!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Введите фамилию сотрудника!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Введите должность сотрудника!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPosition.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbDepartment.Text))
            {
                MessageBox.Show("Выберите отдел сотрудника!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDepartment.Focus();
                return false;
            }

            if (numSalary.Value <= 0)
            {
                MessageBox.Show("Зарплата должна быть больше 0!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                numSalary.Focus();
                return false;
            }

            return true;
        }
    }
}