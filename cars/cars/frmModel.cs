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
    public partial class frmModel : Form
    {
        public frmModel()
        {
            InitializeComponent();
        }
       BusinessLayer bll = new BusinessLayer();
       Model mod = new Model();
        Manu man = new Manu();
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (dgvList.SelectedRows.Count > 0)
            {
                txtDesc.Text = dgvList.SelectedRows[0].Cells["ManufacturerID"].Value.ToString();
                cmbMan.Text = dgvList.SelectedRows[0].Cells["ModelDescription"].Value.ToString();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mod.ManuID = int.Parse(txtDesc.Text);
            mod.ModelDesc = cmbMan.SelectedValue.ToString();
            int x = bll.AddModel(mod);
            if (x > 0)
            {
                MessageBox.Show(x + " added", "Noice!!", MessageBoxButtons.OK);
            }
            else { MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            mod.ManuID = int.Parse(txtDesc.Text);
            mod.ModelDesc = txtDesc.Text;
            dgvList.DataSource = bll.UpdateModel(mod);
            MessageBox.Show("Updated");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = bll.ListModel(mod);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();
            this.Hide();
        }

        private void frmModel_Load(object sender, EventArgs e)
        {
            cmbMan.DataSource = bll.ListManufacturer(man);
            cmbMan.DisplayMember = "ManufatureDesc";
            cmbMan.ValueMember= "ManufacturerID";
        }
    }
}
