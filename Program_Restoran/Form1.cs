﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Restoran
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();

        public string LabelText
        {
            get
            {
                return this.lbluser.Text;
            }
            set
            {
                this.lbluser.Text = value;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("h:mm tt");
            label3.Text = DateTime.Now.ToString("dd MMMM yyyy");
            label2.Text = DateTime.Now.ToString("ddd");
        }

        private void foodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmfood food = new Frmfood();
            food.ShowDialog();
        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmfood drink = new Frmfood();
            drink.ShowDialog();
        }

        private void dessertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDesserts desserts = new FrmDesserts();
            desserts.ShowDialog();
        }

        private void snackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSnack snack = new FrmSnack();
            snack.ShowDialog();
        }

        private void pesanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registerUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmregis register = new frmregis();
            register.ShowDialog();
        }

        private void btproses_Click(object sender, EventArgs e)
        {
            if (this.txtmenu.Text == "" || this.txtjumlah.Text == null)
            {
                MessageBox.Show("Data tidak boleh kosong", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int value1 = Convert.ToInt32(this.lblharga.Text);
            int value2 = Convert.ToInt32(this.txtjumlah.Text);
            int value3 = (value1) * (value2);
            table.Rows.Add(txtid.Text, txtmenu.Text, txtjumlah.Text, lblharga.Text,value3);
            DG.DataSource = table;
            txtid.Clear();
            txtjumlah.Clear();
            txtmenu.Clear();
            lblharga.Text = "0";
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (txtid.Text == "D001" || txtid.Text == "D001")
            {
                txtmenu.Text = "Orange Juice";
                lblharga.Text = "7000";

               }

            else if (txtid.Text == "D002" || txtid.Text == "d002")
            {
                txtmenu.Text = "Avocado Float";
                lblharga.Text = "10000";
            }
            else if (txtid.Text == "D003" || txtid.Text == "d003")
            {
                txtmenu.Text = "Strawberry Milkshake";
                lblharga.Text = "15000";
            }

            else if (txtid.Text == "D004" || txtid.Text == "d004")
            {
                txtmenu.Text = "Chocolate Milkshare";
                lblharga.Text = "15000";
            }

            else if (txtid.Text == "D005" || txtid.Text == "d005")
            {
                txtmenu.Text = "Lemon Tea";
                lblharga.Text = "10000";
            }
            else if (txtid.Text == "D006" || txtid.Text == "d006")
            {
                txtmenu.Text = " Tea";
                lblharga.Text = "7000";
            }
            else if (txtid.Text == "D007" || txtid.Text == "d007")
            {
                txtmenu.Text = "Coffee";
                lblharga.Text = "10000";
            }
            else if (txtid.Text == "D008" || txtid.Text == "d008")
            {
                txtmenu.Text = "Chocolate";
                lblharga.Text = "12000";
            }

            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Id", typeof(String));// data type int
            table.Columns.Add("Menu", typeof(string));// datatype string
            table.Columns.Add("Jumlah", typeof(string));// datatype string
            table.Columns.Add("Harga", typeof(Int32));// data type int
            table.Columns.Add("Total", typeof(Int32));// data type int
            DG.DataSource = table;
        }
    }
}
