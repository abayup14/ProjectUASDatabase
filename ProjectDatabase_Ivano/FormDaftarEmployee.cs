using DiBa_LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDatabase_Ivano
{
    public partial class FormDaftarEmployee : Form
    {
        List<Employee> listEmployee;

        public FormDaftarEmployee()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahEmployee formTambahEmployee = new FormTambahEmployee();

            formTambahEmployee.Owner = this;

            formTambahEmployee.Show();
        }

        private void FormDaftarEmployee_Load(object sender, EventArgs e)
        {
            listEmployee = Employee.BacaData("", "");

            if (listEmployee.Count > 0)
            {
                dataGridViewEmployee.DataSource = listEmployee;
            }
            else
            {
                dataGridViewEmployee.DataSource = null;
            }
        }
    }
}
