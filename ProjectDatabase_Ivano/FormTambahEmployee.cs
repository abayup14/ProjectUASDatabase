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
    public partial class FormTambahEmployee : Form
    {
        public FormTambahEmployee()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Position positionDipilih = (Position)comboBoxPosition.SelectedItem;


            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        private void FormTambahEmployee_Load(object sender, EventArgs e)
        {
            List<Position> listPosition = Position.BacaData("", "");

            comboBoxPosition.DataSource = listPosition;

            comboBoxPosition.DisplayMember = "Nama";
        }
    }
}
