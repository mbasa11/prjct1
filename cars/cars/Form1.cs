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
    public partial class frmManufacturer : Form
    {
        public frmManufacturer()
        {
            InitializeComponent();
        }
        DataAccessLayer dal = new DataAccessLayer();
        BusinessLayer bll = new BusinessLayer();
        Manu man = new Manu();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            man = new Manu();
            man.ManuDesc = txtDesc.Text;
            man.ManuLoc = txtLoc.Text;
            man.contact = txtContact.Text;
            int x = bll.AddManufacturer(man);
            if (x > 0)
            {
                MessageBox.Show(x+" added","Noice!!", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            man.ManuDesc = txtDesc.Text;
            man.ManuLoc = txtLoc.Text;
            man.contact = txtContact.Text;
            dgvList.DataSource = bll.UpdateManufacturer(man);
            MessageBox.Show("Updated");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = bll.ListManufacturer(man);
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if(dgvList.SelectedRows.Count > 0)
            {
          //      txtDesc.Text = dgvList.SelectedRows[0].Cells["ManufactureriD"].Value.ToString();
                txtDesc.Text = dgvList.SelectedRows[0].Cells["ManufacturerDesc"].Value.ToString();
                txtLoc.Text = dgvList.SelectedRows[0].Cells["ManufactureLocation"].Value.ToString();
                txtContact.Text = dgvList.SelectedRows[0].Cells["ManufacturerContactPerson"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();
            this.Hide();
        }

        private void frmManufacturer_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
