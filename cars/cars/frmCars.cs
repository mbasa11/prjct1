using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace cars
{
    public partial class frmCars : Form
    {
        public frmCars()
        {
            InitializeComponent();
        }
        BusinessLayer bll = new BusinessLayer();
        Car car = new Car();
        Manu man = new Manu();
        Model mod = new Model();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();
            this.Hide();
        }

        private void frmCars_Load(object sender, EventArgs e)
        {
            cmbMan.DataSource = bll.ListManufacturer(man);
            cmbMan.DisplayMember = "ManufactureDesc";
            cmbMan.ValueMember = "ManufacturerID";

            cmbModel.DataSource = bll.ListModel(mod);
            cmbModel.DisplayMember = "ModelDescription";
            cmbModel.ValueMember = "ModelID";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {


            car.ManID = int.Parse(cmbMan.SelectedValue.ToString());
            car.ModelID = int.Parse(cmbModel.SelectedValue.ToString());
            car.CarDesc = txtDesc.Text;
            car.CarYear = txtYear.Text;
            car.Price = float.Parse(txtPrice.Text);
            int x = bll.AddCars(car);
            if (x > 0)
            {
                MessageBox.Show(x + " addred", "Okay then", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Something went wrong","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            car.ManID = int.Parse(cmbMan.SelectedValue.ToString());
            car.ModelID = int.Parse(cmbModel.SelectedValue.ToString());
            car.CarDesc = txtDesc.Text;
            car.CarYear = txtYear.Text;
            car.Price = float.Parse(txtPrice.Text);
            dgvList.DataSource = bll.UpdateCars(car);
            MessageBox.Show("Update");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = bll.ListCars(car);
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                cmbMan.Text = dgvList.SelectedRows[0].Cells["ManufactureDesc"].Value.ToString();
                cmbModel.Text = dgvList.SelectedRows[0].Cells["ModelDesc"].Value.ToString();
            }
        }
    }
}
