using Domain;
using Domain.EmployeeServices;
using Domain.FormCounter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar
{
    public partial class DeleteConfirmation : Form
    {
        Employee employee;
        EmployeeServices employeeServices;
        EmployeeForm employeeForm;
        public DeleteConfirmation(Employee employee, EmployeeServices employeeServices, EmployeeForm employeeForm)
        {
            InitializeComponent();
            this.employee = employee;
            this.employeeServices = employeeServices;
            this.employeeForm = employeeForm;
        }

        private void Terminate_Click(object sender, EventArgs e)
        {
            try
            {
                Contract contract = new Contract(employee.contract.startDate, employee.contract.startDate, employee.contract.contractType, RTxtBxTerminationReason.Text);
                employee.SetNewContract(contract);
                employeeServices.DeleteEmployee(employee);
                MessageBox.Show("Employee Terminated");
                FormCounter.Formcounter--;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            FormCounter.Formcounter--;
            this.Close();
        }

        private void DeleteConfirmation_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormCounter.Formcounter--;
        }
    }
}
