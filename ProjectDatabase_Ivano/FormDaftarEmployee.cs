﻿using System;
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
    }
}
